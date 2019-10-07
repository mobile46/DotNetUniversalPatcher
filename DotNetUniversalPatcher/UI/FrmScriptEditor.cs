using DotNetUniversalPatcher.Engine;
using DotNetUniversalPatcher.Extensions;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DotNetUniversalPatcher.UI
{
    public partial class FrmScriptEditor : Form
    {
        internal static FrmScriptEditor Instance = new FrmScriptEditor();

        internal PatcherScript Script = new PatcherScript();

        internal List<Patch> PatchList = new List<Patch>();

        private int _patchCount;

        private int _selectedTargetFileIndex;

        private string _scriptFileName = string.Empty;

        private bool _checkChanges;

        public FrmScriptEditor()
        {
            InitializeComponent();
        }

        private void FrmScriptEditor_Load(object sender, EventArgs e)
        {
            btnAddTargetFile.Text = "Add";
        }

        private void BtnAddPatch_Click(object sender, EventArgs e)
        {
            PatchList.Add(new Patch($"Patch {_patchCount++}"));

            RefreshPatchList();

            CheckChanges();
        }

        private void BtnRemovePatch_Click(object sender, EventArgs e)
        {
            if (cmbPatchList.Items.Count > 0)
            {
                if (MessageBox.Show($"Are you sure you want to remove \"{cmbPatchList.Text}\"?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PatchList.RemoveAt(cmbPatchList.SelectedIndex);

                    RefreshPatchList();

                    CheckChanges();
                }
            }

            if (cmbPatchList.Items.Count == 0)
            {
                grpTargetOptions.Enabled = false;
            }
        }

        private void BtnPatcherOptions_Click(object sender, EventArgs e)
        {
            FrmPatcherOptions.Instance.ShowDialog();
        }

        private void BtnSelectTargetFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Executable files (.exe;*.dll)|*.exe;*.dll|All files (*.*)|*.*";
                    ofd.CheckFileExists = true;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtFilePath.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.ExceptionMessageBox(ex);
            }
        }

        private void BtnAddTargetFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                Helpers.CustomMessageBox("Target File Path is empty!");
                return;
            }

            if (btnAddTargetFile.Text == "Add")
            {
                dgvTargetFiles.Rows.Add(txtFilePath.Text);
            }
            else if (btnAddTargetFile.Text == "Update")
            {
                dgvTargetFiles.Rows[_selectedTargetFileIndex].Cells[0].Value = txtFilePath.Text;

                _selectedTargetFileIndex = -1;

                btnAddTargetFile.Text = "Add";
            }

            AddTargetFilesToSelectedPatch();

            CheckChanges();
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            FrmAbout.Instance.AboutScriptText = null;
            FrmAbout.Instance.ShowDialog();
        }

        private void TsmiCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsmiNewScript_Click(object sender, EventArgs e)
        {
            if (_checkChanges)
            {
                DialogResult question = MessageBox.Show("Do you want to save changes before closing the script file?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (question == DialogResult.Cancel)
                {
                    return;
                }

                if (question == DialogResult.Yes)
                {
                    if (!SaveAsScript())
                    {
                        return;
                    }
                }
            }

            tsmiNewScript.Enabled = true;
            tsmiOpenScript.Enabled = true;
            tsmiSaveScript.Enabled = false;
            tsmiSaveAsScript.Enabled = true;
            tsmiCloseScript.Enabled = true;

            _patchCount = 0;

            Script = new PatcherScript();

            _scriptFileName = string.Empty;

            chkKeepOldMaxStack.Checked = false;

            _checkChanges = false;

            if (tabTargetOptions.SelectedIndex != 0)
            {
                tabTargetOptions.SelectedTab = tpTargetList;
            }

            Text = "Script Editor - (New Script)";

            PatchList.Clear();

            RefreshPatchList();

            grpPatchList.Enabled = true;

            dgvTargetList.Rows.Clear();

            txtFilePath.Text = string.Empty;

            btnAddTargetFile.Text = "Add";

            dgvTargetFiles.Rows.Clear();
        }

        private void TsmiOpenScript_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = "DNUP files (.dnup)|*.dnup|All files (*.*)|*.*";
                    ofd.CheckFileExists = true;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Script = JsonConvert.DeserializeObject<PatcherScript>(File.ReadAllText(ofd.FileName), new JsonSerializerSettings
                        {
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore,
                            DateFormatString = "dd.MM.yyyy"
                        });

                        ScriptEngineHelpers.ValidateScript(Script);

                        PatchList.Clear();

                        _patchCount = 0;

                        foreach (var patch in Script.PatchList)
                        {
                            patch.Name = $"Patch {_patchCount++}";

                            PatchList.Add(patch);
                        }

                        RefreshPatchList();

                        Text = $"Script Editor - ({ofd.FileName})";

                        _scriptFileName = ofd.FileName;

                        if (tabTargetOptions.SelectedIndex != 0)
                        {
                            tabTargetOptions.SelectedTab = tpTargetList;
                        }

                        cmbPatchList.SelectedIndex = 0;

                        grpPatchList.Enabled = true;

                        tsmiNewScript.Enabled = true;
                        tsmiOpenScript.Enabled = true;
                        tsmiCloseScript.Enabled = true;
                        tsmiSaveScript.Enabled = true;
                        tsmiSaveAsScript.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.ExceptionMessageBox(ex);
            }
        }

        private void TsmiSaveScript_Click(object sender, EventArgs e)
        {
            try
            {
                if (_scriptFileName != string.Empty && File.Exists(_scriptFileName))
                {
                    CheckScript();

                    var script = JsonConvert.SerializeObject(Script, new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore,
                        DateFormatString = "dd.MM.yyyy"
                    });

                    File.WriteAllText(_scriptFileName, script);

                    Text = $"Script Editor - ({_scriptFileName})";

                    _checkChanges = false;
                }
            }
            catch (Exception ex)
            {
                Helpers.ExceptionMessageBox(ex);
            }
        }

        private void TsmiSaveAsScript_Click(object sender, EventArgs e)
        {
            if (SaveAsScript())
            {
                _checkChanges = false;
            }
        }

        private void TsmiCloseScript_Click(object sender, EventArgs e)
        {
            if (_checkChanges)
            {
                DialogResult question = MessageBox.Show("Do you want to save changes before closing the script file?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (question == DialogResult.Cancel)
                {
                    return;
                }

                if (question == DialogResult.Yes)
                {
                    if (!SaveAsScript())
                    {
                        return;
                    }
                }
            }

            tsmiNewScript.Enabled = true;
            tsmiOpenScript.Enabled = true;
            tsmiSaveScript.Enabled = false;
            tsmiSaveAsScript.Enabled = false;
            tsmiCloseScript.Enabled = false;

            Text = "Script Editor";

            Script = null;

            _scriptFileName = string.Empty;

            chkKeepOldMaxStack.Checked = false;

            _checkChanges = false;

            if (tabTargetOptions.SelectedIndex != 0)
            {
                tabTargetOptions.SelectedTab = tpTargetList;
            }

            PatchList.Clear();

            RefreshPatchList();

            grpPatchList.Enabled = false;

            dgvTargetList.Rows.Clear();

            txtFilePath.Text = string.Empty;

            btnAddTargetFile.Text = "Add";

            dgvTargetFiles.Rows.Clear();
        }

        private void TsmiAddTarget_Click(object sender, EventArgs e)
        {
            FrmAddTarget.Instance.Text = "Add Target";
            FrmAddTarget.Instance.btnSave.Text = "Save";
            FrmAddTarget.Instance.SelectedTargetId = -1;
            FrmAddTarget.Instance.ShowDialog();
        }

        private void TsmiEditTarget_Click(object sender, EventArgs e)
        {
            if (dgvTargetList.SelectedRows.Count > 0)
            {
                FrmAddTarget.Instance.Text = "Edit Target";
                FrmAddTarget.Instance.btnSave.Text = "Update";
                FrmAddTarget.Instance.SelectedTargetId = dgvTargetList.SelectedRows[0].Index;
                FrmAddTarget.Instance.ShowDialog();
            }
        }

        private void TsmiRemoveTarget_Click(object sender, EventArgs e)
        {
            if (dgvTargetList.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvTargetList.SelectedRows[0].Index;

                PatchList[cmbPatchList.SelectedIndex].TargetList.RemoveAt(selectedIndex);
                dgvTargetList.Rows.RemoveAt(selectedIndex);

                CheckChanges();
            }
        }

        private void TsmiEditTargetFile_Click(object sender, EventArgs e)
        {
            if (dgvTargetFiles.SelectedRows.Count > 0)
            {
                _selectedTargetFileIndex = dgvTargetFiles.SelectedRows[0].Index;

                txtFilePath.Text = dgvTargetFiles.SelectedRows[0].Cells[0].Value.ToString().EmptyIfNull();

                btnAddTargetFile.Text = "Update";
            }
        }

        private void TsmiRemoveTargetFile_Click(object sender, EventArgs e)
        {
            if (dgvTargetFiles.SelectedRows.Count > 0)
            {
                dgvTargetFiles.Rows.RemoveAt(dgvTargetFiles.SelectedRows[0].Index);

                ResetAddTargetFile();

                AddTargetFilesToSelectedPatch();
            }
        }

        private void CmbPatchList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPatchList.SelectedIndex != -1)
            {
                if (grpTargetOptions.Enabled == false)
                {
                    grpTargetOptions.Enabled = true;
                }

                var targetList = PatchList[cmbPatchList.SelectedIndex].TargetList;

                if (dgvTargetList.Rows.Count > 0)
                {
                    dgvTargetList.Rows.Clear();
                }

                if (targetList != null)
                {
                    if (targetList.Count > 0)
                    {
                        foreach (var target in targetList)
                        {
                            dgvTargetList.Rows.Add($"[{target.Action}]", target.FullName);
                        }
                    }
                }

                var targetFiles = PatchList[cmbPatchList.SelectedIndex].TargetInfo.TargetFiles;

                if (dgvTargetFiles.Rows.Count > 0)
                {
                    dgvTargetFiles.Rows.Clear();
                }

                if (targetFiles != null)
                {
                    if (targetFiles.Count > 0)
                    {
                        foreach (var targetFile in targetFiles)
                        {
                            dgvTargetFiles.Rows.Add(targetFile);
                        }
                    }
                }

                chkKeepOldMaxStack.Checked = PatchList[cmbPatchList.SelectedIndex].TargetInfo.KeepOldMaxStack;
            }
            else
            {
                grpTargetOptions.Enabled = false;
            }
        }

        private void TxtFilePath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop"))
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }

            e.Effect = DragDropEffects.None;
        }

        private void TxtFilePath_DragDrop(object sender, DragEventArgs e)
        {
            txtFilePath.Text = (e.Data.GetData("FileDrop") as string[])?[0];
        }

        private void ChkKeepOldMaxStack_CheckedChanged(object sender, EventArgs e)
        {
            if (PatchList.Count > 0 && PatchList[cmbPatchList.SelectedIndex]?.TargetInfo != null)
            {
                PatchList[cmbPatchList.SelectedIndex].TargetInfo.KeepOldMaxStack = chkKeepOldMaxStack.Checked;

                CheckChanges();
            }
        }

        private void TsmiMoveUpTarget_Click(object sender, EventArgs e)
        {
            if (dgvTargetList.SelectedRows.Count > 0)
            {
                PatchList[cmbPatchList.SelectedIndex].TargetList.MoveUp(dgvTargetList.SelectedRows[0].Index);

                dgvTargetList.MoveUp();
            }
        }

        private void TsmiMoveDownTarget_Click(object sender, EventArgs e)
        {
            if (dgvTargetList.SelectedRows.Count > 0)
            {
                PatchList[cmbPatchList.SelectedIndex].TargetList.MoveDown(dgvTargetList.SelectedRows[0].Index);

                dgvTargetList.MoveDown();
            }
        }

        private void TsmiMoveUpTargetFile_Click(object sender, EventArgs e)
        {
            if (dgvTargetFiles.SelectedRows.Count > 0)
            {
                dgvTargetFiles.MoveUp();

                ResetAddTargetFile();

                AddTargetFilesToSelectedPatch();
            }
        }

        private void TsmiMoveDownTargetFile_Click(object sender, EventArgs e)
        {
            if (dgvTargetFiles.SelectedRows.Count > 0)
            {
                dgvTargetFiles.MoveDown();

                ResetAddTargetFile();

                AddTargetFilesToSelectedPatch();
            }
        }

        private void RefreshPatchList()
        {
            cmbPatchList.DataSource = null;
            cmbPatchList.DataSource = PatchList;
        }

        private bool SaveAsScript()
        {
            try
            {
                CheckScript();

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "DNUP files (.dnup)|*.dnup|All files (*.*)|*.*";
                    sfd.OverwritePrompt = true;
                    sfd.FileName = $"{Script.PatcherOptions.PatcherInfo.Software}.dnup";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var script = JsonConvert.SerializeObject(Script, new JsonSerializerSettings
                        {
                            Formatting = Formatting.Indented,
                            DefaultValueHandling = DefaultValueHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore,
                            DateFormatString = "dd.MM.yyyy"
                        });

                        File.WriteAllText(sfd.FileName, script);

                        if (_scriptFileName == string.Empty)
                        {
                            _scriptFileName = sfd.FileName;

                            Text = $"Script Editor - ({_scriptFileName})";
                        }

                        tsmiNewScript.Enabled = true;
                        tsmiOpenScript.Enabled = true;
                        tsmiSaveScript.Enabled = true;
                        tsmiSaveAsScript.Enabled = true;
                        tsmiCloseScript.Enabled = true;

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.ExceptionMessageBox(ex);
            }

            return false;
        }

        private void CheckScript()
        {
            Script.PatchList = PatchList;

            ScriptEngineHelpers.ValidateScript(Script);

            if (Script.PatcherOptions.Placeholders != null)
            {
                if (Script.PatcherOptions.Placeholders.Count == 0)
                {
                    Script.PatcherOptions.Placeholders = null;
                }
                else
                {
                    foreach (var placeholder in Script.PatcherOptions.Placeholders)
                    {
                        if (placeholder.Key == string.Empty)
                        {
                            throw new Exception($"Placeholder Key is empty!\r\nPlaceholder Value -> \"{placeholder.Value}\"");
                        }
                    }
                }
            }

            if (Script.PatchList != null)
            {
                if (Script.PatchList.Count == 0)
                {
                    throw new Exception("Patch List is Empty!");
                }

                foreach (var patch in Script.PatchList)
                {
                    if (patch.TargetList.Count == 0)
                    {
                        throw new Exception("Target List is Empty!");
                    }

                    foreach (var target in patch.TargetList)
                    {
                        switch (target.Action)
                        {
                            case ActionMethod.Patch:
                                target.Indices = null;
                                target.Optional = null;
                                break;

                            case ActionMethod.Insert:
                                target.Optional = null;
                                break;

                            case ActionMethod.Replace:
                                target.Optional = null;
                                break;

                            case ActionMethod.Remove:
                                target.ILCodes = null;
                                target.Optional = null;
                                break;

                            case ActionMethod.EmptyBody:
                                target.ILCodes = null;
                                target.Indices = null;
                                target.Optional = null;
                                break;

                            case ActionMethod.ReturnBody:
                                target.ILCodes = null;
                                target.Indices = null;
                                break;
                        }

                        if (target.Action == ActionMethod.Patch || target.Action == ActionMethod.Insert || target.Action == ActionMethod.Replace)
                        {
                            if (target.ILCodes != null && target.ILCodes.Count == 0)
                            {
                                throw new Exception($"Instructions are Empty!\r\nTarget -> {target.FullName}");
                            }
                        }

                        if (target.Indices != null)
                        {
                            bool checkIndices = false;

                            foreach (string index in target.Indices)
                            {
                                checkIndices = index == string.Empty;

                                if (checkIndices)
                                {
                                    if (target.Action == ActionMethod.Insert || target.Action == ActionMethod.Replace || target.Action == ActionMethod.Remove)
                                    {
                                        throw new Exception($"Indices are empty! -> {target.FullName}");
                                    }
                                }
                            }

                            if (checkIndices || target.Indices.Count == 0)
                            {
                                target.Indices = null;
                            }
                        }
                    }
                }
            }
        }

        internal void CheckChanges()
        {
            if (_checkChanges == false)
            {
                _checkChanges = true;
            }
        }

        private void ResetAddTargetFile()
        {
            if (btnAddTargetFile.Text == "Update")
            {
                btnAddTargetFile.Text = "Add";
                _selectedTargetFileIndex = -1;
            }
        }

        private void AddTargetFilesToSelectedPatch()
        {
            int selectedPatchIndex = cmbPatchList.SelectedIndex;

            PatchList[selectedPatchIndex].TargetInfo.TargetFiles.Clear();

            foreach (DataGridViewRow dgvr in dgvTargetFiles.Rows)
            {
                PatchList[selectedPatchIndex].TargetInfo.TargetFiles.Add(dgvr.Cells[0].Value.ToString());
            }
        }
    }
}