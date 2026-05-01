using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve{
 public class Explore{
  Deck deck;
  public Explore(){
   deck=new Deck();
  }
  public ExploreResult DoExplore(int level,Position p,int turn){
   ExploreResult res=new ExploreResult();
   Card c=deck.DrawCard();
   res.Log="Turn: "+turn.ToString();
   res.Log="Drew: "+c.Name;
   while(level==1&&c.Suite==Card.Suites.Spades) {
    res.Log="Draw again because of level 1";
    c=deck.DrawCard();
    res.Log="Drew: "+c.Name;
   }
   switch(c.Suite){
     // need to add room efects
    case Card.Suites.Diamonds:
     res.Type=ExploreResult.ExploreResultType.TradeGoods;
     res.TradeGoods=c.Value+level;
     res.Log="Add "+res.TradeGoods.ToString()+" Trade Goods";
    break;
    // need to add room efects
    case Card.Suites.Hearts:
     res.Type=ExploreResult.ExploreResultType.Resources;
     res.Resources=c.Value+level;
     res.Log="Add "+res.Resources.ToString()+" Resources";
    break;
    case Card.Suites.Clubs:
     res.Type=ExploreResult.ExploreResultType.NaturalFormations;
     res.Naturalformation=new NaturalFormation(level,deck,p);
     res.Log="Found natural formation: "+res.Naturalformation.Name;
     if(res.Naturalformation.monster!=null)res.Log+=" ("+res.Naturalformation.monster.Name+" ATK: "+res.Naturalformation.monster.STR+")";
    break;
    case Card.Suites.Spades:
     res.Type=ExploreResult.ExploreResultType.Remnants;
     res.Remnants=new Remnant(level,deck,p);
     res.Log="Found remnant: "+res.Remnants.Name;
     if(res.Remnants.monster!=null)res.Log+=" ("+res.Remnants.monster.Name+" ATK: "+res.Remnants.monster.STR+")";
    break;
   }
   return res;
  }
 }
}