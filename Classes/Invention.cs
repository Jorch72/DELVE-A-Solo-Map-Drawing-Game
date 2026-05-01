using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve{
 public enum InventionType{
  None,Monster,MusicalGolems,SecretBrew,Pheromones,CaveRain,Orefinder,BurglarAlarms,WeaponizedMinecarts,MiningSongbirds,Dragonfire,MadScience,
  TrapMaster,EndersGate
 }

 internal class Inventions{
  Position Pos;
  int Level=1;
  int i=0;
  List<Invention> InventionList;
  public Inventions(int level,Position p){
   Pos=p;
   Level=level;
   InventionList=new List<Invention>();
  }
  public void AddInvention(Invention inv){
   InventionList.Add(inv);
  }
  public bool findInvention(InventionType t){
   foreach(Invention inv in InventionList){
    if(inv.Type==t){
     return true;
    }
   }
   return false;
  }
  public Monster? DiscoverInvention(Deck dck){
   Invention inv=new Invention(dck);
   while(findInvention(inv.Type)){
    if(inv.Type==InventionType.Monster){
     return new Monster("A Monster!",200+5*Level,Pos);
    }
    inv=new Invention(dck);
   }
   AddInvention(inv);
   return null;
  }
  public int GetInventionCount(){ 
   return InventionList.Count();
  }
  public InventionType GetFirstInvention(){
   if(InventionList.Count==0)return InventionType.None;
   i=0;
   return InventionList[i].Type;
  }
  public InventionType GetNextInvention(){
   i++;
   if(i>InventionList.Count)return InventionType.None;
   return InventionList[i].Type;
  }
 }
 internal class Invention{
  public InventionType Type=InventionType.None;
  public string Name=string.Empty;
  public string Description=string.Empty;
  public Invention(Deck dck){
   switch(dck.DrawCard().Value){
    case 1:
     Type=InventionType.Monster;
     Name="A Monster!";
     Description="Your inventors have created a monster. A twisted amalgamation of flesh and machine. It seeks to escape. 200 STR. Any time the monster passes through a Forge, it gains 100 STR.";
    break;
    case 2:
     Type=InventionType.MusicalGolems;
     Name="Musical Golems";
     Description="A concert hall centred around these wonderful musical machines will make your hold famous. It attracts monsters similar to the Siren Song, unless the Concert Hall is destroyed. Draw the Concert Hall somewhere in your hold.";
    break;
    case 3:
     Type=InventionType.SecretBrew;
     Name="Secret Brew";
     Description="Using a special blend of mushrooms and cave goat milk, your inventors have made a potent ale that will empower your Adventurers. All Adventurers now have double STR. Draw a Brewery somewhere in your hold.";
    break;
    case 4:
     Type=InventionType.Pheromones;
     Name="Pheromones";
     Description="Monsters are simple things. Using these vials you can calm them or encourage them to breed. Pay 30♦ to use one of these vials on a Large Creature (Q♣). If calmed, you may pass its grid space. You can now build the Breeder room.";
    break;
    case 5:
     Type=InventionType.CaveRain;
     Name="Cave Rain";
     Description="Fire and lava are some of your biggest threats. With these handy devices, you can summon rain indoors to quench fires and cool lava before they become an issue. Cannot be used in Forges. Lava now solidifies in the grid it was discovered in, making it impassable but no longer flows.";
    break;
    case 6:
     Type=InventionType.Orefinder;
     Name="Orefinder";
     Description="By feeding all manner of resources into this temperamental machine, your inventors are able to discern what lies below. When exploring, you may draw a card but choose to not explore that Grid Space. If you do not explore, mark the grid space with the suit and value of the card you drew and explore elsewhere. Can be used once per Turn. All Jokers must be played. Draw this special machine somewhere in your hold.";
    break;
    case 7:
     Type=InventionType.BurglarAlarms;
     Name="Burglar Alarms";
     Description="Thieves no longer instantly steal ½ of your Trade Goods (♦). Whenever a thief event happens, treat it as though you rolled a 4.";
    break;
    case 8:
     Type=InventionType.WeaponizedMinecarts;
     Name="Weaponized Minecarts";
     Description="A little dwarven ingenuity can see your Tracks turned into a trap of their own. Once per combat, you may pay 10♥ and choose a grid space with Tracks on which to place a minecart. It travels instantly along the length of the Tracks (in the direction you choose) until it hits an enemy, dealing 5 STR of damage for each grid space it travelled through before hitting.";
    break;
    case 9:
     Type=InventionType.MiningSongbirds;
     Name="Mining Songbirds";
     Description="Canaries for poison gas, phoenix chicks for flammable gas. Some might see it as cruelty, but it is a necessity in these dangerous spaces. Ignore all gas effects.";
    break;
    case 10:
     Type=InventionType.Dragonfire;
     Name="Dragonfire";
     Description="We have discovered the secret of dragonfire. Gunners and Cannons are upgraded to dragonfire variants. Dragonfire Gunners gain +5 STR, Dragonfire Cannons gain +20 STR. Draw a special 2 grid space Dragonfire Forge somewhere in your hold.";
    break;
    case 11:
     Type=InventionType.MadScience;
     Name="Mad Science";
     Description="One of your inventors has gone mad and disappeared into the hold, screaming something about “destroying us all”. At the start of combat, roll 1D2. On a 1, Traps also affect your own units and Troops this combat. Effect ends when the J♥ is drawn.";
    break;
    case 12:
     Type=InventionType.TrapMaster;
     Name="Trap Master";
     Description="A renowned trap craftsdwarf from the far holds has set up a workshop. Draw this 2 grid space workshop somewhere in your hold. You may now build Traps to level 4.";
    break;
    case 13:
     Type=InventionType.EndersGate;
     Name="Ender’s Gate";
     Description="Your inventors have found a way to see beyond the veil of death, and use this to your advantage. You can flood the hold with vengeful spirits, killing all enemies... and all your units. Draw this mysterious device somewhere in your hold.";
    break;
   }
  }
 } 
}