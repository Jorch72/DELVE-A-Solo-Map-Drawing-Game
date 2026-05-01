namespace Delve{
    partial class frmHire{
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
            btnBuild=new Button();
            btnCancel=new Button();
            txtDescription=new TextBox();
            lblResources=new Label();
            lblTGoods=new Label();
            label2=new Label();
            label1=new Label();
            SuspendLayout();
            // 
            // btnBuild
            // 
            btnBuild.Anchor=AnchorStyles.Bottom|AnchorStyles.Left;
            btnBuild.Location=new Point(157,762);
            btnBuild.Name="btnBuild";
            btnBuild.Size=new Size(112,34);
            btnBuild.TabIndex=1;
            btnBuild.Text="&Build";
            btnBuild.UseVisualStyleBackColor=true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor=AnchorStyles.Bottom|AnchorStyles.Right;
            btnCancel.Location=new Point(558,762);
            btnCancel.Name="btnCancel";
            btnCancel.Size=new Size(112,34);
            btnCancel.TabIndex=2;
            btnCancel.Text="&Cancel";
            btnCancel.UseVisualStyleBackColor=true;
            btnCancel.Click+=btnCancel_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            txtDescription.Location=new Point(473,105);
            txtDescription.Multiline=true;
            txtDescription.Name="txtDescription";
            txtDescription.ScrollBars=ScrollBars.Both;
            txtDescription.Size=new Size(400,421);
            txtDescription.TabIndex=3;
            // 
            // lblResources
            // 
            lblResources.AutoSize=true;
            lblResources.Location=new Point(691,63);
            lblResources.Name="lblResources";
            lblResources.Size=new Size(42,25);
            lblResources.TabIndex=11;
            lblResources.Text="000";
            lblResources.TextAlign=ContentAlignment.MiddleRight;
            // 
            // lblTGoods
            // 
            lblTGoods.AutoSize=true;
            lblTGoods.Location=new Point(691,26);
            lblTGoods.Name="lblTGoods";
            lblTGoods.Size=new Size(42,25);
            lblTGoods.TabIndex=10;
            lblTGoods.Text="000";
            lblTGoods.TextAlign=ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(499,63);
            label2.Name="label2";
            label2.Size=new Size(171,25);
            label2.TabIndex=9;
            label2.Text="Available Resources:";
            label2.TextAlign=ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(478,26);
            label1.Name="label1";
            label1.Size=new Size(192,25);
            label1.TabIndex=8;
            label1.Text="Available Trade Goods:";
            label1.TextAlign=ContentAlignment.MiddleRight;
            // 
            // frmHire
            // 
            AcceptButton=btnBuild;
            AutoScaleDimensions=new SizeF(10F,25F);
            AutoScaleMode=AutoScaleMode.Font;
            CancelButton=btnCancel;
            ClientSize=new Size(885,808);
            Controls.Add(lblResources);
            Controls.Add(lblTGoods);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDescription);
            Controls.Add(btnCancel);
            Controls.Add(btnBuild);
            Name="frmHire";
            StartPosition=FormStartPosition.CenterParent;
            Text="Hire Troops (as many as you want)";
            Load+=frmHire_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBuild;
        private Button btnCancel;
        private TextBox txtDescription;
        private Label lblResources;
        private Label lblTGoods;
        private Label label2;
        private Label label1;
    }
}