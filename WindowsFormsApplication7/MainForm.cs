using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class MainForm : Form
    {
        const int SEAT_WIDTH = 25;
        const int SEAT_HEIGHT = 25;

        const int ROW_CNT = 15;
        const int COL_CNT = 15;

        Seance currentSeance;

        OptionsService OptionsService = new OptionsService();
        Options Options;
        Seances seances = new Seances();
        Films  films = new Films();
        Rooms rooms = new Rooms();

        Button[,] btnArray;
        public MainForm()
        {
            InitializeComponent();
        }
        private void DisplaySeance(Seance seance)
        {
            currentSeance = seance;
            var room = seance.Room;
            if (btnArray != null)
            {
                foreach (Button btn in btnArray)
                {
                    panelRoom.Controls.Remove(btn);
                }
            }

            btnArray = new Button[room.RowCnt, room.ColCnt];
            panelRoom.Visible = false;
            for (int row = 0; row < room.RowCnt; row++)
            {
                for (int col = 0; col < room.ColCnt; col++)
                {
                    DisplaySeat(row, col, room.Seats[row, col]);
                }
            }

            panelRoom.Visible = true;
        }
        private void DisplaySeat(int row, int col, Seat seat)
        {
            Button btn = new Button();
            btn.Tag = seat;
            panelRoom.Controls.Add(btn);

            btn.Width = SEAT_WIDTH;
            btn.Height = SEAT_HEIGHT;
            btn.Left = 20 + col * (SEAT_WIDTH + 1);
            btn.Top = 20 + row * (SEAT_HEIGHT + 1);

            UpdateButtonState(btn);

            btn.FlatStyle = FlatStyle.Flat;

            btn.Click += btnSeat_Click;

            btnArray[row, col] = btn;

            btn.Visible = true;
        }

        private void btnSeat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Seat seat = (Seat)btn.Tag;

            if (seat.IsAvailable)
            {
                if (btn.BackColor == Color.Black)
                {
                    UpdateButtonState(btn);
                }
                else
                {
                    btn.BackColor = Color.Black;
                }
            }

        }

        private bool IsSeatBusy(Seat seat)
        {
            return currentSeance.BusySeats[seat.Row, seat.Col];
        }

        private void UpdateButtonState(Button btn)
        {
            Seat seat = (Seat)btn.Tag;
            if (!seat.IsAvailable)
            {
                btn.BackColor = Color.Gray;
            }
            else if (IsSeatBusy(seat))
            {
                btn.BackColor = Color.Red;
            }
            else
            {
                btn.BackColor = Color.Green;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            films.Load();
            rooms.Load();
            seances.Load(films, rooms);

            UpdateFilmList();
            cbFilms.Enabled = false;
            cbSeances.Enabled = false;
            Options = OptionsService.Load();

            if (Options.AutoSelectDate)
            {
                var s = seances.GetNearlest(DateTime.Now);
                if (s != null)
                {
                    dateTimePicker1.Value = s.Date;
                }
            }
        }

        void UpdateFilmList()
        {
            cbFilms.Items.Clear();
            foreach (var film in films.GetFilms())
            {
                cbFilms.Items.Add(film);
            }
        }

        private void cbFilms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeances.Enabled)
            {
                cbSeances.Items.Clear();
                var film = (Film)cbFilms.SelectedItem;
                if (film != null)
                {
                    foreach (var seance in seances.GetSeances(film.ID, dateTimePicker1.Value))
                    {
                        cbSeances.Items.Add(seance);
                    }
                }

                cbSeances.SelectedItem = null;
                cbSeances.Text = string.Empty;
                tbPrice.Text = string.Empty;
            }
        }

        private void cbSeances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSeances.Enabled)
            {
                var seance = (Seance)cbSeances.SelectedItem;
                if (seance != null)
                {
                    tbPrice.Text = seance.Price.ToString();
                }
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var seance = (Seance)cbSeances.SelectedItem;
            if (seance != null)
            {
                DisplaySeance(seance);
            }
        }
        private List<Button> GetSelectedButtonList()
        {
            List<Button> btnList = new List<Button>();
            foreach (Button btn in btnArray)
            {
                if (btn.BackColor == Color.Black)
                {
                    btnList.Add(btn);
                }
            }

            return btnList;
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            List<Button> btnList = GetSelectedButtonList();
            int price = btnList.Count * currentSeance.Price;
            DialogResult result = MessageBox.Show("Цена:" + price, "Купить билтеты", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                foreach (var btn in btnArray)
                {
                    if (btn.BackColor == Color.Black)
                    {
                        var seat = (Seat)btn.Tag;
                        if (!IsSeatBusy(seat))
                        {
                            currentSeance.BusySeats[seat.Row, seat.Col] = true;
                            UpdateButtonState(btn);
                        }
                    }
                }
            }

            seances.Save();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            foreach (var btn in btnArray)
            {
                if (btn.BackColor == Color.Black)
                {
                    var seat = (Seat)btn.Tag;
                    if (IsSeatBusy(seat))
                    {
                        currentSeance.BusySeats[seat.Row, seat.Col] = false;
                        UpdateButtonState(btn);
                    }

                }
            }

            seances.Save();
        }       


        private void btnOptions_Click(object sender, EventArgs e)
        {
            var formOptions = new FormOptions();
            formOptions.Options = Options;
            var result = formOptions.ShowDialog();


            if (result == DialogResult.OK)
            {
                OptionsService.Save(formOptions.Options);
            }
        }

        private void UpdateForm()
        {

            films.Load();
            rooms.Load();
            seances.Load(films, rooms);

            cbSeances.SelectedIndex = -1;
            cbFilms.SelectedIndex = -1;

            DateTime thisDate = dateTimePicker1.Value;
            List<Seance> listSeance = seances.GetSeancesByDate(thisDate);
            cbSeances.Items.Clear();
            foreach (var s in listSeance)
            {
                cbSeances.Items.Add(s);
            }
            List<Film> listFilms = seances.GetFilmsBySeance(listSeance);
            cbFilms.Items.Clear();
            foreach (var f in listFilms)
            {
                cbFilms.Items.Add(f);
            }
            cbFilms.Enabled = true;
            cbSeances.Enabled = true;

            if (Options.AutoSelectFilm)
            {
                if (cbFilms.Items.Count > 0)
                {
                    cbFilms.SelectedIndex = 0;
                }

                if (cbSeances.Items.Count > 0)
                {
                    cbSeances.SelectedIndex = 0;
                }         
            }            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void filmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filmsForm = new FilmsForm();
            filmsForm.Init(films);
            filmsForm.ShowDialog();
            UpdateForm();
        }

        private void seanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var seanceForm = new SeanceForm();
            seanceForm.Init(seances, films, rooms);
            seanceForm.ShowDialog();
            UpdateForm();
        }

        private void btnProgramAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработка приложения на тему: Кинотетр \n" + "Петрова Елена, БИ-17-1", "О программе");
        }

        private void комнатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var roomsForm = new RoomsForm();
            roomsForm.Init(rooms);
            roomsForm.ShowDialog();
            UpdateForm();
        }
    }
}