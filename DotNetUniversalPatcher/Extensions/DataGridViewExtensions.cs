using System.Windows.Forms;

namespace DotNetUniversalPatcher.Extensions
{
    internal static class DataGridViewExtensions
    {
        internal static void MoveUp(this DataGridView dgv)
        {
            int index = dgv.SelectedRows[0].Index;

            if (index == 0)
            {
                return;
            }

            DataGridViewRowCollection rows = dgv.Rows;
            DataGridViewRow prevRow = rows[index - 1];

            rows.Remove(prevRow);
            prevRow.Frozen = false;
            rows.Insert(index, prevRow);
            dgv.ClearSelection();
            dgv.Rows[index - 1].Selected = true;
        }

        internal static void MoveDown(this DataGridView dgv)
        {
            int rowCount = dgv.Rows.Count;
            int index = dgv.SelectedRows[0].Index;

            if (index == rowCount - 1)
            {
                return;
            }

            DataGridViewRowCollection rows = dgv.Rows;
            DataGridViewRow nextRow = rows[index + 1];

            rows.Remove(nextRow);
            nextRow.Frozen = false;
            rows.Insert(index, nextRow);
            dgv.ClearSelection();
            dgv.Rows[index + 1].Selected = true;
        }
    }
}