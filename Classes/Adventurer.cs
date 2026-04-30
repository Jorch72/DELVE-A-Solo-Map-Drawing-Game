using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve{
    [Serializable]
    public class Adventurer:Unit{
        public string Description=string.Empty;
        public Room.RoomType Requirement=Room.RoomType.None;

        public Adventurer(Card c){
            Requirement=Room.RoomType.Inn;
            switch (c.Value){
                case 1:
                    Name = "Drunkard";
                    STR = 5;
                    Description = "";
                    break;
                case 2:
                    Name = "Witch Hunter";
                    STR = 15;
                    Description = "";
                    break;
                case 3:
                    Name = "Saboteur";
                    STR = 5;
                    Description = "";
                    break;
                case 4:
                    Name = "Pathfinder";
                    STR = 5;
                    Description = "";
                    break;
                case 5:
                    Name = "Shieldbearer";
                    STR = 100;
                    Description = "";
                    break;
                case 6:
                    Name = "Druid";
                    STR = 5;
                    Description = "";
                    break;
                case 7:
                    Name = "Barbarian";
                    STR = 20;
                    Description = "";
                    break;
                case 8:
                    Name = "Field Surgeon";
                    STR = 10;
                    Description = "";
                    break;
                case 9:
                    Name = "Bard";
                    STR = 5;
                    Description = "";
                    break;
                case 10:
                    Name = "Witch";
                    STR = 5;
                    Description = "";
                    break;
                case 11:
                    Name = "Jester";
                    STR = 1;
                    Description = "";
                    break;
                case 12:
                    Name = "Greedy Hero";
                    STR = 60;
                    Description = "";
                    break;
                case 13:
                    Name = "Monster Slayer";
                    STR = 25;
                    Description = "";
                    break;
            }
        }
    }
}