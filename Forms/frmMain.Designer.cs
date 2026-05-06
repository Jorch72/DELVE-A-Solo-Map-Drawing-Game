namespace Delve{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btnStart=new Button();
            txtMap=new TextBox();
            lblResources=new Label();
            lblTradeGoods=new Label();
            lblRes=new Label();
            lblTrade=new Label();
            btnLeft=new Button();
            btnRight=new Button();
            txtLog=new TextBox();
            btnBuild=new Button();
            btnHire=new Button();
            chkLstTurnOverview=new CheckedListBox();
            menuStrip1=new MenuStrip();
            fileToolStripMenuItem=new ToolStripMenuItem();
            saveToolStripMenuItem=new ToolStripMenuItem();
            loadToolStripMenuItem=new ToolStripMenuItem();
            challengesToolStripMenuItem=new ToolStripMenuItem();
            btnNext=new Button();
            btnTrade=new Button();
            lblTurn=new Label();
            lblTurnNum=new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location=new Point(12,52);
            btnStart.Name="btnStart";
            btnStart.Size=new Size(112,34);
            btnStart.TabIndex=0;
            btnStart.Text="&Start";
            btnStart.UseVisualStyleBackColor=true;
            btnStart.Click+=btnStart_Click;
            // 
            // txtMap
            // 
            txtMap.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left;
            txtMap.Font=new Font("Lucida Console",9F,FontStyle.Regular,GraphicsUnit.Point,0);
            txtMap.Location=new Point(190,187);
            txtMap.Multiline=true;
            txtMap.Name="txtMap";
            txtMap.ScrollBars=ScrollBars.Both;
            txtMap.Size=new Size(529,494);
            txtMap.TabIndex=1;
            txtMap.WordWrap=false;
            // 
            // lblResources
            // 
            lblResources.AutoSize=true;
            lblResources.Location=new Point(586,113);
            lblResources.Name="lblResources";
            lblResources.Size=new Size(95,25);
            lblResources.TabIndex=2;
            lblResources.Text="Resources:";
            // 
            // lblTradeGoods
            // 
            lblTradeGoods.AutoSize=true;
            lblTradeGoods.Location=new Point(586,147);
            lblTradeGoods.Name="lblTradeGoods";
            lblTradeGoods.Size=new Size(116,25);
            lblTradeGoods.TabIndex=3;
            lblTradeGoods.Text="Trade Goods:";
            // 
            // lblRes
            // 
            lblRes.AutoSize=true;
            lblRes.Location=new Point(708,113);
            lblRes.Name="lblRes";
            lblRes.Size=new Size(0,25);
            lblRes.TabIndex=4;
            // 
            // lblTrade
            // 
            lblTrade.AutoSize=true;
            lblTrade.Location=new Point(708,147);
            lblTrade.Name="lblTrade";
            lblTrade.Size=new Size(0,25);
            lblTrade.TabIndex=5;
            // 
            // btnLeft
            // 
            btnLeft.Enabled=false;
            btnLeft.Location=new Point(112,104);
            btnLeft.Name="btnLeft";
            btnLeft.Size=new Size(155,34);
            btnLeft.TabIndex=6;
            btnLeft.Text="<< Explore &Left";
            btnLeft.UseVisualStyleBackColor=true;
            btnLeft.Click+=btnLeft_Click;
            // 
            // btnRight
            // 
            btnRight.Enabled=false;
            btnRight.Location=new Point(295,104);
            btnRight.Name="btnRight";
            btnRight.Size=new Size(155,34);
            btnRight.TabIndex=7;
            btnRight.Text="Explore &Right >>";
            btnRight.UseVisualStyleBackColor=true;
            btnRight.Click+=btnRight_Click;
            // 
            // txtLog
            // 
            txtLog.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            txtLog.Location=new Point(736,27);
            txtLog.Multiline=true;
            txtLog.Name="txtLog";
            txtLog.ScrollBars=ScrollBars.Both;
            txtLog.Size=new Size(293,649);
            txtLog.TabIndex=8;
            txtLog.WordWrap=false;
            // 
            // btnBuild
            // 
            btnBuild.Enabled=false;
            btnBuild.Location=new Point(481,104);
            btnBuild.Name="btnBuild";
            btnBuild.Size=new Size(80,34);
            btnBuild.TabIndex=9;
            btnBuild.Text="&Build";
            btnBuild.UseVisualStyleBackColor=true;
            btnBuild.Click+=btnBuild_Click;
            // 
            // btnHire
            // 
            btnHire.Enabled=false;
            btnHire.Location=new Point(481,147);
            btnHire.Name="btnHire";
            btnHire.Size=new Size(80,34);
            btnHire.TabIndex=10;
            btnHire.Text="&Hire";
            btnHire.UseVisualStyleBackColor=true;
            btnHire.Click+=btnHire_Click;
            // 
            // chkLstTurnOverview
            // 
            chkLstTurnOverview.FormattingEnabled=true;
            chkLstTurnOverview.Location=new Point(12,187);
            chkLstTurnOverview.Name="chkLstTurnOverview";
            chkLstTurnOverview.Size=new Size(174,284);
            chkLstTurnOverview.TabIndex=11;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize=new Size(24,24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem,challengesToolStripMenuItem });
            menuStrip1.Location=new Point(0,0);
            menuStrip1.Name="menuStrip1";
            menuStrip1.Size=new Size(1047,33);
            menuStrip1.TabIndex=12;
            menuStrip1.Text="menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem,loadToolStripMenuItem });
            fileToolStripMenuItem.Name="fileToolStripMenuItem";
            fileToolStripMenuItem.Size=new Size(54,29);
            fileToolStripMenuItem.Text="&File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name="saveToolStripMenuItem";
            saveToolStripMenuItem.Size=new Size(153,34);
            saveToolStripMenuItem.Text="&Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name="loadToolStripMenuItem";
            loadToolStripMenuItem.Size=new Size(153,34);
            loadToolStripMenuItem.Text="&Load";
            // 
            // challengesToolStripMenuItem
            // 
            challengesToolStripMenuItem.Name="challengesToolStripMenuItem";
            challengesToolStripMenuItem.Size=new Size(113,29);
            challengesToolStripMenuItem.Text="&Challenges";
            challengesToolStripMenuItem.Click+=challengesToolStripMenuItem_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled=false;
            btnNext.Location=new Point(33,147);
            btnNext.Name="btnNext";
            btnNext.Size=new Size(114,34);
            btnNext.TabIndex=13;
            btnNext.Text="&Next Phase";
            btnNext.UseVisualStyleBackColor=true;
            btnNext.Click+=btnNext_Click;
            // 
            // btnTrade
            // 
            btnTrade.Enabled=false;
            btnTrade.Location=new Point(481,52);
            btnTrade.Name="btnTrade";
            btnTrade.Size=new Size(80,34);
            btnTrade.TabIndex=14;
            btnTrade.Text="&Trade";
            btnTrade.UseVisualStyleBackColor=true;
            btnTrade.Click+=btnTrade_Click;
            // 
            // lblTurn
            // 
            lblTurn.AutoSize=true;
            lblTurn.Location=new Point(708,78);
            lblTurn.Name="lblTurn";
            lblTurn.Size=new Size(0,25);
            lblTurn.TabIndex=16;
            // 
            // lblTurnNum
            // 
            lblTurnNum.AutoSize=true;
            lblTurnNum.Location=new Point(586,78);
            lblTurnNum.Name="lblTurnNum";
            lblTurnNum.Size=new Size(51,25);
            lblTurnNum.TabIndex=15;
            lblTurnNum.Text="Turn:";
            // 
            // frmMain
            // 
            AutoScaleDimensions=new SizeF(10F,25F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1047,693);
            Controls.Add(lblTurn);
            Controls.Add(lblTurnNum);
            Controls.Add(btnTrade);
            Controls.Add(btnNext);
            Controls.Add(chkLstTurnOverview);
            Controls.Add(btnHire);
            Controls.Add(btnBuild);
            Controls.Add(txtLog);
            Controls.Add(btnRight);
            Controls.Add(btnLeft);
            Controls.Add(lblTrade);
            Controls.Add(lblRes);
            Controls.Add(lblTradeGoods);
            Controls.Add(lblResources);
            Controls.Add(txtMap);
            Controls.Add(btnStart);
            Controls.Add(menuStrip1);
            MainMenuStrip=menuStrip1;
            Name="frmMain";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Delve";
            FormClosed+=frmMain_FormClosed;
            Load+=frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private TextBox txtMap;
        private Label lblResources;
        private Label lblTradeGoods;
        private Label lblRes;
        private Label lblTrade;
        private Button btnLeft;
        private Button btnRight;
        private TextBox txtLog;
        private Button btnBuild;
        private Button btnHire;
        private CheckedListBox chkLstTurnOverview;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem challengesToolStripMenuItem;
        private Button btnNext;
        private Button btnTrade;
        private Label lblTurn;
        private Label lblTurnNum;
    }
}
