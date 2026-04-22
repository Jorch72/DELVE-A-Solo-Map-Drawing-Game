using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve {
    class Magic {
        public string Name;
        public string Description;

        private void GoodMagic(int n) {
            switch (n) {
                case 1:
                    Name = "Passage to the Deep";
                    Description = "";
                    break;
                case 2:
                    Name = "Protective Wards";
                    Description = "";
                    break;
                case 3:
                    Name = "Living Metal";
                    Description = "";
                    break;
                case 4:
                    Name = "Clone";
                    Description = "";
                    break;
                case 5:
                    Name = "Pawrtl";
                    Description = "";
                    break;
                case 6:
                    Name = "Fleet Forest";
                    Description = "";
                    break;
                case 7:
                    Name = "Blessing";
                    Description = "";
                    break;
                case 8:
                    Name = "Siren Song";
                    Description = "";
                    break;
                case 9:
                    Name = "Nurse's Sigil";
                    Description = "";
                    break;
                case 10:
                    Name = "Gills";
                    Description = "";
                    break;
                case 11:
                    Name = "Valkyria";
                    Description = "";
                    break;
                case 12:
                    Name = "Hudrak's Chains";
                    Description = "";
                    break;
                case 13:
                    Name = "Charming Colours";
                    Description = "";
                    break;
            }
        }

        private void BadMagic(int n) {
            switch (n) {
                case 1:
                    Name = "The Greedy King's Touch";
                    Description = "";
                    break;
                case 2:
                    Name = "Grozin's Garish Gaze";
                    Description = "";
                    break;
                case 3:
                    Name = "Diamond Dust";
                    Description = "";
                    break;
                case 4:
                    Name = "Contagious Cowardice";
                    Description = "";
                    break;
                case 5:
                    Name = "Mortek's Magma Drill";
                    Description = "";
                    break;
                case 6:
                    Name = "Circus of Chaos";
                    Description = "";
                    break;
                case 7:
                    Name = "Worm";
                    Description = "";
                    break;
                case 8:
                    Name = "Swampify!";
                    Description = "";
                    break;
                case 9:
                    Name = "Mimic";
                    Description = "";
                    break;
                case 10:
                    Name = "Doomed";
                    Description = "";
                    break;
                case 11:
                    Name = "Possession";
                    Description = "";
                    break;
                case 12:
                    Name = "Outbreak";
                    Description = "";
                    break;
                case 13:
                    Name = "Monstrous Form";
                    Description = "";
                    break;
            }
        }

        public Magic(Card c, bool GoodMagic) {
            switch (GoodMagic) {
                case true:
                    this.GoodMagic(c.Value);
                    break;
                default:
                    BadMagic(c.Value);
                    break;
            }
        }
    }
}
