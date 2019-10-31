using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PeachFox
{
    public partial class Project : Form
    {
        private void UpdateRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            // Table Update
            var row = dataGridView.Rows[e.RowIndex];
            EnableRow(row, row.Cells[0].Value != null && row.Cells[0].Value.ToString().Length > 0);
            CheckAnimation(row);
            // Graphic Update
        }

        private void EnableRow(DataGridViewRow row, bool enable)
        {
            for (int i = 1; i < 3; i++)
            {
                row.Cells[i].ReadOnly = !enable;
                row.Cells[i].Style.BackColor = !enable ? Color.Gray : Color.White;
            }
        }

        private void CheckAnimation(DataGridViewRow row)
        {
            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[2];
            bool enable = cell.Value == cell.TrueValue;
            for (int i = 3; i < 6; i++)
            {
                row.Cells[i].ReadOnly = !enable;
                row.Cells[i].Style.BackColor = !enable ? Color.Gray : Color.White;
            }
        }

        private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            UpdateRow(sender, e);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = characterGraphicBox.BackColor;
            colorDialog.ShowDialog();
            characterGraphicBox.BackColor = colorDialog.Color;
        }
    }
}
