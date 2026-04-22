using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve {
    [Serializable]
    class AncientMonstrosities : Unit {
        public string Description;
        private string[] name1 = { "Orbos", "Acras", "Sange", "Enrom", "Kos", "Manegokk", "Donir", "Samri", "Ild", "Skyde", "Lokrum", "Partus", "Metus" };
        private string[] name2 = { "Groundshaking Beast", "Glutton", "Prince", "Sultan", "Brothers", "Assassin", "Dancer", "Prophet", "Warrior", "Deliverer", "Br" };
        private string[] name3 = { "Stone", "Undying", "Gore", "War", "Bonded", "Night", "Quiet", "Doom", "Untouchable", "Spikes", "Lies", "Horde", "Patience" };

        public AncientMonstrosities(Card c1, Card c2, Card c3, int lvl) {
            STR = 100;
            List<int> lst = new List<int>();
            Name = name1[c1.Value] + " " + name2[c2.Value] + " " + name3[c3.Value];
            STR += lvl * 5;
            lst.Add(c1.Value);
            if (!lst.Contains(c2.Value)) lst.Add(c2.Value);
            else STR += 50;
            if (!lst.Contains(c3.Value)) lst.Add(c3.Value);
            else STR += 50;
            foreach (int v in lst) {
                Description += getTrait(v) + "\r\n";
            }
        }

        private string getTrait(int n) {
            switch (n) {
                case 1:
                    return "Burrowing";
                case 2:
                    return "Regenerating";
                case 3:
                    return "Black-blooded";
                case 4:
                    STR += 100;
                    return "Hulking";
                case 5:
                    return "Twinned";
                case 6:
                    return "Dark";
                case 7:
                    return "Nimble";
                case 8:
                    return "Omen";
                case 9:
                    return "Burning Armour";
                case 10:
                    return "Spines";
                case 11:
                    return "Hypnosis";
                case 12:
                    return "Brood Mother";
                case 13:
                    return "Mastermind";
                default:
                    return "";
            }
        }
    }
}
