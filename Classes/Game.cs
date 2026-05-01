using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Delve{
 public class Game{
  public int Resources=0;
  public int MaxResources=0;
  public int TradeGoods=0;
  public int MaxTradeGoods=0;
  public int Level=1;
  public int Turn=1;
  public Map? map=null;
  public Explore? explore=null;
  public Explorer? CurPos=null;

  public List<string>? BuiltRooms=null;
  public List<string>? ActiveFoes=null;
  public bool VoidCrystalFound=false;
  public bool GameOver=false;
  public string GameOverReason=string.Empty;

  public Game(){
   StartGame();
  }
  void StartGame(){
   Resources=20;
   MaxResources=50;
   TradeGoods=20;
   MaxTradeGoods=50;
   map=new Map();
   explore=new Explore();
   CurPos=new Explorer();
   Room r=map.GetRoom(CurPos.Pos);
   CurPos.Enter(r);
  }
  public string DoExplore(Direction d){
   CurPos.Move(d);
   Room? r=null;
   ExploreResult er=explore.DoExplore(Level,CurPos.Pos,Turn);
   switch(er.Type){
    case ExploreResult.ExploreResultType.Resources:
     if(Resources+er.Resources<MaxResources)Resources+=er.Resources;
     else{
      er.Log="Resource Cap Reached, setting Resources to Max: "+MaxResources.ToString();
      Resources=MaxResources;
     }
     r=map.addRoom(Room.RoomType.Empty,d,CurPos.Pos);
     CurPos.Enter(r);
    break;
    case ExploreResult.ExploreResultType.TradeGoods:
     if(TradeGoods+er.TradeGoods<MaxTradeGoods)TradeGoods+=er.TradeGoods;
     else{
      er.Log="Trade Goods Cap Reached, setting Trade Goods to Max: "+MaxTradeGoods.ToString();
      TradeGoods=MaxTradeGoods;
     }
     r=map.addRoom(Room.RoomType.Empty,d,CurPos.Pos);
     CurPos.Enter(r);
    break;
    case ExploreResult.ExploreResultType.NaturalFormations:
     r=map.addRoom(er.Naturalformation.Type,d,CurPos.Pos);
     if(er.Naturalformation.monster!=null)r.add(er.Naturalformation.monster);
     CurPos.Enter(r);
    break;
    case ExploreResult.ExploreResultType.Remnants:
     r=map.addRoom(er.Remnants.Type,d,CurPos.Pos);
     if(er.Remnants.monster!=null)r.add(er.Remnants.monster);
     CurPos.Enter(r);
    break;
   }
   return er.Log;
  }
 }
}