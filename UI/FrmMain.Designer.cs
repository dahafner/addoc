namespace Addoc.UI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbxOrgUnits = new System.Windows.Forms.ListBox();
            this.LvwUsers = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LbxOrgUnits
            // 
            this.LbxOrgUnits.FormattingEnabled = true;
            this.LbxOrgUnits.ItemHeight = 25;
            this.LbxOrgUnits.Location = new System.Drawing.Point(12, 29);
            this.LbxOrgUnits.Name = "LbxOrgUnits";
            this.LbxOrgUnits.Size = new System.Drawing.Size(263, 404);
            this.LbxOrgUnits.TabIndex = 0;
            // 
            // LvwUsers
            // 
            this.LvwUsers.HideSelection = false;
            this.LvwUsers.Location = new System.Drawing.Point(281, 29);
            this.LvwUsers.Name = "LvwUsers";
            this.LvwUsers.Size = new System.Drawing.Size(507, 404);
            this.LvwUsers.TabIndex = 1;
            this.LvwUsers.UseCompatibleStateImageBehavior = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LvwUsers);
            this.Controls.Add(this.LbxOrgUnits);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbxOrgUnits;
        private System.Windows.Forms.ListView LvwUsers;
    }
}