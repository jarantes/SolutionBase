using System;
using System.Threading;
using System.Windows.Forms;

namespace BASE_APP
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            lblStatus.Text = @"Iniciando Aplicação...";
            lblStatus.Refresh();
            lblVersion.Text = Application.ProductVersion;
            timer1.Enabled = true;
        }

        private void IniciaAplicacao()
        {
            Hide();
            timer1.Enabled = false;
            var frm = new FrmPrincipal();
            frm.Show();
        }

        public void ShowMeAbout()
        {
            Show();
            progressBar1.Visible = false;
            timer1.Enabled = false;
            lblVersion.Text = Application.ProductVersion;
            lblStatus.Text = @"Sistema em Funcionamento";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
            for (var i = 0; i < 25; i++)
            {
                progressBar1.Value = i;
                progressBar1.Refresh();
                Thread.Sleep(50);
            }
            Refresh();
            Thread.Sleep(1000);
            Refresh();
            for (var i = 26; i < 65; i++)
            {
                progressBar1.Value = i;
                progressBar1.Refresh();
                Thread.Sleep(50);
            }
            Refresh();
            lblStatus.Text = @"Conectando ao Banco de Dados";
            lblStatus.Refresh();
            Refresh();
            for (var i = 66; i < 85; i++)
            {
                progressBar1.Value = i;
                progressBar1.Refresh();
                Thread.Sleep(100);
            }
            lblStatus.Text = "";
            lblStatus.Refresh();
            Refresh();
            lblStatus.Text = @"Carregando Formulários";
            lblStatus.Refresh();
            Thread.Sleep(1000);
            Refresh();

            progressBar1.Value = 100;
            progressBar1.Refresh();
            Thread.Sleep(1500);
            Refresh();
            IniciaAplicacao();
        }

        private void FrmSplash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Escape)
            {
                Close();
            }
        }
    }
}
