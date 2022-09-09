using DotNetUniversalPatcher.Engine;
using DotNetUniversalPatcher.Extensions;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DotNetUniversalPatcher.Properties;

namespace DotNetUniversalPatcher.UI
{
    public partial class FrmScriptEditor : Form
    {
        internal static FrmScriptEditor Instance { get; } = new FrmScriptEditor();

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
            btnAddTargetFile.Text = Resources.FrmScriptEditor_AddTargetFile_Text;
        }

        private void BtnAddPatch_Click(object sender, EventArgs e)
        {
            PatchList.Add(new Patch(string.Format(Resources.FrmScriptEditor_TsmiOpenScript_PatchName_Text, _patchCount++)));

            RefreshPatchList();

            CheckChanges();
        }

        private void BtnRemovePatch_Click(object sender, EventArgs e)
        {
            if (cmbPatchList.SelectedIndex > -1 && MessageBox.Show(
                    string.Format(Resources.FrmScriptEditor_BtnRemovePatch_Msg, cmbPatchList.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PatchList.RemoveAt(cmbPatchList.SelectedIndex);

                RefreshPatchList();

                CheckChanges();
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
                    ofd.Filter = Resources.ScriptEngine_Process_Filter_ExtName;
                    ofd.CheckFileExists = true;
                    ofd.RestoreDirectory = true;

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
                Helpers.CustomMessageBox(Resources.FrmScriptEditor_BtnAddTargetFile_Target_File_Path_is_empty_Msg);
                return;
            }

            if (btnAddTargetFile.Text == Resources.FrmScriptEditor_AddTargetFile_Text)
            {
                dgvTargetFiles.Rows.Add(txtFilePath.Text);
            }
            else if (btnAddTargetFile.Text == Resources.FrmScriptEditor_TsmiEditTargetFile_Update_Text)
            {
                dgvTargetFiles.Rows[_selectedTargetFileIndex].Cells[0].Value = txtFilePath.Text;

                _selectedTargetFileIndex = -1;

                btnAddTargetFile.Text = Resources.FrmScriptEditor_AddTargetFile_Text;
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
                DialogResult question = MessageBox.Show(Resources.FrmScriptEditor_TsmiCloseScript_Message, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

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

            Text = string.Format("{0} - (New Script)", Resources.FrmScriptEditor_Script_Editor_Text);

            PatchList.Clear();

            RefreshPatchList();

            grpPatchList.Enabled = true;

            dgvTargetList.Rows.Clear();

            txtFilePath.Text = string.Empty;

            btnAddTargetFile.Text = Resources.FrmScriptEditor_AddTargetFile_Text;

            dgvTargetFiles.Rows.Clear();
        }

        private void TsmiOpenScript_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Filter = string.Format("DNUP files (.{0})|*.{1}|All files (*.*)|*.*",
                        Constants.ScriptFileExtension, Constants.ScriptFileExtension);
                    ofd.CheckFileExists = true;
                    ofd.RestoreDirectory = true;

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
                            patch.Name = string.Format(Resources.FrmScriptEditor_TsmiOpenScript_PatchName_Text, _patchCount++);

                            PatchList.Add(patch);
                        }

                        RefreshPatchList();

                        Text = string.Format("{0} - ({1})", Resources.FrmScriptEditor_Script_Editor_Text, ofd.FileName);

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

                    Text = string.Format("{0} - ({1})", Resources.FrmScriptEditor_Script_Editor_Text, _scriptFileName);

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
                DialogResult question = MessageBox.Show(Resources.FrmScriptEditor_TsmiCloseScript_Message, "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

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

            Text = Resources.FrmScriptEditor_Script_Editor_Text;

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

            btnAddTargetFile.Text = Resources.FrmScriptEditor_AddTargetFile_Text;

            dgvTargetFiles.Rows.Clear();
        }

        private void TsmiAddTarget_Click(object sender, EventArgs e)
        {
            FrmAddTarget.Instance.Text = Resources.FrmAddTarget_Add_Target_Text;
            FrmAddTarget.Instance.btnSave.Text = Resources.FrmAddTarget_Save_Text;
            FrmAddTarget.Instance.SelectedTargetId = -1;
            FrmAddTarget.Instance.ShowDialog();
        }

        private void TsmiEditTarget_Click(object sender, EventArgs e)
        {
            if (dgvTargetList.SelectedRows.Count > 0)
            {
                FrmAddTarget.Instance.Text = Resources.FrmScriptEditor_TsmiEditTarget_Text;
                FrmAddTarget.Instance.btnSave.Text = Resources.FrmScriptEditor_btnSave_Update_Text;
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

                txtFilePath.Text = dgvTargetFiles.SelectedRows[0].Cells[0].Value?.ToString().EmptyIfNull();

                btnAddTargetFile.Text = Resources.FrmScriptEditor_TsmiEditTargetFile_Update_Text;
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
                            dgvTargetList.Rows.Add(string.Format("[{0}]", target.Action), target.FullName);
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
                    sfd.Filter = string.Format("DNUP files (.{0})|*.{1}|All files (*.*)|*.*",
                        Constants.ScriptFileExtension, Constants.ScriptFileExtension);
                    sfd.FileName = string.Format("{0}.{1}", Script.PatcherOptions.PatcherInfo.Software,
                        Constants.ScriptFileExtension);
                    sfd.InitialDirectory = Constants.PatchersDir;
                    sfd.OverwritePrompt = true;

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

                            Text = string.Format("{0} - ({1})", Resources.FrmScriptEditor_Script_Editor_Text, _scriptFileName);
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
                            throw new Exception(string.Format(
                                Resources.FrmScriptEditor_CheckScript_Placeholder_Key_is_empty_Msg, placeholder.Value));
                        }
                    }
                }
            }

            if (Script.PatchList != null)
            {
                if (Script.PatchList.Count == 0)
                {
                    throw new Exception(Resources.FrmScriptEditor_CheckScript_Patch_List_is_Empty_Msg);
                }

                foreach (var patch in Script.PatchList)
                {
                    if (patch.TargetList.Count == 0)
                    {
                        throw new Exception(Resources.FrmScriptEditor_CheckScript_Target_List_is_Empty_Msg);
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
                                throw new Exception(string.Format(Resources.FrmScriptEditor_CheckScript_Instructions_are_Empty_Msg,
                                    target.FullName));
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
                                        throw new Exception(string.Format(Resources.FrmScriptEditor_CheckScript_Indices_are_empty_Msg, target.FullName));
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
            if (btnAddTargetFile.Text == Resources.FrmScriptEditor_TsmiEditTargetFile_Update_Text)
            {
                btnAddTargetFile.Text = Resources.FrmScriptEditor_AddTargetFile_Text;
                _selectedTargetFileIndex = -1;
            }
        }

        private void AddTargetFilesToSelectedPatch()
        {
            int selectedPatchIndex = cmbPatchList.SelectedIndex;

            PatchList[selectedPatchIndex].TargetInfo.TargetFiles.Clear();

            foreach (DataGridViewRow dgvr in dgvTargetFiles.Rows)
            {
                PatchList[selectedPatchIndex].TargetInfo.TargetFiles.Add(dgvr.Cells[0].Value?.ToString());
            }
        }
    }
}