using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using static Delve.Monster;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Delve{
 public class Remnant:Room{
  public int Size=1;
  public Monster? monster=null;
  public Remnant(int level,Deck dck,Position p):base(RoomType.None,p){
   switch(dck.DrawCard().Value){
    case 1:
     Size=dck.Roll1D4();
     Type=RoomType.MonsterLair;
     monster=new Monster(Monster.MonsterType.MonsterVillage,Size,level,dck.Roll1D4(),p);
     Name="Monster village of "+monster.Name;
     Description="If monsters enter a room with no units in it, lose 10♦ as they break and steal what they can.";
    break;
    case 2:
     Type=RoomType.ForgottenCrypts;
     Name="Forgotten Crypts";
     monster=new Monster("Undead",20,p);
     Description="Houses 20 Skull Dwarves. Once cleared, you may summon Skull Dwarves (1 STR) here for 5♦.";
    break;
    case 3:
     Type=RoomType.WishingWell;
     Name="Wishing Well";
     Description="Once per turn, you may pay 10♦ to roll 1D2 and draw a card: On 1, Good Magic. On 2, Bad Magic.";
    break; 
    case 4:
     Type=RoomType.SealedRoom;
     Status=RoomStatus.Closed;
     monster=new Monster(MonsterType.TrappedEvil,Size,level,dck.Roll1D4(),p);
     Name="A sealed room with an evil "+monster.Name+" inside.";
     Description="If this room is opened, draw a card. Consult Bad Magic to determine what you find.";
     monster=null;
    break;
    case 5:
     Type=RoomType.AbandonedMine;
     Name="Abandoned Mine";
     Size=dck.Roll1D2();
     Description="Others have left behind their haul. More for us! Gain 20♦, plus 2♦xLevel.";
    break;
    case 6:
     Type=RoomType.BuriedTemple;
     Name="Buried Temple";
     Description="Recruit a cleric here to Roll 1D4. On 1–3, consult Bad Magic. On 4, consult Good Magic. Usable once.";
    break;
    case 7:
     Type=RoomType.AbandonedRoom;   
     Name="Abandoned Room";
     Description="Looks like you weren’t the first... choose a room and place it here.";
    break;
    case 8:
     Type=RoomType.AncientLibrary;
     Size=dck.Roll1D2();
     Name="Ancient Library";
     Description="For the knowledge contained herein, roll 1D2. On 1, consult Good Magic. On 2, consult Bad Magic.";
    break;
    case 9:
     Name="Demon Portal";
     Type=RoomType.DemonPortal;
     Description="Roll 1D4 at the end of each turn. On 1, spawn Demons with 20 STR. To destroy the portal, pay 20♦ and sacrifice one of your Clerics.";
    break;
    case 10:
     Name="Golem Forge";
     Status=RoomStatus.unClaimed;
     Type=RoomType.GolemForge;
     Description="40 STR of Golems, who won’t attack unless you try to claim the room. If the Golems are defeated, this room allows you to recruit Golems at Forges.";
     monster=new Monster("Golem",40+5*level,p);
    break;
    case 11:
     Name="Long Lost Artefact";
     Type=RoomType.LongLostArtefact;
     Description="Ancient magical weapon or armour. Choose a unit room to house this artefact, it adds +15 STR to any Troop housed there.";
    break;
    case 12:
     Name="Slumbering Wyrm";
     Type=RoomType.SlumberingWyrm;
     Description="An ancient dragon sleeps upon its hoard. Once per turn, you may steal 20♦, and roll 1D4. On 1, the Wyrm awakens, destroying the hoard. The Wyrm has 100 STR and Ranged, and rooms it attacks through are damaged.";
     monster=new Monster("Slumbering Wyrm",100+level*5,p);
    break; 
    case 13:
     string[] enemy={"Lich King","Vampire Queen’s Coterie","Skeletal Court"};
     int i=dck._rand.Next()%3;
     Size=2+dck.Roll1D4();
     monster=new Monster(Monster.MonsterType.MonsterCourt,Size,level,dck.Roll1D4(),p);
     Name="The desolate halls of a "+monster.Name;
     monster.Name=enemy[i];
     Type=RoomType.MonsterLair;
    break;
   }
  }
 }
}