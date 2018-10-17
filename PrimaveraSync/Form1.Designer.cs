namespace PrimaveraSync
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStatusPedido = new System.Windows.Forms.Button();
            this.btnReceberPedidos = new System.Windows.Forms.Button();
            this.btnReceberClientes = new System.Windows.Forms.Button();
            this.btnEscreverPedidos = new System.Windows.Forms.Button();
            this.btnSetProdutos = new System.Windows.Forms.Button();
            this.tbcResultados = new System.Windows.Forms.TabControl();
            this.tbpGridView = new System.Windows.Forms.TabPage();
            this.stsLegendas = new System.Windows.Forms.StatusStrip();
            this.lblTtlRegs = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtgResultado = new System.Windows.Forms.DataGridView();
            this.tbpTxt = new System.Windows.Forms.TabPage();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSetEstoque = new System.Windows.Forms.Button();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.lblProduto = new System.Windows.Forms.Label();
            this.tempoSync = new System.Windows.Forms.Timer(this.components);
            this.tempoStart = new System.Windows.Forms.Timer(this.components);
            this.cbxExibeGrid = new System.Windows.Forms.CheckBox();
            this.cbxSyncPedido = new System.Windows.Forms.CheckBox();
            this.cbxSyncProduto = new System.Windows.Forms.CheckBox();
            this.lblCpro = new System.Windows.Forms.Label();
            this.txtCpro = new System.Windows.Forms.TextBox();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cbxEscreveString = new System.Windows.Forms.CheckBox();
            this.tbcResultados.SuspendLayout();
            this.tbpGridView.SuspendLayout();
            this.stsLegendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultado)).BeginInit();
            this.tbpTxt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStatusPedido
            // 
            this.btnStatusPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusPedido.Location = new System.Drawing.Point(529, 12);
            this.btnStatusPedido.Name = "btnStatusPedido";
            this.btnStatusPedido.Size = new System.Drawing.Size(107, 41);
            this.btnStatusPedido.TabIndex = 0;
            this.btnStatusPedido.Text = "DESAT Receber Status Pedido";
            this.btnStatusPedido.UseVisualStyleBackColor = true;
            this.btnStatusPedido.Visible = false;
            this.btnStatusPedido.Click += new System.EventHandler(this.btnStatusPedido_Click);
            // 
            // btnReceberPedidos
            // 
            this.btnReceberPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceberPedidos.Location = new System.Drawing.Point(642, 12);
            this.btnReceberPedidos.Name = "btnReceberPedidos";
            this.btnReceberPedidos.Size = new System.Drawing.Size(107, 41);
            this.btnReceberPedidos.TabIndex = 0;
            this.btnReceberPedidos.Text = "Receber Pedidos";
            this.btnReceberPedidos.UseVisualStyleBackColor = true;
            this.btnReceberPedidos.Click += new System.EventHandler(this.btnReceberPedidos_Click);
            // 
            // btnReceberClientes
            // 
            this.btnReceberClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceberClientes.Location = new System.Drawing.Point(642, 59);
            this.btnReceberClientes.Name = "btnReceberClientes";
            this.btnReceberClientes.Size = new System.Drawing.Size(107, 41);
            this.btnReceberClientes.TabIndex = 2;
            this.btnReceberClientes.Text = "DESAT Receber Clientes";
            this.btnReceberClientes.UseVisualStyleBackColor = true;
            this.btnReceberClientes.Visible = false;
            this.btnReceberClientes.Click += new System.EventHandler(this.btnReceberClientes_Click);
            // 
            // btnEscreverPedidos
            // 
            this.btnEscreverPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEscreverPedidos.Location = new System.Drawing.Point(529, 59);
            this.btnEscreverPedidos.Name = "btnEscreverPedidos";
            this.btnEscreverPedidos.Size = new System.Drawing.Size(107, 41);
            this.btnEscreverPedidos.TabIndex = 0;
            this.btnEscreverPedidos.Text = "DESAT Escrever Pedidos";
            this.btnEscreverPedidos.UseVisualStyleBackColor = true;
            this.btnEscreverPedidos.Visible = false;
            this.btnEscreverPedidos.Click += new System.EventHandler(this.btnEscreverPedidos_Click);
            // 
            // btnSetProdutos
            // 
            this.btnSetProdutos.Location = new System.Drawing.Point(12, 12);
            this.btnSetProdutos.Name = "btnSetProdutos";
            this.btnSetProdutos.Size = new System.Drawing.Size(107, 41);
            this.btnSetProdutos.TabIndex = 3;
            this.btnSetProdutos.Text = "Enviar Produtos, preço e estoque";
            this.btnSetProdutos.UseVisualStyleBackColor = true;
            this.btnSetProdutos.Click += new System.EventHandler(this.btnSetProdutos_Click);
            // 
            // tbcResultados
            // 
            this.tbcResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcResultados.Controls.Add(this.tbpGridView);
            this.tbcResultados.Controls.Add(this.tbpTxt);
            this.tbcResultados.Location = new System.Drawing.Point(12, 194);
            this.tbcResultados.Name = "tbcResultados";
            this.tbcResultados.SelectedIndex = 0;
            this.tbcResultados.Size = new System.Drawing.Size(737, 472);
            this.tbcResultados.TabIndex = 4;
            this.tbcResultados.Visible = false;
            // 
            // tbpGridView
            // 
            this.tbpGridView.Controls.Add(this.stsLegendas);
            this.tbpGridView.Controls.Add(this.dtgResultado);
            this.tbpGridView.Location = new System.Drawing.Point(4, 22);
            this.tbpGridView.Name = "tbpGridView";
            this.tbpGridView.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGridView.Size = new System.Drawing.Size(729, 446);
            this.tbpGridView.TabIndex = 1;
            this.tbpGridView.Text = "GridView";
            this.tbpGridView.UseVisualStyleBackColor = true;
            // 
            // stsLegendas
            // 
            this.stsLegendas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTtlRegs});
            this.stsLegendas.Location = new System.Drawing.Point(3, 421);
            this.stsLegendas.Name = "stsLegendas";
            this.stsLegendas.Size = new System.Drawing.Size(723, 22);
            this.stsLegendas.TabIndex = 1;
            this.stsLegendas.Text = "statusStrip1";
            // 
            // lblTtlRegs
            // 
            this.lblTtlRegs.Name = "lblTtlRegs";
            this.lblTtlRegs.Size = new System.Drawing.Size(110, 17);
            this.lblTtlRegs.Text = "Total de registros: 0";
            // 
            // dtgResultado
            // 
            this.dtgResultado.AllowUserToAddRows = false;
            this.dtgResultado.AllowUserToDeleteRows = false;
            this.dtgResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResultado.Location = new System.Drawing.Point(6, 6);
            this.dtgResultado.Name = "dtgResultado";
            this.dtgResultado.Size = new System.Drawing.Size(717, 412);
            this.dtgResultado.TabIndex = 0;
            // 
            // tbpTxt
            // 
            this.tbpTxt.Controls.Add(this.txtResult);
            this.tbpTxt.Location = new System.Drawing.Point(4, 22);
            this.tbpTxt.Name = "tbpTxt";
            this.tbpTxt.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTxt.Size = new System.Drawing.Size(729, 446);
            this.tbpTxt.TabIndex = 0;
            this.tbpTxt.Text = "Texto";
            this.tbpTxt.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(6, 6);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(717, 477);
            this.txtResult.TabIndex = 2;
            // 
            // btnSetEstoque
            // 
            this.btnSetEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetEstoque.Location = new System.Drawing.Point(125, 12);
            this.btnSetEstoque.Name = "btnSetEstoque";
            this.btnSetEstoque.Size = new System.Drawing.Size(107, 41);
            this.btnSetEstoque.TabIndex = 5;
            this.btnSetEstoque.Text = "DESAT Enviar Estoque";
            this.btnSetEstoque.UseVisualStyleBackColor = true;
            this.btnSetEstoque.Visible = false;
            this.btnSetEstoque.Click += new System.EventHandler(this.btnSetEstoque_Click);
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.Location = new System.Drawing.Point(12, 135);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(737, 41);
            this.pgbProgresso.TabIndex = 6;
            this.pgbProgresso.Visible = false;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(15, 178);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(54, 13);
            this.lblProduto.TabIndex = 3;
            this.lblProduto.Text = "lblProduto";
            this.lblProduto.Visible = false;
            // 
            // tempoSync
            // 
            this.tempoSync.Interval = 3600000;
            this.tempoSync.Tick += new System.EventHandler(this.tempoSync_Tick);
            // 
            // tempoStart
            // 
            this.tempoStart.Interval = 10000;
            this.tempoStart.Tick += new System.EventHandler(this.tempoStart_Tick);
            // 
            // cbxExibeGrid
            // 
            this.cbxExibeGrid.AutoSize = true;
            this.cbxExibeGrid.Location = new System.Drawing.Point(236, 13);
            this.cbxExibeGrid.Name = "cbxExibeGrid";
            this.cbxExibeGrid.Size = new System.Drawing.Size(104, 17);
            this.cbxExibeGrid.TabIndex = 8;
            this.cbxExibeGrid.Text = "Mostrar detalhes";
            this.cbxExibeGrid.UseVisualStyleBackColor = true;
            this.cbxExibeGrid.CheckedChanged += new System.EventHandler(this.cbxExibeGrid_CheckedChanged);
            // 
            // cbxSyncPedido
            // 
            this.cbxSyncPedido.AutoSize = true;
            this.cbxSyncPedido.Checked = true;
            this.cbxSyncPedido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSyncPedido.Location = new System.Drawing.Point(236, 35);
            this.cbxSyncPedido.Name = "cbxSyncPedido";
            this.cbxSyncPedido.Size = new System.Drawing.Size(118, 17);
            this.cbxSyncPedido.TabIndex = 9;
            this.cbxSyncPedido.Text = "Sincronizar pedidos";
            this.cbxSyncPedido.UseVisualStyleBackColor = true;
            this.cbxSyncPedido.CheckedChanged += new System.EventHandler(this.cbxSyncPedido_CheckedChanged);
            this.cbxSyncPedido.CheckStateChanged += new System.EventHandler(this.cbxSyncPedido_CheckStateChanged);
            // 
            // cbxSyncProduto
            // 
            this.cbxSyncProduto.AutoSize = true;
            this.cbxSyncProduto.Checked = true;
            this.cbxSyncProduto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSyncProduto.Location = new System.Drawing.Point(236, 59);
            this.cbxSyncProduto.Name = "cbxSyncProduto";
            this.cbxSyncProduto.Size = new System.Drawing.Size(123, 17);
            this.cbxSyncProduto.TabIndex = 10;
            this.cbxSyncProduto.Text = "Sincronizar Produtos";
            this.cbxSyncProduto.UseVisualStyleBackColor = true;
            this.cbxSyncProduto.CheckedChanged += new System.EventHandler(this.cbxSyncProduto_CheckedChanged);
            // 
            // lblCpro
            // 
            this.lblCpro.AutoSize = true;
            this.lblCpro.Location = new System.Drawing.Point(12, 85);
            this.lblCpro.Name = "lblCpro";
            this.lblCpro.Size = new System.Drawing.Size(440, 13);
            this.lblCpro.TabIndex = 11;
            this.lblCpro.Text = "Informe o CPRO a sincronizar. Caso nenhum seja informado, sincronizará todos os p" +
    "rodutos.";
            // 
            // txtCpro
            // 
            this.txtCpro.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpro.Location = new System.Drawing.Point(12, 101);
            this.txtCpro.Name = "txtCpro";
            this.txtCpro.Size = new System.Drawing.Size(100, 27);
            this.txtCpro.TabIndex = 12;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxLogo.Location = new System.Drawing.Point(12, 194);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(737, 472);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 7;
            this.pbxLogo.TabStop = false;
            this.pbxLogo.Visible = false;
            // 
            // cbxEscreveString
            // 
            this.cbxEscreveString.AutoSize = true;
            this.cbxEscreveString.Location = new System.Drawing.Point(365, 13);
            this.cbxEscreveString.Name = "cbxEscreveString";
            this.cbxEscreveString.Size = new System.Drawing.Size(98, 17);
            this.cbxEscreveString.TabIndex = 13;
            this.cbxEscreveString.Text = "Escrever String";
            this.cbxEscreveString.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 678);
            this.Controls.Add(this.cbxEscreveString);
            this.Controls.Add(this.txtCpro);
            this.Controls.Add(this.lblCpro);
            this.Controls.Add(this.cbxSyncProduto);
            this.Controls.Add(this.cbxSyncPedido);
            this.Controls.Add(this.cbxExibeGrid);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.pgbProgresso);
            this.Controls.Add(this.btnSetEstoque);
            this.Controls.Add(this.tbcResultados);
            this.Controls.Add(this.btnSetProdutos);
            this.Controls.Add(this.btnReceberClientes);
            this.Controls.Add(this.btnEscreverPedidos);
            this.Controls.Add(this.btnReceberPedidos);
            this.Controls.Add(this.btnStatusPedido);
            this.Controls.Add(this.pbxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrimaveraSync";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbcResultados.ResumeLayout(false);
            this.tbpGridView.ResumeLayout(false);
            this.tbpGridView.PerformLayout();
            this.stsLegendas.ResumeLayout(false);
            this.stsLegendas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultado)).EndInit();
            this.tbpTxt.ResumeLayout(false);
            this.tbpTxt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStatusPedido;
        private System.Windows.Forms.Button btnReceberPedidos;
        private System.Windows.Forms.Button btnReceberClientes;
        private System.Windows.Forms.Button btnEscreverPedidos;
        private System.Windows.Forms.Button btnSetProdutos;
        private System.Windows.Forms.TabControl tbcResultados;
        private System.Windows.Forms.TabPage tbpTxt;
        private System.Windows.Forms.TabPage tbpGridView;
        private System.Windows.Forms.DataGridView dtgResultado;
        private System.Windows.Forms.StatusStrip stsLegendas;
        private System.Windows.Forms.ToolStripStatusLabel lblTtlRegs;
        private System.Windows.Forms.Button btnSetEstoque;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Timer tempoSync;
        private System.Windows.Forms.Timer tempoStart;
        private System.Windows.Forms.CheckBox cbxExibeGrid;
        private System.Windows.Forms.CheckBox cbxSyncPedido;
        private System.Windows.Forms.CheckBox cbxSyncProduto;
        private System.Windows.Forms.Label lblCpro;
        private System.Windows.Forms.TextBox txtCpro;
        private System.Windows.Forms.PictureBox pbxLogo;
        public System.Windows.Forms.CheckBox cbxEscreveString;
        public System.Windows.Forms.TextBox txtResult;
    }
}

