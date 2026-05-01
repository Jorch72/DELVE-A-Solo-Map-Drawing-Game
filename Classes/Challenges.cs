using Delve;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class Challenge{
  ChallengeType Type=ChallengeType.None;
  string Name=string.Empty;
  string Description=string.Empty;
  bool Completed=false;
  public enum ChallengeType{
   None,
   DWARVEN_DOMINANCE,
   BEASTMASTER,
   YOU_SHALL_NOT_PASS,
   DRAGONS_ARE_OUR_FRIENDS,
   WHAT_IS_A_GOD_TO_A_NONBELIEVER,
   ENDLESS_TREASURY,
   HITTING_THE_GYM,
   MIND_YOUR_STEP,
   LOOKING_FOR_GROUP,
   ARCHMAGE,
   WELCOME_TO_THE_HOLD_OF_TOMORROW,
   RUNE_MASTER,
   DELVING_TOO_DEEP,
   PROGRESS_AT_ALL_COSTS,
   THE_ONE_THEY_FEAR
  }
  public static readonly List<Challenge>Challenges=new(){
   new Challenge(ChallengeType.DWARVEN_DOMINANCE,"DWARVEN DOMINANCE","Kill an Ancient Monstrosity with only\r\nSoldiers and Gunners."),
   new Challenge(ChallengeType.BEASTMASTER,"BEASTMASTER","Tame 10 Large Creatures."),
   new Challenge(ChallengeType.YOU_SHALL_NOT_PASS,"YOU SHALL NOT PASS","Trap an Ancient Monstrosity with Hrudak’s\r\nChains."),
   new Challenge(ChallengeType.DRAGONS_ARE_OUR_FRIENDS,"DRAGONS ARE OUR FRIENDS","Befriend a Slumbering Wyrm using\r\nCharming Colours."),
   new Challenge(ChallengeType.WHAT_IS_A_GOD_TO_A_NONBELIEVER,"WHAT IS A GOD TO A NONBELIEVER?","Kill a God Mushroom by\r\npouring lava into its source."),
   new Challenge(ChallengeType.ENDLESS_TREASURY,"ENDLESS TREASURY","Have 5,000 Trade Goods (♦)."),
   new Challenge(ChallengeType.HITTING_THE_GYM,"HITTING THE GYM","Increase a single unit’s STR to 200."),
   new Challenge(ChallengeType.MIND_YOUR_STEP,"MIND YOUR STEP","Kill an Ancient Monstrosity using nothing but\r\nDamage Traps."),
   new Challenge(ChallengeType.LOOKING_FOR_GROUP,"LOOKING FOR GROUP","Have one of each Adventurer in your hold at\r\nthe same time."),
   new Challenge(ChallengeType.ARCHMAGE,"ARCHMAGE","Cast every spell over the course of a single hold."),
   new Challenge(ChallengeType.WELCOME_TO_THE_HOLD_OF_TOMORROW,"WELCOME TO THE HOLD OF TOMORROW!","Build 3 UMBRA\r\nrooms."),
   new Challenge(ChallengeType.RUNE_MASTER,"RUNE MASTER","Find the Void Crystal while having a Bloodrune active."),
   new Challenge(ChallengeType.DELVING_TOO_DEEP,"DELVING TOO DEEP","Reach the Nightmare layer."),
   new Challenge(ChallengeType.PROGRESS_AT_ALL_COSTS,"PROGRESS AT ALL COSTS","Discover every Invention, and the power\r\nof Transmutation over the course of a single hold."),
   new Challenge(ChallengeType.THE_ONE_THEY_FEAR,"THE ONE THEY FEAR","Find the Void Crystal with every Bloodrune\r\nactive."),
  };
  public Challenge(ChallengeType type,string name,string description){
   Type=type;Name=name;Description=description;
  }
 }
}