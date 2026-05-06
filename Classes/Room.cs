using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 public class Room{
  public RoomStatus Status=RoomStatus.Explored;
  public string Name=string.Empty;
  public string Description=string.Empty; 
  public int TradeGoods=0;
  public int Resources=0;
  public Position? Pos=null;
  internal List<Unit> UnitList=new List<Unit>();
  internal List<RoomItem> RoomItems=new List<RoomItem>();
  [Flags]
  public enum RoomStatus{
   None=0,
   Unexplored=1,
   Explored=1<<1,
   Flooded=1<<2,
   Lava=1<<3,
   Gas=1<<4,
   Collapsed=1<<5,
   Damaged=1<<6,
   Destroyed=1<<7,
   TakenOver=1<<8,
   Closed=1<<9,
   Opened=1<<10,
   unClaimed=1<<11,
   Claimed=1<<12
  }
  public void addUnit(Unit u){
   UnitList.Add(u);
  }
  public void addItem(RoomItem i){
   RoomItems.Add(i);
  }
  public void removeUnit(Unit u){
   UnitList.Remove(u);
  }
  public void removeItem(RoomItem i){
   RoomItems.Remove(i);
  }
  static string centeredString(string s,int width){
   if(s.Length>=width)return s;
   int leftPadding=(width-s.Length)/2;
   int rightPadding=width-s.Length-leftPadding;
   return new string(' ',leftPadding)+s+new string(' ',rightPadding);
  }
  public string PrintUnits(int explorer){
   string s=string.Empty;
   if(UnitList.Count==0)return "";
   switch(explorer){
    case 0:
     foreach(Unit u in UnitList){
      if(u.Type!=Unit.UnitType.The_EXplorer){
       s+=u.Name;
       if(u.Quantity>1)s+="x"+u.Quantity.ToString();
      }
     }
     return s;
    case 1:
     foreach(Unit u in UnitList){
      if(u.Type==Unit.UnitType.The_EXplorer) {
       Explorer ex=(Explorer)u;
       return ex.Draw();
      }
     }
    break;
   }
   return string.Empty;
  }
  public string PrintItems(){
   string s=string.Empty;
   if(RoomItems.Count==0)return "";
   foreach(RoomItem i in RoomItems){
    s+=i.Name;
   }
   return s;
  }
  public string DrawRoom(int line){
   string st=string.Empty;
   switch(line){
    case 0:return  "┌────────────────────┐";
    case 1:return $"│"+centeredString(Name,20)+"│";
    case 2:return $"│"+PrintUnits(1).PadLeft(10)+new string(' ',10)+"│";
    case 3:
     st=PrintUnits(0);
     if(st.Length>0)st="Units: "+st.PadRight(13);
     else st=new string(' ',20);
     return  "│"+st+"│";
    case 4:
     st=PrintItems();
     if(st.Length>0)st="Items: "+st.PadRight(13);
     else st=new string(' ',20);
     return  "│"+st+"│";
    case 5:return  "└────────────────────┘";
    default: return new string(' ',20);
   }
  }
 }
}