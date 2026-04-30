using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 [Serializable]
 public class Unit{
  public string Name=string.Empty;
  public int STR=0;
  public int Quantity=0;
  public int Cost=0;
  public string Power=string.Empty;

  public enum UnitType{
   Soldier,Gunner,Hound,Cleric,Mage,Prisoner,Alchemist,Golem,Cannon,SkullDwarf,Adventurer,YoungCreature
  }
  public static readonly List<Unit>Catalogue=new(){
   new Unit("Soldier",     5, 5,string.Empty),
   new Unit("Gunner",      3, 5,"Ranged"),
   new Unit("Hound",       3, 5,"Moves 2 spaces per round."),
   new Unit("Cleric",      1, 8,"Shields adjacent units (5 STR per Cleric)."),
   new Unit("Mage",        4, 7,"Ranged"),
   new Unit("Prisoner",    1, 0,"Hostile to both sides."),
   new Unit("Alchemist",   2, 8,string.Empty),
   new Unit("Golem",       7,15,"Immune to liquid and gas."),
   new Unit("Cannon",     30,30,"Ranged. Can fire once per combat."),
   new Unit("Skull Dwarf", 1, 5,"On defeat, roll 1D4: 3+ revive after combat."),
  };
  public int TotSTR{
   get {return STR*Quantity;} 
  }
  public Unit(){
  }
  public Unit(string name,int strength,int quantity){ 
   Name=name;
   STR=strength;
   Quantity=quantity;
  }
  public Unit(string name,int strength,int cost,string power){ 
   Name=name;STR=strength;Cost=cost;Power=power;
  }
  public string Draw(){
   return new string('☺',Quantity);
  }
 }
}