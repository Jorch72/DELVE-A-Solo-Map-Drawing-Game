using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class Wyrd{
  public string Name=string.Empty;
  public string Description=string.Empty;
  public int Size=0;
  public Monster? monster=null;
  public LegendaryFind? legendaryFind=null;
  public Wyrd(Deck dck,int level){
   switch(dck.DrawCard().Value){
    case 1:
     Name="A cavern supported by the bones of an ancient beast.";
     Size=dck.Roll1D4();
     Description="The cavern is "+Size.ToString()+" grid spaces in size.\r\nRooms built here automatically get a special Level 5 Defensive\r\nBarricade.";
    break;
    case 2:
     Name="Uh oh...slime cave.";
     monster=new Monster("Slime",32);
     Description="A Slime is here.\r\nWhenever these pesky\r\ncreatures are killed, coat the current grid space with slime which costs\r\nthe same as lava to drain.";
    break;
    case 3:
     Name="Meat Cave.";
     Description="No stone, just meat and organs, in a twisted parody of life.";
    break;
    case 4:
     Name="A portal.";
     Description="Choose a space within 5 grid spaces and spawn a second\r\nportal there. Units can travel between these two portals as if they were\r\nadjacent.";
    break;
    case 5:
     Name="Nuts?! A preposterous amount of acorns, and squirrels.";
     Description="Treat as a liquid\r\n(a river of nuts), followed by a Hive of Squirrels.";
     monster=new Monster(Monster.MonsterType.Hive,1,5);
    break;
    case 6:
     Name="This cavern is filled with the hyphae of a God Mushroom.";
     Description="It spreads 1\r\ngrid space per turn unless touched by fire or lava.\r\nAny Units / Troops in a space affected by the spread become infected:\r\nthey gain +5 STR and become hostile.";
    break;
    case 7:
     Name="Time Crystals.";
     Description="Roll 1D2 whenever a unit / Troop enters this room. On\r\n1, they are safe. On 2, they are aged to dust.\r\nYou can now build rooms from the game UMBRA at 10x\r\ntheir written cost.";
    break;
    case 8:
     Name="Cavern";
     Description="Contains glacially slow, living fossils that crave the sun’s embrace.\r\nIf you have (or find) Time Crystals, they come to life with 100 STR and\r\nare hostile.\r\nTamable once they come to life.";
    break;
    case 9:
     Name="Behold, a village of mole people!";
     Description="These peculiar creatures walk and\r\ntalk like us, and can be hired for 10♦ each. Moles have 7 STR and can\r\ntravel through walls and floors.";
    break;
    case 10:
     Name="Cavern";
     Description="Containing a dwarf encased in crystal clutching an artefact. Mine them out to get\r\na Legendary Finds and receive a free Soldier.";
     legendaryFind=new LegendaryFind(dck);
    break;
    case 11:
     Name="";
     Description="";
    break;
    case 12:
     Name="";
     Description="";
    break;
    case 13:
     Name="";
     Description="";
    break;
    case 14:
     Name="";
     Description="";
    break;
   }
  }
 }
}