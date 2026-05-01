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
            lblReources=new Label();
            lblTradeGoods=new Label();
            lblRes=new Label();
            lblTrade=new Label();
            btnLeft=new Button();
            btnRight=new Button();
            txtLog=new TextBox();
            btnBuild=new Button();
            btnHire=new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location=new Point(12,12);
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
            txtMap.Location=new Point(12,114);
            txtMap.Multiline=true;
            txtMap.Name="txtMap";
            txtMap.ScrollBars=ScrollBars.Both;
            txtMap.Size=new Size(707,324);
            txtMap.TabIndex=1;
            txtMap.WordWrap=false;
            // 
            // lblReources
            // 
            lblReources.AutoSize=true;
            lblReources.Location=new Point(586,27);
            lblReources.Name="lblReources";
            lblReources.Size=new Size(95,25);
            lblReources.TabIndex=2;
            lblReources.Text="Resources:";
            // 
            // lblTradeGoods
            // 
            lblTradeGoods.AutoSize=true;
            lblTradeGoods.Location=new Point(586,61);
            lblTradeGoods.Name="lblTradeGoods";
            lblTradeGoods.Size=new Size(116,25);
            lblTradeGoods.TabIndex=3;
            lblTradeGoods.Text="Trade Goods:";
            // 
            // lblRes
            // 
            lblRes.AutoSize=true;
            lblRes.Location=new Point(708,27);
            lblRes.Name="lblRes";
            lblRes.Size=new Size(0,25);
            lblRes.TabIndex=4;
            // 
            // lblTrade
            // 
            lblTrade.AutoSize=true;
            lblTrade.Location=new Point(708,61);
            lblTrade.Name="lblTrade";
            lblTrade.Size=new Size(0,25);
            lblTrade.TabIndex=5;
            // 
            // btnLeft
            // 
            btnLeft.Enabled=false;
            btnLeft.Location=new Point(98,61);
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
            btnRight.Location=new Point(281,61);
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
            txtLog.Size=new Size(293,406);
            txtLog.TabIndex=8;
            txtLog.WordWrap=false;
            // 
            // btnBuild
            // 
            btnBuild.Enabled=false;
            btnBuild.Location=new Point(453,18);
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
            btnHire.Location=new Point(453,61);
            btnHire.Name="btnHire";
            btnHire.Size=new Size(80,34);
            btnHire.TabIndex=10;
            btnHire.Text="&Hire";
            btnHire.UseVisualStyleBackColor=true;
            btnHire.Click+=btnHire_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions=new SizeF(10F,25F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1047,450);
            Controls.Add(btnHire);
            Controls.Add(btnBuild);
            Controls.Add(txtLog);
            Controls.Add(btnRight);
            Controls.Add(btnLeft);
            Controls.Add(lblTrade);
            Controls.Add(lblRes);
            Controls.Add(lblTradeGoods);
            Controls.Add(lblReources);
            Controls.Add(txtMap);
            Controls.Add(btnStart);
            Name="frmMain";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Delve";
            Load+=frmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private TextBox txtMap;
        private Label lblReources;
        private Label lblTradeGoods;
        private Label lblRes;
        private Label lblTrade;
        private Button btnLeft;
        private Button btnRight;
        private TextBox txtLog;
        private Button btnBuild;
        private Button btnHire;
    }
}
