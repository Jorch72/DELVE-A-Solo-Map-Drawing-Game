using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 [Serializable]
 public class Unit{
  public UnitType Type=UnitType.None;
  public UnitStatus Status=UnitStatus.None;
  public Abilities UnitAbilities=Abilities.None;
  public Position? Pos=null;
  public string Name=string.Empty;
  public int STR=0;
  public int Quantity=1;
  public int Cost=0;
  public int Honor=0;
  public string Power=string.Empty;

  [Flags]  
  public enum Abilities{
   None=0,
   Ranged1=1<<0,
   Ranged2=1<<1,
   Ranged3=1<<2,
   Shield=1<<3,
   Climb =1<<4,
   Ethereal=1<<5,
   Fly=1<<6,
   Drain=1<<7,
   Element=1<<8,
   Living=1<<9,
   Poison=1<<10,
   Slow=1<<11,
   Swarm=1<<12,
   FireVulnerable=1<<13,
   Fast=1<<14,
   InmuneLiquidGas=1<<15,
   FireOnce=1<<16,
   Revive=1<<17,
   MovesTowardsEnemy=1<<18,
   TravelWallFloors=1<<19,
   CreateBarricade=1<<20
  }
  public enum UnitStatus{
   None,Unavailable,Available,Idle,Active,Moving,Neutral,Hostile,InCombat,Attacking,Attacked,Defeated,Dead
  }
  public enum UnitType{
   None,Soldier,Gunner,Hound,Cleric,Mage,Prisoner,Alchemist,Golem,Cannon,SkullDwarf,AdorablePuppy,
   YoungCreature,MolePeople,Adventurer,AncientMonstrosity,Monster,Remnant,The_EXplorer,
   //Biomes Units
   //Root Biome
   Root_Golem,Rootkeeper,Elven_Archer,Elven_Acrobat,
   //Ant Colony
   Soldier_Ant,Flying_Ant,Spitter_Ant,Worker_Ant,
   //Lava Caverns
   Salamander,Magma_Miner,
   //Foul Temple
   Demon,Demonologist,Blood_Mage,Vengeful_Captives,
   //Dark Sea
   Submarine,Mariner,
   //Buried Jungle
   The_Boulder,Darter,Dinosaur,
   //Crystal Caves
   Crystal_Soldier,
   //Glacial Abyss
   Primitive_Dwarves,Explorer,
   //Rising Dungeon
   Minion,Otherworldly_Ally,
   //The Wyrd
   Marine,
   //The Underworld
   Ghost,
   //Ancient Workshop
   Mechanical_Pawn,Mechanical_Shield_Bearer,
   //Fallen Hold
   Wolf_Cannon,Ancient_Mage,
   //Hall of the Gods
   Valkyrie,Godling,Fallen_Hero
  }
  public int TotSTR{
   get {return STR*Quantity;} 
  }
  public string Draw(){
   return new string('☺',Quantity);
  }
 }
}