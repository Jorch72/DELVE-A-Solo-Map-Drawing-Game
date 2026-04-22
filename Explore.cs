using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve {
    class Explore {
        Deck deck = null;

        public Explore() {
            deck = new Deck();
        }

        public ExploreResult DoExplore(int level) {
            ExploreResult res = new ExploreResult();
            Card c = deck.DrawCard();
            res.Log = "Drew: " + c.Name;
            while (level == 1 && c.Suite == Card.Suites.Spades) {
                res.Log = "Draw again because of level 1";
                c = deck.DrawCard();
                res.Log = "Drew: " + c.Name;
            }
            switch (c.Suite) {
                case Card.Suites.Diamonds:
                    res.Type = ExploreResult.ExploreResultType.TradeGoods;
                    res.TradeGoods = c.Value + level;
                    res.Log = "Add " + res.TradeGoods.ToString() + " Trade Goods";
                    break;
                case Card.Suites.Hearts:
                    res.Type = ExploreResult.ExploreResultType.Resources;
                    res.Resources = c.Value + level;
                    res.Log = "Add " + res.Resources.ToString() + " Resources";
                    break;
                case Card.Suites.Clubs:
                    res.Type = ExploreResult.ExploreResultType.NaturalFormations;
                    res.Naturalformation = new NaturalFormation(c, level, deck.Roll1D4(), deck.Roll1D2());
                    res.Log = "Found natural formation: " + res.Naturalformation.Name;
                    if (res.Naturalformation.monster != null) res.Log += " (" + res.Naturalformation.monster.Name + " ATK: " + res.Naturalformation.monster.STR + ")";
                    break;
                case Card.Suites.Spades:
                    res.Type = ExploreResult.ExploreResultType.Remnants;
                    res.Remnants = new Remnant(c, level, deck.Roll1D4(), deck.Roll1D2());
                    res.Log = "Found remnant: " + res.Remnants.Name;
                    break;
                case Card.Suites.Red:

                    break;
                case Card.Suites.Black:

                    break;
            }
            return res;
        }
    }
}
