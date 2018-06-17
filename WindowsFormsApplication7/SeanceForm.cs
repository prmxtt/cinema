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
    public partial class SeanceForm : Form
    {
        Seances seances;
        Films films;
        Rooms rooms;

        public SeanceForm()
        {
            InitializeComponent();
        }
        public void Init(Seances seances, Films films, Rooms rooms)
        {
            this.films = films;
            this.rooms = rooms;
            this.seances = seances;
            /*
            var cbColumnRoom = dgSeances.Columns[cRoom.Name] as DataGridViewComboBoxColumn;
            cbColumnRoom.DataSource = rooms.GetList().Select(r => r.Name).ToList();

            var cbFilmRoom = dgSeances.Columns[cFilm.Name] as DataGridViewComboBoxColumn;
            cbFilmRoom.DataSource = films.GetFilms().Select(f => f.Name).ToList();
            */
            DisplaySeances();
        }

        private void DisplaySeances()
        {
            //seances.Load(films, rooms);
            dgSeances.Rows.Clear();
            foreach (var seance in seances.GetSeances())
            {
                AddSeanceToGrid(seance);
            }
        }

        private void AddSeanceToGrid(Seance seance)
        {
            var rowId = dgSeances.Rows.Add(seance.ID, seance.Room.Name, seance.Film.Name, seance.Price, seance.Time, seance.Date.ToString("dd-MM-yyyy"));
            dgSeances.Rows[rowId].Tag = seance;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var seanceList = new List<Seance>();
            foreach (DataGridViewRow r in dgSeances.Rows)
            {
                var idValue = r.Cells[cId.Name].Value;
                if (idValue != null && !string.IsNullOrEmpty(idValue.ToString()))
                {
                    var id = int.Parse(idValue.ToString());
                    var seance = seances.GetSeance(id);
                    if (seance == null)
                    {
                        seance = new Seance();
                    }

                    seance.ID = id;
                    seance.Room = rooms.GetRoomByName(r.Cells[cRoom.Name].Value.ToString());
                    seance.Film = films.GetFilmByName(r.Cells[cFilm.Name].Value.ToString());
                    seance.Price = int.Parse(r.Cells[cPrice.Name].Value.ToString());
                    seance.Time = r.Cells[cTime.Name].Value.ToString();
                    seance.Date = DateTime.Parse(r.Cells[cDate.Name].Value.ToString());
                    if (seance.Room != null && seance.Film != null)
                    {
                        seance.BusySeats = new bool[seance.Room.RowCnt, seance.Room.ColCnt];
                        seanceList.Add(seance);
                    }
                   
                }
            }

            seances.SetSeances(seanceList);
            seances.Save();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var id = 1;
            if (dgSeances.Rows.Count > 0)
            {
                var r = dgSeances.Rows[dgSeances.Rows.Count - 1];
                var idValue = r.Cells[cId.Name].Value;
                id = int.Parse(idValue.ToString()) +1;
            }

            var seance = new Seance();
            seance.ID = id;
            seance.Date = DateTime.Now;

             var seanceForm = new ChangeSeanceForm();
            seanceForm.Init(seance, rooms, films);
            if (seanceForm.ShowDialog() == DialogResult.OK)
            {
                AddSeanceToGrid(seance);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            var selectedRowList = dgSeances.SelectedRows.OfType<DataGridViewRow>().ToList();
            foreach (var r in selectedRowList)
            {
                dgSeances.Rows.Remove(r);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            dgSeances.ReadOnly = false;
        }

        private void dgSeances_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != ColChange.Index)
            {
                return;
            }

            var r = dgSeances.Rows[e.RowIndex];
            var seance = r.Tag as Seance;
            if (seance != null)
            {

                var seanceForm = new ChangeSeanceForm();
                seanceForm.Init(seance, rooms, films);
                if (seanceForm.ShowDialog() == DialogResult.OK)
                {
                    DisplaySeances();
                }
            }
        }
    }

}
