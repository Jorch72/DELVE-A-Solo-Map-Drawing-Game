namespace DelveCS.Forms {
    partial class frmStartUp {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            gbSavedGames=new GroupBox();
            btnLoad=new Button();
            lstGames=new ListBox();
            gbExtra=new GroupBox();
            chkLstOptions=new CheckedListBox();
            btnNew=new Button();
            lblNoSaveGame=new Label();
            menuStrip1=new MenuStrip();
            gbSavedGames.SuspendLayout();
            gbExtra.SuspendLayout();
            SuspendLayout();
            // 
            // gbSavedGames
            // 
            gbSavedGames.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            gbSavedGames.Controls.Add(btnLoad);
            gbSavedGames.Controls.Add(lstGames);
            gbSavedGames.Location=new Point(12,36);
            gbSavedGames.Name="gbSavedGames";
            gbSavedGames.Size=new Size(774,208);
            gbSavedGames.TabIndex=3;
            gbSavedGames.TabStop=false;
            gbSavedGames.Text="Saved Games:";
            gbSavedGames.Enter+=gbSavedGames_Enter;
            // 
            // btnLoad
            // 
            btnLoad.Anchor=AnchorStyles.Top|AnchorStyles.Right;
            btnLoad.Location=new Point(631,40);
            btnLoad.Name="btnLoad";
            btnLoad.Size=new Size(112,34);
            btnLoad.TabIndex=5;
            btnLoad.Text="&Load";
            btnLoad.UseVisualStyleBackColor=true;
            // 
            // lstGames
            // 
            lstGames.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            lstGames.FormattingEnabled=true;
            lstGames.Location=new Point(6,40);
            lstGames.Name="lstGames";
            lstGames.Size=new Size(609,154);
            lstGames.TabIndex=3;
            // 
            // gbExtra
            // 
            gbExtra.Controls.Add(chkLstOptions);
            gbExtra.Location=new Point(18,255);
            gbExtra.Name="gbExtra";
            gbExtra.Size=new Size(769,301);
            gbExtra.TabIndex=4;
            gbExtra.TabStop=false;
            gbExtra.Text="Dificulty Options:";
            // 
            // chkLstOptions
            // 
            chkLstOptions.CheckOnClick=true;
            chkLstOptions.FormattingEnabled=true;
            chkLstOptions.Location=new Point(33,49);
            chkLstOptions.Name="chkLstOptions";
            chkLstOptions.Size=new Size(675,228);
            chkLstOptions.TabIndex=0;
            // 
            // btnNew
            // 
            btnNew.Location=new Point(286,607);
            btnNew.Name="btnNew";
            btnNew.Size=new Size(183,64);
            btnNew.TabIndex=5;
            btnNew.Text="&New Game";
            btnNew.UseVisualStyleBackColor=true;
            btnNew.Click+=btnNew_Click;
            // 
            // lblNoSaveGame
            // 
            lblNoSaveGame.AutoSize=true;
            lblNoSaveGame.Location=new Point(27,611);
            lblNoSaveGame.Name="lblNoSaveGame";
            lblNoSaveGame.Size=new Size(59,25);
            lblNoSaveGame.TabIndex=6;
            lblNoSaveGame.Text="label1";
            lblNoSaveGame.Visible=false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize=new Size(24,24);
            menuStrip1.Location=new Point(0,0);
            menuStrip1.Name="menuStrip1";
            menuStrip1.Size=new Size(812,24);
            menuStrip1.TabIndex=7;
            menuStrip1.Text="menuStrip1";
            // 
            // frmStartUp
            // 
            AutoScaleDimensions=new SizeF(10F,25F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(812,736);
            Controls.Add(lblNoSaveGame);
            Controls.Add(btnNew);
            Controls.Add(gbExtra);
            Controls.Add(gbSavedGames);
            Controls.Add(menuStrip1);
            MainMenuStrip=menuStrip1;
            Name="frmStartUp";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Delve - A Map Making Game";
            Load+=frmStartUp_Load;
            gbSavedGames.ResumeLayout(false);
            gbExtra.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbSavedGames;
        private Button btnLoad;
        private ListBox lstGames;
        private GroupBox gbExtra;
        private Button btnNew;
        private CheckedListBox chkLstOptions;
        private Label lblNoSaveGame;
        private MenuStrip menuStrip1;
    }
}