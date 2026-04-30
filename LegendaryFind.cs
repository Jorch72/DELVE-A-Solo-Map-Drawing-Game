using System;
using System.Collections.Generic;
using System.Drawing.Imaging.Effects;
using System.Text;

namespace Delve{
 internal class LegendaryFind{
  string Name=string.Empty;
  string Description=string.Empty;
  string form=string.Empty;
  public LegendaryFind(Deck dck){
   int x=0,y=0;
   string[,] forms = {{"Gem","Fountain","Spirit","Shield"},
                      {"Mushroom","Tool","Skeleton","Axe"},
                      {"Artwork","Invention","Statue","Sword"},
                      {"Instrument","Speleotherm","Tome","Armour"}};
   x=dck.DrawCard().Value-1;
   y=dck.DrawCard().Value-1;
   form=forms[x,y];
   switch(dck.DrawCard().Value) {
    case 1:
     Description="Legendary. Dwarves flock to see and protect this artefact. All units cost\r\n½ the usual ♦ cost.";
    break;
    case 2:
     Description="Blessed. Build a Shrine around this artefact and get double its usual effect.";
    break;
    case 3:
     Description="Lucky. Whenever you roll 1D2, you may re-roll once to try for the\r\nresult you want. Good luck.";
    break;
    case 4:
     Description="Guidance. This artefact gives the hold visions of the depths. When\r\nexploring, draw 2 cards, picking the one you want. Jokers must be\r\nplayed.";
    break;
   }
  }
 }
}