using Delve;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Delve{
 internal class Challenge{
  ChallengeType Type=ChallengeType.None;
  public string Name=string.Empty;
  public string Description=string.Empty;
  public bool Completed=false;
  public Biome Biomes=Biome.None;
  [Flags]
  public enum Biome {
   None         =0,
   Wyrd         =1<<0,
   Roots        =1<<1,
   BuriedJungle =1<<2,
   DarkSeas     =1<<3,
   LavaCavern   =1<<4,
   GlacialAbyss =1<<5,
   RisingDungeon=1<<6
  }
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
   THE_ONE_THEY_FEAR,
   // Biomes
   ITS_GETTING_WYRD,
   MOTHER_KNOWS_BEST,
   THE_GOLDEN_CHILD,
   FORTY_TWO,
   THIS_IS_MY_BOOMSTICK,
   TREE_HUGGER,
   PULL_THE_PLUG,
   CAREFUL_ITS_A_RENTAL,
   FIRE_IN_THE_FRIDGE,
   NUTS_TO_ALL_OF_YA,
   FACING_THE_PAST,
   CONSPIRATOR,
   CAT_PERSON,
   OUCH,
   EXPLORER_EXTRAORDINAIRE
  }
  public static void LoadChallenges(){
   if(!File.Exists("challenges.dat"))return;
   string[] lines=File.ReadAllLines("challenges.dat");
   foreach(string line in lines){
    string[] parts=line.Split('|');
    if(parts.Length!=2)continue;
    if(Enum.TryParse(parts[0],out ChallengeType type)){
     Challenge? challenge=Catalogue.Find(c=>c.Type==type);
     if(challenge!=null)challenge.Completed=parts[1]=="1";
    }
   }
  }
  public static void SaveChallenges(){
   List<string> lines=new();
   Catalogue.ForEach(challenge=>{
    lines.Add($"{challenge.Type}|{(challenge.Completed?"1":"0")}");
   });
   File.WriteAllLines("challenges.dat",lines);
  }
  public static readonly List<Challenge>Catalogue=new(){
   new Challenge(ChallengeType.DWARVEN_DOMINANCE,"DWARVEN DOMINANCE","Kill an Ancient Monstrosity with only Soldiers and Gunners."),
   new Challenge(ChallengeType.BEASTMASTER,"BEASTMASTER","Tame 10 Large Creatures."),
   new Challenge(ChallengeType.YOU_SHALL_NOT_PASS,"YOU SHALL NOT PASS","Trap an Ancient Monstrosity with Hrudak’s Chains."),
   new Challenge(ChallengeType.DRAGONS_ARE_OUR_FRIENDS,"DRAGONS ARE OUR FRIENDS","Befriend a Slumbering Wyrm using Charming Colours."),
   new Challenge(ChallengeType.WHAT_IS_A_GOD_TO_A_NONBELIEVER,"WHAT IS A GOD TO A NONBELIEVER?","Kill a God Mushroom by pouring lava into its source."),
   new Challenge(ChallengeType.ENDLESS_TREASURY,"ENDLESS TREASURY","Have 5,000 Trade Goods (♦)."),
   new Challenge(ChallengeType.HITTING_THE_GYM,"HITTING THE GYM","Increase a single unit’s STR to 200."),
   new Challenge(ChallengeType.MIND_YOUR_STEP,"MIND YOUR STEP","Kill an Ancient Monstrosity using nothing but Damage Traps."),
   new Challenge(ChallengeType.LOOKING_FOR_GROUP,"LOOKING FOR GROUP","Have one of each Adventurer in your hold at the same time."),
   new Challenge(ChallengeType.ARCHMAGE,"ARCHMAGE","Cast every spell over the course of a single hold."),
   new Challenge(ChallengeType.WELCOME_TO_THE_HOLD_OF_TOMORROW,"WELCOME TO THE HOLD OF TOMORROW!","Build 3 UMBRA rooms."),
   new Challenge(ChallengeType.RUNE_MASTER,"RUNE MASTER","Find the Void Crystal while having a Bloodrune active."),
   new Challenge(ChallengeType.DELVING_TOO_DEEP,"DELVING TOO DEEP","Reach the Nightmare layer."),
   new Challenge(ChallengeType.PROGRESS_AT_ALL_COSTS,"PROGRESS AT ALL COSTS","Discover every Invention, and the power of Transmutation over the course of a single hold."),
   new Challenge(ChallengeType.THE_ONE_THEY_FEAR,"THE ONE THEY FEAR","Find the Void Crystal with every Bloodrune active."),
   // Biomes
   new Challenge(ChallengeType.ITS_GETTING_WYRD,       "IT'S GETTING WYRD",      "Have an entire Row made up of Wyrd Rooms and Wyrd Biome Squares.",Biome.Wyrd),
   new Challenge(ChallengeType.MOTHER_KNOWS_BEST,      "MOTHER KNOWS BEST",      "Bring the All-Mother a Void Crystal."),
   new Challenge(ChallengeType.THE_GOLDEN_CHILD,       "THE GOLDEN CHILD",       "Gain the Favour of 3 Gods in a single Hold."),
   new Challenge(ChallengeType.FORTY_TWO,              "42",                     "Provide power to The Thinking Machine and ask it a question."),
   new Challenge(ChallengeType.THIS_IS_MY_BOOMSTICK,   "THIS IS MY BOOMSTICK",   "Defeat an Ancient Monstrosity with the legendary Dwarven Artillery piece."),
   new Challenge(ChallengeType.TREE_HUGGER,            "TREE HUGGER",            "In a single Hold, complete both a Roots Biome and Buried Jungle Biome without building a Lumbermill.",Biome.Roots|Biome.BuriedJungle),
   new Challenge(ChallengeType.PULL_THE_PLUG,          "PULL THE PLUG",          "Cause a Liquid Event that Floods 50 Squares."),
   new Challenge(ChallengeType.CAREFUL_ITS_A_RENTAL,   "CAREFUL, IT'S A RENTAL!","Explore an entire Dark Seas Biome with a single Submarine.",Biome.DarkSeas),
   new Challenge(ChallengeType.FIRE_IN_THE_FRIDGE,     "FIRE IN THE FRIDGE",     "Have a Lava Cavern Biome Flood into a Glacial Abyss Biome.",Biome.LavaCavern | Biome.GlacialAbyss),
   new Challenge(ChallengeType.NUTS_TO_ALL_OF_YA,      "NUTS TO ALL OF YA!",     "Have all of your Units turned into Squirrels and still find the Void Crystal."),
   new Challenge(ChallengeType.FACING_THE_PAST,        "FACING THE PAST",        "Face the Underworld Black Joker Event and win."),
   new Challenge(ChallengeType.CONSPIRATOR,            "CONSPIRATOR",            "Let a Rising Dungeon Biome convert 30 Squares.",Biome.RisingDungeon),
   new Challenge(ChallengeType.CAT_PERSON,             "CAT PERSON",             "Defeat the Three Headed Dog with a Sabretooth or other Cat Unit."),
   new Challenge(ChallengeType.OUCH,                   "OUCH",                   "Have a Unit with more than 150 STR Defeated by the Reaper."),
   new Challenge(ChallengeType.EXPLORER_EXTRAORDINAIRE,"EXPLORER EXTRAORDINAIRE","Discover every Biome. Can be done across multiple Holds.",Biome.Wyrd|Biome.Roots|Biome.BuriedJungle|Biome.DarkSeas|Biome.LavaCavern|Biome.GlacialAbyss|Biome.RisingDungeon),
  };
  public Challenge(ChallengeType type,string name,string description,Biome biomes=Biome.None){
   Type=type;
   Name=name;
   Description=description;
   Biomes=biomes;
  }
 }
}