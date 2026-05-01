using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace Delve{
 public class Room{
  public RoomType Type=RoomType.None;
  public RoomStatus Status=RoomStatus.Explored;
  public string Name=string.Empty;
  public string Description=string.Empty; 
  public int TradeGoods=0;
  public int Resources=0;
  public Position? Pos=null;
  internal List<Unit> UnitList=new List<Unit>();
  public enum RoomStatus{
   Unexplored,Explored,Flooded,Lava,Gas,Collapsed,Damaged,TakenOver,Closed,Opened,unClaimed, Claimed
  }
  public enum RoomType{
   None,Empty,Entrance,Barracks,CannonOutpost,Forge,Mason,Inn,Kennel,Laboratory,Library,Prison,
   Dorms,Hospital,Kitchen,Museum,OverseersOffice,Shrine,Stockpile,Storehouse,Temple,Treasury,InvetorsLab,Breeder,
   Drawbridge,Elevator,Pump,Corridor,ConcertHall,Brewery,Workshop,MolePeopleVillage,Tracks=128,Stairs=256,
   UndergroundForest=512,GasFilledChamber,MagicCave,UndergroundRiver,CrystalCavern,MagmaFlow,UndergroundLake,
   MonsterLair,VolcanicShaft,BoneCavern,SlimeCave,MeatCave,PortalCave,NutRiver,GodMushroomCave,TimeCrystalCavern,
   LivingFossilCavern,DwarfinCrystalCavern,KnowledgeableCreature,WhistlingCaves,TheRealmofLostThings,
   ForgottenCrypts,WishingWell,SealedRoom,AbandonedMine,BuriedTemple,
   AbandonedRoom,AncientLibrary,DemonPortal,GolemForge,LongLostArtefact,SlumberingWyrm
  }
  public static readonly List<Room>Catalogue=new(){
   new Room(RoomType.Barracks,       0,  8, "Barracks",         "Houses 10 Soldiers or 10 Gunners."),
   new Room(RoomType.CannonOutpost,  0, 10, "Cannon Outpost",   "Houses 2 Cannons."),
   new Room(RoomType.Forge,         15,  7, "Forge",            "Houses 1 Cannon.\r\nAllows you to build traps."),
   new Room(RoomType.Mason,          0, 20, "Mason",            "Allows construction of Barricades."),
   new Room(RoomType.Inn,           10, 30, "Inn",              "Houses 1 Adventurer,\r\nwho hides in a dark corner booth."),
   new Room(RoomType.Kennel,         0,  5, "Kennel",           "Houses 5 Hounds or a single creature.\r\nAllows you to tame creatures."),
   new Room(RoomType.Laboratory,    10,  5, "Laboratory",       "Houses 10 Alchemists.\r\nAt the start of every turn in which you have 50+ Alchemists, draw a card.\r\nIf you draw the A♠, a laboratory explodes, killing all Units within, and damaging the nearest two rooms.\r\nIf you get the K♦, your dwarves have learned the art of transmutation: for the rest of the game, you may trade one Resource (♥) for three Trade Goods (♦)."),
   new Room(RoomType.Library,        0, 15, "Library",          "Houses 5 Mages. After building, get Good Magic."),
   new Room(RoomType.Prison,         0, 30, "Prison",           "Holds 20 Prisoners.\r\nEach turn, add 2 Prisoners to an available Prison grid.\r\nPrisoners can be let out in times of dire need, but they will act as enemies to both sides.\r\nAt the start of each turn, gain 20♦ for each full Prison in your hold.\r\nAt the start of each Combat, roll 1D4.\r\n On a 1 – the Prisoners escape and move towards your Entrance. They will attack your Units and Enemies.\r\nIf a Prison ever becomes disconnected, the Prisoners escape and begin combat or a takeover."),
   new Room(RoomType.Dorms,          0,  5, "Dorms",            "Increases max Units each adjacent Room can house by 50% per grid of Dorms."),
   new Room(RoomType.Hospital,      10, 10, "Hospital",         "Revives a Troop to full Strength after combat on the same row as a Hospital."),
   new Room(RoomType.Kitchen,        0,  8, "Kitchen",          "Units house in a room adjacent to a Kitchen get 50% STR during combat."),
   new Room(RoomType.Museum,        50, 50, "Museum",           "Houses 4 trophies. Roll 1D4 after defeating an enemy. On a 4, draw an object in the museum to commemorate your\r\n victory and gain +10 STR against that enemy type (i.e. goblins, vampires, golems, etc.) in future combats."),
   new Room(RoomType.OverseersOffice,0, 15, "Overseer's Office","Any ♦ cards revealed when exploring in the same column as an Overseer’s Office are worth double."),
   new Room(RoomType.Shrine,         0, 20, "Shrine",           "Houses 1 Cleric. When building a Shrine, you must also choose its purpose: Defence or Fortune. A Shrine of Defence\r\ncounts as a passable level 3 trap. A Shrine of Fortune increases the value of all ♦ cards by 3. Shrines need a Cleric\r\nto activate their effects."),
   new Room(RoomType.Stockpile,      0, 20, "Stockpile",        "Increases max ♥ cap by 50. If you have more than 100 Resources in your supply, and you draw the J♣, pests have\r\ntargeted your hold: roll 1D4. On a 1, stone mites have eaten ½ your Resources, rounded down. On a 2+, spawn a displaced\r\nelemental (60 STR) at your Stockpile at the lowest depth, and enter combat."),
   new Room(RoomType.Storehouse,     0, 15, "Storehouse",       "Rooms built on this floor cost ½ ♥."),
   new Room(RoomType.Temple,        20, 20, "Temple",           "Houses 3 Priests. (2 Grid Spaces) When building a Temple, you must also choose its purpose: Protection or Purity.\r\nA Temple of Protection allows you to pay 5♦ and place a Shield with 20 STR on a unit or Troop. A Temple of Purity allows\r\nyou to ignore a Bad Magic result by trapping it within the temple. Need at least one Cleric to activate their\r\neffects. If all the Clerics of a Temple of Purity are defeated, the trapped Bad Magic is released on the hold."),
   new Room(RoomType.Treasury,       0, 20, "Treasury",         "Increases max ♦ cap by 50. If you have more than 100 Trade Goods in your supply, and you draw the J♠, thieves have\r\ntargeted your hold: roll 1D4. On a 1, a group of thieves steal ½ of your Trade Goods, rounded down. On a 2+, spawn a\r\ngroup of thieves (40 STR) at your lowest Treasury and enter combat. Thieves do not trigger traps and can use your\r\nsecret passages.If they reach the stairwell, you lose ½ your Trade Goods but the hold does not fall (combat ends if\r\n they are the only enemies in the hold)."),
   new Room(RoomType.InvetorsLab,   50,100, "Inventor's Lab",   "You may pay 50♦ to discover an Invention"),
   new Room(RoomType.Breeder,        0, 80, "Breeder",          "Houses 2 young creatures. (4 Grid Spaces - Requires the Pheromones Invention) After using a breeding pheromone on a\r\nlarge creature, you may place a younger version of that creature in this Breeder room. The young creature has ½ the\r\nSTR of the parent."),
   new Room(RoomType.Drawbridge,     0, 15, "Drawbridge",       "Maybe built over water. During combat, you may close the drawbridge to prevent enemies from crossing. It takes 2\r\nTurns to close a drawbridge. Enemies fall if on the bridge when it closes. They lose 50 STR x the number of Grid Spaces\r\nthey fall. While closed, the Drawbridge becomes a level 1 Defensive Barricade. ♣ Enemies can crawl or fly across\r\n the open space to attack the Barricade. ♠ Enemies hesitate for a Round before finding a way to attack the Barricade.\r\nAncient Monstrosities can cross the open space to attack the Barricade."),
   new Room(RoomType.Elevator,       0,  5, "Elevator",         "Instantly move units up or down the elevator’s length. Enemies take 2 rounds per grid to ascend an Elevator shaft.\r\nIf it does not make sense for them to be able to ascend, they instead start taking over rooms."),
   new Room(RoomType.Pump,           0,  8, "Pump",             "Liquid cannot move through or damage this room. A Pump can be activated to flood if desired; follow the liquid rules,\r\nwith this room as the source."),
   new Room(RoomType.Corridor,       0,  0, "Corridor",         "Maybe built over water. Corridors are rooms that have no effect other than to expand the size of your hold, or\r\npotentially connect two disconnected rooms. They may be built in an unexplored space to the left or right of an existing\r\nroom or empty cavern."),
   new Room(RoomType.ConcertHall,   -1, -1, "Concert Hall",     "Free when you get Musical Golems. It attracts monsters similar to the Siren Song"),
   new Room(RoomType.Brewery,       -1, -1, "Brewery",          "Free when you discover Secret Brew. All Adventurers now have double STR."),
   new Room(RoomType.Workshop,      -1, -1, "Workshop",         "Free when you discover Trap Master. You may now build Traps to level 4."),
   new Room(RoomType.Tracks,         0,  5, "Tracks",           "Instantly move units along the length of the tracks. Tracks can be placed through other rooms."),
   new Room(RoomType.Stairs,         0,  0, "Stairs",           "Stairs are flavourful Rooms that provide vertical paths for your Units and Enemies. Stairs can be built inside\r\nexisting Rooms to connect two rows together.")
  };
  public Room(RoomType R,int tradegood,int resources,string name,string description){
   Type=R;TradeGoods=tradegood;Resources=resources;Name=name;Description=description;
  }
  public Room(RoomType R,Position p){
   Type=R;
   Pos=new Position(p.x,p.y);
   if(R==RoomType.Entrance){
    Name="Entrance";
    Unit u=new Unit(Unit.UnitType.Soldier,5,p);
    add(u);
   }else if((int)R>2&&(int)R<512){
    Name=Catalogue[(int)R-3].Name;
   }else{
    Name=R.ToString();
   }
  }
  public Room(RoomType R,Card c,Position p):this(R,p){
   if(R==RoomType.Inn){
    Adventurer u=new Adventurer(c,p);
    add(u);
   }
  }
  public void add(Unit u){
   UnitList.Add(u);
  }
  public void remove(Unit u){
   UnitList.Remove(u);
  }
  public string PrintUnits(){
   string s=string.Empty;
   foreach(Unit u in UnitList){
    s+=u.Name[0];
    if(u.Quantity>1)s+="x"+u.Quantity.ToString();
   }
   return s.PadRight(12);
  }
  public string DrawRoom(int line){
   switch(line){
    case 0:return  "┌────────────────────┐";
    case 1:return $"│{Type.ToString().PadLeft(20)}│";
    case 2:return $"│{Name.PadLeft(20)}│";
    case 3:return  "│"+PrintUnits().PadLeft(20)+"│";
    case 4:return  "└────────────────────┘";
    default: return new string(' ',20);
   }
  }
 }
}