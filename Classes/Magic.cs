using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve{
 public class Magic{
  public string Name=string.Empty;
  public string Description=string.Empty;
  public int size=0;
  public Direction direction;
  public Monster? monster=null;
  public AncientMonstrosities? ancientMonstrosity=null;

  public enum Direction{
   Up,Left,Down,Right
  }
  private void GoodMagic(Deck dck){
   Card c=dck.DrawCard();
   switch(c.Value){
    case 1:
     Name="Passage to the Deep";
     Description="A magical portal that allows you quick access to the depths.";
     size=dck.DrawCard().Value;
    break;
    case 2:
     Name="Protective Wards";
     Description="Magical sigils, floating lights, or another form of magic entirely protects a room of your choice.";
    break;
    case 3:
     Name="Living Metal";
     Description="This spell counts as a unit, but cannot attack or be attacked on its own.";
    break;
    case 4:
     Name="Clone";
     Description="Choose a Troop and gain an identical clone copy of it.";
    break;
    case 5:
     Name="Pawrtl";
     Description="An elvish wizard’s pocket realm, filled with lovable cats.";
    break;
    case 6:
     Name="Fleet Forest";
     Description="Green liquid pours from this grid space, growing thick bamboo shoots and massive trees in every grid space it touches.";
    break;
    case 7:
     Name="Blessing";
     Description="The gods have smiled upon you, sealing any revealed demon portals.";
    break;
    case 8:
     Name="Siren Song";
     Description="A magical instrument that draws enemies to it. Choose a room to place the Siren Song in: enemies will try to reach this room instead of your Entrance. If an enemy reaches this room, the siren song is destroyed.";
    break;
    case 9:
     Name="Nurse's Sigil";
     Description="Red heart engravings surrounded by floating lights. Choose a grid space. Units and Troops that move through this space are returned to full STR.";
    break;
    case 10:
     Name="Gills";
     Description="A blessing, though from what source, you do not know. Dwarves are now unaffected by liquids (excluding lava).";
    break;
    case 11:
     Name="Valkyria";
     Description="Ethereal dwarves wander the halls of your hold, attending to the sick and dying. Hospital rooms no longer need adjacency, but are still limited to 1 Troop per combat.";
    break;
    case 12:
     Name="Hudrak's Chains";
     Description="Choose a room. If an Ancient Monstrosity enters the chosen room, it is permanently trapped by Hudrak’s Chains. Once one is trapped, dwarves can no longer pass through this room.";
    break;
    case 13:
     Name="Charming Colours";
     Description="A living spell that will make friends of your enemies. Charming Colours moves as though it were a unit, and when it reaches a grid space with an enemy, you gain control of it, and may treat it like one of your own units. Cannot affect Ancient Monstrosities. Charming Colours disappears once an enemy has been charmed.";
    break;
   }
  }

  private void BadMagic(Deck dck,int lvl,Position p){
   Card c=dck.DrawCard();
   switch(c.Value){
    case 1:
     Name = "The Greedy King's Touch";
     Description ="A cursed dwarf touches everything in a room\r\nof your choice, turning it, and themselves, to gold.\r\nGain 30♦ for each grid space of the room, then it is destroyed.";
    break;
    case 2:
     Name = "Grozin's Garish Gaze";
     Description ="Double the cost of the next room you build. The\r\nroom must be decorated awfully: bright pastel colours, outrageous\r\ndecor...just plain terrible.";
    break;
    case 3:
     Name = "Diamond Dust";
     Description ="The next ♦ you draw while exploring turns to dust in\r\nyour hands: you gain no benefit from it.\r\nIf the card is drawn for a Crystal Cavern (6♣), the cavern is destroyed.";
    break;
    case 4:
     Name = "Contagious Cowardice";
     Description ="The nearest Troop is affected by a magical\r\nterror. The Troop moves to the Entrance to escape, taking the shortest\r\npossible route. If the Troop passes through any Unit Rooms, all units in\r\nthose rooms leave with them.";
    break;
    case 5:
     Name = "Mortek's Magma Drill";
     Description ="A pillar of lava melts through 2D4 grid spaces\r\nbelow the room where this spell is discovered, destroying any rooms in\r\nthose spaces. Liquid.";
    break;
    case 6:
     Name = "Circus of Chaos";
     Description ="A Circus appears in the nearest empty grid space. This acts like a Demon Portal (9♠), except it spawns Creepy Clowns with 30 STR instead.";
    break;
    case 7:
     Name = "Worm";
     size=dck.Roll1D4();
     Description ="Using the grid space this spell is discovered in as its source, the\r\nWorm burrows through "+size.ToString()+" grid spaces, destroying any rooms it moves\r\nthrough, leaving a tunnel in its wake.";
     direction=(Direction)dck.Roll1D4();
    break;
    case 8:
     Name = "Swampify!";
     Description ="A swamp spawns in this grid space. Treat as liquid.\r\nAt the end of your next turn, spawn Murder Toads (10 STR) in each\r\ngrid touched by the swamp’s liquid.";
    break;
    case 9:
     Name = "Mimic";
     Description ="The nearest room becomes a Mimic. Its door hides a mouth; its\r\nfurnishings cover wicked teeth. This room has 100 STR, and cannot\r\nmove. Your units cannot pass this room until it is defeated.";
    break;
    case 10:
     Name = "Doomed";
     Description ="Remove the Red Joker for 5 turns. Shuffle the Black Joker\r\ninto the deck if it is not already in.";
    break;
    case 11:
     Name = "Possession";
     Description ="The nearest unit / Troop is possessed by evil spirits and\r\nbecomes an enemy.";
    break;
    case 12:
     Name="Outbreak";
     size=dck.Roll1D2();
     Description="If there are any Units / Troops within "+size.ToString()+"\r\ngrid spaces, they become hostile Undead (10 STR), and you repeat this\r\nprocess from the grid space with the newly created Undead.\r\nThis does not affect Golems, Cannons, or Skull Dwarves.";
    break;
    case 13:
     Name="Monstrous Form";
     Description="Spawn an Ancient Monstrosity with only 25 STR.\r\nDraw only once for a single trait.";
     ancientMonstrosity=new AncientMonstrosities(dck.DrawCard(),lvl,p);
    break;
   }
  }

  public Magic(Deck dck,int level,Position p){
   BadMagic(dck,level,p);
  }
  public Magic(Deck dck,int level){
   GoodMagic(dck);
  }
 }
}