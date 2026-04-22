using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Delve {
    public enum Dir {
        Right = 1, East = 1, Left = 3, West = 3, Up = 4, North = 4, Down = 2, South = 2
    }

    [Serializable]
    class Map {
        List<Room> maprow = new List<Room>();

        public Map() {
            Room r = new Room(Room.RoomType.Entrance);
            maprow.Add(r);
        }

        public Room addRoom(Room.RoomType T, string name, Dir direction) {
            Room r = new Room(T, name);
            switch (direction) {
                case Dir.Right:
                    maprow.Add(r);
                    break;
                case Dir.Left:
                    maprow.Insert(0, r);
                    break;
                case Dir.Up:

                    break;
                case Dir.Down:

                    break;
            }
            return r;
        }

        public string Draw() {
            StringBuilder sb = new StringBuilder();
            for (int k = 0; k < 4; k++) {
                if (maprow.Count < 5) {
                    sb.Append(new string(' ', 20));
                }
                foreach (Room r in maprow) sb.Append(r.DrawRoom(k));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public bool Save(string filename) {
            using (Stream stream = File.Open(filename, FileMode.Create)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bformatter.Serialize(stream, maprow);
            }
            return true;
        }

        public bool Load(string filename) {
            using (Stream stream = File.Open(filename, FileMode.Open)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                maprow = (List<Room>)bformatter.Deserialize(stream);
            }
            return true;
        }
    }
}
