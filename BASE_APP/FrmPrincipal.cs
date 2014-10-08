using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BASE_APP.Annotations;
using BASE_APP.Models;

namespace BASE_APP
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserDescription { get; set; }
        public static int ProfileId { get; set; }
        public static Form Frm = new Form();
        private object _strModuleClass = "";

        private String PMcDescription { [UsedImplicitly] get; set; }
        private String PMcCloseForm { get; set; }

        private readonly AppDatabaseUtil _db = new AppDatabaseUtil();

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            tss1.Text = "";
            tss2.Text = "";
            tssUserLogged.Text = "";
            tssVersion.Text = "";
            var frm = new FrmLogin();
            frm.ShowMe(this);
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void GetMenu()
        {
            tss1.Text = @"Carregando Menus...";
            tssUserLogged.Text = UserDescription;
            tssVersion.Text = Application.ProductVersion;
            try
            {
                var lista = _db.GetModuleClassPai(ProfileId);
                for (var i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Checked == "Y")
                    {
                        string item = lista[i].ModuleDescription;
                        var tag = lista[i].ModuleId;
                        var mnuItem = new ToolStripMenuItem(item)
                        {
                            Tag = tag,
                            Image = imageList.Images[lista[i].ImageIndex],
                            ImageScaling = ToolStripItemImageScaling.None
                        };
                        mnuPrincipal.Items.Add(mnuItem);
                        GetMenuRecursivo(mnuItem, lista[i].ModuleId);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //adcionar o botão sobre/sair
            var mnuSobre = new ToolStripMenuItem("Sobre")
            {
                Image = imageList.Images[3],
                ImageScaling = ToolStripItemImageScaling.None
            };
            mnuSobre.Click += Menu_Sobre;

            var mnuSair = new ToolStripMenuItem("Sair")
            {
                Image = imageList.Images[4],
                ImageScaling = ToolStripItemImageScaling.None
            };
            mnuSair.Click += Menu_Sair;

            mnuPrincipal.Items.Add(mnuSobre);
            mnuPrincipal.Items.Add(mnuSair);

            tss1.Text = @"Usuario:";
            tss2.Text = @"  Versão:";
        }

        private void GetMenuRecursivo(ToolStripDropDownItem mnuItem, int parentModuleId)
        {
            try
            {
                var lista = _db.GetModuleClassFilho(ProfileId, 0, parentModuleId);
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Checked == "Y")
                    {
                        var item = lista[i].ModuleDescription;
                        var tag = lista[i].ModuleId;
                        var mnuItemPai = (ToolStripMenuItem)mnuItem.DropDownItems.Add(item, null, Menu_OnClick);
                        mnuItemPai.Tag = tag;
                        GetMenuRecursivo(mnuItemPai, Convert.ToInt32(tag));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Menu_OnClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var frmCriar = new Form();
            if (PMcCloseForm == "Y")
            {
                foreach (var frmClose in MdiChildren)
                {
                    frmClose.Close();
                }
            }

            Refresh();
            AppModules module;
            try
            {
                module = _db.GetModuleById(Convert.ToInt16(((ToolStripMenuItem) sender).Tag));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Não foi possível carregar as informações do módulo, DETALHES:" + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                return;
            }

            if (module.AssociateForm != null)
            {
                _strModuleClass = module.AssociateForm;
                PMcDescription = module.ModuleDescription;
                PMcCloseForm = module.CloseForm;

                frmCriar.Visible = false;
                frmCriar = FU_DynamicallyLoadedObject((string)_strModuleClass, null, "");
                frmCriar.MdiParent = this;
                frmCriar.Show();
                frmCriar.Visible = true;
                Frm = frmCriar;
            }

            Cursor = Cursors.Default;
        }

        private static Form FU_DynamicallyLoadedObject(String objectName, object[] args, string folder)
        {
            object returnObj = null;
            var type = Assembly.GetExecutingAssembly().GetType("BASE_APP." + objectName);

            if (folder != "")
            {
                type = Assembly.GetExecutingAssembly().GetType("BASE_APP.Forms." + folder + "." + objectName);
            }

            if (type != null)
            {
                try
                {
                    returnObj = Activator.CreateInstance(type, args);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro: " + ex.Message);
                }

            }
            return (Form)returnObj;
        }

        private static void Menu_Sobre(object sender, EventArgs e)
        {
            var frm = new FrmSplash();
            frm.ShowMeAbout();
        }

        private static void Menu_Sair(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
