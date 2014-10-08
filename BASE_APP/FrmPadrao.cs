using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Runtime.InteropServices;

namespace BASE_APP
{
    public partial class FrmPadrao : Form
    {
        public FrmPadrao()
        {
            InitializeComponent();
        }

        public static void GetExcel(DataGridView grid, Application app)
        {
            var salvar = new SaveFileDialog(); // novo SaveFileDialog

            object misValue = System.Reflection.Missing.Value;

            var workBook = app.Workbooks.Add(misValue);
            var workSheet = (Worksheet)workBook.Worksheets.Item[1];
            int i;

            for (var x = 0; x <= grid.ColumnCount - 1; x++)
            {
                if (grid.Columns[x].GetType() != typeof(DataGridViewImageColumn))
                {
                    string nomeColuna = grid.Columns[x].HeaderText;
                    workSheet.Cells[1, x + 1] = nomeColuna;
                    workSheet.Cells[1, x + 1].Font.Bold = true;
                }
            }

            // passa as celulas do DataGridView para a Pasta do Excel
            for (i = 0; i <= grid.RowCount - 1; i++)
            {
                int j;
                for (j = 0; j <= grid.ColumnCount - 1; j++)
                {
                    if (grid.Columns[j].GetType() != typeof(DataGridViewImageColumn))
                    {
                        DataGridViewCell cell = grid[j, i];
                        workSheet.Cells[i + 2, j + 1] = cell.Value;
                    }
                }
            }

            // define algumas propriedades da caixa salvar
            salvar.Title = "Exportar para Excel";
            salvar.Filter = "Arquivo do Excel *.xls | *.xls";
            salvar.ShowDialog(); // mostra
            try
            {
                // salva o arquivo
                workBook.SaveAs(salvar.FileName, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

                    XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                workBook.Close(true, misValue, misValue);
                app.Quit(); // encerra o excel
            }
            catch (COMException)
            {
                MessageBox.Show("Nenhum arquivo será salvo!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Exportado com sucesso!");
        }
    }
}
