namespace DotNetUniversalPatcher.UI
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.btnOK = new System.Windows.Forms.Button();
            this.rtbAboutText = new System.Windows.Forms.RichTextBox();
            this.btnShowAboutText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(302, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // rtbAboutText
            // 
            this.rtbAboutText.BackColor = System.Drawing.Color.White;
            this.rtbAboutText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAboutText.Location = new System.Drawing.Point(12, 9);
            this.rtbAboutText.Name = "rtbAboutText";
            this.rtbAboutText.ReadOnly = true;
            this.rtbAboutText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbAboutText.Size = new System.Drawing.Size(370, 120);
            this.rtbAboutText.TabIndex = 0;
            this.rtbAboutText.Text = "";
            this.rtbAboutText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RtbAboutText_LinkClicked);
            // 
            // btnShowAboutText
            // 
            this.btnShowAboutText.Location = new System.Drawing.Point(12, 135);
            this.btnShowAboutText.Name = "btnShowAboutText";
            this.btnShowAboutText.Size = new System.Drawing.Size(110, 30);
            this.btnShowAboutText.TabIndex = 2;
            this.btnShowAboutText.Text = "About DNUP";
            this.btnShowAboutText.UseVisualStyleBackColor = true;
            this.btnShowAboutText.Visible = false;
            this.btnShowAboutText.Click += new System.EventHandler(this.BtnShowAboutText_Click);
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(394, 176);
            this.Controls.Add(this.btnShowAboutText);
            this.Controls.Add(this.rtbAboutText);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RichTextBox rtbAboutText;
        private System.Windows.Forms.Button btnShowAboutText;
    }
}