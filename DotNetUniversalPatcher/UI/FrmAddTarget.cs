using dnlib.DotNet.Emit;
using DotNetUniversalPatcher.Extensions;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DotNetUniversalPatcher.UI
{
    public partial class FrmAddTarget : Form
    {
        internal static FrmAddTarget Instance = new FrmAddTarget();

        public static List<OpCode> OpCodes;

        internal int SelectedTargetId;

        internal int SelectedActionMethod;
        internal int SelectedInstructionIndex;
        internal OpCode SelectedOpCode;

        public FrmAddTarget()
        {
            InitializeComponent();
        }

        private void FrmAddTarget_Load(object sender, EventArgs e)
        {
            if (cmbActionMethod.Items.Count == 0)
            {
                foreach (var action in Enum.GetNames(typeof(ActionMethod)))
                {
                    cmbActionMethod.Items.Add(action);
                }
            }

            if (cmbOpCodes.Items.Count == 0)
            {
                LoadOpCodes();
                cmbOpCodes.Items.AddRange(OpCodes.ToArray());
            }

            txtFullName.Text = string.Empty;
            cmbActionMethod.SelectedIndex = -1;
            cmbOptional.SelectedIndex = -1;

            ClearControls();

            if (dgvInstructions.Rows.Count > 0)
            {
                dgvInstructions.Rows.Clear();
            }

            btnAddTarget.Text = "Add";

            if (Text == "Edit Target")
            {
                var selectedPatchIndex = FrmScriptEditor.Instance.cmbPatchList.SelectedIndex;

                var target = FrmScriptEditor.Instance.PatchList[selectedPatchIndex].TargetList[SelectedTargetId];

                txtFullName.Text = target.FullName;

                if (target.Action != null)
                {
                    cmbActionMethod.SelectedIndex = (int)target.Action;
                }

                switch (target.Optional?.ToLowerInvariant())
                {
                    case "true":
                        cmbOptional.SelectedIndex = 0;
                        break;

                    case "false":
                        cmbOptional.SelectedIndex = 1;
                        break;

                    default:
                        cmbOptional.SelectedIndex = -1;
                        break;
                }

                for (var i = 0; i < target.ILCodes?.Count; i++)
                {
                    var ilCode = target.ILCodes?[i];

                    dgvInstructions.Rows.Add(target.Indices?.Count > 0 ? target.Indices[i] : string.Empty as object, ilCode?.OpCode, ilCode?.Operand);
                }
            }
        }

        private void BtnAddTarget_Click(object sender, EventArgs e)
        {
            if (SelectedActionMethod == -1)
            {
                Helpers.CustomMessageBox("Action Method is empty!");
                cmbActionMethod.Focus();
                return;
            }

            switch (SelectedActionMethod)
            {
                case (int)ActionMethod.Insert:
                case (int)ActionMethod.Replace:
                case (int)ActionMethod.Remove:
                    {
                        if (string.IsNullOrWhiteSpace(txtIndex.Text))
                        {
                            Helpers.CustomMessageBox("Index is empty!");
                            txtIndex.Focus();
                            return;
                        }

                        break;
                    }
            }

            switch (SelectedActionMethod)
            {
                case (int)ActionMethod.Patch:
                case (int)ActionMethod.Insert:
                case (int)ActionMethod.Replace:
                    {
                        if (cmbOpCodes.SelectedIndex == -1)
                        {
                            Helpers.CustomMessageBox("OpCode is empty!");
                            cmbOpCodes.Focus();
                            return;
                        }

                        break;
                    }
            }

            if (btnAddTarget.Text == "Add")
            {
                string[] cells = new string[3];

                cells[0] = txtIndex.Text != string.Empty ? txtIndex.Text : string.Empty;
                cells[1] = cmbOpCodes.Text != string.Empty ? cmbOpCodes.Text : string.Empty;

                if (SelectedOpCode != null)
                {
                    switch (SelectedOpCode.OperandType)
                    {
                        case OperandType.InlineNone:
                        case OperandType.InlinePhi:
                        case OperandType.NOT_USED_8:
                            cells[2] = string.Empty;
                            break;

                        default:
                            cells[2] = txtOperand.Text;
                            break;
                    }
                }

                dgvInstructions.Rows.Add(cells);
            }
            else if (btnAddTarget.Text == "Update")
            {
                dgvInstructions.Rows[SelectedInstructionIndex].Cells[0].Value = txtIndex.Text;
                dgvInstructions.Rows[SelectedInstructionIndex].Cells[1].Value = cmbOpCodes.Text;

                if (SelectedOpCode != null)
                {
                    switch (SelectedOpCode.OperandType)
                    {
                        case OperandType.InlineNone:
                        case OperandType.InlinePhi:
                        case OperandType.NOT_USED_8:
                            dgvInstructions.Rows[SelectedInstructionIndex].Cells[2].Value = string.Empty;
                            break;

                        default:
                            dgvInstructions.Rows[SelectedInstructionIndex].Cells[2].Value = txtOperand.Text;
                            break;
                    }
                }

                btnAddTarget.Text = "Add";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (txtIndex.TextLength > 0 || cmbOpCodes.SelectedIndex != -1 || txtOperand.TextAlign > 0)
            {
                ClearControls();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                Helpers.CustomMessageBox("Full Name is empty!");
                txtFullName.Focus();
                return;
            }

            if (SelectedActionMethod == (int)ActionMethod.ReturnBody && cmbOptional.SelectedIndex == -1)
            {
                Helpers.CustomMessageBox("Optional is empty!");
                cmbOptional.Focus();
                return;
            }

            var selectedPatchIndex = FrmScriptEditor.Instance.cmbPatchList.SelectedIndex;

            List<ILCode> ilCodes = new List<ILCode>();
            List<object> indices = new List<object>();

            foreach (DataGridViewRow dgvInstructionsRow in dgvInstructions.Rows)
            {
                indices.Add(dgvInstructionsRow.Cells[0].Value == null ? string.Empty : dgvInstructionsRow.Cells[0].Value.ToString());
                ilCodes.Add(new ILCode { OpCode = dgvInstructionsRow.Cells[1].Value == null ? string.Empty : dgvInstructionsRow.Cells[1].Value.ToString(), Operand = dgvInstructionsRow.Cells[2].Value == null ? string.Empty : dgvInstructionsRow.Cells[2].Value.ToString() });
            }

            if (btnSave.Text == "Save")
            {
                FrmScriptEditor.Instance.PatchList[selectedPatchIndex].TargetList.Add(new Target
                {
                    FullName = txtFullName.Text,
                    Action = (ActionMethod)cmbActionMethod.SelectedIndex,
                    Optional = cmbOptional.Text,
                    ILCodes = ilCodes,
                    Indices = indices
                });

                FrmScriptEditor.Instance.dgvTargetList.Rows.Add($"[{cmbActionMethod.Text}]", txtFullName.Text);

                SelectedTargetId = FrmScriptEditor.Instance.PatchList[selectedPatchIndex].TargetList.Count - 1;

                btnSave.Text = "Update";
            }
            else if (btnSave.Text == "Update")
            {
                var selectedTarget = FrmScriptEditor.Instance.PatchList[selectedPatchIndex].TargetList[SelectedTargetId];

                selectedTarget.FullName = txtFullName.Text;
                selectedTarget.Action = (ActionMethod)cmbActionMethod.SelectedIndex;
                selectedTarget.Optional = cmbOptional.Text;
                selectedTarget.ILCodes = ilCodes;
                selectedTarget.Indices = indices;

                FrmScriptEditor.Instance.dgvTargetList.Rows[SelectedTargetId].Cells[0].Value = $"[{cmbActionMethod.Text}]";
                FrmScriptEditor.Instance.dgvTargetList.Rows[SelectedTargetId].Cells[1].Value = txtFullName.Text;
            }

            FrmScriptEditor.Instance.CheckChanges();
        }

        private void CmbActionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedActionMethod = cmbActionMethod.SelectedIndex;

            cmbOptional.Enabled = cmbActionMethod.SelectedIndex == (int)ActionMethod.ReturnBody;

            txtIndex.Enabled = SelectedActionMethod != (int)ActionMethod.Patch;

            if (SelectedActionMethod == (int)ActionMethod.Remove)
            {
                cmbOpCodes.Enabled = false;
                txtOperand.Enabled = false;
            }
            else
            {
                cmbOpCodes.Enabled = true;
                txtOperand.Enabled = true;
            }

            if (SelectedActionMethod == (int)ActionMethod.EmptyBody || SelectedActionMethod == (int)ActionMethod.ReturnBody)
            {
                grpInstructions.Enabled = false;
                grpAddInstruction.Enabled = false;
            }
            else
            {
                grpInstructions.Enabled = true;
                grpAddInstruction.Enabled = true;
            }
        }

        private void CmbOpCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOpCodes.SelectedIndex != -1)
            {
                SelectedOpCode = (OpCode)cmbOpCodes.SelectedItem;

                switch (SelectedOpCode.OperandType)
                {
                    case OperandType.InlineNone:
                    case OperandType.InlinePhi:
                    case OperandType.NOT_USED_8:
                        txtOperand.Enabled = false;
                        break;

                    default:
                        txtOperand.Enabled = true;
                        break;
                }
            }
        }

        private void TsmiEditInstruction_Click(object sender, EventArgs e)
        {
            if (dgvInstructions.SelectedRows.Count > 0)
            {
                SelectedInstructionIndex = dgvInstructions.SelectedRows[0].Index;

                txtIndex.Text = dgvInstructions.Rows[SelectedInstructionIndex].Cells[0].Value == null ? string.Empty : dgvInstructions.Rows[SelectedInstructionIndex].Cells[0].Value.ToString();
                cmbOpCodes.Text = dgvInstructions.Rows[SelectedInstructionIndex].Cells[1].Value == null ? string.Empty : dgvInstructions.Rows[SelectedInstructionIndex].Cells[1].Value.ToString();
                txtOperand.Text = dgvInstructions.Rows[SelectedInstructionIndex].Cells[2].Value == null ? string.Empty : dgvInstructions.Rows[SelectedInstructionIndex].Cells[2].Value.ToString();

                btnAddTarget.Text = "Update";
            }
        }

        private void TsmiRemoveInstruction_Click(object sender, EventArgs e)
        {
            if (dgvInstructions.SelectedRows.Count > 0)
            {
                dgvInstructions.Rows.RemoveAt(dgvInstructions.SelectedRows[0].Index);

                if (btnAddTarget.Text == "Update")
                {
                    btnAddTarget.Text = "Add";
                    SelectedInstructionIndex = -1;
                }
            }
        }

        private void tsmiMoveUpInstruction_Click(object sender, EventArgs e)
        {
            if (dgvInstructions.SelectedRows.Count > 0)
            {
                dgvInstructions.MoveUp();

                ResetAddTarget();
            }
        }

        private void tsmiMoveDownInstruction_Click(object sender, EventArgs e)
        {
            if (dgvInstructions.SelectedRows.Count > 0)
            {
                dgvInstructions.MoveDown();

                ResetAddTarget();
            }
        }

        public static void LoadOpCodes()
        {
            OpCodes = new List<OpCode>();

            var type = typeof(OpCodes);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                if (field.FieldType.Name == "OpCode")
                {
                    var opCode = (OpCode)type.InvokeMember(field.Name, BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField, null, null, null);
                    OpCodes.Add(opCode);
                }
            }

            OpCodes = OpCodes.OrderBy(x => x.Name).ToList();
        }

        private void ClearControls()
        {
            txtIndex.Text = string.Empty;
            cmbOpCodes.SelectedIndex = -1;
            txtOperand.Text = string.Empty;
        }

        private void ResetAddTarget()
        {
            if (btnAddTarget.Text == "Update")
            {
                btnAddTarget.Text = "Add";
                SelectedInstructionIndex = -1;
            }
        }
    }
}