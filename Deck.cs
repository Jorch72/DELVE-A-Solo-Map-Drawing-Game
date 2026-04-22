using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve {
    public class Deck {
        public List<Card> Cards = null;
        private readonly Random _rand = null;

        public Deck() {
            _rand = new Random();
            FillDeck();
            Shuffle();
        }

        public void FillDeck() {
            FillDeck(false);
        }

        public void FillDeck(bool addJokers) {
            //Can use a single loop utilising the mod operator % and Math.Floor
            //Using divition based on 13 cards in a suited
            Cards = new List<Card>();
            for (int i = 0; i < 52; i++) {
                Card.Suites suite = (Card.Suites)(Math.Floor((decimal)i / 13));
                //Add 2 to value as a cards start a 2
                int val = i % 13 + 1;
                Cards.Add(new Card(val, suite));
            }
            if (addJokers) {
                Cards.Add(new Card(14, Card.Suites.Black));
                Cards.Add(new Card(14, Card.Suites.Red));
            }
        }

        public void Shuffle() {
            List<Card> Crd = new List<Card>();
            Card c = null;
            while (Cards.Count > 0) {
                c = Cards[_rand.Next() % Cards.Count];
                Cards.Remove(c);
                Crd.Add(c);
            }
            Cards = null;
            Cards = Crd;
        }

        public string Draw() {
            Card c = null;
            c = Cards[_rand.Next() % Cards.Count];
            // Cards.Remove(c);
            return c.Name;
        }

        public Card DrawCard() {
            return Cards[_rand.Next() % Cards.Count];
        }

        public string PrintDeck() {
            int i = 1;
            StringBuilder sb = new StringBuilder();
            foreach (Card card in this.Cards) {
                sb.Append(i.ToString() + ": " + card.Name + "\r\n");
                i++;
            }
            return sb.ToString();
        }

        public int Roll1D4() {
            Card c = DrawCard();
            int n = (int)c.Suite + 1;
            return n;
        }

        public int Roll1D2() {
            Card c = DrawCard();
            switch (c.Suite) {
                case Card.Suites.Clubs:
                    return 1;
                case Card.Suites.Spades:
                    return 1;
                case Card.Suites.Black:
                    return 1;
                case Card.Suites.Hearts:
                    return 2;
                case Card.Suites.Diamonds:
                    return 2;
                case Card.Suites.Red:
                    return 2;
            }
            throw new Exception("Suite not Found!");
        }
    }
}
