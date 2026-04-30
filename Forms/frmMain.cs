using Delve;

namespace Delve{
 public partial class frmMain:Form{
  Game? game=null;
  public frmMain(){
   InitializeComponent();
  }
  void UpdateUI(){
   if(game==null) return;
   lblRes.Text=game.Resources.ToString();
   lblTrade.Text=game.TradeGoods.ToString();
   txtMap.Text=game.map.Draw();
  }
  private void btnStart_Click(object sender,EventArgs e){
   game=new Game();
   UpdateUI();
  }
  private void btnLeft_Click(object sender,EventArgs e){
   txtLog.Text+=game.DoExplore(Dir.Left);
   UpdateUI();
  }
  private void btnRight_Click(object sender,EventArgs e){
   txtLog.Text+=game.DoExplore(Dir.Right);
   UpdateUI();
  }
 }
}