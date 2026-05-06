namespace DelveCS.Forms {
    partial class frmChallenges {
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
            chkLstChallenges=new CheckedListBox();
            btnOk=new Button();
            txtDescription=new TextBox();
            SuspendLayout();
            // 
            // chkLstChallenges
            // 
            chkLstChallenges.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            chkLstChallenges.FormattingEnabled=true;
            chkLstChallenges.Location=new Point(12,36);
            chkLstChallenges.Name="chkLstChallenges";
            chkLstChallenges.Size=new Size(573,256);
            chkLstChallenges.TabIndex=0;
            chkLstChallenges.Click+=chkLstChallenges_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor=AnchorStyles.Bottom|AnchorStyles.Left;
            btnOk.Location=new Point(250,450);
            btnOk.Name="btnOk";
            btnOk.Size=new Size(114,48);
            btnOk.TabIndex=1;
            btnOk.Text="&Ok";
            btnOk.UseVisualStyleBackColor=true;
            btnOk.Click+=btnOk_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor=AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            txtDescription.Location=new Point(9,312);
            txtDescription.Multiline=true;
            txtDescription.Name="txtDescription";
            txtDescription.Size=new Size(575,104);
            txtDescription.TabIndex=2;
            // 
            // frmChallenges
            // 
            AcceptButton=btnOk;
            AutoScaleDimensions=new SizeF(10F,25F);
            AutoScaleMode=AutoScaleMode.Font;
            CancelButton=btnOk;
            ClientSize=new Size(597,525);
            Controls.Add(txtDescription);
            Controls.Add(btnOk);
            Controls.Add(chkLstChallenges);
            Name="frmChallenges";
            Text="Challenges";
            Load+=frmChallenges_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox chkLstChallenges;
        private Button btnOk;
        private TextBox txtDescription;
    }
}