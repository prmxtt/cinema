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
    public partial class RoomForm : Form
    {
        Room room;
        Button[,] btnArray;
        const int SEAT_WIDTH = 25;
        const int SEAT_HEIGHT = 25;
        public RoomForm()
        {
            InitializeComponent();
        }

        public void Init(Room room)
        {
            this.room = room;
            tbName.Text = room.Name;
            tbColCount.Text = room.ColCnt.ToString();
            tbRowCount.Text = room.RowCnt.ToString();

            DisplayRoom();
        }



        private void DisplayRoom()
        {

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
            seat.IsAvailable = !seat.IsAvailable;
            UpdateButtonState(btn);

        }

        private void UpdateButtonState(Button btn)
        {
            Seat seat = (Seat)btn.Tag;
            if (!seat.IsAvailable)
            {
                btn.BackColor = Color.Gray;
            }
            else
            {
                btn.BackColor = Color.Green;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            room.ColCnt = int.Parse(tbColCount.Text);
            room.RowCnt = int.Parse(tbRowCount.Text);
            room.Seats = new Seat[room.RowCnt, room.ColCnt];
            for (var r = 0; r < room.RowCnt; r++)
            {
                for (var c = 0; c < room.ColCnt; c++)
                {
                    room.Seats[r, c] = new Seat
                    {
                        IsAvailable = true,
                        Col = c,
                        Row = r
                    };
                }
            }

            DisplayRoom();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            room.Name = tbName.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
