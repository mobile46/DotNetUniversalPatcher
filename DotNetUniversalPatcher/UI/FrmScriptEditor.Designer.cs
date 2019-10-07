namespace DotNetUniversalPatcher.UI
{
    partial class FrmScriptEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScriptEditor));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseForm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddPatch = new System.Windows.Forms.Button();
            this.cmsTargetList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveUpTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveDownTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemovePatch = new System.Windows.Forms.Button();
            this.cmbPatchList = new System.Windows.Forms.ComboBox();
            this.grpPatchList = new System.Windows.Forms.GroupBox();
            this.btnPatcherOptions = new System.Windows.Forms.Button();
            this.grpTargetOptions = new System.Windows.Forms.GroupBox();
            this.tabTargetOptions = new System.Windows.Forms.TabControl();
            this.tpTargetList = new System.Windows.Forms.TabPage();
            this.grpTargetList = new System.Windows.Forms.GroupBox();
            this.dgvTargetList = new System.Windows.Forms.DataGridView();
            this.dgvcActionMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpTargetInfo = new System.Windows.Forms.TabPage();
            this.grpAddTarget = new System.Windows.Forms.GroupBox();
            this.btnSelectTargetFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnAddTargetFile = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkKeepOldMaxStack = new System.Windows.Forms.CheckBox();
            this.grpTargetFiles = new System.Windows.Forms.GroupBox();
            this.dgvTargetFiles = new System.Windows.Forms.DataGridView();
            this.dgvcPlaceholderKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsTargetFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditTargetFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveTargetFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveUpTargetFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveDownTargetFile = new System.Windows.Forms.ToolStripMenuItem();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.msMain.SuspendLayout();
            this.cmsTargetList.SuspendLayout();
            this.grpPatchList.SuspendLayout();
            this.grpTargetOptions.SuspendLayout();
            this.tabTargetOptions.SuspendLayout();
            this.tpTargetList.SuspendLayout();
            this.grpTargetList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetList)).BeginInit();
            this.tpTargetInfo.SuspendLayout();
            this.grpAddTarget.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpTargetFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetFiles)).BeginInit();
            this.cmsTargetFiles.SuspendLayout();
            this.flpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiAbout,
            this.tsmiCloseForm});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.msMain.Size = new System.Drawing.Size(454, 25);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewScript,
            this.tsmiOpenScript,
            this.tsmiSaveScript,
            this.tsmiSaveAsScript,
            this.tsmiCloseScript});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.ShortcutKeyDisplayString = "";
            this.tsmiFile.Size = new System.Drawing.Size(37, 19);
            this.tsmiFile.Text = "File";
            // 
            // tsmiNewScript
            // 
            this.tsmiNewScript.Name = "tsmiNewScript";
            this.tsmiNewScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiNewScript.Size = new System.Drawing.Size(186, 22);
            this.tsmiNewScript.Text = "New";
            this.tsmiNewScript.Click += new System.EventHandler(this.TsmiNewScript_Click);
            // 
            // tsmiOpenScript
            // 
            this.tsmiOpenScript.Name = "tsmiOpenScript";
            this.tsmiOpenScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiOpenScript.Size = new System.Drawing.Size(186, 22);
            this.tsmiOpenScript.Text = "Open";
            this.tsmiOpenScript.Click += new System.EventHandler(this.TsmiOpenScript_Click);
            // 
            // tsmiSaveScript
            // 
            this.tsmiSaveScript.Enabled = false;
            this.tsmiSaveScript.Name = "tsmiSaveScript";
            this.tsmiSaveScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveScript.Size = new System.Drawing.Size(186, 22);
            this.tsmiSaveScript.Text = "Save";
            this.tsmiSaveScript.Click += new System.EventHandler(this.TsmiSaveScript_Click);
            // 
            // tsmiSaveAsScript
            // 
            this.tsmiSaveAsScript.Enabled = false;
            this.tsmiSaveAsScript.Name = "tsmiSaveAsScript";
            this.tsmiSaveAsScript.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiSaveAsScript.Size = new System.Drawing.Size(186, 22);
            this.tsmiSaveAsScript.Text = "Save As...";
            this.tsmiSaveAsScript.Click += new System.EventHandler(this.TsmiSaveAsScript_Click);
            // 
            // tsmiCloseScript
            // 
            this.tsmiCloseScript.Enabled = false;
            this.tsmiCloseScript.Name = "tsmiCloseScript";
            this.tsmiCloseScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsmiCloseScript.Size = new System.Drawing.Size(186, 22);
            this.tsmiCloseScript.Text = "Close";
            this.tsmiCloseScript.Click += new System.EventHandler(this.TsmiCloseScript_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(52, 19);
            this.tsmiAbout.Text = "About";
            this.tsmiAbout.Click += new System.EventHandler(this.TsmiAbout_Click);
            // 
            // tsmiCloseForm
            // 
            this.tsmiCloseForm.Name = "tsmiCloseForm";
            this.tsmiCloseForm.Size = new System.Drawing.Size(48, 19);
            this.tsmiCloseForm.Text = "Close";
            this.tsmiCloseForm.Click += new System.EventHandler(this.TsmiCloseForm_Click);
            // 
            // btnAddPatch
            // 
            this.btnAddPatch.Location = new System.Drawing.Point(155, 23);
            this.btnAddPatch.Name = "btnAddPatch";
            this.btnAddPatch.Size = new System.Drawing.Size(71, 27);
            this.btnAddPatch.TabIndex = 1;
            this.btnAddPatch.Text = "Add";
            this.btnAddPatch.UseVisualStyleBackColor = true;
            this.btnAddPatch.Click += new System.EventHandler(this.BtnAddPatch_Click);
            // 
            // cmsTargetList
            // 
            this.cmsTargetList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddTarget,
            this.tsmiEditTarget,
            this.tsmiRemoveTarget,
            this.tsmiMoveUpTarget,
            this.tsmiMoveDownTarget});
            this.cmsTargetList.Name = "contextMenuStrip1";
            this.cmsTargetList.Size = new System.Drawing.Size(200, 114);
            // 
            // tsmiAddTarget
            // 
            this.tsmiAddTarget.Name = "tsmiAddTarget";
            this.tsmiAddTarget.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.tsmiAddTarget.Size = new System.Drawing.Size(199, 22);
            this.tsmiAddTarget.Text = "Add";
            this.tsmiAddTarget.Click += new System.EventHandler(this.TsmiAddTarget_Click);
            // 
            // tsmiEditTarget
            // 
            this.tsmiEditTarget.Name = "tsmiEditTarget";
            this.tsmiEditTarget.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiEditTarget.Size = new System.Drawing.Size(199, 22);
            this.tsmiEditTarget.Text = "Edit";
            this.tsmiEditTarget.Click += new System.EventHandler(this.TsmiEditTarget_Click);
            // 
            // tsmiRemoveTarget
            // 
            this.tsmiRemoveTarget.Name = "tsmiRemoveTarget";
            this.tsmiRemoveTarget.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiRemoveTarget.Size = new System.Drawing.Size(199, 22);
            this.tsmiRemoveTarget.Text = "Remove";
            this.tsmiRemoveTarget.Click += new System.EventHandler(this.TsmiRemoveTarget_Click);
            // 
            // tsmiMoveUpTarget
            // 
            this.tsmiMoveUpTarget.Name = "tsmiMoveUpTarget";
            this.tsmiMoveUpTarget.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.tsmiMoveUpTarget.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveUpTarget.Text = "Move Up";
            this.tsmiMoveUpTarget.Click += new System.EventHandler(this.TsmiMoveUpTarget_Click);
            // 
            // tsmiMoveDownTarget
            // 
            this.tsmiMoveDownTarget.Name = "tsmiMoveDownTarget";
            this.tsmiMoveDownTarget.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.tsmiMoveDownTarget.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveDownTarget.Text = "Move Down";
            this.tsmiMoveDownTarget.Click += new System.EventHandler(this.TsmiMoveDownTarget_Click);
            // 
            // btnRemovePatch
            // 
            this.btnRemovePatch.Location = new System.Drawing.Point(232, 23);
            this.btnRemovePatch.Name = "btnRemovePatch";
            this.btnRemovePatch.Size = new System.Drawing.Size(71, 27);
            this.btnRemovePatch.TabIndex = 2;
            this.btnRemovePatch.Text = "Remove";
            this.btnRemovePatch.UseVisualStyleBackColor = true;
            this.btnRemovePatch.Click += new System.EventHandler(this.BtnRemovePatch_Click);
            // 
            // cmbPatchList
            // 
            this.cmbPatchList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPatchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPatchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatchList.FormattingEnabled = true;
            this.cmbPatchList.Location = new System.Drawing.Point(6, 24);
            this.cmbPatchList.Name = "cmbPatchList";
            this.cmbPatchList.Size = new System.Drawing.Size(143, 25);
            this.cmbPatchList.TabIndex = 0;
            this.cmbPatchList.SelectedValueChanged += new System.EventHandler(this.CmbPatchList_SelectedValueChanged);
            // 
            // grpPatchList
            // 
            this.grpPatchList.Controls.Add(this.btnPatcherOptions);
            this.grpPatchList.Controls.Add(this.btnAddPatch);
            this.grpPatchList.Controls.Add(this.btnRemovePatch);
            this.grpPatchList.Controls.Add(this.cmbPatchList);
            this.grpPatchList.Enabled = false;
            this.grpPatchList.Location = new System.Drawing.Point(11, 3);
            this.grpPatchList.Name = "grpPatchList";
            this.grpPatchList.Size = new System.Drawing.Size(430, 63);
            this.grpPatchList.TabIndex = 0;
            this.grpPatchList.TabStop = false;
            this.grpPatchList.Text = "Patch List";
            // 
            // btnPatcherOptions
            // 
            this.btnPatcherOptions.Location = new System.Drawing.Point(307, 23);
            this.btnPatcherOptions.Name = "btnPatcherOptions";
            this.btnPatcherOptions.Size = new System.Drawing.Size(112, 27);
            this.btnPatcherOptions.TabIndex = 3;
            this.btnPatcherOptions.Text = "Patcher Options";
            this.btnPatcherOptions.UseVisualStyleBackColor = true;
            this.btnPatcherOptions.Click += new System.EventHandler(this.BtnPatcherOptions_Click);
            // 
            // grpTargetOptions
            // 
            this.grpTargetOptions.Controls.Add(this.tabTargetOptions);
            this.grpTargetOptions.Enabled = false;
            this.grpTargetOptions.Location = new System.Drawing.Point(11, 72);
            this.grpTargetOptions.Name = "grpTargetOptions";
            this.grpTargetOptions.Size = new System.Drawing.Size(430, 389);
            this.grpTargetOptions.TabIndex = 1;
            this.grpTargetOptions.TabStop = false;
            this.grpTargetOptions.Text = "Target Options";
            // 
            // tabTargetOptions
            // 
            this.tabTargetOptions.Controls.Add(this.tpTargetList);
            this.tabTargetOptions.Controls.Add(this.tpTargetInfo);
            this.tabTargetOptions.Location = new System.Drawing.Point(6, 18);
            this.tabTargetOptions.Name = "tabTargetOptions";
            this.tabTargetOptions.SelectedIndex = 0;
            this.tabTargetOptions.Size = new System.Drawing.Size(417, 365);
            this.tabTargetOptions.TabIndex = 0;
            // 
            // tpTargetList
            // 
            this.tpTargetList.Controls.Add(this.grpTargetList);
            this.tpTargetList.Location = new System.Drawing.Point(4, 26);
            this.tpTargetList.Name = "tpTargetList";
            this.tpTargetList.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargetList.Size = new System.Drawing.Size(409, 335);
            this.tpTargetList.TabIndex = 0;
            this.tpTargetList.Text = "Target List";
            this.tpTargetList.UseVisualStyleBackColor = true;
            // 
            // grpTargetList
            // 
            this.grpTargetList.Controls.Add(this.dgvTargetList);
            this.grpTargetList.Location = new System.Drawing.Point(6, 6);
            this.grpTargetList.Name = "grpTargetList";
            this.grpTargetList.Size = new System.Drawing.Size(395, 323);
            this.grpTargetList.TabIndex = 0;
            this.grpTargetList.TabStop = false;
            this.grpTargetList.Text = "Target List";
            // 
            // dgvTargetList
            // 
            this.dgvTargetList.AllowUserToAddRows = false;
            this.dgvTargetList.AllowUserToDeleteRows = false;
            this.dgvTargetList.AllowUserToResizeRows = false;
            this.dgvTargetList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTargetList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTargetList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTargetList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTargetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTargetList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcActionMethod,
            this.dgvcFullName});
            this.dgvTargetList.ContextMenuStrip = this.cmsTargetList;
            this.dgvTargetList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTargetList.Location = new System.Drawing.Point(6, 24);
            this.dgvTargetList.MultiSelect = false;
            this.dgvTargetList.Name = "dgvTargetList";
            this.dgvTargetList.RowHeadersVisible = false;
            this.dgvTargetList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTargetList.Size = new System.Drawing.Size(383, 293);
            this.dgvTargetList.TabIndex = 0;
            // 
            // dgvcActionMethod
            // 
            this.dgvcActionMethod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcActionMethod.HeaderText = "Action Method";
            this.dgvcActionMethod.Name = "dgvcActionMethod";
            this.dgvcActionMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcFullName
            // 
            this.dgvcFullName.HeaderText = "Full Name";
            this.dgvcFullName.Name = "dgvcFullName";
            this.dgvcFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpTargetInfo
            // 
            this.tpTargetInfo.Controls.Add(this.grpAddTarget);
            this.tpTargetInfo.Controls.Add(this.grpOptions);
            this.tpTargetInfo.Controls.Add(this.grpTargetFiles);
            this.tpTargetInfo.Location = new System.Drawing.Point(4, 26);
            this.tpTargetInfo.Name = "tpTargetInfo";
            this.tpTargetInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpTargetInfo.Size = new System.Drawing.Size(409, 335);
            this.tpTargetInfo.TabIndex = 1;
            this.tpTargetInfo.Text = "Target Info";
            this.tpTargetInfo.UseVisualStyleBackColor = true;
            // 
            // grpAddTarget
            // 
            this.grpAddTarget.Controls.Add(this.btnSelectTargetFile);
            this.grpAddTarget.Controls.Add(this.txtFilePath);
            this.grpAddTarget.Controls.Add(this.btnAddTargetFile);
            this.grpAddTarget.Location = new System.Drawing.Point(6, 6);
            this.grpAddTarget.Name = "grpAddTarget";
            this.grpAddTarget.Size = new System.Drawing.Size(395, 64);
            this.grpAddTarget.TabIndex = 0;
            this.grpAddTarget.TabStop = false;
            this.grpAddTarget.Text = "Add Target File";
            // 
            // btnSelectTargetFile
            // 
            this.btnSelectTargetFile.Location = new System.Drawing.Point(285, 23);
            this.btnSelectTargetFile.Name = "btnSelectTargetFile";
            this.btnSelectTargetFile.Size = new System.Drawing.Size(27, 27);
            this.btnSelectTargetFile.TabIndex = 1;
            this.btnSelectTargetFile.Text = "...";
            this.btnSelectTargetFile.UseVisualStyleBackColor = true;
            this.btnSelectTargetFile.Click += new System.EventHandler(this.BtnSelectTargetFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.Location = new System.Drawing.Point(6, 24);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(273, 25);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtFilePath_DragDrop);
            this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtFilePath_DragEnter);
            // 
            // btnAddTargetFile
            // 
            this.btnAddTargetFile.Location = new System.Drawing.Point(318, 23);
            this.btnAddTargetFile.Name = "btnAddTargetFile";
            this.btnAddTargetFile.Size = new System.Drawing.Size(71, 27);
            this.btnAddTargetFile.TabIndex = 2;
            this.btnAddTargetFile.Text = "Add";
            this.btnAddTargetFile.UseVisualStyleBackColor = true;
            this.btnAddTargetFile.Click += new System.EventHandler(this.BtnAddTargetFile_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkKeepOldMaxStack);
            this.grpOptions.Location = new System.Drawing.Point(6, 277);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(395, 52);
            this.grpOptions.TabIndex = 2;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkKeepOldMaxStack
            // 
            this.chkKeepOldMaxStack.AutoSize = true;
            this.chkKeepOldMaxStack.Location = new System.Drawing.Point(6, 24);
            this.chkKeepOldMaxStack.Name = "chkKeepOldMaxStack";
            this.chkKeepOldMaxStack.Size = new System.Drawing.Size(176, 21);
            this.chkKeepOldMaxStack.TabIndex = 0;
            this.chkKeepOldMaxStack.Text = "Keep Old MaxStack Value";
            this.chkKeepOldMaxStack.UseVisualStyleBackColor = true;
            this.chkKeepOldMaxStack.CheckedChanged += new System.EventHandler(this.ChkKeepOldMaxStack_CheckedChanged);
            // 
            // grpTargetFiles
            // 
            this.grpTargetFiles.Controls.Add(this.dgvTargetFiles);
            this.grpTargetFiles.Location = new System.Drawing.Point(6, 76);
            this.grpTargetFiles.Name = "grpTargetFiles";
            this.grpTargetFiles.Size = new System.Drawing.Size(395, 195);
            this.grpTargetFiles.TabIndex = 1;
            this.grpTargetFiles.TabStop = false;
            this.grpTargetFiles.Text = "Target Files";
            // 
            // dgvTargetFiles
            // 
            this.dgvTargetFiles.AllowUserToAddRows = false;
            this.dgvTargetFiles.AllowUserToDeleteRows = false;
            this.dgvTargetFiles.AllowUserToResizeRows = false;
            this.dgvTargetFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTargetFiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTargetFiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvTargetFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTargetFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTargetFiles.ColumnHeadersVisible = false;
            this.dgvTargetFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcPlaceholderKey});
            this.dgvTargetFiles.ContextMenuStrip = this.cmsTargetFiles;
            this.dgvTargetFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTargetFiles.Location = new System.Drawing.Point(6, 24);
            this.dgvTargetFiles.MultiSelect = false;
            this.dgvTargetFiles.Name = "dgvTargetFiles";
            this.dgvTargetFiles.RowHeadersVisible = false;
            this.dgvTargetFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTargetFiles.Size = new System.Drawing.Size(383, 165);
            this.dgvTargetFiles.TabIndex = 0;
            // 
            // dgvcPlaceholderKey
            // 
            this.dgvcPlaceholderKey.HeaderText = "File Path";
            this.dgvcPlaceholderKey.Name = "dgvcPlaceholderKey";
            this.dgvcPlaceholderKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmsTargetFiles
            // 
            this.cmsTargetFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditTargetFile,
            this.tsmiRemoveTargetFile,
            this.tsmiMoveUpTargetFile,
            this.tsmiMoveDownTargetFile});
            this.cmsTargetFiles.Name = "contextMenuStrip1";
            this.cmsTargetFiles.Size = new System.Drawing.Size(200, 92);
            // 
            // tsmiEditTargetFile
            // 
            this.tsmiEditTargetFile.Name = "tsmiEditTargetFile";
            this.tsmiEditTargetFile.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiEditTargetFile.Size = new System.Drawing.Size(199, 22);
            this.tsmiEditTargetFile.Text = "Edit";
            this.tsmiEditTargetFile.Click += new System.EventHandler(this.TsmiEditTargetFile_Click);
            // 
            // tsmiRemoveTargetFile
            // 
            this.tsmiRemoveTargetFile.Name = "tsmiRemoveTargetFile";
            this.tsmiRemoveTargetFile.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiRemoveTargetFile.Size = new System.Drawing.Size(199, 22);
            this.tsmiRemoveTargetFile.Text = "Remove";
            this.tsmiRemoveTargetFile.Click += new System.EventHandler(this.TsmiRemoveTargetFile_Click);
            // 
            // tsmiMoveUpTargetFile
            // 
            this.tsmiMoveUpTargetFile.Name = "tsmiMoveUpTargetFile";
            this.tsmiMoveUpTargetFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.tsmiMoveUpTargetFile.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveUpTargetFile.Text = "Move Up";
            this.tsmiMoveUpTargetFile.Click += new System.EventHandler(this.TsmiMoveUpTargetFile_Click);
            // 
            // tsmiMoveDownTargetFile
            // 
            this.tsmiMoveDownTargetFile.Name = "tsmiMoveDownTargetFile";
            this.tsmiMoveDownTargetFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.tsmiMoveDownTargetFile.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveDownTargetFile.Text = "Move Down";
            this.tsmiMoveDownTargetFile.Click += new System.EventHandler(this.TsmiMoveDownTargetFile_Click);
            // 
            // flpMain
            // 
            this.flpMain.Controls.Add(this.grpPatchList);
            this.flpMain.Controls.Add(this.grpTargetOptions);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 25);
            this.flpMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpMain.Name = "flpMain";
            this.flpMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.flpMain.Size = new System.Drawing.Size(454, 472);
            this.flpMain.TabIndex = 6;
            // 
            // FrmScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 497);
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmScriptEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script Editor";
            this.Load += new System.EventHandler(this.FrmScriptEditor_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.cmsTargetList.ResumeLayout(false);
            this.grpPatchList.ResumeLayout(false);
            this.grpTargetOptions.ResumeLayout(false);
            this.tabTargetOptions.ResumeLayout(false);
            this.tpTargetList.ResumeLayout(false);
            this.grpTargetList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetList)).EndInit();
            this.tpTargetInfo.ResumeLayout(false);
            this.grpAddTarget.ResumeLayout(false);
            this.grpAddTarget.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpTargetFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetFiles)).EndInit();
            this.cmsTargetFiles.ResumeLayout(false);
            this.flpMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseForm;
        private System.Windows.Forms.Button btnRemovePatch;
        private System.Windows.Forms.Button btnAddPatch;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseScript;
        private System.Windows.Forms.GroupBox grpPatchList;
        private System.Windows.Forms.ContextMenuStrip cmsTargetList;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditTarget;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveTarget;
        private System.Windows.Forms.GroupBox grpTargetOptions;
        private System.Windows.Forms.Button btnPatcherOptions;
        private System.Windows.Forms.TabControl tabTargetOptions;
        private System.Windows.Forms.TabPage tpTargetList;
        private System.Windows.Forms.TabPage tpTargetInfo;
        private System.Windows.Forms.GroupBox grpAddTarget;
        private System.Windows.Forms.Button btnAddTargetFile;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkKeepOldMaxStack;
        private System.Windows.Forms.GroupBox grpTargetFiles;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Button btnSelectTargetFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddTarget;
        private System.Windows.Forms.GroupBox grpTargetList;
        internal System.Windows.Forms.ComboBox cmbPatchList;
        private System.Windows.Forms.DataGridView dgvTargetFiles;
        private System.Windows.Forms.ContextMenuStrip cmsTargetFiles;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditTargetFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveTargetFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPlaceholderKey;
        internal System.Windows.Forms.DataGridView dgvTargetList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcActionMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFullName;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveUpTarget;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDownTarget;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveUpTargetFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDownTargetFile;
    }
}