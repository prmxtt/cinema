using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApplication7
{
    public class Film
    {
        public int ID;
        public string Name;
        public override string ToString()
        {
            return Name;
        }
    }

    public class Films
    {
        List<Film> allFilms;

        public Film GetFilm(int id)
        {
            return allFilms.FirstOrDefault(f => f.ID == id);
        }

        public Film GetFilmByName(string name)
        {
            return allFilms.FirstOrDefault(f => f.Name == name);
        }

        public List<Film> GetFilms()
        {
            return allFilms;
        }

        public  void SetFilms(List<Film> films)
        {
            allFilms = films;
        }

        public void Save()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Film>));
            using (TextWriter writer = new StreamWriter("films.xml"))
            {
                xmlSerializer.Serialize(writer, allFilms);
            }
        }

        public void Load()
        {
            if (File.Exists("films.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Film>));
                using (TextReader reader = new StreamReader("films.xml"))
                {
                    allFilms = (List<Film>)xmlSerializer.Deserialize(reader);
                }
            }

            if (allFilms == null)
            {
                allFilms = new List<Film>();
            }
        }

        protected Film CreateFilm(string line)
        {
            var split = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length > 1)
            {
                var film = new Film();
                film.ID = int.Parse(split[0]);
                film.Name = split[1];
                return film;
            }

            return null;
        }

    }
}
