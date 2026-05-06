using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve{
 public enum Direction{
  Right=1,East=1,Left=3,West=3,Up=4,North=4,Down=2,South=2
 }
 [Serializable]
 public class Map{
  List<Room> maprow=new List<Room>();
  public Map(){
   DelveRoom r=new DelveRoom(DelveRoom.RoomType.Entrance,new Position(0,1));
   maprow.Add(r);
  }
  public List<Room> ContainsRoom(DelveRoom.RoomType type){
   List<Room> lst=new List<Room>();
   foreach(DelveRoom r in maprow){
    if(r.Type==type)lst.Add(r);
   }
   return lst;
  }
  public DelveRoom addRoom(DelveRoom.RoomType T,Direction direction,Position p){
   DelveRoom r=new DelveRoom(T,p);
   switch(direction){
    case Direction.Right:
     r.Pos.x=p.x+1;
     maprow.Add(r);
    break;
    case Direction.Left:
     r.Pos.x=p.x-1;
     maprow.Insert(0, r);
    break;
    case Direction.Up:
    break;
    case Direction.Down:
    break;
   }
   return r;
  }
  public int GetRoomCount(){
   return maprow.Count;
  }
  public int GetRoomCount(DelveRoom.RoomType type){
   int i=0;
   foreach(DelveRoom room in maprow)if(room.Type==type)i++;
   return i;
  }
  public DelveRoom GetRoom(Position p){
   foreach(DelveRoom r in maprow)if(r.Pos.x==p.x&&r.Pos.y==p.y)return r;
   return null;
  }
  public string Draw(){
   StringBuilder sb=new StringBuilder();
   for(int k=0;k<=5;k++){
    if(maprow.Count<5){
     sb.Append(new string(' ',20));
    }
    foreach(DelveRoom r in maprow)sb.Append(r.DrawRoom(k));
    sb.AppendLine();
   }
   return sb.ToString();
  }
  public bool Save(string filename){
   using (Stream stream=File.Open(filename, FileMode.Create)){
          //var bformatter=new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
          //bformatter.Serialize(stream,maprow);
   }
   return true;
  }
  public bool Load(string filename){
   using (Stream stream=File.Open(filename,FileMode.Open)){
          //var bformatter=new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
          //maprow=(List<Room>)bformatter.Deserialize(stream);
   }
   return true;
  }
 }
}