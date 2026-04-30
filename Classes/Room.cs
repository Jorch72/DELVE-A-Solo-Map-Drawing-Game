using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace Delve{
 public class Room{
  public RoomType Type=RoomType.None;
  public string Name=string.Empty;
  internal List<Unit> UnitList=new List<Unit>();
  public enum RoomType{
   None,Entrance,Empty,Inn,Shop,Treasure,Monster,Boss
  }
  public Room(RoomType R){
   Type=R;
   if(R==RoomType.Entrance){
    Unit u=new Unit("Soldier",5,5);
    add(u);
   }
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
    case 0:return  "┌────────┐";
    case 1:return $"│{Type.ToString().PadLeft(9)}│";
    case 2:return $"│{Name.PadLeft(14)}│";
    case 3:return  "│"+PrintUnits()+"│";
    case 4:return  "└────────┘";
    default: return new string(' ',9);
   }
  }
 }
}