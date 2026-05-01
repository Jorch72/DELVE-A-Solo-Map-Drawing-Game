using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve{
 [Serializable]
 public enum AdventurerType{
  None,Drunkard,WitchHunter,Saboteur,Pathfinder,Shieldbearer,Druid,Barbarian,FieldSurgeon,Bard,Witch,Jester,GreedyHero,MonsterSlayer
 }
 [Serializable]
 public class Adventurer:Unit{
  public AdventurerType AdventType=AdventurerType.None;
  public string Description=string.Empty;
  public Room.RoomType Requirement=Room.RoomType.None;
  public Adventurer(Card c,Position p):base(UnitType.Adventurer,p){
   Requirement=Room.RoomType.Inn;
   switch(c.Value){
    case 1:
     AdventType=AdventurerType.Drunkard;
     Name="Drunkard";
     STR=5;
     Description="A cowardly drunk, this adventurer won’t fight and won’t leave the inn during combat.";
    break;
    case 2:
     AdventType=AdventurerType.WitchHunter;
     Name="Witch Hunter";
     STR=15;
     Description="Ranged. Their first attack during each combat stops an enemy from moving / attacking for two rounds.";
    break;
    case 3:
     AdventType=AdventurerType.Saboteur;
     Name="Saboteur";
     STR=5;
     Description="Automatically places a temporary level 2 Damage Trap in its grid space at the start of combat. This trap is removed at the end of combat.";
    break;
    case 4:
     AdventType=AdventurerType.Pathfinder;
     Name="Pathfinder";
     STR=5;
     Description="Choose any grid space. The Pathfinder, and any one unit or Troop of your choice may start combat in that space.";
    break;
    case 5:
     AdventType=AdventurerType.Shieldbearer;
     Name="Shieldbearer";
     STR=100;
     Description="The Shieldbearer is treated as a Defensive Barricade, except it can move as if it were a normal unit. Does not block line of sight of units with Ranged.";
    break;
    case 6:
     AdventType=AdventurerType.Druid;
     Name="Druid";
     STR=5;
     Description="Can tame a Large Creature (Q♣) without fighting it. Once tamed, your dwarves may pass through its lair but you no longer control the Druid. Inn is empty.";
    break;
    case 7:
     AdventType=AdventurerType.Barbarian;
     Name="Barbarian";
     STR=20;
     Description="Once per combat, in a fit of rage, the barbarian can rush forward 4 grid spaces, dealing their STR damage to every enemy and friend they pass.";
    break;
    case 8:
     AdventType=AdventurerType.FieldSurgeon;
     Name="Field Surgeon";
     STR=10;
     Description="Any Units / Troops defeated in the same grid space as the Field Surgeon are returned to full STR after combat.";
    break;
    case 9:
     AdventType=AdventurerType.Bard;
     Name="Bard";
     STR=5;
     Description="After entering combat with an enemy, roll 1D4. On a 4, the enemy is charmed: they are under your control unless taken over by another source. On 1 - 3, the bard is defeated.";
    break;
    case 10:
     AdventType=AdventurerType.Witch;
     Name="Witch";
     STR=5;
     Description="Choose a Unit/Troop and roll 1D2. On a 1, the chosen unit / Troop can no longer move for the rest of this combat. On a 2, double the STR of the chosen unit / Troop.";
    break;
    case 11:
     AdventType=AdventurerType.Jester;
     Name="Jester";
     STR=1;
     Description="Enemies will chase the nearest Jester instead of targeting the Entrance.";
    break;
    case 12:
     AdventType=AdventurerType.GreedyHero;
     Name="Greedy Hero";
     STR=60;
     Description="Ranged. If you do not pay them 5♦ per turn, they turn hostile.";
    break;
    case 13:
     AdventType=AdventurerType.MonsterSlayer;
     Name="Monster Slayer";
     STR=25;
     Description="Draw one less card for the Ancient Monstrosity to a minimum of 1 card.";
    break;
   }
  }
 }
}