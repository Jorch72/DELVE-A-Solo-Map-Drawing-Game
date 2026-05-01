using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Text;

namespace Delve{
 public class LegendaryFind{
  string Name=string.Empty;
  string Description=string.Empty;
  string Form=string.Empty;
  public LegendaryFind(Deck dck){
   int x=0,y=0;
   string[,] forms = {{"Gem","Fountain","Spirit","Shield"},
                      {"Mushroom","Tool","Skeleton","Axe"},
                      {"Artwork","Invention","Statue","Sword"},
                      {"Instrument","Speleotherm","Tome","Armour"}};
   x=dck.DrawCard().Value-1;
   y=dck.DrawCard().Value-1;
   Form=forms[x,y];
   switch(dck.DrawCard().Value) {
    case 1:
     Description="Legendary. Dwarves flock to see and protect this artefact. All units cost ½ the usual ♦ cost.";
    break;
    case 2:
     Description="Blessed. Build a Shrine around this artefact and get double its usual effect.";
    break;
    case 3:
     Description="Lucky. Whenever you roll 1D2, you may re-roll once to try for the result you want. Good luck.";
    break;
    case 4:
     Description="Guidance. This artefact gives the hold visions of the depths. When exploring, draw 2 cards, picking the one you want. Jokers must be played.";
    break;
    case 5:
     Description="Valuable. A collector offers you 300♦ for this artefact.";
    break;
    case 6:
     Description="Animated. This artefact may move freely. Its STR is 20 multiplied by the number of the column you rolled (e.g. Sword=80 STR; Gem=20 STR).";
    break;
    case 7:
     Description="Resurrection. The recently deceased are revived by this blessed artefact. After combat, revive a Troop of your choice with full STR.";
    break;
    case 8:
     Description="Inspiring. Units at the same depth as this artefact have +50% of their usual STR.";
    break;
    case 9:
     Description="Purposeful. Choose a room. This artefact counts as a copy of that room, except it does not spawn units at the start of combat.";
    break;
    case 10:
     Description="Creation. Place this artefact in an empty grid space to create 2 grid spaces of fast-growing cave trees (20♥ per turn).";
    break;
    case 11:
     Description="Dealmaker. Pay 100♦ to immediately banish an Ancient Monstrosity, removing it from your hold. The next Ancient Monstrosity gets 4 cards for its traits.";
    break;
    case 12:
     Description="Vengeful. If this artefact is destroyed, 120 STR of allied units arrive at the Entrance to help. They depart after this combat.";
    break;
    case 13:
     Description="Old Soul. The spirit of a legendary hero resides in this artefact, and can project into the grid space the artefact is in. 120 STR. It cannot leave its grid space without the Animated trait.";
    break;
   }
  }
 }
}