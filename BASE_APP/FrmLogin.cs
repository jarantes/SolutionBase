using System;
using System.Windows.Forms;
using BASE_APP.Properties;

namespace BASE_APP
{
    public partial class FrmLogin : Form
    {
        private readonly AppDatabaseUtil _db = new AppDatabaseUtil();
        private readonly AppFormUtil _frmUtil = new AppFormUtil();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private FrmPrincipal _frmPrincipal;
        private bool IsAuthenticated;

        private void txtUserName_GotFocus(object sender, EventArgs e)
        {
            _frmUtil.SetMessageError(ref tssStatus, true, @"Informe o usuário", AppFormUtil.StatusForm.Info);
        }

        private void txtPassword_GotFocus(object sender, EventArgs e)
        {
            _frmUtil.SetMessageError(ref tssStatus, true, @"Informe a senha", AppFormUtil.StatusForm.Info);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_GotFocus(object sender, EventArgs e)
        {
            _frmUtil.SetMessageError(ref tssStatus, false, null, null);
        }

        public void ShowMe(FrmPrincipal frmPrincipal)
        {
            _frmPrincipal = frmPrincipal;
            ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ValidaDados();
        }

        private void ValidaDados()
        {
            if (!ValidaInput()) return;

            _frmUtil.SetMessageError(ref tssStatus, true, @"Logando...", AppFormUtil.StatusForm.Info);

            //Setando a propriedade de usuário
            _db.ClearPropertys();
            _db.User.UserName = txtUserName.Text;
            _db.User.Password = txtPassword.Text;

            picLoading.Visible = true;

            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {
                picLoading.Visible = false;
                picLoading.Refresh();
                _frmUtil.SetMessageError(ref tssStatus, true, @"Erro ao autenticar usuário", AppFormUtil.StatusForm.Error);
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IsAuthenticated = _db.Signon();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            picLoading.Visible = false;
            picLoading.Refresh();

            //Se não houve erro compara o resultado
            if (!IsAuthenticated)
            {
                _frmUtil.SetMessageError(ref tssStatus, true, @"Usuário ou Senha incorretos", AppFormUtil.StatusForm.Error);
                return;
            }

            var user = _db.GetUserByName(txtUserName.Text);
            FrmPrincipal.UserId = user.UserID;
            FrmPrincipal.UserName = user.UserName;
            FrmPrincipal.ProfileId = user.ProfileID;
            FrmPrincipal.UserDescription = user.UserDescription;

            _frmPrincipal.GetMenu();
            Close();
        }

        private bool ValidaInput()
        {
            if (txtUserName.Text.Length == 0)
            {
                errorProvider.SetError(txtUserName, Resources.VALIDATE_USERNAME);
                _frmUtil.SetMessageError(ref tssStatus, true, Resources.VALIDATE_USERNAME, AppFormUtil.StatusForm.Error);
                return false;
            }

            if (txtPassword.Text.Length == 0)
            {
                errorProvider.SetError(txtPassword, Resources.VALIDATE_PASSWORD);
                _frmUtil.SetMessageError(ref tssStatus, true, Resources.VALIDATE_PASSWORD, AppFormUtil.StatusForm.Error);
                return false;
            }
            errorProvider.Clear();
            return true;
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnEntrar_Click(sender, e);
            }
        }
    }
}
