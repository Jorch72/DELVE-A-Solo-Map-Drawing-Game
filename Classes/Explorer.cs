using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 public class Explorer:Unit{
  Room? Current=null;
  public Explorer():base(UnitType.Explorer,new Position(0,1)){   
  }
  public void Enter(Room r){
   if(Current!=null)Current.remove(this);
   Current=r;
   Current.add(this);
  }
  public void Move(Direction d){
   switch(d){
    case Direction.Up:
     MoveUp();
    break;
    case Direction.Down:
     MoveDown();
    break;
    case Direction.Left:
     MoveLeft();
    break;
    case Direction.Right:
     MoveRight();
    break;
   }
  }
  public void MoveRight(){
   Pos.x++;
  }
  public void MoveLeft(){
   Pos.x--;
  }
  public void MoveUp(){
   Pos.y++;
  }
  public void MoveDown(){
   Pos.y--;
  }
  public new string Draw(){
   return "X";
  }
 }
}