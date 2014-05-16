using System;
using System.Windows.Forms;
using BASE_APP.Properties;

namespace BASE_APP
{
    public partial class FrmLogin : Form
    {
        private readonly AppDatabaseUtil _db = new AppDatabaseUtil();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private FrmPrincipal _frmPrincipal;

        private void txtUserName_GotFocus(object sender, EventArgs e)
        {
            tssStatus.Text = @"Informe o usuário";
        }

        private void txtPassword_GotFocus(object sender, EventArgs e)
        {
            tssStatus.Text = @"Informe a senha";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_GotFocus(object sender, EventArgs e)
        {
            tssStatus.Text = "";
        }

        public void ShowMe(FrmPrincipal frmPrincipal)
        {
            _frmPrincipal = frmPrincipal;
            ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                _frmPrincipal.GetMenu();
                Close();
            }
        }

        private bool ValidaDados()
        {
            if (!ValidaInput()) return false;
            if (!_db.Signon(txtUserName.Text, txtPassword.Text))
            {
                MessageBox.Show(@"Usuário ou Senha incorretos", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var user = _db.GetUserByName(txtUserName.Text);
            FrmPrincipal.UserId = user.UserID;
            FrmPrincipal.UserName = user.UserName;
            FrmPrincipal.ProfileId = user.ProfileID;
            FrmPrincipal.UserDescription = user.UserDescription;
            return true;
        }

        private bool ValidaInput()
        {
            if (txtUserName.Text.Length == 0)
            {
                errorProvider.SetError(txtUserName, Resources.VALIDATE_USERNAME);
                MessageBox.Show(Resources.VALIDATE_USERNAME, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPassword.Text.Length == 0)
            {
                errorProvider.SetError(txtPassword, Resources.VALIDATE_PASSWORD);
                MessageBox.Show(Resources.VALIDATE_PASSWORD, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            errorProvider.Clear();
            return true;
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                btnEntrar_Click(sender, e);
            }
        }
    }
}
