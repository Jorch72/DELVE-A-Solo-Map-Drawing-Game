using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Delve{
 internal class NaturalFormation{
  public string Name=string.Empty;
  public string Description=string.Empty;
  public int size=0;
  public Monster? monster=null;
  public Magic? magic=null;
  public Wyrd? wyrd=null;
  public NaturalFormation(int depth,Deck dck){
   size=1;
   switch(dck.DrawCard().Value){
    case 1:
     if(depth<5){
      Name="Underground forest";
     }else{
      Name="Get Wyrd";
      wyrd=new Wyrd(dck,depth);
     }
    break;
    case 2:
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
     Name="Natural magic in cave plants, crystals, or the air itself";
     switch(dck.Roll1D2()){
      case 1:
       magic=new Magic(dck,true,depth);
      break;
      case 2:
       magic=new Magic(dck,false,depth);
      break;
     }
    break;
    case 4:
     Name="An underground river.";
     Description="Draw the river all the way to the closest page edge";
    break;
    case 5:
     Name="Cavern";
     size=dck.Roll1D4();
     Description=size.ToString()+" grid spaces in size";
    break;
    case 6:
     Name="Crystal cavern";
     size=dck.Roll1D2();
     Description=size.ToString()+" grid spaces in size";
    break;
    case 7:
     Name="Magma flow";
     Description="Draw the Magma all the way to the closest page edge";
    break;
    case 8:
     Name="Underground lake";
     size=dck.Roll1D4();
    break;
    case 9:
     size=dck.Roll1D2();
     monster=new Monster(Monster.MonsterType.Hive,size,dck.Roll1D4());
     Name="A hive of "+monster.Name;
    break;
    case 10:
     Name="Volcanic shaft, dormant...for now";
     Description="Draw the shaft all the way to the closest page edge";
    break;
    case 11:
     Name="Cavern";
     monster=new Monster(Monster.MonsterType.SmallCreature,size,dck.Roll1D4());
     Description="housing a small "+monster.Name+".\r\nAttacks the nearest room, then retreats back to its home cavern, ending\r\ncombat unless you wish to follow and attack.";
    break;
    case 12:
     Name="Environment suitable for a large creature";
     size=4;
     monster=new Monster(Monster.MonsterType.LargeCreature,size,dck.Roll1D4());
     Description="housing a "+monster.Name+". 4 grid spaces.\r\nCreature will not leave here unless attacked but will attack anything\r\nentering its lair.";     
    break;
    case 13:
     Name="Burrowing beast";
     monster=new Monster(Monster.MonsterType.BurrowingBeast,2,dck.Roll1D4());
     Description=monster.Name+". Digs a tunnel straight up from this space.\r\nWhen it reaches one of your rooms, combat starts and it moves\r\nnormally towards the Entrance. Can be tamed, does not burrow";
    break;
   }
  }
 }
}