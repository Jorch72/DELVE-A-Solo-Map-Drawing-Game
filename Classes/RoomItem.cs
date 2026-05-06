using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 public class RoomItem{
  public string Name=string.Empty;
  public string Description=string.Empty;
  public RoomItemType Type=RoomItemType.None;
  [Flags]
  public enum RoomItemType{
   None=0,
   Trap=1<<0,
   Magic=1<<1,
   Artefact=1<<2,
   Tracks=1<<3,
   StairsUp=1<<4,
   StairsDown=1<<5,
   Barricade=1<<6,
   Portal=1<<7
  }
  public RoomItem(string name,string description,RoomItemType type=RoomItemType.None){
   Name=name;
   Description=description;
   Type=type;
  }
  public RoomItem(RoomItemType type=RoomItemType.None){
   Name=type.ToString();
   Type=type;
  }
 }
}