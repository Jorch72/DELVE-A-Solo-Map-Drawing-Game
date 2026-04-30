using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 [Serializable]
 public class Unit{
  public string Name=string.Empty;
  public int STR=0;
  public int Quantity=0;
  public int TotSTR{
   get {return STR*Quantity;} 
  }
  public Unit(){
  }
  public Unit(string name,int strength,int quantity){ 
   Name=name;
   STR=strength;
   Quantity=quantity;
  }
  public string Draw(){
   return new string('☺',Quantity);
  }
 }
}