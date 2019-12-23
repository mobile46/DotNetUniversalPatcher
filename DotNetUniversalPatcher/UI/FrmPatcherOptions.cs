using DotNetUniversalPatcher.Engine;
using DotNetUniversalPatcher.Extensions;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.Utilities;
using System;
using System.Windows.Forms;

namespace DotNetUniversalPatcher.UI
{
    public partial class FrmPatcherOptions : Form
    {
        internal static FrmPatcherOptions Instance { get; } = new FrmPatcherOptions();

        private int _selectedPlaceholderIndex;

        public FrmPatcherOptions()
        {
            InitializeComponent();
        }

        private void FrmPatcherOptions_Load(object sender, EventArgs e)
        {
            tabPatcherOptions.SelectedTab = tpPatcherOptions;

            var patcherInfo = FrmScriptEditor.Instance.Script.PatcherOptions.PatcherInfo;

            if (patcherInfo != null)
            {
                txtSoftwareName.Text = patcherInfo.Software;
                txtAuthor.Text = patcherInfo.Author;
                txtWebsite.Text = patcherInfo.Website;

                dtpReleaseDate.Value = patcherInfo.ReleaseDate != null ? Convert.ToDateTime(patcherInfo.ReleaseDate) : DateTime.Now;

                txtReleaseInfo.Text = patcherInfo.ReleaseInfo;
                txtAboutText.Text = patcherInfo.AboutText;
                chkMakeBackup.Checked = Convert.ToBoolean(patcherInfo.MakeBackup);
            }

            dgvPlaceholders.Rows.Clear();

            var placeholders = FrmScriptEditor.Instance.Script.PatcherOptions.Placeholders;

            if (placeholders != null)
            {
                foreach (var placeholder in placeholders)
                {
                    dgvPlaceholders.Rows.Add(placeholder.Key, placeholder.Value);
                }
            }

            if (dgvReservedPlaceholders.Rows.Count == 0)
            {
                foreach (var placeholder in ScriptEngineHelpers.ReservedPlaceholders)
                {
                    dgvReservedPlaceholders.Rows.Add(placeholder.Key, placeholder.Value);
                }
            }

            txtPlaceholderKey.Text = string.Empty;
            txtPlaceholderValue.Text = string.Empty;

            btnAddPlaceholder.Text = "Add";
            _selectedPlaceholderIndex = -1;
        }

        private void BtnVisit_Click(object sender, EventArgs e)
        {
            Helpers.VisitWebsite(txtWebsite.Text);
        }

        private void BtnToday_Click(object sender, EventArgs e)
        {
            dtpReleaseDate.Value = DateTime.Today;
        }

        private void BtnAddPlaceholder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlaceholderKey.Text))
            {
                Helpers.CustomMessageBox("Placeholder Key is empty!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPlaceholderValue.Text))
            {
                Helpers.CustomMessageBox("Placeholder Value is empty!");
                return;
            }

            if (btnAddPlaceholder.Text == "Add")
            {
                dgvPlaceholders.Rows.Add(txtPlaceholderKey.Text.EmptyIfNull(), txtPlaceholderValue.Text.EmptyIfNull());
            }
            else if (btnAddPlaceholder.Text == "Update")
            {
                dgvPlaceholders.Rows[_selectedPlaceholderIndex].Cells[0].Value = txtPlaceholderKey.Text.EmptyIfNull();
                dgvPlaceholders.Rows[_selectedPlaceholderIndex].Cells[1].Value = txtPlaceholderValue.Text.EmptyIfNull();

                _selectedPlaceholderIndex = -1;

                btnAddPlaceholder.Text = "Add";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (txtPlaceholderKey.TextLength > 0 || txtPlaceholderValue.TextLength > 0)
            {
                txtPlaceholderKey.Text = string.Empty;
                txtPlaceholderValue.Text = string.Empty;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoftwareName.Text))
            {
                Helpers.CustomMessageBox("Software Name is empty!");

                if (tabPatcherOptions.SelectedIndex != 0)
                {
                    tabPatcherOptions.SelectedTab = tpPatcherOptions;
                }

                txtSoftwareName.Focus();
                return;
            }

            FrmScriptEditor.Instance.Script.PatcherOptions = new PatcherOptions
            {
                PatcherInfo = new PatcherInfo
                {
                    Software = txtSoftwareName.Text,
                    Author = txtAuthor.Text,
                    Website = txtWebsite.Text,
                    ReleaseDate = dtpReleaseDate.Value,
                    ReleaseInfo = txtReleaseInfo.Text,
                    AboutText = txtAboutText.Text,
                    MakeBackup = chkMakeBackup.Checked
                }
            };

            FrmScriptEditor.Instance.Script.PatcherOptions.Placeholders.Clear();

            foreach (DataGridViewRow dgvr in dgvPlaceholders.Rows)
            {
                string key = dgvr.Cells[0].Value?.ToString().Replace("#", string.Empty);

                if (!FrmScriptEditor.Instance.Script.PatcherOptions.Placeholders.ContainsKey(key))
                {
                    FrmScriptEditor.Instance.Script.PatcherOptions.Placeholders.Add(key, dgvr.Cells[1].Value?.ToString());
                }
                else
                {
                    Helpers.CustomMessageBox($"\"{key}\" Placeholder already exists!");

                    if (tabPatcherOptions.SelectedIndex != 1)
                    {
                        tabPatcherOptions.SelectedTab = tpPlaceholders;
                    }

                    FrmScriptEditor.Instance.Script.PatcherOptions.Placeholders.Clear();
                    return;
                }
            }

            FrmScriptEditor.Instance.CheckChanges();

            Helpers.CustomMessageBox("Patcher Options are successfully saved!");
        }

        private void TsmiEditPlaceholder_Click(object sender, EventArgs e)
        {
            if (dgvPlaceholders.SelectedRows.Count > 0)
            {
                _selectedPlaceholderIndex = dgvPlaceholders.SelectedRows[0].Index;

                txtPlaceholderKey.Text = dgvPlaceholders.Rows[_selectedPlaceholderIndex].Cells[0].Value?.ToString().EmptyIfNull();
                txtPlaceholderValue.Text = dgvPlaceholders.Rows[_selectedPlaceholderIndex].Cells[1].Value?.ToString().EmptyIfNull();

                btnAddPlaceholder.Text = "Update";
            }
        }

        private void TsmiRemovePlaceholder_Click(object sender, EventArgs e)
        {
            if (dgvPlaceholders.SelectedRows.Count > 0)
            {
                dgvPlaceholders.Rows.RemoveAt(dgvPlaceholders.SelectedRows[0].Index);

                if (btnAddPlaceholder.Text == "Update")
                {
                    btnAddPlaceholder.Text = "Add";
                    _selectedPlaceholderIndex = -1;
                }
            }
        }

        private void TsmiMoveUpPlaceholder_Click(object sender, EventArgs e)
        {
            if (dgvPlaceholders.SelectedRows.Count > 0)
            {
                dgvPlaceholders.MoveUp();

                ResetAddPlaceholder();
            }
        }

        private void TsmiMoveDownPlaceholder_Click(object sender, EventArgs e)
        {
            if (dgvPlaceholders.SelectedRows.Count > 0)
            {
                dgvPlaceholders.MoveDown();

                ResetAddPlaceholder();
            }
        }

        private void ResetAddPlaceholder()
        {
            if (btnAddPlaceholder.Text == "Update")
            {
                btnAddPlaceholder.Text = "Add";
                _selectedPlaceholderIndex = -1;
            }
        }

        private void DgvReservedPlaceholders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Helpers.CopyTextToClipboard(dgvReservedPlaceholders.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}