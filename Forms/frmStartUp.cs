using Delve;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DelveCS.Forms{
    public partial class frmStartUp:Form{
        public frmStartUp(){
         InitializeComponent();
        }
        private void frmStartUp_Load(object sender,EventArgs e){
            bool foundsaved=false;
            string st=Application.StartupPath+"Save";
            if(!System.IO.Directory.Exists(st)) System.IO.Directory.CreateDirectory(st);
            foreach(string fil in System.IO.Directory.GetFiles(st,"*.sav")){
                foundsaved=true;
                st=fil.Substring(fil.LastIndexOf("\\")+1);
                lstGames.Items.Add(st);
            }
            if(!foundsaved){
                gbSavedGames.Visible=false;
                lblNoSaveGame.Text="No saved games found.\r\nChoose options and start a new Game.";
                lblNoSaveGame.Visible=true;
                lblNoSaveGame.Location=new Point(gbSavedGames.Left,gbSavedGames.Top);
            }
            chkLstOptions.Items.Add("World Layers");
            chkLstOptions.Items.Add("Bloodrunes");
            chkLstOptions.Items.Add("Feast and Famine");
            chkLstOptions.Items.Add("Honor");
            chkLstOptions.Items.Add("Biomes");
        }

        private void btnNew_Click(object sender,EventArgs e){
            frmMain fMain=new frmMain();
            if(chkLstOptions.CheckedItems.Contains("World Layers"))fMain.useWorldLayers=true;
            if(chkLstOptions.CheckedItems.Contains("Bloodrunes"))fMain.useBloodrunes=true;
            fMain.Show();
            this.Hide();
        }

        private void gbSavedGames_Enter(object sender,EventArgs e) {
         //Load saved game
        }
    }
}