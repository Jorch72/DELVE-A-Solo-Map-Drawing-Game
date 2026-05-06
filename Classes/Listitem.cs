using System;
using System.Collections.Generic;
using System.Text;

namespace DelveCS.Classes{
 internal class Listitem{
  private string _name;
  private string _description;
  public string name { get{return _name; } set{_name = value; } }
  public string description { get{return _description; } set{_description = value; } }
  public Listitem(){_name=string.Empty;_description=string.Empty;}
  public Listitem(string name, string description) {
   _name=name;
   _description=description;
  }
  public override string ToString(){
   return $"{name}";
  }
 }
}