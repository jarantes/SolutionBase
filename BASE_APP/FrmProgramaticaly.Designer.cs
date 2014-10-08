namespace BASE_APP
{
    partial class FrmProgramaticaly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgramaticaly));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdLimpar = new System.Windows.Forms.ToolStripButton();
            this.cmdNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMessageError = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnMover = new System.Windows.Forms.Button();
            this.pnlDynamic = new System.Windows.Forms.Panel();
            this.picFilha = new System.Windows.Forms.PictureBox();
            this.gpbTarget1 = new System.Windows.Forms.GroupBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.gpbTarget2 = new System.Windows.Forms.GroupBox();
            this.gpbTarget3 = new System.Windows.Forms.GroupBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlDynamic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilha)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "lblTitulo";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLimpar,
            this.cmdNovo,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(585, 25);
            this.toolStrip1.TabIndex = 1;
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
            // 
            // cmdNovo
            // 
            this.cmdNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdNovo.Image = global::BASE_APP.Properties.Resources.page_add;
            this.cmdNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdNovo.Name = "cmdNovo";
            this.cmdNovo.Size = new System.Drawing.Size(23, 22);
            this.cmdNovo.Text = "Novo";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::BASE_APP.Properties.Resources.disk;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus,
            this.tssMessageError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(585, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            this.tssStatus.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(57, 18);
            this.tssStatus.Text = "tssStatus";
            // 
            // tssMessageError
            // 
            this.tssMessageError.BackColor = System.Drawing.Color.Firebrick;
            this.tssMessageError.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tssMessageError.Name = "tssMessageError";
            this.tssMessageError.Size = new System.Drawing.Size(92, 18);
            this.tssMessageError.Text = "tssMessageError";
            this.tssMessageError.Visible = false;
            // 
            // btnMover
            // 
            this.btnMover.Location = new System.Drawing.Point(415, 115);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(75, 23);
            this.btnMover.TabIndex = 11;
            this.btnMover.Text = "Mover";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // pnlDynamic
            // 
            this.pnlDynamic.Controls.Add(this.picFilha);
            this.pnlDynamic.Location = new System.Drawing.Point(426, 206);
            this.pnlDynamic.Name = "pnlDynamic";
            this.pnlDynamic.Size = new System.Drawing.Size(94, 79);
            this.pnlDynamic.TabIndex = 10;
            // 
            // picFilha
            // 
            this.picFilha.Image = global::BASE_APP.Properties.Resources.Exit;
            this.picFilha.Location = new System.Drawing.Point(31, 22);
            this.picFilha.Name = "picFilha";
            this.picFilha.Size = new System.Drawing.Size(31, 32);
            this.picFilha.TabIndex = 0;
            this.picFilha.TabStop = false;
            // 
            // gpbTarget1
            // 
            this.gpbTarget1.Location = new System.Drawing.Point(39, 93);
            this.gpbTarget1.Name = "gpbTarget1";
            this.gpbTarget1.Size = new System.Drawing.Size(107, 100);
            this.gpbTarget1.TabIndex = 9;
            this.gpbTarget1.TabStop = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(415, 144);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // gpbTarget2
            // 
            this.gpbTarget2.Location = new System.Drawing.Point(161, 93);
            this.gpbTarget2.Name = "gpbTarget2";
            this.gpbTarget2.Size = new System.Drawing.Size(107, 100);
            this.gpbTarget2.TabIndex = 13;
            this.gpbTarget2.TabStop = false;
            // 
            // gpbTarget3
            // 
            this.gpbTarget3.Location = new System.Drawing.Point(285, 93);
            this.gpbTarget3.Name = "gpbTarget3";
            this.gpbTarget3.Size = new System.Drawing.Size(107, 100);
            this.gpbTarget3.TabIndex = 14;
            this.gpbTarget3.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = global::BASE_APP.Properties.Resources.favicon_fw;
            this.picLogo.Location = new System.Drawing.Point(484, 28);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(89, 81);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            // 
            // FrmProgramaticaly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 437);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.pnlDynamic);
            this.Controls.Add(this.gpbTarget3);
            this.Controls.Add(this.gpbTarget2);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnMover);
            this.Controls.Add(this.gpbTarget1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmProgramaticaly";
            this.Text = "Form Padrao";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlDynamic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFilha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.ToolStripButton cmdLimpar;
        private System.Windows.Forms.ToolStripButton cmdNovo;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripStatusLabel tssMessageError;
        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Panel pnlDynamic;
        private System.Windows.Forms.PictureBox picFilha;
        private System.Windows.Forms.GroupBox gpbTarget1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.GroupBox gpbTarget2;
        private System.Windows.Forms.GroupBox gpbTarget3;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

