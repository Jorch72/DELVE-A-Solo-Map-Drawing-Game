using Delve;

namespace Delve{
 public partial class frmMain:Form{
  Game? game=null;
  public frmMain(){
   InitializeComponent();
  }
  void UpdateUI(){
   if(game==null)return;
   lblRes.Text=game.Resources.ToString();
   lblTrade.Text=game.TradeGoods.ToString();
   txtMap.Text=game.map.Draw();
  }
  private void btnStart_Click(object sender,EventArgs e){
   game=new Game();
   UpdateUI();
   btnBuild.Enabled=true;
   btnHire.Enabled=true;
   btnLeft.Enabled=true;
   btnRight.Enabled=true;
  }
  private void btnLeft_Click(object sender,EventArgs e){
   txtLog.Text+=game.DoExplore(Direction.Left);
   UpdateUI();
   //if()
  }
  private void btnRight_Click(object sender,EventArgs e){
   txtLog.Text+=game.DoExplore(Direction.Right);
   UpdateUI();
  }
  private void btnBuild_Click(object sender,EventArgs e){
   frmBuild? buildForm=new frmBuild(game);
   buildForm.ShowDialog();
   buildForm=null;
  }
  private void btnHire_Click(object sender,EventArgs e){
   frmHire? hireForm=new frmHire(game);
   hireForm.ShowDialog();
   hireForm=null;
  }
  private void frmMain_Load(object sender,EventArgs e){
  }
 }
}