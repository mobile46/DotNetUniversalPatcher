using System.ComponentModel;
using System.Windows.Forms;

namespace DotNetUniversalPatcher.UI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.grpPatcherInfo = new System.Windows.Forms.GroupBox();
            this.lblSoftware = new System.Windows.Forms.Label();
            this.cmbSoftware = new System.Windows.Forms.ComboBox();
            this.txtReleaseDate = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTargetFiles = new System.Windows.Forms.TextBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblTargetFiles = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.grpReleaseInfo = new System.Windows.Forms.GroupBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.txtReleaseInfo = new System.Windows.Forms.TextBox();
            this.chkMakeBackup = new System.Windows.Forms.CheckBox();
            this.btnPatch = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tipLogItem = new System.Windows.Forms.ToolTip(this.components);
            this.tipTargetFiles = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scriptEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpMain.SuspendLayout();
            this.grpPatcherInfo.SuspendLayout();
            this.grpReleaseInfo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpMain
            // 
            this.flpMain.Controls.Add(this.grpPatcherInfo);
            this.flpMain.Controls.Add(this.grpReleaseInfo);
            this.flpMain.Controls.Add(this.chkMakeBackup);
            this.flpMain.Controls.Add(this.btnPatch);
            this.flpMain.Controls.Add(this.btnAbout);
            this.flpMain.Controls.Add(this.btnExit);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 24);
            this.flpMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpMain.Name = "flpMain";
            this.flpMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.flpMain.Size = new System.Drawing.Size(454, 361);
            this.flpMain.TabIndex = 0;
            // 
            // grpPatcherInfo
            // 
            this.grpPatcherInfo.Controls.Add(this.lblSoftware);
            this.grpPatcherInfo.Controls.Add(this.cmbSoftware);
            this.grpPatcherInfo.Controls.Add(this.txtReleaseDate);
            this.grpPatcherInfo.Controls.Add(this.lblAuthor);
            this.grpPatcherInfo.Controls.Add(this.lblReleaseDate);
            this.grpPatcherInfo.Controls.Add(this.txtAuthor);
            this.grpPatcherInfo.Controls.Add(this.txtTargetFiles);
            this.grpPatcherInfo.Controls.Add(this.txtWebsite);
            this.grpPatcherInfo.Controls.Add(this.lblTargetFiles);
            this.grpPatcherInfo.Controls.Add(this.lblWebsite);
            this.grpPatcherInfo.Enabled = false;
            this.grpPatcherInfo.Location = new System.Drawing.Point(11, 3);
            this.grpPatcherInfo.Name = "grpPatcherInfo";
            this.grpPatcherInfo.Size = new System.Drawing.Size(430, 175);
            this.grpPatcherInfo.TabIndex = 0;
            this.grpPatcherInfo.TabStop = false;
            this.grpPatcherInfo.Text = "Patcher Info";
            // 
            // lblSoftware
            // 
            this.lblSoftware.AutoSize = true;
            this.lblSoftware.Location = new System.Drawing.Point(6, 24);
            this.lblSoftware.Name = "lblSoftware";
            this.lblSoftware.Size = new System.Drawing.Size(62, 17);
            this.lblSoftware.TabIndex = 0;
            this.lblSoftware.Text = "Software:";
            // 
            // cmbSoftware
            // 
            this.cmbSoftware.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSoftware.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoftware.FormattingEnabled = true;
            this.cmbSoftware.Location = new System.Drawing.Point(112, 21);
            this.cmbSoftware.Name = "cmbSoftware";
            this.cmbSoftware.Size = new System.Drawing.Size(308, 25);
            this.cmbSoftware.TabIndex = 1;
            this.cmbSoftware.SelectedIndexChanged += new System.EventHandler(this.CmbSoftware_SelectedIndexChanged);
            // 
            // txtReleaseDate
            // 
            this.txtReleaseDate.Location = new System.Drawing.Point(112, 140);
            this.txtReleaseDate.Name = "txtReleaseDate";
            this.txtReleaseDate.ReadOnly = true;
            this.txtReleaseDate.Size = new System.Drawing.Size(308, 25);
            this.txtReleaseDate.TabIndex = 9;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(6, 85);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(50, 17);
            this.lblAuthor.TabIndex = 4;
            this.lblAuthor.Text = "Author:";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Location = new System.Drawing.Point(6, 143);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(87, 17);
            this.lblReleaseDate.TabIndex = 8;
            this.lblReleaseDate.Text = "Release Date:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(112, 82);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(308, 25);
            this.txtAuthor.TabIndex = 5;
            // 
            // txtTargetFiles
            // 
            this.txtTargetFiles.Location = new System.Drawing.Point(112, 52);
            this.txtTargetFiles.Name = "txtTargetFiles";
            this.txtTargetFiles.ReadOnly = true;
            this.txtTargetFiles.Size = new System.Drawing.Size(308, 25);
            this.txtTargetFiles.TabIndex = 3;
            this.txtTargetFiles.MouseHover += new System.EventHandler(this.TxtTargetFiles_MouseHover);
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(112, 111);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.ReadOnly = true;
            this.txtWebsite.Size = new System.Drawing.Size(308, 25);
            this.txtWebsite.TabIndex = 7;
            this.txtWebsite.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TxtWebsite_MouseDoubleClick);
            // 
            // lblTargetFiles
            // 
            this.lblTargetFiles.AutoSize = true;
            this.lblTargetFiles.Location = new System.Drawing.Point(6, 55);
            this.lblTargetFiles.Name = "lblTargetFiles";
            this.lblTargetFiles.Size = new System.Drawing.Size(96, 17);
            this.lblTargetFiles.TabIndex = 2;
            this.lblTargetFiles.Text = "Target Files (0):";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(6, 114);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(57, 17);
            this.lblWebsite.TabIndex = 6;
            this.lblWebsite.Text = "Website:";
            // 
            // grpReleaseInfo
            // 
            this.grpReleaseInfo.Controls.Add(this.lstLog);
            this.grpReleaseInfo.Controls.Add(this.txtReleaseInfo);
            this.grpReleaseInfo.Enabled = false;
            this.grpReleaseInfo.Location = new System.Drawing.Point(11, 184);
            this.grpReleaseInfo.Name = "grpReleaseInfo";
            this.grpReleaseInfo.Size = new System.Drawing.Size(430, 125);
            this.grpReleaseInfo.TabIndex = 1;
            this.grpReleaseInfo.TabStop = false;
            this.grpReleaseInfo.Text = "Release Info";
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 17;
            this.lstLog.Location = new System.Drawing.Point(9, 24);
            this.lstLog.Name = "lstLog";
            this.lstLog.ScrollAlwaysVisible = true;
            this.lstLog.Size = new System.Drawing.Size(411, 89);
            this.lstLog.TabIndex = 1;
            this.lstLog.Visible = false;
            this.lstLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstLog_KeyDown);
            this.lstLog.MouseLeave += new System.EventHandler(this.LstLog_MouseLeave);
            this.lstLog.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LstLog_MouseMove);
            // 
            // txtReleaseInfo
            // 
            this.txtReleaseInfo.Enabled = false;
            this.txtReleaseInfo.Location = new System.Drawing.Point(9, 24);
            this.txtReleaseInfo.Multiline = true;
            this.txtReleaseInfo.Name = "txtReleaseInfo";
            this.txtReleaseInfo.ReadOnly = true;
            this.txtReleaseInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReleaseInfo.Size = new System.Drawing.Size(411, 89);
            this.txtReleaseInfo.TabIndex = 0;
            // 
            // chkMakeBackup
            // 
            this.chkMakeBackup.AutoSize = true;
            this.chkMakeBackup.Enabled = false;
            this.chkMakeBackup.Location = new System.Drawing.Point(14, 321);
            this.chkMakeBackup.Margin = new System.Windows.Forms.Padding(6, 9, 2, 5);
            this.chkMakeBackup.Name = "chkMakeBackup";
            this.chkMakeBackup.Size = new System.Drawing.Size(104, 21);
            this.chkMakeBackup.TabIndex = 2;
            this.chkMakeBackup.Text = "Make Backup";
            this.chkMakeBackup.UseVisualStyleBackColor = true;
            this.chkMakeBackup.CheckedChanged += new System.EventHandler(this.ChkMakeBackup_CheckedChanged);
            // 
            // btnPatch
            // 
            this.btnPatch.Enabled = false;
            this.btnPatch.Location = new System.Drawing.Point(123, 314);
            this.btnPatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(102, 34);
            this.btnPatch.TabIndex = 3;
            this.btnPatch.Text = "Patch";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.BtnPatch_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(231, 314);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(102, 34);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(339, 314);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 34);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptEditorToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(454, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // scriptEditorToolStripMenuItem
            // 
            this.scriptEditorToolStripMenuItem.Name = "scriptEditorToolStripMenuItem";
            this.scriptEditorToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.scriptEditorToolStripMenuItem.Text = "Script Editor";
            this.scriptEditorToolStripMenuItem.Click += new System.EventHandler(this.ScriptEditorToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnPatch;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(454, 385);
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DotNet Universal Patcher";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.flpMain.ResumeLayout(false);
            this.flpMain.PerformLayout();
            this.grpPatcherInfo.ResumeLayout(false);
            this.grpPatcherInfo.PerformLayout();
            this.grpReleaseInfo.ResumeLayout(false);
            this.grpReleaseInfo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flpMain;
        private Label lblSoftware;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblWebsite;
        private TextBox txtWebsite;
        private Label lblReleaseDate;
        private TextBox txtReleaseDate;
        internal TextBox txtReleaseInfo;
        private Button btnAbout;
        private Button btnExit;
        internal CheckBox chkMakeBackup;
        internal GroupBox grpReleaseInfo;
        private TextBox txtTargetFiles;
        internal Label lblTargetFiles;
        internal ListBox lstLog;
        private ToolTip tipLogItem;
        private ToolTip tipTargetFiles;
        internal ComboBox cmbSoftware;
        internal GroupBox grpPatcherInfo;
        internal Button btnPatch;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem scriptEditorToolStripMenuItem;
    }
}

