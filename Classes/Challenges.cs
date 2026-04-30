using Delve;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class Challenge{
  string Name=string.Empty;
  string Description=string.Empty;
  bool Completed=false;
  public static readonly List<Challenge>Challenges=new(){
   new Challenge("DWARVEN DOMINANCE","Kill an Ancient Monstrosity with only\r\nSoldiers and Gunners."),
   new Challenge("BEASTMASTER","Tame 10 Large Creatures."),
   new Challenge("YOU SHALL NOT PASS","Trap an Ancient Monstrosity with Hrudak’s\r\nChains."),
   new Challenge("DRAGONS ARE OUR FRIENDS","Befriend a Slumbering Wyrm using\r\nCharming Colours."),
   new Challenge("WHAT IS A GOD TO A NONBELIEVER?","Kill a God Mushroom by\r\npouring lava into its source."),
   new Challenge("ENDLESS TREASURY","Have 5,000 Trade Goods (♦)."),
   new Challenge("HITTING THE GYM","Increase a single unit’s STR to 200."),
   new Challenge("MIND YOUR STEP","Kill an Ancient Monstrosity using nothing but\r\nDamage Traps."),
   new Challenge("LOOKING FOR GROUP","Have one of each Adventurer in your hold at\r\nthe same time."),
   new Challenge("ARCHMAGE","Cast every spell over the course of a single hold."),
   new Challenge("WELCOME TO THE HOLD OF TOMORROW!","Build 3 UMBRA\r\nrooms."),
   new Challenge("RUNE MASTER","Find the Void Crystal while having a Bloodrune active."),
   new Challenge("DELVING TOO DEEP","Reach the Nightmare layer."),
   new Challenge("PROGRESS AT ALL COSTS","Discover every Invention, and the power\r\nof Transmutation over the course of a single hold."),
   new Challenge("THE ONE THEY FEAR","Find the Void Crystal with every Bloodrune\r\nactive."),
  };
  public Challenge(string name,string description){
   Name=name;Description=description;
  }
 }
}