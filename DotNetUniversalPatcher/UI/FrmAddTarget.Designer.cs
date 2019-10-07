namespace DotNetUniversalPatcher.UI
{
    partial class FrmAddTarget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddTarget));
            this.cmbActionMethod = new System.Windows.Forms.ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.lblOpCode = new System.Windows.Forms.Label();
            this.cmsInstructions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveUpInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveDownInstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOperand = new System.Windows.Forms.Label();
            this.txtOperand = new System.Windows.Forms.TextBox();
            this.cmbOpCodes = new System.Windows.Forms.ComboBox();
            this.lblOptional = new System.Windows.Forms.Label();
            this.grpAddInstruction = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddTarget = new System.Windows.Forms.Button();
            this.grpTarget = new System.Windows.Forms.GroupBox();
            this.cmbOptional = new System.Windows.Forms.ComboBox();
            this.grpInstructions = new System.Windows.Forms.GroupBox();
            this.dgvInstructions = new System.Windows.Forms.DataGridView();
            this.dgvcIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcOpCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcOperand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmsInstructions.SuspendLayout();
            this.grpAddInstruction.SuspendLayout();
            this.grpTarget.SuspendLayout();
            this.grpInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructions)).BeginInit();
            this.flpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbActionMethod
            // 
            this.cmbActionMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbActionMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbActionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionMethod.FormattingEnabled = true;
            this.cmbActionMethod.Location = new System.Drawing.Point(89, 52);
            this.cmbActionMethod.Name = "cmbActionMethod";
            this.cmbActionMethod.Size = new System.Drawing.Size(328, 25);
            this.cmbActionMethod.TabIndex = 3;
            this.cmbActionMethod.SelectedIndexChanged += new System.EventHandler(this.CmbActionMethod_SelectedIndexChanged);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(8, 55);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(47, 17);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Action:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(89, 21);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(328, 25);
            this.txtFullName.TabIndex = 1;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(6, 24);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(69, 17);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(6, 24);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(42, 17);
            this.lblIndex.TabIndex = 0;
            this.lblIndex.Text = "Index:";
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(89, 21);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(328, 25);
            this.txtIndex.TabIndex = 1;
            // 
            // lblOpCode
            // 
            this.lblOpCode.AutoSize = true;
            this.lblOpCode.Location = new System.Drawing.Point(6, 55);
            this.lblOpCode.Name = "lblOpCode";
            this.lblOpCode.Size = new System.Drawing.Size(60, 17);
            this.lblOpCode.TabIndex = 2;
            this.lblOpCode.Text = "OpCode:";
            // 
            // cmsInstructions
            // 
            this.cmsInstructions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditInstruction,
            this.tsmiRemoveInstruction,
            this.tsmiMoveUpInstruction,
            this.tsmiMoveDownInstruction});
            this.cmsInstructions.Name = "cmsInstructions";
            this.cmsInstructions.Size = new System.Drawing.Size(200, 92);
            // 
            // tsmiEditInstruction
            // 
            this.tsmiEditInstruction.Name = "tsmiEditInstruction";
            this.tsmiEditInstruction.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmiEditInstruction.Size = new System.Drawing.Size(199, 22);
            this.tsmiEditInstruction.Text = "Edit";
            this.tsmiEditInstruction.Click += new System.EventHandler(this.TsmiEditInstruction_Click);
            // 
            // tsmiRemoveInstruction
            // 
            this.tsmiRemoveInstruction.Name = "tsmiRemoveInstruction";
            this.tsmiRemoveInstruction.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiRemoveInstruction.Size = new System.Drawing.Size(199, 22);
            this.tsmiRemoveInstruction.Text = "Remove";
            this.tsmiRemoveInstruction.Click += new System.EventHandler(this.TsmiRemoveInstruction_Click);
            // 
            // tsmiMoveUpInstruction
            // 
            this.tsmiMoveUpInstruction.Name = "tsmiMoveUpInstruction";
            this.tsmiMoveUpInstruction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.tsmiMoveUpInstruction.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveUpInstruction.Text = "Move Up";
            this.tsmiMoveUpInstruction.Click += new System.EventHandler(this.TsmiMoveUpInstruction_Click);
            // 
            // tsmiMoveDownInstruction
            // 
            this.tsmiMoveDownInstruction.Name = "tsmiMoveDownInstruction";
            this.tsmiMoveDownInstruction.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.tsmiMoveDownInstruction.Size = new System.Drawing.Size(199, 22);
            this.tsmiMoveDownInstruction.Text = "Move Down";
            this.tsmiMoveDownInstruction.Click += new System.EventHandler(this.TsmiMoveDownInstruction_Click);
            // 
            // lblOperand
            // 
            this.lblOperand.AutoSize = true;
            this.lblOperand.Location = new System.Drawing.Point(6, 86);
            this.lblOperand.Name = "lblOperand";
            this.lblOperand.Size = new System.Drawing.Size(63, 17);
            this.lblOperand.TabIndex = 4;
            this.lblOperand.Text = "Operand:";
            // 
            // txtOperand
            // 
            this.txtOperand.Location = new System.Drawing.Point(89, 83);
            this.txtOperand.Name = "txtOperand";
            this.txtOperand.Size = new System.Drawing.Size(328, 25);
            this.txtOperand.TabIndex = 5;
            // 
            // cmbOpCodes
            // 
            this.cmbOpCodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOpCodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOpCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOpCodes.FormattingEnabled = true;
            this.cmbOpCodes.Location = new System.Drawing.Point(89, 52);
            this.cmbOpCodes.Name = "cmbOpCodes";
            this.cmbOpCodes.Size = new System.Drawing.Size(328, 25);
            this.cmbOpCodes.TabIndex = 3;
            this.cmbOpCodes.SelectedIndexChanged += new System.EventHandler(this.CmbOpCodes_SelectedIndexChanged);
            // 
            // lblOptional
            // 
            this.lblOptional.AutoSize = true;
            this.lblOptional.Location = new System.Drawing.Point(8, 87);
            this.lblOptional.Name = "lblOptional";
            this.lblOptional.Size = new System.Drawing.Size(61, 17);
            this.lblOptional.TabIndex = 4;
            this.lblOptional.Text = "Optional:";
            // 
            // grpAddInstruction
            // 
            this.grpAddInstruction.Controls.Add(this.btnClear);
            this.grpAddInstruction.Controls.Add(this.txtIndex);
            this.grpAddInstruction.Controls.Add(this.btnAddTarget);
            this.grpAddInstruction.Controls.Add(this.lblIndex);
            this.grpAddInstruction.Controls.Add(this.lblOpCode);
            this.grpAddInstruction.Controls.Add(this.cmbOpCodes);
            this.grpAddInstruction.Controls.Add(this.lblOperand);
            this.grpAddInstruction.Controls.Add(this.txtOperand);
            this.grpAddInstruction.Location = new System.Drawing.Point(11, 128);
            this.grpAddInstruction.Name = "grpAddInstruction";
            this.grpAddInstruction.Size = new System.Drawing.Size(430, 148);
            this.grpAddInstruction.TabIndex = 2;
            this.grpAddInstruction.TabStop = false;
            this.grpAddInstruction.Text = "Add Instruction";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(256, 115);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(161, 27);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Location = new System.Drawing.Point(89, 115);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(161, 27);
            this.btnAddTarget.TabIndex = 6;
            this.btnAddTarget.Text = "Add";
            this.btnAddTarget.UseVisualStyleBackColor = true;
            this.btnAddTarget.Click += new System.EventHandler(this.BtnAddTarget_Click);
            // 
            // grpTarget
            // 
            this.grpTarget.Controls.Add(this.cmbOptional);
            this.grpTarget.Controls.Add(this.lblAction);
            this.grpTarget.Controls.Add(this.cmbActionMethod);
            this.grpTarget.Controls.Add(this.lblOptional);
            this.grpTarget.Controls.Add(this.txtFullName);
            this.grpTarget.Controls.Add(this.lblFullName);
            this.grpTarget.Location = new System.Drawing.Point(11, 3);
            this.grpTarget.Name = "grpTarget";
            this.grpTarget.Size = new System.Drawing.Size(430, 119);
            this.grpTarget.TabIndex = 1;
            this.grpTarget.TabStop = false;
            this.grpTarget.Text = "Target";
            // 
            // cmbOptional
            // 
            this.cmbOptional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOptional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOptional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOptional.Enabled = false;
            this.cmbOptional.FormattingEnabled = true;
            this.cmbOptional.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmbOptional.Location = new System.Drawing.Point(89, 84);
            this.cmbOptional.Name = "cmbOptional";
            this.cmbOptional.Size = new System.Drawing.Size(328, 25);
            this.cmbOptional.TabIndex = 5;
            // 
            // grpInstructions
            // 
            this.grpInstructions.Controls.Add(this.dgvInstructions);
            this.grpInstructions.Location = new System.Drawing.Point(11, 282);
            this.grpInstructions.Name = "grpInstructions";
            this.grpInstructions.Size = new System.Drawing.Size(430, 199);
            this.grpInstructions.TabIndex = 3;
            this.grpInstructions.TabStop = false;
            this.grpInstructions.Text = "Instructions";
            // 
            // dgvInstructions
            // 
            this.dgvInstructions.AllowUserToAddRows = false;
            this.dgvInstructions.AllowUserToDeleteRows = false;
            this.dgvInstructions.AllowUserToResizeRows = false;
            this.dgvInstructions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstructions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInstructions.BackgroundColor = System.Drawing.Color.White;
            this.dgvInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInstructions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstructions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcIndex,
            this.dgvcOpCode,
            this.dgvcOperand});
            this.dgvInstructions.ContextMenuStrip = this.cmsInstructions;
            this.dgvInstructions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInstructions.Location = new System.Drawing.Point(9, 20);
            this.dgvInstructions.MultiSelect = false;
            this.dgvInstructions.Name = "dgvInstructions";
            this.dgvInstructions.RowHeadersVisible = false;
            this.dgvInstructions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstructions.Size = new System.Drawing.Size(408, 173);
            this.dgvInstructions.TabIndex = 0;
            // 
            // dgvcIndex
            // 
            this.dgvcIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcIndex.HeaderText = "Index";
            this.dgvcIndex.Name = "dgvcIndex";
            this.dgvcIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvcIndex.Width = 45;
            // 
            // dgvcOpCode
            // 
            this.dgvcOpCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcOpCode.HeaderText = "OpCode";
            this.dgvcOpCode.Name = "dgvcOpCode";
            this.dgvcOpCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvcOpCode.Width = 63;
            // 
            // dgvcOperand
            // 
            this.dgvcOperand.HeaderText = "Operand";
            this.dgvcOperand.Name = "dgvcOperand";
            this.dgvcOperand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // flpMain
            // 
            this.flpMain.Controls.Add(this.grpTarget);
            this.flpMain.Controls.Add(this.grpAddInstruction);
            this.flpMain.Controls.Add(this.grpInstructions);
            this.flpMain.Controls.Add(this.btnCancel);
            this.flpMain.Controls.Add(this.btnSave);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 0);
            this.flpMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flpMain.Name = "flpMain";
            this.flpMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 7);
            this.flpMain.Size = new System.Drawing.Size(454, 524);
            this.flpMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(11, 487);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(212, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(229, 487);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(212, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmAddTarget
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 524);
            this.Controls.Add(this.flpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmAddTarget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Target";
            this.Load += new System.EventHandler(this.FrmAddTarget_Load);
            this.cmsInstructions.ResumeLayout(false);
            this.grpAddInstruction.ResumeLayout(false);
            this.grpAddInstruction.PerformLayout();
            this.grpTarget.ResumeLayout(false);
            this.grpTarget.PerformLayout();
            this.grpInstructions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructions)).EndInit();
            this.flpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbActionMethod;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label lblOpCode;
        private System.Windows.Forms.Label lblOperand;
        private System.Windows.Forms.TextBox txtOperand;
        private System.Windows.Forms.ComboBox cmbOpCodes;
        private System.Windows.Forms.Label lblOptional;
        private System.Windows.Forms.GroupBox grpAddInstruction;
        private System.Windows.Forms.GroupBox grpTarget;
        private System.Windows.Forms.GroupBox grpInstructions;
        private System.Windows.Forms.Button btnAddTarget;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ContextMenuStrip cmsInstructions;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveInstruction;
        private System.Windows.Forms.ComboBox cmbOptional;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditInstruction;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvInstructions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcOpCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcOperand;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveUpInstruction;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDownInstruction;
    }
}