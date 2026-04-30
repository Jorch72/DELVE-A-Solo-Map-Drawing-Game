using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Delve{
 internal class Game{
  public int Resources=0;
  public int MaxResources=0;
  public int TradeGoods=0;
  public int MaxTradeGoods=0;
  public int Level=1;
  public int Turn=1;
  public Map? map=null;
  public Explore? explore=null;

  public List<string>? BuiltRooms=null;
  public List<string>? ActiveFoes=null;
  public bool VoidCrystalFound=false;
  public bool GameOver=false;
  public string GameOverReason="";


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
  }
  public string DoExplore(Dir d){
   ExploreResult er=explore.DoExplore(Level);
   switch(er.Type){
    case ExploreResult.ExploreResultType.Resources:
     if(Resources+er.Resources<MaxResources)Resources+=er.Resources;
     else{
      er.Log="Resource Cap Reached, setting Resources to Max: "+MaxResources.ToString();
      Resources=MaxResources;
     }
     map.addRoom(Room.RoomType.Empty,"",d);
    break;
    case ExploreResult.ExploreResultType.TradeGoods:
     if(TradeGoods+er.TradeGoods<MaxTradeGoods)TradeGoods+=er.TradeGoods;
     else{
      er.Log="Trade Goods Cap Reached, setting Trade Goods to Max: "+MaxTradeGoods.ToString();
      TradeGoods=MaxTradeGoods;
     }
     map.addRoom(Room.RoomType.Empty,"",d);
    break;
    case ExploreResult.ExploreResultType.NaturalFormations:
     er.Log="Natural Formation Discovered, adding empty room.";
     map.addRoom(Room.RoomType.Empty,"",d);
    break;
    case ExploreResult.ExploreResultType.Remnants:
     er.Log="Remnants Discovered, adding empty room.";
     map.addRoom(Room.RoomType.Empty,"",d);
    break;
   }
   return er.Log;
  }
 }
}