using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//Todo:
//-Get possible units from the game (are available and have map has buildings) and disable those that can't be hired.
//-Add + button to be able to hire multiple units at once
namespace Delve{
 public partial class frmHire:Form{
  public frmHire(Game game){
   RadioButton? rad=null;
   Label? lab=null;
   int y=5;
   InitializeComponent();
   lblResources.Text=game.Resources.ToString();
   lblTGoods.Text=game.TradeGoods.ToString();
   lab=new Label();
   lab.TextAlign=ContentAlignment.MiddleRight;
   lab.Text="Strength";
   lab.AutoSize=true;
   lab.BorderStyle=BorderStyle.FixedSingle;
   lab.Location=new Point(210,y);
   Controls.Add(lab);
   lab=new Label();
   lab.TextAlign=ContentAlignment.MiddleRight;
   lab.Text="Cost";
   lab.AutoSize=true;
   lab.BorderStyle=BorderStyle.FixedSingle;
   lab.Location=new Point(330,y);
   y=30;
   Controls.Add(lab);
   Unit.Catalogue.ForEach(u=>{
    rad=new RadioButton();
    rad.AutoSize=true;
    rad.Text=u.Name;
    rad.Location=new Point(30,y);
    rad.Tag=u.Power;
    rad.CheckedChanged+=rad_CheckedChanged;
    if(u.Cost<0)rad.Enabled=false;
    Controls.Add(rad);
    lab=new Label();
    lab.TextAlign=ContentAlignment.MiddleRight;
    lab.Text=u.Cost.ToString();
    lab.Width=45;
    lab.BorderStyle=BorderStyle.FixedSingle;
    lab.Location=new Point(230,y);
    Controls.Add(lab);
    lab=new Label();
    lab.TextAlign=ContentAlignment.MiddleRight;
    lab.Text=u.STR.ToString();
    lab.Width=45;
    lab.BorderStyle=BorderStyle.FixedSingle;
    lab.Location=new Point(330,y);
    Controls.Add(lab);
    y+=25;
   });
  }
  private void btnCancel_Click(object sender,EventArgs e){
   this.Close();
  }
  private void rad_CheckedChanged(object sender,EventArgs e){
   txtDescription.Text=(string)((RadioButton)sender).Tag;
  }
  private void frmHire_Load(object sender,EventArgs e){
  }
 }
}