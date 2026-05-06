using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class BiomesRoom:Room{
  public RoomType Type=RoomType.None;
  public RoomRequirement Requirement=RoomRequirement.None;
  [Flags]
  public enum RoomRequirement{
   None=0,
   Roots_Biome=1<<0,
   Lumbermill=1<<1,
   Enchanters_Workshop=1<<2
  }
  public enum RoomType{
   None,Lumbermill,Enchanters_Workshop,Enchanted_Barricade,Elven_Parlor
  }
  public BiomesRoom(RoomType type,int resources,int tradeGoods,string name,string description,RoomRequirement requirement=RoomRequirement.None){
   Type=type;
   Resources=resources;
   TradeGoods=tradeGoods;
   Name=name;
   Description=description;
   Requirement=requirement;
  }
  public static readonly List<BiomesRoom>Catalogue=new(){
   new BiomesRoom(RoomType.Lumbermill,          30, 0, "Lumbermill"          ,"Gain 10♥ per Turn. nHaving a Lumbermill counts as having Damaged the Roots.",RoomRequirement.Roots_Biome),
   new BiomesRoom(RoomType.Enchanters_Workshop, 25,15, "Enchanter's Workshop","You can Hire Root Golems and Build Enchanted Barricades.",RoomRequirement.Lumbermill),
   new BiomesRoom(RoomType.Enchanted_Barricade, 20, 0, "Enchanted Barricade" ,"50 STR per Level and cannot be passed by Ethereal Enemies.",RoomRequirement.Enchanters_Workshop),
   new BiomesRoom(RoomType.Elven_Parlor,        30,20, "Elven Parlor"        ,"Allows the Hiring of Elves. This Room can House 5 Elven Archers or Eleven Acrobats or Rootkeepers.",RoomRequirement.Roots_Biome)
  };
 }
 internal class BiomesUnit:Unit{
  public BiomesRoom.RoomRequirement Requirement=BiomesRoom.RoomRequirement.None;
  public static readonly List<BiomesUnit>Catalogue=new(){
   new BiomesUnit(UnitType.Root_Golem,   "Root Golem",   50,100,"Instantly Defeated by Fire",UnitStatus.None,Abilities.FireVulnerable,BiomesRoom.RoomRequirement.Enchanters_Workshop),
   new BiomesUnit(UnitType.Rootkeeper,   "Rootkeeper",    5,8,"Place a 10 STR Enchanted Barricade anywhere at the Start of Combat.",UnitStatus.None,Abilities.CreateBarricade),
   new BiomesUnit(UnitType.Elven_Archer, "Elven Archer", 10,20,"Fast. Ranged 3.",UnitStatus.None,Abilities.Fast|Abilities.FireVulnerable),
   new BiomesUnit(UnitType.Elven_Acrobat,"Elven Acrobat", 6,10,"Fast. Climb.",UnitStatus.None,Abilities.Fast|Abilities.FireVulnerable),
  };

  public BiomesUnit(UnitType type,string name,int strength,int cost,string power,UnitStatus status=UnitStatus.None,Abilities abilities=Abilities.None,BiomesRoom.RoomRequirement requirement=BiomesRoom.RoomRequirement.None){    
   Type=type;
   Name=name;
   STR=strength;
   Cost=cost;
   Power=power;
   Requirement=requirement;
   Status=status;
   UnitAbilities=abilities;
  } 
 }
}