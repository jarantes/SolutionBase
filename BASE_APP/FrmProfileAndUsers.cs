using System;
using System.Data.Entity.Core;
using System.Drawing;
using System.Windows.Forms;
using BASE_APP.Properties;
using BASE_APP.Models;

namespace BASE_APP
{
    public partial class FrmProfileAndUsers : Form
    {
        readonly AppDatabaseUtil _db = new AppDatabaseUtil();
        readonly AppFunctionsUtil _fn = new AppFunctionsUtil();
        readonly AppFormUtil _frmUtil = new AppFormUtil();
        private int _profileId;
        private int _userId;
        private TreeNode _nodeItem;
        private TreeNode _nodeItemPai;

        public FrmProfileAndUsers()
        {
            InitializeComponent();
        }

        public enum TypeTransaction
        {
            Clear,
            New,
            Save
        }

        private void FrmProfileAndUsers_Load(object sender, EventArgs e)
        {
            _frmUtil.SetMessageError(ref tssStatus, false, null, null);

            txtProfile.GotFocus += Control_GotFocus;
            txtUserDescription.GotFocus += Control_GotFocus;
            txtUserName.GotFocus += Control_GotFocus;
            cboProfile.GotFocus += Control_GotFocus;

            txtProfile.LostFocus += Control_LostFocus;
            txtUserDescription.LostFocus += Control_LostFocus;
            txtUserName.LostFocus += Control_LostFocus;
            cboProfile.LostFocus += Control_LostFocus;

            GetAllProfiles();
            GetAllUsers();

            var dt = _fn.ToDataTable(_db.GetAllProfiles());
            _frmUtil.Combo(ref cboProfile, dt, "ProfileDescription", "ProfileID", "Selecione");
        }

        private void GetAllUsers()
        {
            try
            {
                grdUsers.DataSource = _db.GetAllUsers();
            }
            catch (EntityException ex)
            {
                MessageBox.Show(Resources.ERROR_CARGA_USUARIO + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void GetAllProfiles()
        {
            try
            {
                grdProfile.DataSource = _db.GetAllProfiles();
            }
            catch (EntityException ex)
            {
                MessageBox.Show(Resources.ERROR_CARGA_PERFIL + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void cmdLimpar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ControlesPerfil(TypeTransaction.Clear);
            }
            else
            {
                ControlesUsuarios(TypeTransaction.Clear);
            }
        }

        private void cmdNovo_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ControlesPerfil(TypeTransaction.New);
            }
            else
            {
                ControlesUsuarios(TypeTransaction.New);
            }
            cmdSalvar.Enabled = true;
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            cmdSalvar.Enabled = false;
            if (tabControl1.SelectedIndex == 0)
            {
                ControlesPerfil(TypeTransaction.Save);
            }
            else
            {
                ControlesUsuarios(TypeTransaction.Save);
            }
        }

        private void ControlesUsuarios(TypeTransaction tipo)
        {
            switch (tipo)
            {
                case TypeTransaction.Clear:

                    txtUserDescription.Text = string.Empty;
                    txtUserName.Text = string.Empty;
                    cboProfile.SelectedIndex = -1;

                    break;

                case TypeTransaction.New:

                    txtUserDescription.Text = string.Empty;
                    txtUserName.Text = string.Empty;
                    cboProfile.SelectedIndex = -1;
                    _userId = 0;

                    break;

                case TypeTransaction.Save:

                    if (_userId == 0)
                    {
                        InsertUser();
                    }
                    else
                    {
                        UpdateUser();
                    }

                    break;
            }

        }

        private void UpdateUser()
        {
            if (!ValidaUser()) return;
            try
            {
                var user = _db.GetUserById(_userId);

                user.UserName = txtUserName.Text;
                user.UserDescription = txtUserDescription.Text;
                user.ProfileID = Convert.ToInt32(cboProfile.SelectedValue);

                _db.UpdateUser(user);
            }
            catch (EntityException ex)
            {
                MessageBox.Show(Resources.ERRO_UPDATE_USER + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cmdSalvar.Enabled = true;
                return;
            }
            _frmUtil.SetMessageError(ref tssStatus, true, "Usuário atualizado com sucesso!", AppFormUtil.StatusForm.Success);
            GetAllUsers();
            ControlesUsuarios(TypeTransaction.Clear);
        }

        private void InsertUser()
        {
            if (!ValidaUser()) return;
            try
            {
                var user = new AppUsers
                {
                    UserName = txtUserName.Text,
                    UserDescription = txtUserDescription.Text,
                    ProfileID = Convert.ToInt32(cboProfile.SelectedValue),
                    CreatedBy = FrmPrincipal.UserId,
                    Password = "sis123",
                    Activated = "Y",
                    CreationDate = DateTime.Now
                };

                _db.InsertUser(user);
            }
            catch (EntityException ex)
            {
                MessageBox.Show(Resources.ERROR_INSERT_USER + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cmdSalvar.Enabled = true;
                return;
            }
            _frmUtil.SetMessageError(ref tssStatus, true, "Usuário inserido com sucesso!", AppFormUtil.StatusForm.Success);
            GetAllUsers();
        }

        private bool ValidaUser()
        {
            if (txtUserName.Text == string.Empty)
            {
                errorProvider.SetError(txtUserName, Resources.VALIDATE_USERNAME);
                _frmUtil.SetMessageError(ref tssStatus, true, Resources.VALIDATE_USERNAME, AppFormUtil.StatusForm.Error);
                cmdSalvar.Enabled = true;
                return false;
            }

            if (txtUserDescription.Text == string.Empty)
            {
                errorProvider.SetError(txtUserDescription, Resources.VALIDATE_USER_DESCRIPTION);
                _frmUtil.SetMessageError(ref tssStatus, true, Resources.VALIDATE_USER_DESCRIPTION, AppFormUtil.StatusForm.Error);
                cmdSalvar.Enabled = true;
                return false;
            }

            if (cboProfile.SelectedIndex < 0)
            {
                errorProvider.SetError(cboProfile, Resources.VALIDADE_PROFILE);
                _frmUtil.SetMessageError(ref tssStatus, true, Resources.VALIDADE_PROFILE, AppFormUtil.StatusForm.Error);
                return false;
            }
            errorProvider.Clear();
            _frmUtil.SetMessageError(ref tssStatus, false, null, null);
            return true;
        }

        private void GetMenu(int profileId)
        {
            try
            {
                var lista = _db.GetModuleClassPai(profileId);
                treeModulos.Nodes.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    _nodeItem = new TreeNode();
                    _nodeItem = treeModulos.Nodes.Add(lista[i].ModuleDescription);
                    _nodeItem.Tag = lista[i].ModuleId;
                    if (lista[i].Checked == "Y")
                    {
                        _nodeItem.Checked = true;
                    }
                    GetMenuRecursivo(_nodeItem, lista[i].ModuleId);
                }
                treeModulos.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ERROR_CARGA_MODULOS + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void GetMenuRecursivo(TreeNode nodeItem, int parentModuleId)
        {

            var lista = _db.GetModuleClassFilho(_profileId, 0, parentModuleId);
            for (int i = 0; i < lista.Count; i++)
            {
                _nodeItemPai = new TreeNode();
                _nodeItemPai = nodeItem.Nodes.Add(lista[i].ModuleDescription);
                _nodeItemPai.Tag = lista[i].ModuleId;
                if (lista[i].Checked == "Y")
                {
                    _nodeItemPai.Checked = true;
                }
                GetMenuRecursivo(_nodeItemPai, lista[i].ModuleId);
            }
        }

        private void ControlesPerfil(TypeTransaction tipo)
        {
            switch (tipo)
            {
                case TypeTransaction.Clear:

                    txtProfile.Text = string.Empty;
                    treeModulos.Nodes.Clear();

                    break;

                case TypeTransaction.New:

                    txtProfile.Text = string.Empty;
                    _profileId = 0;
                    treeModulos.Nodes.Clear();

                    break;

                case TypeTransaction.Save:

                    if (_profileId == 0)
                    {
                        InsertProfile();
                    }
                    else
                    {
                        UpdateProfile();
                    }

                    break;
            }
        }

        private void UpdateProfile()
        {
            if (!ValidaProfile()) return;
            try
            {
                var profile = _db.GetProfileById(_profileId);
                profile.ProfileDescription = txtProfile.Text;

                _db.UpdateProfile(profile);

                _db.DeleteAllProfileClass(_profileId);

                foreach (TreeNode node in treeModulos.Nodes)
                {
                    if (node.Checked)
                    {
                        var moduleId = Convert.ToInt32(node.Tag);
                        var profileClass = new AppProfileClass { ProfileID = _profileId, ModuleID = moduleId };
                        _db.InsertProfileClass(profileClass);
                    }
                    AddNodeFilho(node);
                }

            }
            catch (EntityException ex)
            {
                MessageBox.Show(Resources.ERROR_UPDATE_PROFILE + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cmdSalvar.Enabled = true;
                return;
            }
            _frmUtil.SetMessageError(ref tssStatus, true, "Perfil atualizado com sucesso!", AppFormUtil.StatusForm.Success);
            GetAllProfiles();
            ControlesPerfil(TypeTransaction.Clear);
        }

        private void AddNodeFilho(TreeNode node)
        {
            foreach (TreeNode nodeitem in node.Nodes)
            {
                if (nodeitem.Checked)
                {
                    var moduleId = Convert.ToInt32(nodeitem.Tag);
                    var profileClass = new AppProfileClass { ProfileID = _profileId, ModuleID = moduleId };
                    _db.InsertProfileClass(profileClass);
                }
                AddNodeFilho(nodeitem);
            }
        }

        private void InsertProfile()
        {
            if(!ValidaProfile()) return;
            try
            {
                var profile = new AppProfiles
                {
                    ProfileDescription = txtProfile.Text,
                    CreationDate = DateTime.Now
                };

                _db.InsertProfile(profile);
            }
            catch (EntityException ex)
            {
                MessageBox.Show(Resources.ERROR_INSERT_PROFILE + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cmdSalvar.Enabled = true;
                return;
            }
            _frmUtil.SetMessageError(ref tssStatus, true, "Perfil inserido com sucesso!", AppFormUtil.StatusForm.Success);
            GetAllProfiles();
            ControlesPerfil(TypeTransaction.Clear);
        }

        private bool ValidaProfile()
        {
            if (txtProfile.Text == string.Empty)
            {
                errorProvider.SetError(txtProfile, Resources.VALIDADE_PROFILE);
                _frmUtil.SetMessageError(ref tssStatus, true, Resources.VALIDADE_PROFILE, AppFormUtil.StatusForm.Error);
                cmdSalvar.Enabled = true;
                return false;
            }
            errorProvider.Clear();
            return true;
        }

        private void grdProfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex < 0) return;
            _profileId = Convert.ToInt32(grdProfile.Rows[e.RowIndex].Cells["ProfileID"].Value);
            cmdLimpar.Enabled = true;
            cmdSalvar.Enabled = true;
            txtProfile.Text = grdProfile.Rows[e.RowIndex].Cells["ProfileDescription"].Value.ToString();
            GetMenu(_profileId);
        }

        private void grdUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ControlesUsuarios(TypeTransaction.Clear);
                if (e.ColumnIndex == 0)
                {
                    txtUserName.Text = grdUsers.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                    txtUserDescription.Text = grdUsers.Rows[e.RowIndex].Cells["UserDescription"].Value.ToString();
                    _userId = Convert.ToInt32(grdUsers.Rows[e.RowIndex].Cells["UserID"].Value);
                    cboProfile.SelectedValue = grdUsers.Rows[e.RowIndex].Cells["ProfileID2"].Value;
                    cmdSalvar.Enabled = true;
                }
                if (e.ColumnIndex == 1)
                {
                    DesativeUser(Convert.ToInt32(grdUsers.Rows[e.RowIndex].Cells["UserID"].Value));
                }
                if (e.ColumnIndex == 2)
                {
                    if (
                        MessageBox.Show(
                            Resources.QUESTION_DELETE_USER +
                            grdUsers.Rows[e.RowIndex].Cells["UserName"].Value + Resources.QUESTION, Text,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RemoveUser(Convert.ToInt32(grdUsers.Rows[e.RowIndex].Cells["UserID"].Value));
                    }
                }
            }
        }

        private void RemoveUser(int userId)
        {
            try
            {
                _db.DeleteUser(userId);
            }
            catch (EntityException ex)
            {
                MessageBox.Show(Resources.ERROR_DELETE_USER + ex.Message, Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            GetAllUsers();
        }

        private void DesativeUser(int userId)
        {
            var user = _db.GetUserById(userId);
            user.Activated = user.Activated == "Y" ? "N" : "Y";
            _db.UpdateUser(user);
        }

        private void grdUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grdUsers.Rows[e.RowIndex].Cells["Activated"].Value.ToString() == "N")
            {
                e.CellStyle.BackColor = Color.LightSalmon;
            }
        }

        private void Control_GotFocus(Object sender, EventArgs e)
        {
            if (sender.GetType().Name.Contains("TextBox"))
            {
                var txt = (TextBox)sender;

                switch (txt.Name)
                {
                    case "txtProfile":
                        _frmUtil.SetMessageError(ref tssStatus, true, _profileId == 0 ? @"Informe o nome do perfil" : @"Atualize o nome do perfil", AppFormUtil.StatusForm.Info);
                        break;
                    case "txtUserName":
                        _frmUtil.SetMessageError(ref tssStatus, true, _userId == 0 ? @"Informe o nome do usuário" : @"Atualize o nome do usuário", AppFormUtil.StatusForm.Info);
                        break;
                    case "txtUserDescription":
                        _frmUtil.SetMessageError(ref tssStatus, true, _userId == 0 ? @"Informe o nome completo do usuário" : @"Atualize o nome completo do usuário", AppFormUtil.StatusForm.Info);
                        break;
                }
            }
            else if (sender.GetType().Name.Contains("ComboBox"))
            {
                _frmUtil.SetMessageError(ref tssStatus, true, @"Selecione o Perfil para o usuário", AppFormUtil.StatusForm.Info);
            }
            else
            {
                _frmUtil.SetMessageError(ref tssStatus, false, null, AppFormUtil.StatusForm.Info);
            }
        }

        private void Control_LostFocus(Object sender, EventArgs e)
        {
            _frmUtil.SetMessageError(ref tssStatus, false, null, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            cmdSalvar.Enabled = false;
            _frmUtil.SetMessageError(ref tssStatus, false, null, null);
        }

        private void grdUsers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex <= 2)
            {
                Cursor = Cursors.Default;
            }
        }

        private void grdUsers_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex <= 2)
            {
                Cursor = Cursors.Hand;
            }
        }
    }
}
