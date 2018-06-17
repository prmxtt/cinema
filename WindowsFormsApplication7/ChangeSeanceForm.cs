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
    public partial class ChangeSeanceForm : Form
    {
        public ChangeSeanceForm()
        {
            InitializeComponent();
        }

        private Seance seance;
        private Rooms rooms;
        private Films films;

        public void Init (Seance seance, Rooms rooms, Films films)
        {
            this.seance = seance;
            this.rooms = rooms;
            this.films = films;
            tbDate.Value= seance.Date;
            tbPrice.Text = seance.Price.ToString();
            tbTime.Text = seance.Time;

            cbRooms.DataSource = rooms.GetList();
            cbFilms.DataSource = films.GetFilms();

            if(seance.Room != null)
            {
                cbRooms.SelectedItem = seance.Room;
            }

            if (seance.Film != null)
            {
                cbFilms.SelectedItem = seance.Film;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            seance.Date = tbDate.Value;
            seance.Price = int.Parse(tbPrice.Text);
            seance.Time = tbTime.Text;
            seance.Film = cbFilms.SelectedItem as Film;
            seance.Room = cbRooms.SelectedItem as Room;
            DialogResult = DialogResult.OK;               
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
