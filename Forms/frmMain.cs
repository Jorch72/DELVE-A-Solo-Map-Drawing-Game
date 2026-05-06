using Delve;
using DelveCS.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Delve{
    public partial class frmMain:Form {
        Form? frmParent = null;
        Game? game = null;
        public bool useWorldLayers = false;
        public bool useBloodrunes = false;
        public bool useFeastandFamine = false;
        public bool useHonor = false;
        public bool useBiomes = false;
        enum Buttons {
           None,Explore,Trade,Build,Hire,Movement
        }
        public frmMain() {
            InitializeComponent();
        }
        void UpdateUI(){
         if(game==null)return;
         lblRes.Text=game.Resources.ToString();
         lblTrade.Text=game.TradeGoods.ToString();
         lblTurn.Text=game.Turn.ToString();
         txtMap.Text=game.map.Draw();
        }
        private void btnStart_Click(object sender,EventArgs e) {
            txtLog.Text=string.Empty;
            txtMap.Text=string.Empty;
            chkLstTurnOverview.SetItemChecked(0,false);
            chkLstTurnOverview.SetItemChecked(1,false);
            chkLstTurnOverview.SetItemChecked(2,false);
            chkLstTurnOverview.SetItemChecked(3,false);
            chkLstTurnOverview.SetItemChecked(4,false);
            chkLstTurnOverview.SetItemChecked(5,false);
            btnStart.Text="Restart Game";
            DisableButtons(Buttons.None);
            game=new Game();
            UpdateUI();         
            chkLstTurnOverview.SelectedIndex=0;
            NextPhase();
            btnNext.Enabled=true;
        }
        private void btnLeft_Click(object sender,EventArgs e){
            txtLog.Text+=game.DoExplore(Direction.Left);
            UpdateUI();
            NextPhase();
        }
        private void btnRight_Click(object sender,EventArgs e) {
            txtLog.Text+=game.DoExplore(Direction.Right);            
            UpdateUI();
            NextPhase();
        }
        private void btnBuild_Click(object sender,EventArgs e) {
         frmBuild? buildForm=new frmBuild(game);
         buildForm.ShowDialog();
         if(buildForm.RoomType!=DelveRoom.RoomType.None){
          txtLog.Text+=game.BuyRoom(buildForm.RoomType);
          UpdateUI();
         }
         buildForm=null;
         chkLstTurnOverview.SelectedIndex++;
         NextPhase();
        }
        private void btnHire_Click(object sender,EventArgs e) {
            frmHire? hireForm = new frmHire(game);
            chkLstTurnOverview.SetItemChecked(4,true);
            hireForm.ShowDialog();
            hireForm=null;
            NextPhase();
        }
        private void frmMain_Load(object sender,EventArgs e) {
            chkLstTurnOverview.Items.Add("START OF TURN");
            chkLstTurnOverview.Items.Add("EXPLORING");
            chkLstTurnOverview.Items.Add("TRADING");
            chkLstTurnOverview.Items.Add("BUILDING");
            chkLstTurnOverview.Items.Add("RECRUITING");
            chkLstTurnOverview.Items.Add("END OF TURN");
        }
        private void DisableButtons(Buttons except) {
            btnLeft.Enabled=false;
            btnRight.Enabled=false;
            btnTrade.Enabled=false;
            btnBuild.Enabled=false;
            btnHire.Enabled=false;
            switch(except) {
             case Buttons.Trade: btnTrade.Enabled=true; break;
             case Buttons.Build: btnBuild.Enabled=true; break;
             case Buttons.Hire: btnHire.Enabled=true; break;
             case Buttons.Movement: btnLeft.Enabled=true; btnRight.Enabled=true; break;
            }
        }
        private void NextPhase(){            
            switch(chkLstTurnOverview.SelectedIndex){
            case 0:
             chkLstTurnOverview.SetItemChecked(0,true);
             //Draw a card for each Crystal Caverns in your hold.
             //Pay the Orefinder or Knowledgeable Creature
             game.StartofTurn();
             UpdateUI();
             Application.DoEvents();
             Thread.Sleep(500);
             chkLstTurnOverview.SelectedIndex++;
             NextPhase();             
            break;
            case 1:
             chkLstTurnOverview.SetItemChecked(1,true);
             DisableButtons(Buttons.Movement);
             //Exploring is handled by the Explore buttons
            break;
            case 2:
             //Make a single trade.
             //One unit of Trade Goods (♦) is worth two units of Resources (♥).
             //OR
             //One unit of Resources (♥) is worth half a unit of Trade Goods(♦).
             chkLstTurnOverview.SetItemChecked(2,true);
             DisableButtons(Buttons.Trade);
             //Trading is handled by the Trade button
            break;
            case 3:
            chkLstTurnOverview.SetItemChecked(3,true);
            DisableButtons(Buttons.Build);
            //Building is handled by the Build button
            break;
            case 4:
            chkLstTurnOverview.SetItemChecked(4,true);
            DisableButtons(Buttons.Hire);
            //Recruiting is handled by the Hire button
            break;
            case 5:
            //Do end of turn stuff here
            //Check for any events such as:
            //Demon Portal (Remnants – 9),
            //Circus of Chaos (Bad Magic – 6),
            //God Mushroom (Wyrd – 6),
            //Realm of Lost Things (Wyrd – K),
            //Pawrtal (Good Magic – 5)
             chkLstTurnOverview.SetItemChecked(5,true);
             Application.DoEvents();
             Thread.Sleep(1000);
             game.EndTurn();
             chkLstTurnOverview.SetItemChecked(0,false);
             chkLstTurnOverview.SetItemChecked(1,false);
             chkLstTurnOverview.SetItemChecked(2,false);
             chkLstTurnOverview.SetItemChecked(3,false);
             chkLstTurnOverview.SetItemChecked(4,false);
             chkLstTurnOverview.SetItemChecked(5,false);
             chkLstTurnOverview.SelectedIndex=0;
             UpdateUI();
             Application.DoEvents();
             NextPhase();             
            break;
            }
        }
        private void frmMain_FormClosed(object sender,FormClosedEventArgs e) {
            if(frmParent!=null) frmParent.Close();
            Application.Exit();
        }
        private void challengesToolStripMenuItem_Click(object sender,EventArgs e) {
            frmChallenges? frmChall = new frmChallenges();
            frmChall.ShowDialog();
            frmChall.Close();
            frmChall=null;
        }
        private void btnNext_Click(object sender,EventArgs e) {
            chkLstTurnOverview.SelectedIndex++;
            NextPhase();        }
        private void btnTrade_Click(object sender,EventArgs e) {
             chkLstTurnOverview.SetItemChecked(2,true);
            NextPhase();
        }
    }
}