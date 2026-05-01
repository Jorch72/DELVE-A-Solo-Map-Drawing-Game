using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Delve{
 public class NaturalFormation:Room{
  public int size=0;
  public Monster? monster=null;
  public Magic? magic=null;
  public Wyrd? wyrd=null;
  public NaturalFormation(int level,Deck dck,Position p):base(RoomType.None,p){
   size=1;
   switch(dck.DrawCard().Value){
    case 1:
     if(level<5){
      Name="Underground Forest";
      Type=RoomType.UndergroundForest;
       Description="Cut down for a free room, or keep for 2♥ per turn.";
     }else{      
      wyrd=new Wyrd(dck,level,p);
      Type=wyrd.Type;
      Name=wyrd.Name;
     }
    break;
    case 2:
     Type=RoomType.GasFilledChamber;
     Name="Gas-filled chamber";
     switch(dck.Roll1D4()){
      case 1:
       Description="Poison Gas";
      break;
      case 2:
       Description="Flammable Gas";
       break;
      case 3:
      case 4:
       Description="Blinding Gas";
      break;
     }          
    break;
    case 3:
     Type=RoomType.MagicCave;
     Name="Natural magic in cave plants, crystals, or the air itself";
     switch(dck.Roll1D2()){
      case 1:
       magic=new Magic(dck,level);
      break;
      case 2:
       magic=new Magic(dck,level,p);
      break;
     }
    break;
    case 4:
     Type=RoomType.UndergroundRiver;
     Name="An underground river.";
     Description="Draw the river all the way to the closest page edge";
    break;
    case 5:
     Type=RoomType.Empty;
     Name="Cavern";
     size=dck.Roll1D4();
     Description=size.ToString()+" grid spaces in size";
    break;
    case 6:
     Type=RoomType.CrystalCavern;
     Name="Crystal Cavern";
     size=dck.Roll1D2();
     Description=size.ToString()+" grid spaces in size";
    break;
    case 7:
     Type=RoomType.MagmaFlow;
     Name="Magma flow";
     Description="Draw the Magma all the way to the closest page edge";
    break;
    case 8:
     Type=RoomType.UndergroundLake;
     Name="Underground Lake";
     size=dck.Roll1D4();
    break;
    case 9:
     Type=RoomType.MonsterLair;
     size=dck.Roll1D2();
     monster=new Monster(Monster.MonsterType.Hive,size,level,dck.Roll1D4(),p);
     Name="A hive of "+monster.Name;
    break;
    case 10:
     Type=RoomType.VolcanicShaft;
     Name="Volcanic Shaft, dormant...for now";
     Description="Draw the shaft all the way to the closest page edge";
    break;
    case 11:
     Name="Cavern";
     Type=RoomType.MonsterLair;
     monster=new Monster(Monster.MonsterType.SmallCreature,size,level,dck.Roll1D4(),p);
     Description="housing a small "+monster.Name+". Attacks the nearest room, then retreats back to its home cavern, ending combat unless you wish to follow and attack.";
    break;
    case 12:
     Type=RoomType.MonsterLair;
     Name="Environment suitable for a large creature";
     size=4;
     monster=new Monster(Monster.MonsterType.LargeCreature,size,level,dck.Roll1D4(),p);
     Description="housing a "+monster.Name+". 4 grid spaces. Creature will not leave here unless attacked but will attack anything entering its lair.";     
    break;
    case 13:
     Type=RoomType.MonsterLair;
     Name="Burrowing beast";
     monster=new Monster(Monster.MonsterType.BurrowingBeast,size,level,dck.Roll1D4(),p);
     Description=monster.Name+". Digs a tunnel straight up from this space. When it reaches one of your rooms, combat starts and it moves normally towards the Entrance. Can be tamed, does not burrow";
    break;
   }
  }
 }
}