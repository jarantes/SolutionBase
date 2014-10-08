using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASE_APP
{
    public class AppFormUtil
    {

        public enum StatusForm
        {
            Info,
            Success,
            Error
        }

        public void SetMessageError(ref ToolStripStatusLabel tssRef, bool visible, string message, StatusForm? sttFrm)
        {
            switch (sttFrm)
            {
                case StatusForm.Success :
                    tssRef.BackColor = Color.Lime;
                    tssRef.ForeColor = Color.Black;
                    break;
                case StatusForm.Info:
                    tssRef.BackColor = Color.LightYellow;
                    tssRef.ForeColor = Color.Black;
                    break;
                case StatusForm.Error:
                    tssRef.BackColor = Color.Firebrick;
                    tssRef.ForeColor = Color.White;
                    break;
            }
            tssRef.Text = message;
            tssRef.Visible = visible;
        }

        public void Combo(ref ComboBox combo, DataTable dt, string strText, string strValue, string strLabel = "")
        {
            if (!string.IsNullOrEmpty(strLabel))
            {

                if (dt.Rows.Count > 0)
                {
                    DataRow ln = dt.NewRow();
                    ln[strText] = strLabel;
                    ln[strValue] = "0";
                    dt.Rows.InsertAt(ln, 0);
                }
            }

            combo.ValueMember = strValue;
            combo.DisplayMember = strText;
            combo.DataSource = dt;

            if (!string.IsNullOrEmpty(strLabel))
            {
                combo.SelectedValue = "0";
            }
            else
            {
                combo.SelectedIndex = -1;
            }
        }

        public void Grid(ref DataGridView grid, DataTable dt, bool codigoVisible, bool clearSelection, bool autoSizeColumnMode)
        {
            try
            {
                grid.AutoGenerateColumns = false;
                grid.MultiSelect = false;
                grid.ReadOnly = true;
                grid.Columns[1].Visible = codigoVisible;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.DataSource = dt;
                if (autoSizeColumnMode)
                {
                    int i;
                    for (i = 0; i <= grid.ColumnCount - 1; i++)
                    {
                        grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
                if (clearSelection)
                {
                    grid.ClearSelection();
                }
            }
            catch
            {
            }
        }
    }
}
