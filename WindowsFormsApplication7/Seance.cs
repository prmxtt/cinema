using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    public class Seance
    {
        public int ID;
        public Room Room;
        public Film Film;
        public int Price;
        public string Time;
        public DateTime Date;

        public bool[,] BusySeats;

        public override string ToString()
        {
            return Time + " - " + Room.Name;
        }
    }

    public class Seances
    {
        public List<Film> GetFilmsBySeance(List<Seance> seanceList)
        {
            Dictionary<string, Film> UniqueFilmName = new Dictionary<string, Film>();
            foreach (Seance s in seanceList)
            {
                if (!UniqueFilmName.ContainsKey(s.Film.Name))
                {
                    UniqueFilmName.Add(s.Film.Name, s.Film);
                }
                
            }
            return UniqueFilmName.Values.ToList();
             
        } 
        List<Seance> allSeances;
        
        

        public Seance GetNearlest(DateTime date)
        {
             return allSeances.OrderBy(s => Math.Abs((s.Date - date).TotalDays)).FirstOrDefault();
        }

        public void SetSeances(List<Seance> seances)
        {
            allSeances = seances;
        }

        public Seance GetSeance(int id)
        {
            return allSeances.FirstOrDefault(f => f.ID == id);
        }

        public List<Seance> GetSeancesByDate(DateTime date)
        {
            return allSeances.Where(s => s.Date.Year == date.Year && s.Date.Month == date.Month && s.Date.Day == date.Day).ToList();
        }


        public List<Seance> GetSeances(int filmId, DateTime date)
        {
            return allSeances.Where(s => s.Film.ID == filmId && s.Date.Year == date.Year && s.Date.Month == date.Month && s.Date.Day == date.Day).ToList();
        }


        public void Save()
        {
            var fileStr = new string[allSeances.Count];
            for (var i = 0; i <  allSeances.Count; i++)
            {
                var seance = allSeances[i];
                fileStr[i] =  string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", seance.ID, seance.Room.ID, seance.Film.ID, seance.Price, seance.Time, seance.Date.ToString("dd-MM-yyyy"), CreateBusySeatsStr(seance));
            }

            File.WriteAllLines("Seances.txt", fileStr, Encoding.UTF8);
        }

        private string CreateBusySeatsStr(Seance seance)
        {
            var busySeatsStr = string.Empty;
            for (var r = 0; r < seance.Room.RowCnt; r++)
            {
                for (var c = 0; c < seance.Room.ColCnt; c++)
                {
                    if (seance.BusySeats[r,c] == true)
                    {
                        if (!string.IsNullOrEmpty(busySeatsStr))
                        {
                            busySeatsStr += ",";
                        }

                        busySeatsStr += string.Format("{0}:{1}", r + 1,c + 1);
                    }
                }
            }

            return busySeatsStr;
        }

        public void Load(Films films, Rooms rooms)
        {
            var lines = File.ReadAllLines("Seances.txt");
            allSeances = lines.Select(l => CreateSeance(l, films, rooms)).Where(f => f != null).ToList();
        }

        public List<Seance> GetSeances()
        {
            return allSeances;
        }


        protected Seance CreateSeance(string line, Films films, Rooms rooms)
        {
            var split = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length > 5)
            {
                var seance = new Seance();
                seance.ID = int.Parse(split[0]);
                var room = rooms.GetRoom(int.Parse(split[1]));
                var film = films.GetFilm(int.Parse(split[2]));
                seance.Room = room;
                seance.Film = film;
                seance.Price = int.Parse(split[3]);
                seance.Time = split[4];
                seance.Date = DateTime.Parse(split[5]);

                seance.BusySeats = new bool[seance.Room.RowCnt, seance.Room.ColCnt];

                if (split.Length > 6)
                {
                    InitBusySeats(seance, split[6]);
                }

                return seance;
            }

            return null;
        }


        protected void InitBusySeats(Seance seance, string busySeatsStr) {
            var split = busySeatsStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in split)
            {
                var seatSplit = s.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (seatSplit.Length == 2)
                {
                    var row = int.Parse(seatSplit[0]) - 1;
                    var col = int.Parse(seatSplit[1]) - 1;
                    if ((row >= 0 && row < seance.Room.RowCnt) && (col >= 0 && col < seance.Room.ColCnt))
                    {
                        seance.BusySeats[row, col] = true;
                    }
                }
            }
        }

    }
    
}
