using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace Delve{
 public class Room{
  public RoomType Type=RoomType.None;
  public string Name=string.Empty;
  public string Description=string.Empty;
  public RoomStatus Status=RoomStatus.Explored;
  int TradeGoods=0;
  int Resources=0;
  internal List<Unit> UnitList=new List<Unit>();
  public enum RoomStatus{
   Unexplored,Explored,Flooded,Lava,Gas,Collapsed,Damaged,TakenOver
  }
  public enum RoomType{
   None,Entrance,Empty,Barracks,CannonOutpost,Forge,Mason,Inn,Kennel,Laboratory,Library,Prison,
   Dorms,Hospital,Kitchen,Museum,OverseersOffice,Shrine,Stockpile,Storehouse,Temple,Treasury,InvetorsLab,Breeder,
   Drawbridge,Elevator,Pump,Corridor,ConcertHall,Tracks=128,Stairs=256
  }
  public static readonly List<Room>Catalogue=new(){
   new Room(RoomType.Barracks,       0,  8, "Barracks",         "Houses 10 Soldiers or 10 Gunners."),
   new Room(RoomType.CannonOutpost,  0, 10, "Cannon Outpost",   "Houses 2 Cannons."),
   new Room(RoomType.Forge,         15,  7, "Forge",            "Houses 1 Cannon.\r\nAllows you to build traps."),
   new Room(RoomType.Mason,          0, 20, "Mason",            "Allows construction of Barricades."),
   new Room(RoomType.Inn,           10, 30, "Inn",              "Houses 1 Adventurer,\r\nwho hides in a dark corner booth."),
   new Room(RoomType.Kennel,         0,  5, "Kennel",           "Houses 5 Hounds or a single creature.\r\nAllows you to tame creatures."),
   new Room(RoomType.Laboratory,    10,  5, "Laboratory",       "Houses 10 Alchemists.\r\nAt the start of every turn in which you have 50+ Alchemists, draw a card.\r\nIf you draw the A♠, a laboratory explodes, killing all Units within, and\r\ndamaging the nearest two rooms.\r\nIf you get the K♦, your dwarves have learned the art of transmutation: for the\r\nrest of the game, you may trade one Resource (♥) for three Trade Goods (♦)."),
   new Room(RoomType.Library,        0, 15, "Library",          "Houses 5 Mages.\r\nAfter building, get Good Magic."),
   new Room(RoomType.Prison,         0, 30, "Prison",           "Holds 20 Prisoners.\r\nEach turn, add 2 Prisoners to an available Prison grid.\r\nPrisoners can be let out in times of dire need, but they will act as enemies to\r\nboth sides.\r\nAt the start of each turn, gain 20♦ for each full Prison in your hold.\r\nAt the start of each Combat, roll 1D4. On a 1 – the Prisoners escape and\r\nmove towards your Entrance. They will attack your Units and Enemies.\r\nIf a Prison ever becomes disconnected, the Prisoners escape and begin\r\ncombat or a takeover."),
   new Room(RoomType.Dorms,          0,  5, "Dorms",            "Increases max Units each adjacent Room can house by 50% per grid of Dorms."),
   new Room(RoomType.Hospital,      10, 10, "Hospital",         "Revives a Troop to full Strength after combat on the same row as a Hospital."),
   new Room(RoomType.Kitchen,        0,  8, "Kitchen",          "Units house in a room adjacent to a Kitchen get 50% STR during combat."),
   new Room(RoomType.Museum,        50, 50, "Museum",           "Houses 4 trophies.\r\nRoll 1D4 after defeating an enemy. On a 4, draw an object in the museum to\r\ncommemorate your victory and gain +10 STR against that enemy type\r\n(i.e. goblins, vampires, golems, etc.) in future combats."),
   new Room(RoomType.OverseersOffice,0, 15, "Overseer's Office","Any ♦ cards revealed when exploring in the same column as an Overseer’s\r\nOffice are worth double."),
   new Room(RoomType.Shrine,         0, 20, "Shrine",           "Houses 1 Cleric.\r\nWhen building a Shrine, you must also choose its purpose:\r\nDefence or Fortune.\r\nA Shrine of Defence counts as a passable level 3 trap (page 17).\r\nA Shrine of Fortune increases the value of all ♦ cards by 3.\r\nShrines need a Cleric to activate their effects."),
   new Room(RoomType.Stockpile,      0, 20, "Stockpile",        "Increases max ♥ cap by 50.\r\nIf you have more than 100 Resources in your supply, and you draw the J♣,\r\npests have targeted your hold: roll 1D4.\r\nOn a 1, stone mites have eaten ½ your Resources, rounded down.\r\nOn a 2+, spawn a displaced elemental (60 STR) at your Stockpile at the\r\nlowest depth, and enter combat."),
   new Room(RoomType.Storehouse,     0, 15, "Storehouse",       "Rooms built on this floor cost ½ ♥."),
   new Room(RoomType.Temple,        20, 20, "Temple",           "Houses 3 Priests.\r\n(2 Grid Spaces)\r\nWhen building a Temple, you must also choose its purpose:\r\nProtection or Purity.\r\nA Temple of Protection allows you to pay 5♦ and place a Shield with 20 STR\r\non a unit or Troop.\r\nA Temple of Purity allows you to ignore a Bad Magic result by trapping it\r\nwithin the temple.\r\nNeed at least one Cleric to activate their\r\neffects. If all the Clerics of a Temple of Purity are defeated, the trapped\r\nBad Magic is released on the hold."),
   new Room(RoomType.Treasury,       0, 20, "Treasury",         "Increases max ♦ cap by 50.\r\nIf you have more than 100 Trade Goods in your supply, and you draw the J♠,\r\nthieves have targeted your hold: roll 1D4.\r\nOn a 1, a group of thieves steal ½ of your Trade Goods, rounded down.\r\nOn a 2+, spawn a group of thieves (40 STR) at your lowest Treasury and\r\nenter combat.\r\nThieves do not trigger traps and can use your secret passages.\r\nIf they reach the stairwell, you lose ½ your Trade Goods but the hold does\r\nnot fall (combat ends if they are the only enemies in the hold)."),
   new Room(RoomType.InvetorsLab,   50,100, "Inventor's Lab",   "You may pay 50♦ for an Invention"),
   new Room(RoomType.Breeder,        0, 80, "Breeder",          "Houses 2 young creatures.\r\n(4 Grid Spaces - Requires the Pheromones Invention)\r\nAfter using a breeding pheromone on a large creature, you may place a\r\nyounger version of that creature in this Breeder room.\r\nThe young creature has ½ the STR of the parent."),
   new Room(RoomType.Drawbridge,     0, 15, "Drawbridge",       "Maybe built over water.\r\nDuring combat, you may close the drawbridge to prevent enemies from\r\ncrossing. It takes 2 Turns to close a drawbridge. Enemies fall if on the bridge\r\nwhen it closes. They lose 50 STR x the number of Grid Spaces they fall.\r\nWhile closed, the Drawbridge becomes a level 1 Defensive Barricade.\r\n♣ Enemies can crawl or fly across the open space to attack the Barricade.\r\n♠ Enemies hesitate for a Round before finding a way to attack the Barricade.\r\nAncient Monstrosities can cross the open space to attack the Barricade."),
   new Room(RoomType.Elevator,       0,  5, "Elevator",         "Instantly move units up or down the elevator’s length.\r\nEnemies take 2 rounds per grid to ascend an Elevator shaft. If it does not\r\nmake sense for them to be able to ascend, they instead start taking over\r\nrooms."),
   new Room(RoomType.Pump,           0,  8, "Pump",             "Liquid cannot move through or damage this room.\r\nA Pump can be activated to flood if desired; follow the liquid rules,\r\nwith this room as the source."),
   new Room(RoomType.Corridor,       0,  0, "Corridor",         "Maybe built over water.\r\nCorridors are rooms that have no effect other than to expand the size of your\r\nhold, or potentially connect two disconnected rooms. They may be built in an\r\nunexplored space to the left or right of an existing room or empty cavern."),
   new Room(RoomType.ConcertHall,    0,  0, "Concert Hall",     "Free when you get Musical Golems."),
   new Room(RoomType.Tracks,         0,  5, "Tracks",           "Instantly move units along the length of the tracks. Tracks can be placed\r\nthrough other rooms."),
   new Room(RoomType.Stairs,         0,  0, "Stairs",           "Stairs are flavourful Rooms that provide vertical paths for your Units and\r\nEnemies. Stairs can be built inside existing Rooms to connect two rows together.")
  };
  public Room(RoomType R,int tradegood,int resources,string name,string description){
   Type=R;TradeGoods=tradegood;Resources=resources;Name=name;Description=description;
  }
  public Room(RoomType R){
   Type=R;
   if(R==RoomType.Entrance){
    Unit u=new Unit("Soldier",5,5);
    add(u);
   }
   //if(R==RoomType.Inn){
   // Adventurer u=new Adventurer();
   // add(u);
   //}
  }
  public Room(RoomType R,string name):this(R){
   Name=name;
  }
  public void add(Unit u){
   UnitList.Add(u);
  }
  public string PrintUnits(){
   string s="";
   foreach(Unit u in UnitList){
    s+=u.Name[0];
    if(u.Quantity>1) s+="x"+u.Quantity.ToString();
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