using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class BloodRune{
  BloodRuneType Type=BloodRuneType.None;
  string Name=string.Empty;
  string Description=string.Empty;
  string Reward=string.Empty;
  public enum BloodRuneType{
   None,
   RUNE_OF_NIGHTMARES,
   PRIMAL_RUNE,
   GORE_SPLATTERED_RUNE,
   TOMBSTONE_RUNE,
   RUNE_OF_DROUGHT,
   RUNE_OF_GREED,
   RUNE_OF_DOOM,
   WOLF_RUNE,
   RUNE_OF_WAR,
   SHUNNED_RUNE
  }
  public static readonly List<BloodRune>BloodRunes=new(){
   new BloodRune(BloodRuneType.RUNE_OF_NIGHTMARES,"RUNE OF NIGHTMARES","At the start of the game, you are immediately transported to the Nightmare layer\r\nand progress upwards through the layers.","Defeating an ancient monstrosity grants you 30♦."),
   new BloodRune(BloodRuneType.PRIMAL_RUNE,"PRIMAL RUNE","You cannot use Gunners or Cannons.","Soldiers are empowered by primal energies, and have a base STR of 7."),
   new BloodRune(BloodRuneType.GORE_SPLATTERED_RUNE,"GORE-SPLATTERED RUNE","Whenever a unit or enemy is defeated in a grid space, treat that space as a source\r\nof liquid.","Ignore the effects of Contagious Cowardice"),
   new BloodRune(BloodRuneType.TOMBSTONE_RUNE,"TOMBSTONE RUNE","Defeated units and enemies respawn immediately at ½ their original STR\r\n(rounded down), but are corrupted versions of their original forms, hostile to\r\nyou.","Skull Dwarves are immune to this effect, and now have 3 STR."),
   new BloodRune(BloodRuneType.RUNE_OF_DROUGHT,"RUNE OF DROUGHT","All ♥ cards drawn while exploring are now worth ½ their value (rounded down).","Underground Rivers and Lakes are dried up, and have no liquid."),
   new BloodRune(BloodRuneType.RUNE_OF_GREED,"RUNE OF GREED","If you would ever end a turn with more Trade Goods (♦) than the capacity of\r\nyour Treasuries, spawn a Dragon with 100 STR and Ranged at your Entrance. It\r\nmoves toward your deepest Treasury. If it reaches its target, it melts all the gold\r\ninside.","Double the trade good value of all ♦ cards."),
   new BloodRune(BloodRuneType.RUNE_OF_DOOM,"RUNE OF DOOM","Never remove the Black Joker from the deck.","Never remove the Red Joker from the deck."),
   new BloodRune(BloodRuneType.WOLF_RUNE,"WOLF RUNE","At the start of any combat, spawn an Adorable Puppy from this rune (treat it as a\r\nHound with STR 1). Each round, the Adorable Puppy moves towards the nearest\r\nenemy, taking the shortest possible route. If it is defeated, a ferocious wolf\r\nmonstrosity spawns in its place: draw two cards, consulting the Ancient\r\nMonstrosity table. It also gains the Feral trait (it can move three grid spaces per\r\nround). The wolf monstrosity follows the normal rules for Ancient Monstrosities.","Your units in the same grid space as the Adorable Puppy have double STR."),
   new BloodRune(BloodRuneType.RUNE_OF_WAR,"RUNE OF WAR","All ♥ and ♦ face cards are replaced with the Siege discovery:\r\nA ramshackle siege camp. Spawn a band of Skirmishers (40 STR). The\r\nSkirmishers have a siege engine allowing them to immediately destroy any\r\nbarricades.","Each time you defeat an enemy, gain your choice of 5♥ or 5♦."),
   new BloodRune(BloodRuneType.SHUNNED_RUNE,"SHUNNED RUNE","Merchants spit at you: Trade Goods may only be traded for Resources at 1♦ for\r\n1♥, and Resources cannot be traded for Trade Goods at all.\r\nWhen recruiting Units, you must pay twice any printed cost (except for Golems,\r\nCannons, and Skull Dwarves).","Your seclusion makes your hold a prime spot for prisons.\r\nFull prisons generate 40♦, and Prisoners have 10 STR. However, when you draw\r\na ♣ or ♠, roll 1D4: on a 1, all Prisoners break out.")
  };
  public BloodRune(BloodRuneType type,string name,string description,string reward){
   Type=type;Name=name;Description=description;Reward=reward;
  }
 }
}