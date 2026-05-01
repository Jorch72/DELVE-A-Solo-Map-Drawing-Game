using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 public enum WorldLayerType{
  None,Normal,Magma,Graveyard,Skitter,Leylines,Riches,Dungeon,Nightmare
 }
 internal class WorldLayer{
  public WorldLayerType Type=WorldLayerType.None;
  public string Name=string.Empty;
  public string Description=string.Empty;
 }
 internal class Layers{
  int CurrentLayer=0;
  List<WorldLayer> Layer=new List<WorldLayer>();
  public Layers(){
   Layer.Add(new WorldLayer(){Type=WorldLayerType.None,Name="None",Description="Not being used."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Normal,Name="ALL NORMAL",Description="No effect. Everything is normal."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Magma,Name="MAGMA",Description="All liquid on this layer (excluding any spawned by Good or Bad Magic) is now lava."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Graveyard,Name="GRAVEYARD",Description="Any of your units (aside from Golems and Cannons) defeated in this layer are revived after combat ends as Skulldwarves. Enemies defeated in this layer are revived with ½ STR (rounded down). Drawing bones in the walls will help you remember this layer."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Skitter,Name="SKITTER",Description="Ignore all ♦ results; your miners are too nervous to excavate gems. When you draw the 9♣ in this layer, double the STR of the creatures in the hive."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Leylines,Name="LEYLINES",Description="Whenever you draw for Good or Bad Magic, draw twice and use both results."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Riches,Name="RICHES",Description="Brilliant gemstones adorn every surface. Double the value of all ♦ cards drawn while on this layer."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Dungeon,Name="DUNGEON",Description="Whenever you draw a ♠, draw from the deck until you draw a second ♠ and resolve both cards. Optionally, use the ♠ table from RISE."});
   Layer.Add(new WorldLayer(){Type=WorldLayerType.Nightmare,Name="NIGHTMARE",Description="You went too deep… Ancient Monstrosities get an additional trait."});
  }
  public void StartLayers(){
   CurrentLayer=(int)WorldLayerType.Normal;
  }
  public WorldLayer GetCurrentLayer(){
   return Layer[CurrentLayer];
  }
  public WorldLayerType MoveDown(){
   if(CurrentLayer==8)return WorldLayerType.Nightmare;
   CurrentLayer++;
   return (WorldLayerType)CurrentLayer;
  }
  public WorldLayerType MoveUp(){
   if(CurrentLayer==0)return WorldLayerType.None;
   if(CurrentLayer==1)return WorldLayerType.Normal;
   CurrentLayer--;
   return (WorldLayerType)CurrentLayer;
  }
 }
}