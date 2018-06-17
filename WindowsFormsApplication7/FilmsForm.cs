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
    public partial class FilmsForm : Form
    {

        Films films;
        public FilmsForm()
        {
            InitializeComponent();
        }

        public void Init(Films films)
        {
            this.films = films;

            dgFilms.Rows.Clear();
            foreach(var film in films.GetFilms())
            {
                AddFilmRow(film);
            }
        }

        private void AddFilmRow(Film film)
        {
            var rowId = dgFilms.Rows.Add(film.ID, film.Name);
            var row = dgFilms.Rows[rowId];
            row.Tag = film;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var filmsList = new List<Film>();
            foreach(DataGridViewRow r in dgFilms.Rows)
            {
                var idValue = r.Cells[cId.Name].Value;
                if (idValue != null && !string.IsNullOrEmpty(idValue.ToString()))
                {
                    var id = int.Parse(idValue.ToString());
                    var name = r.Cells[cTitle.Name].Value.ToString();
                    var film = new Film();
                    film.ID = id;
                    film.Name = name;
                    filmsList.Add(film);
                }
            }

            films.SetFilms(filmsList);
            films.Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRowList = dgFilms.SelectedRows.OfType<DataGridViewRow>().ToList();
            foreach(var r in selectedRowList)
            {
                dgFilms.Rows.Remove(r);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var id = 1;
            if (dgFilms.Rows.Count > 0)
            {
                var r = dgFilms.Rows[dgFilms.Rows.Count - 1];
                var idValue = r.Cells[cId.Name].Value;
                id = int.Parse(idValue.ToString()) + 1;
            }

            var film = new Film();
            film.ID = id;
            film.Name = "";

            var filmForm = new FilmForm();
            filmForm.Init(film);
            if (filmForm.ShowDialog() == DialogResult.OK)
            {
                AddFilmRow(film);
            }

            
        }

        private void dgFilms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var r = dgFilms.Rows[e.RowIndex];
            var film = r.Tag as Film;
            if (film != null)
            {
                var name = r.Cells[cTitle.Name].Value.ToString();
                film.Name = name;

                var filmForm = new FilmForm();
                filmForm.Init(film);
                if (filmForm.ShowDialog() == DialogResult.OK)
                {
                    r.Cells[cTitle.Name].Value = film.Name;
                    films.Save();
                }
            }
        }
    }
}
