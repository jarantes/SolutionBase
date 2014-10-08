namespace BASE_APP
{
    partial class FrmProfileAndUsers
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfileAndUsers));
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.treeModulos = new System.Windows.Forms.TreeView();
            this.gpbInfoPerfil = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProfile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdProfile = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ProfileDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.Edit2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Desative = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfileID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboProfile = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserDescription = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdLimpar = new System.Windows.Forms.ToolStripButton();
            this.cmdNovo = new System.Windows.Forms.ToolStripButton();
            this.cmdSalvar = new System.Windows.Forms.ToolStripButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.gpbInfoPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfile)).BeginInit();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Perfis/Usuários";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(585, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            this.tssStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tssStatus.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(57, 18);
            this.tssStatus.Text = "tssStatus";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Location = new System.Drawing.Point(0, 85);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 326);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.label4);
            this.tabProfile.Controls.Add(this.treeModulos);
            this.tabProfile.Controls.Add(this.gpbInfoPerfil);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.grdProfile);
            this.tabProfile.Location = new System.Drawing.Point(4, 25);
            this.tabProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabProfile.Size = new System.Drawing.Size(577, 297);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Perfis";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(180, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Permissões";
            // 
            // treeModulos
            // 
            this.treeModulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeModulos.CheckBoxes = true;
            this.treeModulos.Location = new System.Drawing.Point(184, 98);
            this.treeModulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeModulos.Name = "treeModulos";
            this.treeModulos.Size = new System.Drawing.Size(387, 191);
            this.treeModulos.TabIndex = 6;
            // 
            // gpbInfoPerfil
            // 
            this.gpbInfoPerfil.Controls.Add(this.label3);
            this.gpbInfoPerfil.Controls.Add(this.txtProfile);
            this.gpbInfoPerfil.Location = new System.Drawing.Point(184, 6);
            this.gpbInfoPerfil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbInfoPerfil.Name = "gpbInfoPerfil";
            this.gpbInfoPerfil.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gpbInfoPerfil.Size = new System.Drawing.Size(228, 71);
            this.gpbInfoPerfil.TabIndex = 5;
            this.gpbInfoPerfil.TabStop = false;
            this.gpbInfoPerfil.Text = "Infomações do Perfil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome do Perfil";
            // 
            // txtProfile
            // 
            this.txtProfile.Location = new System.Drawing.Point(9, 36);
            this.txtProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProfile.Name = "txtProfile";
            this.txtProfile.Size = new System.Drawing.Size(201, 20);
            this.txtProfile.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Perfis Existentes";
            // 
            // grdProfile
            // 
            this.grdProfile.AllowUserToAddRows = false;
            this.grdProfile.AllowUserToDeleteRows = false;
            this.grdProfile.AllowUserToResizeColumns = false;
            this.grdProfile.AllowUserToResizeRows = false;
            this.grdProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.ProfileDescription,
            this.CreationDate,
            this.ProfileID});
            this.grdProfile.Location = new System.Drawing.Point(6, 28);
            this.grdProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdProfile.MultiSelect = false;
            this.grdProfile.Name = "grdProfile";
            this.grdProfile.ReadOnly = true;
            this.grdProfile.RowHeadersWidth = 8;
            this.grdProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProfile.Size = new System.Drawing.Size(168, 260);
            this.grdProfile.TabIndex = 3;
            this.grdProfile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProfiles_CellClick);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Image = global::BASE_APP.Properties.Resources.page_edit;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 20;
            // 
            // ProfileDescription
            // 
            this.ProfileDescription.DataPropertyName = "ProfileDescription";
            this.ProfileDescription.HeaderText = "Descrição";
            this.ProfileDescription.Name = "ProfileDescription";
            this.ProfileDescription.ReadOnly = true;
            this.ProfileDescription.Width = 120;
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "CreationDate";
            this.CreationDate.HeaderText = "CreationDate";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Visible = false;
            // 
            // ProfileID
            // 
            this.ProfileID.DataPropertyName = "ProfileID";
            this.ProfileID.HeaderText = "ProfileID";
            this.ProfileID.Name = "ProfileID";
            this.ProfileID.ReadOnly = true;
            this.ProfileID.Visible = false;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.label5);
            this.tabUsers.Controls.Add(this.grdUsers);
            this.tabUsers.Controls.Add(this.groupBox1);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabUsers.Size = new System.Drawing.Size(577, 297);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Usuário";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Usuários Cadastrados";
            // 
            // grdUsers
            // 
            this.grdUsers.AllowUserToAddRows = false;
            this.grdUsers.AllowUserToDeleteRows = false;
            this.grdUsers.AllowUserToResizeColumns = false;
            this.grdUsers.AllowUserToResizeRows = false;
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit2,
            this.Desative,
            this.Delete,
            this.UserName,
            this.UserDescription,
            this.CreationDate2,
            this.Password,
            this.ProfileID2,
            this.UserID,
            this.CreatedBy,
            this.Activated});
            this.grdUsers.Location = new System.Drawing.Point(6, 113);
            this.grdUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdUsers.MultiSelect = false;
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.ReadOnly = true;
            this.grdUsers.RowHeadersWidth = 8;
            this.grdUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUsers.Size = new System.Drawing.Size(565, 178);
            this.grdUsers.TabIndex = 1;
            this.grdUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers_CellClick);
            this.grdUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdUsers_CellFormatting);
            this.grdUsers.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers_CellMouseLeave);
            this.grdUsers.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdUsers_CellMouseMove);
            // 
            // Edit2
            // 
            this.Edit2.HeaderText = "";
            this.Edit2.Image = global::BASE_APP.Properties.Resources.user_edit;
            this.Edit2.Name = "Edit2";
            this.Edit2.ReadOnly = true;
            this.Edit2.Width = 20;
            // 
            // Desative
            // 
            this.Desative.HeaderText = "";
            this.Desative.Image = global::BASE_APP.Properties.Resources.user_female;
            this.Desative.Name = "Desative";
            this.Desative.ReadOnly = true;
            this.Desative.Width = 20;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::BASE_APP.Properties.Resources.cross;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 20;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Usuário";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserDescription
            // 
            this.UserDescription.DataPropertyName = "UserDescription";
            this.UserDescription.HeaderText = "Nome Completo";
            this.UserDescription.Name = "UserDescription";
            this.UserDescription.ReadOnly = true;
            this.UserDescription.Width = 200;
            // 
            // CreationDate2
            // 
            this.CreationDate2.DataPropertyName = "CreationDate";
            this.CreationDate2.HeaderText = "Criação";
            this.CreationDate2.Name = "CreationDate2";
            this.CreationDate2.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            // 
            // ProfileID2
            // 
            this.ProfileID2.DataPropertyName = "ProfileID";
            this.ProfileID2.HeaderText = "ProfileID";
            this.ProfileID2.Name = "ProfileID2";
            this.ProfileID2.ReadOnly = true;
            this.ProfileID2.Visible = false;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // CreatedBy
            // 
            this.CreatedBy.DataPropertyName = "CreatedBy";
            this.CreatedBy.HeaderText = "CreatedBy";
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            this.CreatedBy.Visible = false;
            // 
            // Activated
            // 
            this.Activated.DataPropertyName = "Activated";
            this.Activated.HeaderText = "Activated";
            this.Activated.Name = "Activated";
            this.Activated.ReadOnly = true;
            this.Activated.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboProfile);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUserDescription);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(565, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Usuário";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(364, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Perfil";
            // 
            // cboProfile
            // 
            this.cboProfile.BackColor = System.Drawing.SystemColors.Window;
            this.cboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfile.FormattingEnabled = true;
            this.cboProfile.Location = new System.Drawing.Point(367, 39);
            this.cboProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboProfile.Name = "cboProfile";
            this.cboProfile.Size = new System.Drawing.Size(167, 24);
            this.cboProfile.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(127, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nome Completo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nome de Usuário";
            // 
            // txtUserDescription
            // 
            this.txtUserDescription.Location = new System.Drawing.Point(130, 39);
            this.txtUserDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserDescription.Name = "txtUserDescription";
            this.txtUserDescription.Size = new System.Drawing.Size(213, 20);
            this.txtUserDescription.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(6, 39);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLimpar,
            this.cmdNovo,
            this.cmdSalvar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(585, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdLimpar
            // 
            this.cmdLimpar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdLimpar.Image = global::BASE_APP.Properties.Resources.page;
            this.cmdLimpar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLimpar.Name = "cmdLimpar";
            this.cmdLimpar.Size = new System.Drawing.Size(23, 22);
            this.cmdLimpar.Text = "Limpar";
            this.cmdLimpar.Click += new System.EventHandler(this.cmdLimpar_Click);
            // 
            // cmdNovo
            // 
            this.cmdNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdNovo.Image = global::BASE_APP.Properties.Resources.page_add;
            this.cmdNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNovo.Name = "cmdNovo";
            this.cmdNovo.Size = new System.Drawing.Size(23, 22);
            this.cmdNovo.Text = "Novo";
            this.cmdNovo.Click += new System.EventHandler(this.cmdNovo_Click);
            // 
            // cmdSalvar
            // 
            this.cmdSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSalvar.Enabled = false;
            this.cmdSalvar.Image = global::BASE_APP.Properties.Resources.disk;
            this.cmdSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSalvar.Name = "cmdSalvar";
            this.cmdSalvar.Size = new System.Drawing.Size(23, 22);
            this.cmdSalvar.Text = "Salvar";
            this.cmdSalvar.Click += new System.EventHandler(this.cmdSalvar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = global::BASE_APP.Properties.Resources.favicon_fw;
            this.picLogo.Location = new System.Drawing.Point(489, 24);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(89, 81);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 6;
            this.picLogo.TabStop = false;
            // 
            // FrmProfileAndUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(585, 437);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmProfileAndUsers";
            this.Text = "Perfis/Usuários";
            this.Load += new System.EventHandler(this.FrmProfileAndUsers_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.gpbInfoPerfil.ResumeLayout(false);
            this.gpbInfoPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfile)).EndInit();
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.GroupBox gpbInfoPerfil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdProfile;
        private System.Windows.Forms.TextBox txtProfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeModulos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdUsers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboProfile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserDescription;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdLimpar;
        private System.Windows.Forms.ToolStripButton cmdNovo;
        private System.Windows.Forms.ToolStripButton cmdSalvar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfileDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfileID;
        private System.Windows.Forms.DataGridViewImageColumn Edit2;
        private System.Windows.Forms.DataGridViewImageColumn Desative;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfileID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activated;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

