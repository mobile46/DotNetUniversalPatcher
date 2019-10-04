using DotNetUniversalPatcher.Engine;
using DotNetUniversalPatcher.Utilities;
using System;
using System.Text;
using System.Windows.Forms;

namespace DotNetUniversalPatcher.UI
{
    public partial class FrmMain : Form
    {
        public static FrmMain Instance;

        internal IScriptEngine Engine;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Text = BuildTitle();

            Engine = new ScriptEngine();

            ScriptEngineHelpers.AddSpecialFoldersToPlaceholders();

            Engine.LoadAndParseScripts();

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

        private void BtnPatch_Click(object sender, EventArgs e)
        {
            if (cmbSoftware.Items.Count > 0)
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
            if (cmbSoftware.Items.Count > 0)
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
                try
                {
                    Clipboard.SetText(lstLog.Items[lstLog.SelectedIndex].ToString());
                }
                catch
                {
                    // ignored
                }
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

        private string BuildTitle()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Constants.TitleAndVersion);

            if (Program.IsDebugModeEnabled)
            {
                sb.Append(" (Debug)");
            }

            if (Helpers.IsAdministrator())
            {
                sb.Append(" (Administrator)");
            }

            return sb.ToString();
        }

        private void ScriptEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScriptEditor.Instance.ShowDialog();
        }
    }
}