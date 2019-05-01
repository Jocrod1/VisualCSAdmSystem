namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRegistros = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSistema,
            this.MnuRegistros,
            this.MnuProcesos,
            this.acercaDeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(894, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // MnuSistema
            // 
            this.MnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirDelSistemaToolStripMenuItem});
            this.MnuSistema.Image = ((System.Drawing.Image)(resources.GetObject("MnuSistema.Image")));
            this.MnuSistema.Name = "MnuSistema";
            this.MnuSistema.Size = new System.Drawing.Size(95, 36);
            this.MnuSistema.Text = "Sistema ";
            // 
            // salirDelSistemaToolStripMenuItem
            // 
            this.salirDelSistemaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirDelSistemaToolStripMenuItem.Image")));
            this.salirDelSistemaToolStripMenuItem.Name = "salirDelSistemaToolStripMenuItem";
            this.salirDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.salirDelSistemaToolStripMenuItem.Text = "Salir";
            this.salirDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salirDelSistemaToolStripMenuItem_Click);
            // 
            // MnuRegistros
            // 
            this.MnuRegistros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.trabajadoresToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.articulosToolStripMenuItem});
            this.MnuRegistros.Image = ((System.Drawing.Image)(resources.GetObject("MnuRegistros.Image")));
            this.MnuRegistros.Name = "MnuRegistros";
            this.MnuRegistros.Size = new System.Drawing.Size(99, 36);
            this.MnuRegistros.Text = "Registros";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clientesToolStripMenuItem.Image")));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // trabajadoresToolStripMenuItem
            // 
            this.trabajadoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trabajadoresToolStripMenuItem.Image")));
            this.trabajadoresToolStripMenuItem.Name = "trabajadoresToolStripMenuItem";
            this.trabajadoresToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.trabajadoresToolStripMenuItem.Text = "Trabajadores";
            this.trabajadoresToolStripMenuItem.Click += new System.EventHandler(this.trabajadoresToolStripMenuItem_Click_1);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("proveedoresToolStripMenuItem.Image")));
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("articulosToolStripMenuItem.Image")));
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(168, 38);
            this.articulosToolStripMenuItem.Text = "Articulos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click_1);
            // 
            // MnuProcesos
            // 
            this.MnuProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresoToolStripMenuItem,
            this.ventaToolStripMenuItem});
            this.MnuProcesos.Image = ((System.Drawing.Image)(resources.GetObject("MnuProcesos.Image")));
            this.MnuProcesos.Name = "MnuProcesos";
            this.MnuProcesos.Size = new System.Drawing.Size(98, 36);
            this.MnuProcesos.Text = "Procesos";
            // 
            // ingresoToolStripMenuItem
            // 
            this.ingresoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ingresoToolStripMenuItem.Image")));
            this.ingresoToolStripMenuItem.Name = "ingresoToolStripMenuItem";
            this.ingresoToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ingresoToolStripMenuItem.Text = "Ingreso";
            this.ingresoToolStripMenuItem.Click += new System.EventHandler(this.ingresoToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventaToolStripMenuItem.Image")));
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("acercaDeToolStripMenuItem.Image")));
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(103, 36);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(894, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel.Text = "Crystal Blue Sistema";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(894, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPrincipal";
            this.Text = "Farmacia Crystal Blue - Sistema de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem MnuSistema;
        private System.Windows.Forms.ToolStripMenuItem salirDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuRegistros;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trabajadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuProcesos;
        private System.Windows.Forms.ToolStripMenuItem ingresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}



