using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Delve{
 internal class Game{
  public int Resources=0;
  public int TradeGoods=0;
  public int Level=1;
  public int Turn=1;
  public Map? map=null;
  public Explore? explore=null;

  public Game(){
   StartGame();
  }
  void StartGame(){
   Resources=20;
   TradeGoods=20;
   map=new Map();
   explore=new Explore();
  }
  public string DoExplore(Dir d){
   ExploreResult er=explore.DoExplore(Level);
   switch(er.Type){
    case ExploreResult.ExploreResultType.Resources:
     Resources+=er.Resources;
     map.addRoom(Room.RoomType.Empty,"",d);
    break;
    case ExploreResult.ExploreResultType.TradeGoods:
     TradeGoods+=er.TradeGoods;
     map.addRoom(Room.RoomType.Empty,"",d);
    break;
    case ExploreResult.ExploreResultType.NaturalFormations:
     return er.Naturalformation.Description;
    case ExploreResult.ExploreResultType.Remnants:
    break;
   }
   Debug.WriteLine(er.Log);
   return "";
  }
 }
}