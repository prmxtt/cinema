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
    public partial class RoomsForm : Form
    {

        Rooms rooms;
        public RoomsForm()
        {
            InitializeComponent();
        }

        public void Init(Rooms rooms)
        {
            this.rooms = rooms;

            dgRooms.Rows.Clear();
            foreach (var room in rooms.GetList())
            {
                AddRoomToGrid(room);
            }
        }

        private Room GetRoomFromRow(DataGridViewRow row)
        {
            var room = row.Tag as Room;
            if (room != null)
            {
                var name = row.Cells[cTitle.Name].Value.ToString();
                room.Name = name;
            }

            return room;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            var roomList = new List<Room>();
            foreach(DataGridViewRow r in dgRooms.Rows)
            {
                var room = GetRoomFromRow(r);
                if (room != null)
                {
                    roomList.Add(room);
                }
            }

            rooms.SetList(roomList);
            rooms.Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRowList = dgRooms.SelectedRows.OfType<DataGridViewRow>().ToList();
            foreach (var r in selectedRowList)
            {
                dgRooms.Rows.Remove(r);
            }
        }

        private void AddRoomToGrid(Room room)
        {
            var indexRow = dgRooms.Rows.Add(room.ID, room.Name);
            var row = dgRooms.Rows[indexRow];
            row.Tag = room;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgRooms.ReadOnly = false;
            var id = 1;
            if (dgRooms.Rows.Count > 0)
            {
                var r = dgRooms.Rows[dgRooms.Rows.Count - 1];
                var idValue = r.Cells[cId.Name].Value;
                id = int.Parse(idValue.ToString()) + 1;               
            }

            var room = rooms.CreateRoomById(id);
            AddRoomToGrid(room);
        }

        /*private void dgRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {

                var r = dgRooms.Rows[e.RowIndex];

                var idValue = r.Cells[cId.Name].Value;
                if (idValue != null && !string.IsNullOrEmpty(idValue.ToString()))
                {
                    var id = int.Parse(idValue.ToString());
                    var room = rooms.GetRoom(id);
                    if (room != null)
                    {
                        var roomForm = new RoomForm();
                        roomForm.Init(room);
                        if (roomForm.ShowDialog() == DialogResult.OK)
                        {
                            r.Cells[cTitle.Name].Value = room.Name;
                            rooms.Save();
                        }
                    }
                }
            }
        }*/

        private void btnChange_Click(object sender, EventArgs e)
        {
            dgRooms.ReadOnly = false;
        }

        private void dgRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                 
            var r = dgRooms.Rows[e.RowIndex];
            var room = r.Tag as Room;
            if (room != null)
            {
                var name = r.Cells[cTitle.Name].Value.ToString();
                room.Name = name;

                var roomForm = new RoomForm();
                roomForm.Init(room);                       
                if (roomForm.ShowDialog() == DialogResult.OK)
                {
                    r.Cells[cTitle.Name].Value = room.Name;
                    rooms.Save();
                }
            }               
        }
    }
}
