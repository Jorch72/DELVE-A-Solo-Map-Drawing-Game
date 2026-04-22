using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve {
    [Serializable]
    class Monster : Unit {

        string MonsterVillage(int n) {
            switch (n) {
                case 1:
                    return "Goblins";
                case 2:
                    return "Kobolds";
                case 3:
                    return "Frog People";
                case 4:
                    return "Pixies";
            }
            throw new Exception("Monster Village not Found!: " + n.ToString());
        }

        string LargeCreature(int n) {
            switch (n) {
                case 1:
                    return "Cave Kraken";
                case 2:
                    return "Basilisk";
                case 3:
                    return "Living Shadow";
                case 4:
                    return "Elemental";
            }
            throw new Exception("Large Creature not Found!: " + n.ToString());
        }

        string SmallCreature(int n) {
            switch (n) {
                case 1:
                    return "Feral Dwarf";
                case 2:
                    return "Troll";
                case 3:
                    return "Huge Bat";
                case 4:
                    return "Angry Cave Goat";
            }
            throw new Exception("Small Creature not Found!: " + n.ToString());
        }

        string Hive(int n) {
            switch (n) {
                case 1:
                    return "Black Wasps";
                case 2:
                    return "Giant Ants";
                case 3:
                    return "Clockwork Spiders";
                case 4:
                    return "Snakes";
            }
            throw new Exception("Hive not Found!: " + n.ToString());
        }

        string MonsterCourt(int n) {
            switch (n) {
                case 1:
                    return "Wizard's Study";
                case 2:
                    return "Cthonic Cult";
                case 3:
                    return "Elvish Oubliette";
                case 4:
                    return "Demonic Fortress";
            }
            throw new Exception("Monster Court not Found!: " + n.ToString());
        }

        string BurrowingBeast(int n) {
            switch (n) {
                case 1:
                    return "Sabre-tooth Mole";
                case 2:
                    return "Stone Worm";
                case 3:
                    return "Undead Owl";
                case 4:
                    return "Nesting Lizard";
            }
            throw new Exception("Borrowing Beast not Found!: " + n.ToString());
        }

        string TrappedEvil(int n) {
            switch (n) {
                case 1:
                    return "Burning Orb";
                case 2:
                    return "Chain Bound Soul";
                case 3:
                    return "Skull Topped Staff";
                case 4:
                    return "Arcane Machinery";
            }
            throw new Exception("Monster not Found!");
        }

        public Monster(Card c, int d4) {
            switch (c.Value) {
                case 1:
                    Name = MonsterVillage(d4);
                    break;
                case 2:
                    Name = MonsterVillage(d4);
                    break;
                case 3:
                    Name = SmallCreature(d4);
                    break;
                case 4:
                    Name = SmallCreature(d4);
                    break;
                case 5:
                    Name = Hive(d4);
                    break;
                case 6:
                    Name = Hive(d4);
                    break;
                case 7:
                    Name = BurrowingBeast(d4);
                    break;
                case 8:
                    Name = BurrowingBeast(d4);
                    break;
                case 9:
                    Name = MonsterCourt(d4);
                    break;
                case 10:
                    Name = MonsterCourt(d4);
                    break;
                case 11:
                    Name = LargeCreature(d4);
                    break;
                case 12:
                    Name = LargeCreature(d4);
                    break;
                case 13:
                    Name = TrappedEvil(d4);
                    break;
            }
        }
    }
}
