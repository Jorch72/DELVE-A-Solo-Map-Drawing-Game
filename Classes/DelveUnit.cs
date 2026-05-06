using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class DelveUnit:Unit{
  public static readonly List<DelveUnit>Catalogue=new(){
   new DelveUnit(UnitType.Soldier,       "Soldier",        5, 5,string.Empty),
   new DelveUnit(UnitType.Gunner,        "Gunner",         3, 5,"Ranged",UnitStatus.None,Abilities.Ranged2),
   new DelveUnit(UnitType.Hound,         "Hound",          3, 5,"Moves 2 spaces per round.",UnitStatus.None,Abilities.Fast),
   new DelveUnit(UnitType.Cleric,        "Cleric",         1, 8,"Shields adjacent units (5 STR per Cleric).",UnitStatus.None,Abilities.Shield),
   new DelveUnit(UnitType.Mage,          "Mage",           4, 7,"Ranged",UnitStatus.None,Abilities.Ranged2),
   new DelveUnit(UnitType.Prisoner,      "Prisoner",       1,-1,"Hostile to both sides."),
   new DelveUnit(UnitType.Alchemist,     "Alchemist",      2, 8,string.Empty),
   new DelveUnit(UnitType.Golem,         "Golem",          7,15,"Immune to liquid and gas. Available once a Golem Forge is claimed",UnitStatus.Unavailable,Abilities.InmuneLiquidGas),
   new DelveUnit(UnitType.Cannon,        "Cannon",        30,30,"Ranged. Can fire once per combat.",UnitStatus.None,Abilities.Ranged2|Abilities.FireOnce),
   new DelveUnit(UnitType.SkullDwarf,    "Skull Dwarf",    1, 5,"On defeat, roll 1D4: 3+ revive after combat.",UnitStatus.None,Abilities.Revive),
   new DelveUnit(UnitType.AdorablePuppy, "Adorable Puppy", 1,-1,"Spawns from the Wolf Rune.\r\nMoves towards nearest enemy.\r\nYour units in the same grid space as the Adorable Puppy have double STR.",UnitStatus.Unavailable,Abilities.MovesTowardsEnemy),
   new DelveUnit(UnitType.YoungCreature, "Young Creature", 0,-1,"When Beats are bred.",UnitStatus.Unavailable),
   new DelveUnit(UnitType.MolePeople,    "Mole People",    7,10,"Can travel through walls and floors.\r\nAvailable once you find the village of mole people",UnitStatus.Unavailable,Abilities.TravelWallFloors)
  };
 public DelveUnit(UnitType type,Position p){
   Type=type;
   Status=UnitStatus.Idle;
   Pos=p;
   if(Type==UnitType.Explorer)Name="X";
   else if(Type>UnitType.None && Type<UnitType.Adventurer){
    Name=Catalogue[(int)type-1].Name;
    STR=Catalogue[(int)type-1].STR;
   }
  }
  public DelveUnit(UnitType type,int quantity,Position p){ 
   Type=type;
   Name=Catalogue[(int)type-1].Name;
   STR=Catalogue[(int)type-1].STR;
   Quantity=quantity;
   Pos=p;
  }
  public DelveUnit(UnitType type,string name,int strength,int cost,string power,UnitStatus status=UnitStatus.None,Abilities abilities=Abilities.None){ 
   Type=type;Name=name;STR=strength;Cost=cost;Power=power;Status=status;UnitAbilities=abilities;
  } 
 }
}