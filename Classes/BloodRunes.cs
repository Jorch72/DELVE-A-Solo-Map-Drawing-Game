using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class BloodRune{
  string Name=string.Empty;
  string Description=string.Empty;
  string Reward=string.Empty;
  public static readonly List<BloodRune>BloodRunes=new(){
   new BloodRune("RUNE OF NIGHTMARES","At the start of the game, you are immediately transported to the Nightmare layer\r\nand progress upwards through the layers.","Defeating an ancient monstrosity grants you 30♦."),
   new BloodRune("PRIMAL RUNE","You cannot use Gunners or Cannons.","Soldiers are empowered by primal energies, and have a base STR of 7.")
  };
  public BloodRune(string name,string description,string reward){
   Name=name;Description=description;Reward=reward;
  }
 }
}