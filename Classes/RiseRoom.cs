using System;
using System.Collections.Generic;
using System.Text;
using static Delve.DelveRoom;

namespace Delve{
 internal class RiseRoom:Room{
  public RoomType Type=RoomType.None;
  public RiseRoomCategory Category=RiseRoomCategory.None;
  public int MaxSTR=0;      // Lair rooms only
 
  public enum RiseRoomCategory {
   None,Lair,Building,Effect,Happiness,Buffing,Raid
  }
  public enum RoomType{
   None,
   // Lair
   Hovel,Chamber,Manor,
   // Building
   Forge,Mason,Rattery,SupplyCloset,
   // Effect
   Prison,TortureChamber,HiringOffice,PuzzleRoom,Altar,
   // Happiness
   Casino,Tavern,Theatre,Carnival,
   // Buffing
   Kitchen,Surgery,Laundry,Treasury,Stockpile,
   // Raid
   PortalSiegeCamp,ThievesGallery
  }

  public static readonly List<RiseRoom> Catalogue=new(){
   // Lair
   new RiseRoom(RoomType.Hovel,         RiseRoomCategory.Lair,      5,  0,  30, "Hovel",              "The most basic of lairs, this room is the equivalent of a draughty cave with a straw mat or a certain franchise hotel. Lair. Can house a maximum of 10 units."),
   new RiseRoom(RoomType.Chamber,       RiseRoomCategory.Lair,     20,  0,  50, "Chamber",            "Some privacy, a place to hang one's helmet. Lair. Can house a maximum of 10 units. Decrease the housed units' Mutiny Threshold by 1."),
   new RiseRoom(RoomType.Manor,         RiseRoomCategory.Lair,     50, 20, 180, "Manor",              "The fanciest of digs, it would take a right curmudgeon to grumble about living here. Lair. Adjacent Chambers become Hovels, adjacent Hovels stop counting as Lairs. Can house a maximum of 1 unit. Decrease the housed units' Mutiny Threshold by 3."),
   // Building
   new RiseRoom(RoomType.Forge,          RiseRoomCategory.Building, 10, 14,   0, "Forge",              "Pounding hammers and burning forges, hissing pipes and half built machines. Building a Forge lets you build traps and hire machines. Serves as the Machine's unit room and can house 2 machines."),
   new RiseRoom(RoomType.Mason,          RiseRoomCategory.Building, 20,  0,   0, "Mason",              "Dungeon architecture is more of an art than a science, at least that's what the masons say. Building a Mason lets you build barricades and secret passages."),
   new RiseRoom(RoomType.Rattery,        RiseRoomCategory.Building, 16,  0,   0, "Rattery",            "Oh look at their little plaguey faces. Aren't they just the cutest, Keeper? Serves as the Rats' unit room and can house 20 Rats regardless of size."),
   new RiseRoom(RoomType.SupplyCloset,   RiseRoomCategory.Building, 10,  0,   0, "Supply Closet",      "Filled with arrows, rocks, and acid for the various traps. Serves as the Trapper's unit room and can house 1 Trapper."),
   // Effect
   new RiseRoom(RoomType.Prison,         RiseRoomCategory.Effect,   15,  0,   0, "Prison",             "A place for unruly adventurers and minions to cool off and practice their arts and crafts. After defeating an enemy, you may choose to imprison them here. Each Prison can hold a single enemy."),
   new RiseRoom(RoomType.TortureChamber, RiseRoomCategory.Effect,   25,  0,   0, "Torture Chamber",    "A place for well behaved minions of a certain disposition to practice their arts and crafts. You can torture one prisoner per turn. Roll 1D4. On a 4, draw on the Information table."),
   new RiseRoom(RoomType.HiringOffice,   RiseRoomCategory.Effect,   20, 10,   0, "Hiring Office",      "Good help is hard to come by but everyone has their price. Attempt to hire one prisoner per turn. Roll 1D4. On a 4, they join. On a 3, they join at a cost. Any unit hired this way has a Mutiny Threshold of 12."),
   new RiseRoom(RoomType.PuzzleRoom,     RiseRoomCategory.Effect,   12,  5,   0, "Puzzle Room",        "What good dungeon would be complete without some sort of convoluted puzzle? Roll 1D2 each combat round an enemy is stuck here. On a 2, they solve it and continue."),
   new RiseRoom(RoomType.Altar,          RiseRoomCategory.Effect,   10,  0,   0, "Altar",              "While some minions may get pouty about it, their sacrifice is one we must be willing to make. Sacrifice a unit to draw on the Good Magic table. Decrease Dungeon Happiness by 5."),
   // Happiness
   new RiseRoom(RoomType.Casino,         RiseRoomCategory.Happiness,20, 10,   0, "Casino",             "Look at them. Mindlessly chucking dice, hoping to win big. Increase Dungeon Happiness by 15. Gain 5♦ every turn per Casino. If K♦ is drawn, lose ½ your total ♦."),
   new RiseRoom(RoomType.Tavern,         RiseRoomCategory.Happiness,10,  0,   0, "Tavern",             "Alcohol, darts, snooker, bad karaoke — is there really any other kind? Increase Dungeon Happiness by 5 but raise the Mutiny Threshold of all units on this floor by 1."),
   new RiseRoom(RoomType.Theatre,        RiseRoomCategory.Happiness,25,  0,   0, "Theatre",            "Some of our minions prefer more... refined entertainment. Increase Dungeon Happiness by 10. When a Mutiny happens, choose a friendly Troop to be immediately defeated."),
   new RiseRoom(RoomType.Carnival,       RiseRoomCategory.Happiness,20,  0,   0, "Carnival",           "Shrunken head shy, acid dunk tanks, and creepy clowns. Increase Dungeon Happiness by 10. Gain 2♦ every turn per Carnival. If K♥ is drawn, lose your highest STR unit."),
   // Buffing
   new RiseRoom(RoomType.Kitchen,        RiseRoomCategory.Buffing,   8,  0,   0, "Kitchen",            "Whatever the form, units adjacent to the Kitchen have 150% their normal STR."),
   new RiseRoom(RoomType.Surgery,        RiseRoomCategory.Buffing,  15,  0,   0, "Surgery",            "A hacksaw and a jug of leeches is the cure for any ailment. Revive one unit/Troop of your choice after combat, and raise their Mutiny Threshold by 1."),
   new RiseRoom(RoomType.Laundry,        RiseRoomCategory.Buffing,  10,  0,   0, "Laundry",            "Some minions might be fine with lazing around in their own filth, but the smell is really starting to upset the rest of us. Increase Dungeon Happiness by 2 for each Lair on the same row as this room."),
   new RiseRoom(RoomType.Treasury,       RiseRoomCategory.Buffing,  10,  0,   0, "Treasury",           "Each Treasury increases your max Trade Goods (♦) by 50. If you ever have 500♦+, you may hire a Dragon (100 STR, Ranged) for free."),
   new RiseRoom(RoomType.Stockpile,      RiseRoomCategory.Buffing,  10,  0,   0, "Stockpile",          "Each Stockpile increases your max Resources (♥) by 50."),
   // Raid
   new RiseRoom(RoomType.PortalSiegeCamp,RiseRoomCategory.Raid,     50,  0,   0, "Portal Siege Camp",  "Allows you to raid Realms. Pay 20♦ to stabilise the portal, choose up to 10 units, draw cards per 10 STR, then draw a Realm card."),
   new RiseRoom(RoomType.ThievesGallery, RiseRoomCategory.Raid,     15,  0,   0, "Thieves' Gallery",   "Each gallery holds items from one realm. Collect 4 items to reduce that realm's card draw by 1. At 0 cards, the realm is razed."),
  };

  public RiseRoom(RoomType type,RiseRoomCategory category,int resources,int tradeGoods,int maxSTR,string name,string description){
   Type=type;
   Category=category;
   Resources=resources;
   TradeGoods=tradeGoods;
   MaxSTR=maxSTR;
   Name=name;
   Description=description;
  }
 }
}