using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 [Serializable]
 public class Unit{
  public UnitType Type=UnitType.None;
  public UnitStatus Status=UnitStatus.None;
  public Position? Pos=null;
  public string Name=string.Empty;
  public int STR=0;
  public int Quantity=0;
  public int Cost=0;
  public string Power=string.Empty;

  public enum UnitStatus{
   None,Unavailable,Available,Idle,Active,Moving,Hostile,InCombat,Attacking,Attacked,Defeated,Dead
  }
  public enum UnitType{
   None,Soldier,Gunner,Hound,Cleric,Mage,Prisoner,Alchemist,Golem,Cannon,SkullDwarf,AdorablePuppy,YoungCreature,MolePeople,Adventurer,AncientMonstrosity,Monster,Remnant,Explorer
  }
  public static readonly List<Unit>Catalogue=new(){
   new Unit(UnitType.Soldier,       "Soldier",        5, 5,string.Empty),
   new Unit(UnitType.Gunner,        "Gunner",         3, 5,"Ranged"),
   new Unit(UnitType.Hound,         "Hound",          3, 5,"Moves 2 spaces per round."),
   new Unit(UnitType.Cleric,        "Cleric",         1, 8,"Shields adjacent units (5 STR per Cleric)."),
   new Unit(UnitType.Mage,          "Mage",           4, 7,"Ranged"),
   new Unit(UnitType.Prisoner,      "Prisoner",       1,-1,"Hostile to both sides."),
   new Unit(UnitType.Alchemist,     "Alchemist",      2, 8,string.Empty),
   new Unit(UnitType.Golem,         "Golem",          7,15,"Immune to liquid and gas. Available once a Golem Forge is claimed",UnitStatus.Unavailable),
   new Unit(UnitType.Cannon,        "Cannon",        30,30,"Ranged. Can fire once per combat."),
   new Unit(UnitType.SkullDwarf,    "Skull Dwarf",    1, 5,"On defeat, roll 1D4: 3+ revive after combat."),
   new Unit(UnitType.AdorablePuppy, "Adorable Puppy", 1,-1,"Spawns from the Wolf Rune.\r\nMoves towards nearest enemy.\r\nYour units in the same grid space as the Adorable Puppy have double STR.",UnitStatus.Unavailable),
   new Unit(UnitType.YoungCreature, "Young Creature", 0,-1,"When Beats are bred.",UnitStatus.Unavailable),
   new Unit(UnitType.MolePeople,    "Mole People",    7,10,"Can travel through walls and floors.\r\nAvailable once you find the village of mole people",UnitStatus.Unavailable)
  };
  public int TotSTR{
   get {return STR*Quantity;} 
  }
  public Unit(UnitType type,Position p){
   Type=type;
   Status=UnitStatus.Idle;
   Pos=p;
   if(Type==UnitType.Explorer)Name="X";
   else if(Type>UnitType.None && Type<UnitType.Adventurer){
    Name=Catalogue[(int)type-1].Name;
    STR=Catalogue[(int)type-1].STR;
   }
  }
  public Unit(UnitType type,int quantity,Position p){ 
   Type=type;
   Name=Catalogue[(int)type-1].Name;
   STR=Catalogue[(int)type-1].STR;
   Quantity=quantity;
   Pos=p;
  }
  public Unit(UnitType type,string name,int strength,int cost,string power,UnitStatus status){ 
   Type=type;Name=name;STR=strength;Cost=cost;Power=power;Status=status;
  }
  public Unit(UnitType type,string name,int strength,int cost,string power){ 
   Type=type;Name=name;STR=strength;Cost=cost;Power=power;Status=UnitStatus.Available;
  }
  public string Draw(){
   return new string('☺',Quantity);
  }
 }
}