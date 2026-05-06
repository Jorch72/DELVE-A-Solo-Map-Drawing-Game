using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Delve{
    //Todo:
    //Add Other Rooms if available: Umbra,Rise,Honor,Biomes,Feast and Famine
    public partial class frmBuild:Form{
        Game? game=null;
        public DelveRoom.RoomType RoomType=DelveRoom.RoomType.None;
        public frmBuild(Game game){
            RadioButton? rad=null;
            Label? lab=null;
            this.game=game;
            int y=5;
            InitializeComponent();
            lblResources.Text=game.Resources.ToString();
            lblTGoods.Text=game.TradeGoods.ToString();
            lab=new Label();
            lab.TextAlign=ContentAlignment.MiddleRight;
            lab.Text="Trade Goods";
            lab.AutoSize=true;
            lab.BorderStyle=BorderStyle.FixedSingle;
            lab.Location=new Point(210,y);
            Controls.Add(lab);
            lab=new Label();
            lab.TextAlign=ContentAlignment.MiddleRight;
            lab.Text="Resources";
            lab.AutoSize=true;
            lab.BorderStyle=BorderStyle.FixedSingle;
            lab.Location=new Point(330,y);
            y=30;
            Controls.Add(lab);
           
            DelveRoom.Catalogue.ForEach(u =>{
                if(u.Type>DelveRoom.RoomType.Entrance&&u.Type<DelveRoom.RoomType.UndergroundForest){
                    rad=new RadioButton();
                    rad.AutoSize=true;
                    rad.Text=u.Name;
                    rad.Location=new Point(30,y);
                    rad.Tag=u.Description;
                    rad.CheckedChanged+=rad_CheckedChanged;
                    if(u.Resources<0) rad.Enabled=false;
                    Controls.Add(rad);
                    lab=new Label();
                    lab.TextAlign=ContentAlignment.MiddleRight;
                    lab.Text=u.TradeGoods.ToString();
                    lab.Width=45;
                    lab.BorderStyle=BorderStyle.FixedSingle;
                    lab.Location=new Point(260,y);
                    Controls.Add(lab);
                    lab=new Label();
                    lab.TextAlign=ContentAlignment.MiddleRight;
                    lab.Text=u.Resources.ToString();
                    lab.Width=45;
                    lab.BorderStyle=BorderStyle.FixedSingle;
                    lab.Location=new Point(360,y);
                    Controls.Add(lab);
                    y+=25;
                }
            });
        }
        private void btnCancel_Click(object sender,EventArgs e){
         RoomType=DelveRoom.RoomType.None;
         this.Close();
        }
        private void rad_CheckedChanged(object sender,EventArgs e) {
         txtDescription.Text=(string)((RadioButton)sender).Tag;
        }
        private void frmBuild_Load(object sender,EventArgs e) {
        }
        private void btnBuild_Click(object sender,EventArgs e){
         string err=string.Empty;
         foreach(Control c in Controls){
          if(c is RadioButton){
           if(((RadioButton)c).Checked){
            RoomType=DelveRoom.Catalogue.Find(r=>r.Name==((RadioButton)c).Text).Type;
            err=game.CanBuyRoom(RoomType);
            if(err.Length>0){
             MessageBox.Show(err);
             RoomType=DelveRoom.RoomType.None;
             return;
            }else{
             this.Close();
             return;
            }            
           }
          }
         }
        }
    }
}