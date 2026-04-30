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
                    Name="Drunkard";
                    STR=5;
                    Description="A cowardly drunk, this adventurer won’t fight and\r\nwon’t leave the inn during combat.";
                    break;
                case 2:
                    Name = "Witch Hunter";
                    STR = 15;
                    Description = "Ranged. Their first attack during each combat\r\nstops an enemy from moving / attacking for two rounds.";
                    break;
                case 3:
                    Name = "Saboteur";
                    STR = 5;
                    Description = "Automatically places a temporary level 2 Damage\r\nTrap in its grid space at the start of combat. This trap is removed at the\r\nend of combat.";
                    break;
                case 4:
                    Name = "Pathfinder";
                    STR = 5;
                    Description = "Choose any grid space. The Pathfinder, and any one\r\nunit or Troop of your choice may start combat in that space.";
                    break;
                case 5:
                    Name = "Shieldbearer";
                    STR = 100;
                    Description = "The Shieldbearer is treated as a Defensive\r\nBarricade, except it can move as if it were a normal unit. Does not\r\nblock line of sight of units with Ranged.";
                    break;
                case 6:
                    Name = "Druid";
                    STR = 5;
                    Description = "Can tame a Large Creature (Q♣) without fighting it.\r\nOnce tamed, your dwarves may pass through its lair but you no longer\r\ncontrol the Druid. Inn is empty.";
                    break;
                case 7:
                    Name = "Barbarian";
                    STR = 20;
                    Description = "Once per combat, in a fit of rage, the barbarian can\r\nrush forward 4 grid spaces, dealing their STR damage to every enemy\r\nand friend they pass.";
                    break;
                case 8:
                    Name = "Field Surgeon";
                    STR = 10;
                    Description = "Any Units / Troops defeated in the same grid\r\nspace as the Field Surgeon are returned to full STR after combat.";
                    break;
                case 9:
                    Name = "Bard";
                    STR = 5;
                    Description = "After entering combat with an enemy, roll 1D4. On a 4,\r\nthe enemy is charmed: they are under your control unless taken over by\r\nanother source. On 1 - 3, the bard is defeated.";
                    break;
                case 10:
                    Name = "Witch";
                    STR = 5;
                    Description = "Choose a Unit/Troop and roll 1D2. On a 1, the chosen\r\nunit / Troop can no longer move for the rest of this combat. On a 2,\r\ndouble the STR of the chosen unit / Troop.";
                    break;
                case 11:
                    Name = "Jester";
                    STR = 1;
                    Description = "Enemies will chase the nearest Jester instead of\r\ntargeting the Entrance.";
                    break;
                case 12:
                    Name = "Greedy Hero";
                    STR = 60;
                    Description = "Ranged. If you do not pay them 5♦ per turn,\r\nthey turn hostile.";
                    break;
                case 13:
                    Name = "Monster Slayer";
                    STR = 25;
                    Description = "Draw one less card for the Ancient\r\nMonstrosity to a minimum of 1 card.";
                    break;
            }
        }
    }
}