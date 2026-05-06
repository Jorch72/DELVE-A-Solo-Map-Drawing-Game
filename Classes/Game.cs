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
   DelveRoom r=map.GetRoom(CurPos.Pos);
   CurPos.Enter(r);
  }
  public void EndTurn(){
   Turn++;
  }
  public string StartofTurn(){
   //Draw a card for each Crystal Caverns in your hold.
   List<Room> LR=map.ContainsRoom(DelveRoom.RoomType.CrystalCavern);
   Card? c=null;
   int TG=0;
   string st=string.Empty;
   if(LR.Count>0){
    //At the start of each turn, draw a card before exploring.
    foreach(Room r in LR){
     if(r.Status.HasFlag(Room.RoomStatus.Destroyed))continue;
     if(r.Status.HasFlag(Room.RoomStatus.Damaged))continue;
     if(r.Status.HasFlag(Room.RoomStatus.TakenOver))continue;
     c=explore.deck.DrawCard();
     //Gain ♦ equal to its value + cavern’s depth.
     TG+=Level+c.Value;
     //If the A♦ is drawn, the cavern is destroyed.
     if(c.Suite==Card.Suites.Diamonds&&c.Value==1)r.Status|=Room.RoomStatus.Destroyed;
    }    
   }
   TradeGoods+=TG;
   if(TG>0)st=string.Format($"Gained {0} Trade Goods from your Crystal Cavern{(LR.Count>0 ? "s" : "" )}.",TG.ToString());
   return st;
   //Pay the Orefinder or Knowledgeable Creature
  }
  public string CanBuyRoom(DelveRoom.RoomType type){
   DelveRoom? r=DelveRoom.Catalogue.Find(r=>r.Type==type);
   if(r==null)return "Error Room not found!";
   if(r.Resources>Resources)return "Not enough Resources!";
   if(r.TradeGoods>TradeGoods)return "Not enough Trade Goods!";
   if(CurPos.getCurrentRoom().Type!=DelveRoom.RoomType.Empty)return "Cannot build here!";
   return string.Empty;
  }
  public string BuyRoom(DelveRoom.RoomType type){
   DelveRoom? r=DelveRoom.Catalogue.Find(r=>r.Type==type);
   if(r==null)return "Error Room not found!";
   if(r.Resources>Resources)return "Not enough Resources!";
   if(r.TradeGoods>TradeGoods)return "Not enough Trade Goods!";
   if(CurPos.getCurrentRoom().Type!=DelveRoom.RoomType.Empty)return "Cannot build here!";
   Resources-=r.Resources;
   TradeGoods-=r.TradeGoods;
   CurPos.getCurrentRoom().Type=r.Type;
   CurPos.getCurrentRoom().Name=r.Name;
   return $"Built {type}!";
  }
  public string DoExplore(Direction d){
   CurPos.Move(d);
   DelveRoom? r=null;
   ExploreResult er=explore.DoExplore(Level,CurPos.Pos,Turn);
   switch(er.Type){
    case ExploreResult.ExploreResultType.Resources:
     if(Resources+er.Resources<MaxResources)Resources+=er.Resources;
     else{
      er.Log="Resource Cap Reached, setting Resources to Max: "+MaxResources.ToString();
      Resources=MaxResources;
     }
     r=map.addRoom(DelveRoom.RoomType.Empty,d,CurPos.Pos);
     CurPos.Enter(r);
    break;
    case ExploreResult.ExploreResultType.TradeGoods:
     if(TradeGoods+er.TradeGoods<MaxTradeGoods)TradeGoods+=er.TradeGoods;
     else{
      er.Log="Trade Goods Cap Reached, setting Trade Goods to Max: "+MaxTradeGoods.ToString();
      TradeGoods=MaxTradeGoods;
     }
     r=map.addRoom(DelveRoom.RoomType.Empty,d,CurPos.Pos);
     CurPos.Enter(r);
    break;
    case ExploreResult.ExploreResultType.NaturalFormations:
     r=map.addRoom(er.Naturalformation.Type,d,CurPos.Pos);
     if(er.Naturalformation.monster!=null)r.addUnit(er.Naturalformation.monster);
     CurPos.Enter(r);
    break;
    case ExploreResult.ExploreResultType.Remnants:
     r=map.addRoom(er.Remnants.Type,d,CurPos.Pos);
     if(er.Remnants.monster!=null)r.addUnit(er.Remnants.monster);
     CurPos.Enter(r);
    break;
   }
   return er.Log;
  }
 }
}