using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 public class Wyrd:Room{
  public int Size=1;
  public Monster? monster=null;
  public LegendaryFind? legendaryFind=null;
  public Wyrd(Deck dck,int level,Position p):base(RoomType.Empty,p){
   switch(dck.DrawCard().Value){
    case 1:
     Type=RoomType.BoneCavern;
     Name="A cavern supported by the bones of an ancient beast.";
     Size=dck.Roll1D4();
     Description="The cavern is "+Size.ToString()+" grid spaces in size. Rooms built here automatically get a special Level 5 Defensive Barricade.";
    break;
    case 2:
     Type=RoomType.SlimeCave;
     Name="Uh oh...slime cave.";
     monster=new Monster("Slime",32,p);
     Description="A Slime is here. Whenever these pesky creatures are killed, coat the current grid space with slime which costs the same as lava to drain.";
    break;
    case 3:
     Type=RoomType.MeatCave;
     Name="Meat Cave.";
     Description="No stone, just meat and organs, in a twisted parody of life.";
    break;
    case 4:
     Type=RoomType.PortalCave;
     Name="A portal.";
     Description="Choose a space within 5 grid spaces and spawn a second portal there. Units can travel between these two portals as if they were adjacent.";
    break;
    case 5:
     Type=RoomType.NutRiver;
     Name="Nuts?! A preposterous amount of acorns, and squirrels.";
     Description="Treat as a liquid (a river of nuts), followed by a Hive of Squirrels.";
     monster=new Monster(Monster.MonsterType.Hive,1,level,5,p);
    break;
    case 6:
     Type=RoomType.GodMushroomCave;
     Name="This cavern is filled with the hyphae of a God Mushroom.";
     Description="It spreads 1 grid space per turn unless touched by fire or lava. Any Units / Troops in a space affected by the spread become infected: they gain +5 STR and become hostile.";
    break;
    case 7:
     Type=RoomType.TimeCrystalCavern;
     Name="Time Crystals.";
     Description="Roll 1D2 whenever a unit / Troop enters this room. On 1, they are safe. On 2, they are aged to dust. You can now build rooms from the game UMBRA at 10x their written cost.";
    break;
    case 8:
     Type=RoomType.LivingFossilCavern;
     Name="Cavern";
     Description="Contains glacially slow, living fossils that crave the sun’s embrace. If you have (or find) Time Crystals, they come to life with 100 STR and are hostile. Tamable once they come to life.";
    break;
    case 9:
     Type=RoomType.DwarfinCrystalCavern;
     Name="Behold, a village of mole people!";
     Description="These peculiar creatures walk and talk like us, and can be hired for 10♦ each. Moles have 7 STR and can travel through walls and floors.";
    break;
    case 10:
     Type=RoomType.DwarfinCrystalCavern;
     Name="Cavern";
     Description="Containing a dwarf encased in crystal clutching an artefact. Mine them out to get a Legendary Find and receive a free Soldier.";
     legendaryFind=new LegendaryFind(dck);
    break;
    case 11:
     Name="Cavern";
     Type=RoomType.KnowledgeableCreature;
     Description="A knowledgeable creature resides here, offering wisdom of the depths. Once per turn, you may pay the creature 5♦ to look at the top card of the deck and choose whether to keep or discard it. If you choose to discard, you must play the next card. Jokers cannot be discarded.";
    break;
    case 12:
     Name="Whistling Caves";
     Type=RoomType.WhistlingCaves;
     Description="Any unit/Troop that moves within 2 grid spaces of this room must roll a 4 on 1D4 to resist getting lost in its depths. If they fail they enter the cave and are defeated. Does not affect Ancient Monstrosities.";
    break;
    case 13:
     Name="The Realm of Lost Things";
     Type=RoomType.TheRealmofLostThings;
     Size=2;
     Description="Filled with junk. Each turn, draw a card. If it is a numbered card, gain ♦ equal to its value. Face cards give you one free unit: J–Soldier, Q–Golem, K–Cannon.";
    break;
   }
  }
 }
}