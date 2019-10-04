namespace DotNetUniversalPatcher.UI
{
    partial class FrmPatcherOptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatcherOptions));
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPatcherOptions = new System.Windows.Forms.TabControl();
            this.tpPatcherOptions = new System.Windows.Forms.TabPage();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkMakeBackup = new System.Windows.Forms.CheckBox();
            this.grpPatcherInfo = new System.Windows.Forms.GroupBox();
            this.lblAboutText = new System.Windows.Forms.Label();
            this.lblReleaseInfo = new System.Windows.Forms.Label();
            this.txtReleaseInfo = new System.Windows.Forms.TextBox();
            this.txtAboutText = new System.Windows.Forms.TextBox();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtSoftwareName = new System.Windows.Forms.TextBox();
            this.btnVisit = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.lblSoftware = new System.Windows.Forms.Label();
            this.tpPlaceholders = new System.Windows.Forms.TabPage();
            this.grpAddPlaceholder = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblPlaceholderValue = new System.Windows.Forms.Label();
            this.lblPlaceholderKey = new System.Windows.Forms.Label();
            this.txtPlaceholderValue = new System.Windows.Forms.TextBox();
            this.txtPlaceholderKey = new System.Windows.Forms.TextBox();
            this.btnAddPlaceholder = new System.Windows.Forms.Button();
            this.grpPlaceholders = new System.Windows.Forms.GroupBox();
            this.dgvPlaceholders = new System.Windows.Forms.DataGridView();
            this.dgvcPlaceholderKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPlaceholderValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPlaceholders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditPlaceholder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemovePlaceholder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tsmiMoveUpPlaceholder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveDownPlaceholder = new System.Windows.Forms.ToolStripMenuItem();
            this.flpMain.SuspendLayout();
            this.tabPatcherOptions.SuspendLayout();
            this.tpPatcherOptions.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpPatcherInfo.SuspendLayout();
            this.tpPlaceholders.SuspendLayout();
            this.grpAddPlaceholder.SuspendLayout();
            this.grpPlaceholders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaceholders)).BeginInit();
            this.cmsPlaceholders.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpMain
            // 
            this.flpMain.Controls.Add(this.tabPatcherOptions);
            this.flpMain.Controls.Add(this.btnCancel);
            this.flpMain.Controls.Add(this.btnSave);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 0);
            this.flpMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpMain.Name = "flpMain";
            this.flpMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.flpMain.Size = new System.Drawing.Size(518, 490);
            this.flpMain.TabIndex = 0;
            // 
            // tabPatcherOptions
            // 
            this.tabPatcherOptions.Controls.Add(this.tpPatcherOptions);
            this.tabPatcherOptions.Controls.Add(this.tpPlaceholders);
            this.tabPatcherOptions.Location = new System.Drawing.Point(11, 3);
            this.tabPatcherOptions.Name = "tabPatcherOptions";
            this.tabPatcherOptions.SelectedIndex = 0;
            this.tabPatcherOptions.Size = new System.Drawing.Size(495, 443);
            this.tabPatcherOptions.TabIndex = 0;
            // 
            // tpPatcherOptions
            // 
            this.tpPatcherOptions.Controls.Add(this.grpOptions);
            this.tpPatcherOptions.Controls.Add(this.grpPatcherInfo);
            this.tpPatcherOptions.Location = new System.Drawing.Point(4, 26);
            this.tpPatcherOptions.Name = "tpPatcherOptions";
            this.tpPatcherOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpPatcherOptions.Size = new System.Drawing.Size(487, 413);
            this.tpPatcherOptions.TabIndex = 0;
            this.tpPatcherOptions.Text = "Patcher Options";
            this.tpPatcherOptions.UseVisualStyleBackColor = true;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkMakeBackup);
            this.grpOptions.Location = new System.Drawing.Point(6, 351);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(469, 52);
            this.grpOptions.TabIndex = 1;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkMakeBackup
            // 
            this.chkMakeBackup.AutoSize = true;
            this.chkMakeBackup.Location = new System.Drawing.Point(6, 24);
            this.chkMakeBackup.Name = "chkMakeBackup";
            this.chkMakeBackup.Size = new System.Drawing.Size(104, 21);
            this.chkMakeBackup.TabIndex = 0;
            this.chkMakeBackup.Text = "Make Backup";
            this.chkMakeBackup.UseVisualStyleBackColor = true;
            // 
            // grpPatcherInfo
            // 
            this.grpPatcherInfo.Controls.Add(this.lblAboutText);
            this.grpPatcherInfo.Controls.Add(this.lblReleaseInfo);
            this.grpPatcherInfo.Controls.Add(this.txtReleaseInfo);
            this.grpPatcherInfo.Controls.Add(this.txtAboutText);
            this.grpPatcherInfo.Controls.Add(this.dtpReleaseDate);
            this.grpPatcherInfo.Controls.Add(this.txtWebsite);
            this.grpPatcherInfo.Controls.Add(this.txtAuthor);
            this.grpPatcherInfo.Controls.Add(this.txtSoftwareName);
            this.grpPatcherInfo.Controls.Add(this.btnVisit);
            this.grpPatcherInfo.Controls.Add(this.btnToday);
            this.grpPatcherInfo.Controls.Add(this.lblAuthor);
            this.grpPatcherInfo.Controls.Add(this.lblReleaseDate);
            this.grpPatcherInfo.Controls.Add(this.lblWebsite);
            this.grpPatcherInfo.Controls.Add(this.lblSoftware);
            this.grpPatcherInfo.Location = new System.Drawing.Point(6, 6);
            this.grpPatcherInfo.Name = "grpPatcherInfo";
            this.grpPatcherInfo.Size = new System.Drawing.Size(469, 339);
            this.grpPatcherInfo.TabIndex = 0;
            this.grpPatcherInfo.TabStop = false;
            this.grpPatcherInfo.Text = "Patcher Info";
            // 
            // lblAboutText
            // 
            this.lblAboutText.AutoSize = true;
            this.lblAboutText.Location = new System.Drawing.Point(6, 242);
            this.lblAboutText.Name = "lblAboutText";
            this.lblAboutText.Size = new System.Drawing.Size(73, 17);
            this.lblAboutText.TabIndex = 12;
            this.lblAboutText.Text = "About Text:";
            // 
            // lblReleaseInfo
            // 
            this.lblReleaseInfo.AutoSize = true;
            this.lblReleaseInfo.Location = new System.Drawing.Point(6, 147);
            this.lblReleaseInfo.Name = "lblReleaseInfo";
            this.lblReleaseInfo.Size = new System.Drawing.Size(82, 17);
            this.lblReleaseInfo.TabIndex = 10;
            this.lblReleaseInfo.Text = "Release Info:";
            // 
            // txtReleaseInfo
            // 
            this.txtReleaseInfo.Location = new System.Drawing.Point(116, 144);
            this.txtReleaseInfo.Multiline = true;
            this.txtReleaseInfo.Name = "txtReleaseInfo";
            this.txtReleaseInfo.Size = new System.Drawing.Size(340, 89);
            this.txtReleaseInfo.TabIndex = 11;
            // 
            // txtAboutText
            // 
            this.txtAboutText.Location = new System.Drawing.Point(116, 239);
            this.txtAboutText.Multiline = true;
            this.txtAboutText.Name = "txtAboutText";
            this.txtAboutText.Size = new System.Drawing.Size(340, 89);
            this.txtAboutText.TabIndex = 13;
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(116, 113);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(274, 25);
            this.dtpReleaseDate.TabIndex = 8;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(116, 83);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(274, 25);
            this.txtWebsite.TabIndex = 5;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(116, 52);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(340, 25);
            this.txtAuthor.TabIndex = 3;
            // 
            // txtSoftwareName
            // 
            this.txtSoftwareName.Location = new System.Drawing.Point(116, 21);
            this.txtSoftwareName.Name = "txtSoftwareName";
            this.txtSoftwareName.Size = new System.Drawing.Size(340, 25);
            this.txtSoftwareName.TabIndex = 1;
            // 
            // btnVisit
            // 
            this.btnVisit.Location = new System.Drawing.Point(396, 82);
            this.btnVisit.Name = "btnVisit";
            this.btnVisit.Size = new System.Drawing.Size(60, 27);
            this.btnVisit.TabIndex = 6;
            this.btnVisit.Text = "Visit";
            this.btnVisit.UseVisualStyleBackColor = true;
            this.btnVisit.Click += new System.EventHandler(this.BtnVisit_Click);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(396, 112);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(60, 27);
            this.btnToday.TabIndex = 9;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.BtnToday_Click);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(6, 55);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(50, 17);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author:";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Location = new System.Drawing.Point(6, 118);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(87, 17);
            this.lblReleaseDate.TabIndex = 7;
            this.lblReleaseDate.Text = "Release Date:";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(6, 86);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(57, 17);
            this.lblWebsite.TabIndex = 4;
            this.lblWebsite.Text = "Website:";
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
            // tpPlaceholders
            // 
            this.tpPlaceholders.Controls.Add(this.grpAddPlaceholder);
            this.tpPlaceholders.Controls.Add(this.grpPlaceholders);
            this.tpPlaceholders.Location = new System.Drawing.Point(4, 26);
            this.tpPlaceholders.Name = "tpPlaceholders";
            this.tpPlaceholders.Padding = new System.Windows.Forms.Padding(3);
            this.tpPlaceholders.Size = new System.Drawing.Size(487, 413);
            this.tpPlaceholders.TabIndex = 1;
            this.tpPlaceholders.Text = "Placeholders";
            this.tpPlaceholders.UseVisualStyleBackColor = true;
            // 
            // grpAddPlaceholder
            // 
            this.grpAddPlaceholder.Controls.Add(this.btnClear);
            this.grpAddPlaceholder.Controls.Add(this.lblPlaceholderValue);
            this.grpAddPlaceholder.Controls.Add(this.lblPlaceholderKey);
            this.grpAddPlaceholder.Controls.Add(this.txtPlaceholderValue);
            this.grpAddPlaceholder.Controls.Add(this.txtPlaceholderKey);
            this.grpAddPlaceholder.Controls.Add(this.btnAddPlaceholder);
            this.grpAddPlaceholder.Location = new System.Drawing.Point(6, 6);
            this.grpAddPlaceholder.Name = "grpAddPlaceholder";
            this.grpAddPlaceholder.Size = new System.Drawing.Size(469, 188);
            this.grpAddPlaceholder.TabIndex = 0;
            this.grpAddPlaceholder.TabStop = false;
            this.grpAddPlaceholder.Text = "Add Placeholder";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(291, 147);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(165, 27);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // lblPlaceholderValue
            // 
            this.lblPlaceholderValue.Location = new System.Drawing.Point(6, 55);
            this.lblPlaceholderValue.Name = "lblPlaceholderValue";
            this.lblPlaceholderValue.Size = new System.Drawing.Size(114, 17);
            this.lblPlaceholderValue.TabIndex = 2;
            this.lblPlaceholderValue.Text = "Placeholder Value:";
            // 
            // lblPlaceholderKey
            // 
            this.lblPlaceholderKey.AutoSize = true;
            this.lblPlaceholderKey.Location = new System.Drawing.Point(6, 24);
            this.lblPlaceholderKey.Name = "lblPlaceholderKey";
            this.lblPlaceholderKey.Size = new System.Drawing.Size(104, 17);
            this.lblPlaceholderKey.TabIndex = 0;
            this.lblPlaceholderKey.Text = "Placeholder Key:";
            // 
            // txtPlaceholderValue
            // 
            this.txtPlaceholderValue.Location = new System.Drawing.Point(120, 52);
            this.txtPlaceholderValue.Multiline = true;
            this.txtPlaceholderValue.Name = "txtPlaceholderValue";
            this.txtPlaceholderValue.Size = new System.Drawing.Size(336, 89);
            this.txtPlaceholderValue.TabIndex = 3;
            // 
            // txtPlaceholderKey
            // 
            this.txtPlaceholderKey.Location = new System.Drawing.Point(120, 21);
            this.txtPlaceholderKey.Name = "txtPlaceholderKey";
            this.txtPlaceholderKey.Size = new System.Drawing.Size(336, 25);
            this.txtPlaceholderKey.TabIndex = 1;
            // 
            // btnAddPlaceholder
            // 
            this.btnAddPlaceholder.Location = new System.Drawing.Point(120, 147);
            this.btnAddPlaceholder.Name = "btnAddPlaceholder";
            this.btnAddPlaceholder.Size = new System.Drawing.Size(165, 27);
            this.btnAddPlaceholder.TabIndex = 4;
            this.btnAddPlaceholder.Text = "Add";
            this.btnAddPlaceholder.UseVisualStyleBackColor = true;
            this.btnAddPlaceholder.Click += new System.EventHandler(this.BtnAddPlaceholder_Click);
            // 
            // grpPlaceholders
            // 
            this.grpPlaceholders.Controls.Add(this.dgvPlaceholders);
            this.grpPlaceholders.Location = new System.Drawing.Point(6, 200);
            this.grpPlaceholders.Name = "grpPlaceholders";
            this.grpPlaceholders.Size = new System.Drawing.Size(469, 203);
            this.grpPlaceholders.TabIndex = 1;
            this.grpPlaceholders.TabStop = false;
            this.grpPlaceholders.Text = "Placeholders";
            // 
            // dgvPlaceholders
            // 
            this.dgvPlaceholders.AllowUserToAddRows = false;
            this.dgvPlaceholders.AllowUserToDeleteRows = false;
            this.dgvPlaceholders.AllowUserToResizeRows = false;
            this.dgvPlaceholders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlaceholders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPlaceholders.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlaceholders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlaceholders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaceholders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcPlaceholderKey,
            this.dgvcPlaceholderValue});
            this.dgvPlaceholders.ContextMenuStrip = this.cmsPlaceholders;
            this.dgvPlaceholders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPlaceholders.Location = new System.Drawing.Point(9, 24);
            this.dgvPlaceholders.MultiSelect = false;
            this.dgvPlaceholders.Name = "dgvPlaceholders";
            this.dgvPlaceholders.RowHeadersVisible = false;
            this.dgvPlaceholders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlaceholders.Size = new System.Drawing.Size(450, 173);
            this.dgvPlaceholders.TabIndex = 0;
            // 
            // dgvcPlaceholderKey
            // 
            this.dgvcPlaceholderKey.HeaderText = "Placeholder Key";
            this.dgvcPlaceholderKey.Name = "dgvcPlaceholderKey";
            this.dgvcPlaceholderKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcPlaceholderValue
            // 
            this.dgvcPlaceholderValue.HeaderText = "Placeholder Value";
            this.dgvcPlaceholderValue.Name = "dgvcPlaceholderValue";
            this.dgvcPlaceholderValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmsPlaceholders
            // 
            this.cmsPlaceholders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditPlaceholder,
            this.tsmiRemovePlaceholder,
            this.tsmiMoveUpPlaceholder,
            this.tsmiMoveDownPlaceholder});
            this.cmsPlaceholders.Name = "cmsInstructions";
            this.cmsPlaceholders.Size = new System.Drawing.Size(200, 114);
            // 
            // tsmiEditPlaceholder
            // 
            this.tsmiEditPlaceholder.Name = "tsmiEditPlaceholder";
            this.tsmiEditPlaceholder.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiEditPlaceholder.Size = new System.Drawing.Size(199, 22);
            this.tsmiEditPlaceholder.Text = "Edit";
            this.tsmiEditPlaceholder.Click += new System.EventHandler(this.TsmiEditPlaceholder_Click);
            // 
            // tsmiRemovePlaceholder
            // 
            this.tsmiRemovePlaceholder.Name = "tsmiRemovePlaceholder";
            this.tsmiRemovePlaceholder.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiRemovePlaceholder.Size = new System.Drawing.Size(199, 22);
            this.tsmiRemovePlaceholder.Text = "Remove";
            this.tsmiRemovePlaceholder.Click += new System.EventHandler(this.TsmiRemovePlaceholder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(11, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(244, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(261, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(244, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tsmiMoveUpPlaceholder
            // 
            this.tsmiMoveUpPlaceholder.Name = "tsmiMoveUpPlaceholder";
            this.tsmiMoveUpPlaceholder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.tsmiMoveUpPlaceholder.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveUpPlaceholder.Text = "Move Up";
            this.tsmiMoveUpPlaceholder.Click += new System.EventHandler(this.tsmiMoveUpPlaceholder_Click);
            // 
            // tsmiMoveDownPlaceholder
            // 
            this.tsmiMoveDownPlaceholder.Name = "tsmiMoveDownPlaceholder";
            this.tsmiMoveDownPlaceholder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.tsmiMoveDownPlaceholder.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveDownPlaceholder.Text = "Move Down";
            this.tsmiMoveDownPlaceholder.Click += new System.EventHandler(this.tsmiMoveDownPlaceholder_Click);
            // 
            // FrmPatcherOptions
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(518, 490);
            this.Controls.Add(this.flpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmPatcherOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patcher Options";
            this.Load += new System.EventHandler(this.FrmPatcherOptions_Load);
            this.flpMain.ResumeLayout(false);
            this.tabPatcherOptions.ResumeLayout(false);
            this.tpPatcherOptions.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpPatcherInfo.ResumeLayout(false);
            this.grpPatcherInfo.PerformLayout();
            this.tpPlaceholders.ResumeLayout(false);
            this.grpAddPlaceholder.ResumeLayout(false);
            this.grpAddPlaceholder.PerformLayout();
            this.grpPlaceholders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaceholders)).EndInit();
            this.cmsPlaceholders.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.GroupBox grpPatcherInfo;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Label lblSoftware;
        private System.Windows.Forms.Label lblReleaseInfo;
        private System.Windows.Forms.Button btnVisit;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Label lblAboutText;
        private System.Windows.Forms.TabControl tabPatcherOptions;
        private System.Windows.Forms.TabPage tpPatcherOptions;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.TabPage tpPlaceholders;
        private System.Windows.Forms.GroupBox grpAddPlaceholder;
        private System.Windows.Forms.TextBox txtPlaceholderKey;
        private System.Windows.Forms.Button btnAddPlaceholder;
        private System.Windows.Forms.GroupBox grpPlaceholders;
        private System.Windows.Forms.Label lblPlaceholderValue;
        private System.Windows.Forms.Label lblPlaceholderKey;
        private System.Windows.Forms.TextBox txtPlaceholderValue;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip cmsPlaceholders;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPlaceholder;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemovePlaceholder;
        internal System.Windows.Forms.TextBox txtReleaseInfo;
        internal System.Windows.Forms.DateTimePicker dtpReleaseDate;
        internal System.Windows.Forms.TextBox txtWebsite;
        internal System.Windows.Forms.TextBox txtAuthor;
        internal System.Windows.Forms.TextBox txtSoftwareName;
        internal System.Windows.Forms.TextBox txtAboutText;
        internal System.Windows.Forms.CheckBox chkMakeBackup;
        private System.Windows.Forms.DataGridView dgvPlaceholders;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPlaceholderKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPlaceholderValue;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveUpPlaceholder;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDownPlaceholder;
    }
}