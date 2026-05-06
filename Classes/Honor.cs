using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class HonorRoom:Room{
  public RoomType Type=RoomType.None;
  public RoomRequirement Requirement=RoomRequirement.None;
  [Flags]
  public enum RoomRequirement{
   None=0,
   Dedicated=1<<0
  }
  public enum RoomType{
   None,Personal_Chambers,Office,Feast_Hall,Gallery,Meeting_Hall,Memorial,Quiet_Room
  }
  public HonorRoom(RoomType type,int resources,int tradeGoods,string name,string description,RoomRequirement requirement=RoomRequirement.None){
   Type=type;
   Resources=resources;
   TradeGoods=tradeGoods;
   Name=name;
   Description=description;
   Requirement=requirement;
  }
  public static readonly List<HonorRoom> Catalogue=new(){
   new HonorRoom(RoomType.Personal_Chambers, 5, 5, "Personal Chambers","This room must be dedicated to a single Honored Unit.",RoomRequirement.Dedicated),
   new HonorRoom(RoomType.Office,           10, 0, "Office"           ,"This room must be dedicated to a single Honored Unit.",RoomRequirement.Dedicated),
   new HonorRoom(RoomType.Feast_Hall,       30, 0, "Feast Hall"       ,"When combat begins, one Troop can spawn at a Feast Hall instead of their home room."),
   new HonorRoom(RoomType.Gallery,           0,35, "Gallery"          ,"Units housed in rooms adjacent to a Gallery gain 2 STR."),
   new HonorRoom(RoomType.Meeting_Hall,     30,20, "Meeting Hall"     ,"Whenever you build a new building, roll 2d4. If the total is 2 or 3, the building’s cost is reduced by half. If the total is 8, the building’s cost is doubled."),
   new HonorRoom(RoomType.Memorial,         10, 0, "Memorial"         ,"A memorial to remember a fallen Honored Unit (see Death of Honored Dwarves)."),
   new HonorRoom(RoomType.Quiet_Room,       50, 0, "Quiet Room"       ,"A single Honored Unit with a Grudge can be resigned to this space for a number of draws equal to their Honor. During this time, they cannot participate in combat or other events. At the end they emerge, and no longer hold a Grudge.")
  };
 }
}