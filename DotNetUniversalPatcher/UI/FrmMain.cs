using DotNetUniversalPatcher.Engine;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DotNetUniversalPatcher.UI
{
    public partial class FrmMain : Form
    {
        internal static FrmMain Instance { get; set; }

        internal IScriptEngine Engine;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Text = Helpers.BuildTitle();

            Engine = new ScriptEngine();

            ScriptEngineHelpers.AddSpecialFoldersToPlaceholders();

            RefreshScripts();
        }

        private void BtnPatch_Click(object sender, EventArgs e)
        {
            if (cmbSoftware.SelectedIndex > -1)
            {
                btnPatch.Enabled = false;

                SetLogVisible(true);

                Logger.Log("---START PATCHING---");
                Logger.Log();

                Engine.Process();

                Logger.Log();
                Logger.Log("---PATCHING DONE---");

                btnPatch.Enabled = true;
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            FrmAbout.Instance.AboutScriptText = Engine.CurrentScript.PatcherOptions?.PatcherInfo.AboutText;
            FrmAbout.Instance.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtWebsite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Helpers.VisitWebsite(txtWebsite.Text);
        }

        private void CmbSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSoftware.SelectedIndex > -1)
            {
                Engine.ChangeScript();

                txtAuthor.Text = Engine.CurrentScript.PatcherOptions.PatcherInfo.Author;
                txtWebsite.Text = Engine.CurrentScript.PatcherOptions.PatcherInfo.Website;

                txtReleaseDate.Text = Engine.CurrentScript.PatcherOptions.PatcherInfo.ReleaseDate != null ? ((DateTime)Engine.CurrentScript.PatcherOptions.PatcherInfo.ReleaseDate).ToString("d") : string.Empty;
                txtReleaseInfo.Text = Engine.CurrentScript.PatcherOptions.PatcherInfo.ReleaseInfo;

                txtTargetFiles.Clear();
                txtTargetFiles.Text += string.Join(", ", Engine.CurrentScript.TargetFilesText);

                chkMakeBackup.Checked = Convert.ToBoolean(Engine.CurrentScript.PatcherOptions.PatcherInfo.MakeBackup);

                SetLogVisible(Engine.IsLoadingError, Engine.IsLoadingError);
            }
        }

        private void ChkMakeBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbSoftware.Items.Count > 0)
            {
                Engine.CurrentScript.PatcherOptions.PatcherInfo.MakeBackup = chkMakeBackup.Checked;
            }
        }

        private void TxtTargetFiles_MouseHover(object sender, EventArgs e)
        {
            if (tipLogItem.GetToolTip(txtTargetFiles) != Engine.CurrentScript.TargetFilesTip)
            {
                tipTargetFiles.SetToolTip(txtTargetFiles, Engine.CurrentScript.TargetFilesTip);
            }
        }

        private void LstLog_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lstLog.IndexFromPoint(e.Location);

            if (index != -1)
            {
                string tip = lstLog.Items[index].ToString();

                if (tipLogItem.GetToolTip(lstLog) != tip)
                {
                    tipLogItem.SetToolTip(lstLog, tip);
                }
            }
        }

        private void LstLog_MouseLeave(object sender, EventArgs e)
        {
            tipLogItem.SetToolTip(lstLog, string.Empty);
        }

        private void LstLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C && lstLog.Items.Count > 0)
            {
                Helpers.CopyTextToClipboard(lstLog.Items[lstLog.SelectedIndex].ToString());
            }
        }

        private void TsmiScriptEditor_Click(object sender, EventArgs e)
        {
            FrmScriptEditor.Instance.ShowDialog();
        }

        private void TsmiRefresh_Click(object sender, EventArgs e)
        {
            RefreshScripts();
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            FrmAbout.Instance.AboutScriptText = null;
            FrmAbout.Instance.ShowDialog();
        }

        private void RefreshScripts()
        {
            Engine.LoadedScripts = new List<PatcherScript>();
            Engine.CurrentScript = new PatcherScript();

            Engine.LoadAndParseScripts();

            cmbSoftware.Items.Clear();

            cmbSoftware.Items.AddRange(Engine.GetSoftwareNames());

            if (cmbSoftware.Items.Count > 0)
            {
                cmbSoftware.SelectedIndex = 0;
            }
            else
            {
                SetLogVisible(Engine.IsLoadingError, Engine.IsLoadingError);
            }
        }

        private void SetLogVisible(bool trueOrFalse, bool error = false)
        {
            if (error && lstLog.Items.Count > 0)
            {
                Engine.IsLoadingError = false;
            }
            else
            {
                Logger.ClearLogs();
            }

            if (trueOrFalse)
            {
                grpReleaseInfo.Text = "Log";
                lstLog.Visible = true;
            }
            else
            {
                grpReleaseInfo.Text = "Release Info";
                lstLog.Visible = false;
            }
        }
    }
}