using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApplication7;

namespace WindowsFormsApplication7
{
    public class Rooms
    {
        List<Room> allRooms;

        public List<Room> GetList()
        {
            return allRooms;
        }

        public void SetList(List<Room> roomList)
        {
            allRooms = roomList;
        }
        public Room GetRoom(int id)
        {
            return allRooms.FirstOrDefault(f => f.ID == id);
        }

        public Room GetRoomByName(string name)
        {
            return allRooms.FirstOrDefault(r => r.Name == name);
        }
        public void Load()
        {
            var lines = File.ReadAllLines("Rooms.txt");
            allRooms = lines.Select(CreateRoom).Where(f => f != null).ToList();
        }

        public void Save()
        {
            var fileStr = new string[allRooms.Count];
            for (var k = 0; k < allRooms.Count; k++)
            {
                var room = allRooms[k];
                string seats = "";
                for (int i = 0; i < room.Seats.GetLength(0); i++)
                {
                    for (int j = 0; j < room.Seats.GetLength(1); j++)
                    {
                        if (room.Seats[i, j].IsAvailable == false)
                            seats += i + ":" + j + ",";
                    }
                }
                fileStr[k] = string.Format("{0}\t{1}\t{2}\t{3}\t{4}", room.ID, room.Name, room.RowCnt, room.ColCnt, seats);
            }
            File.WriteAllLines("rooms.txt", fileStr, Encoding.UTF8);
        }

        protected Room CreateRoom(string line)
        {
            var split = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length > 3)
            {
                var Room = new Room();
                Room.ID = int.Parse(split[0]);
                Room.Name = split[1];
                Room.RowCnt = int.Parse(split[2]);
                Room.ColCnt = int.Parse(split[3]);
                Room.Seats = CreateSeats(Room.RowCnt, Room.ColCnt);
                if (split.Length > 4)
                {
                    InitSeats(Room, split[4]);
                }

                return Room;
            }

            return null;
        }

        public Room CreateRoomById(int id)
        {
            var room = new Room();
            room.ID = id;
            room.Name = "";
            room.RowCnt = 5;
            room.ColCnt = 5;
            room.Seats = CreateSeats(room.RowCnt, room.ColCnt);
            return room;
        }

        protected void InitSeats(Room room, string availableSeatsStr)
        {
            var split = availableSeatsStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in split)
            {
                var seatSplit = s.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (seatSplit.Length == 2)
                {
                    var row = int.Parse(seatSplit[0]);
                    var col = int.Parse(seatSplit[1]);
                    if ((row >= 0 && row < room.RowCnt) && (col >= 0 && col < room.ColCnt))
                    {
                        room.Seats[row, col].IsAvailable = false;
                    }
                }
            }
        }

        protected Seat[,] CreateSeats(int rowCnt, int colCnt)
        {
            var seats = new Seat[rowCnt, colCnt];
            for (var r = 0; r < rowCnt; r++)
            {
                for (var c = 0; c < colCnt; c++)
                {
                    seats[r, c] = new Seat
                    {
                        Col = c,
                        Row = r,
                        IsAvailable = true,
                    };
                }
            }

            return seats;
        }
    }


   
    public class Room
    {
        public int ID;

        public Seat[,] Seats;

        public string Name;
        public int RowCnt;
        public int ColCnt;

        public override string ToString()
        {
            return Name;
        }
    }
}