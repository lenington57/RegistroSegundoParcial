namespace RegistroSegundoParcial
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.registrarArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEntradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarTalleresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarVehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarMantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.registrosToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.AyudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(282, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarArticulosToolStripMenuItem,
            this.registrarEntradasToolStripMenuItem,
            this.registrarTalleresToolStripMenuItem,
            this.registrarVehiculosToolStripMenuItem,
            this.registrarMantenimientosToolStripMenuItem});
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.registrosToolStripMenuItem.Text = "Registros";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // AyudaToolStripMenuItem
            // 
            this.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem";
            this.AyudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.AyudaToolStripMenuItem.Text = "Ayuda";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(282, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // registrarArticulosToolStripMenuItem
            // 
            this.registrarArticulosToolStripMenuItem.Name = "registrarArticulosToolStripMenuItem";
            this.registrarArticulosToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.registrarArticulosToolStripMenuItem.Text = "Registrar Articulos";
            this.registrarArticulosToolStripMenuItem.Click += new System.EventHandler(this.registrarArticulosToolStripMenuItem_Click);
            // 
            // registrarEntradasToolStripMenuItem
            // 
            this.registrarEntradasToolStripMenuItem.Name = "registrarEntradasToolStripMenuItem";
            this.registrarEntradasToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.registrarEntradasToolStripMenuItem.Text = "Registrar Entradas";
            this.registrarEntradasToolStripMenuItem.Click += new System.EventHandler(this.registrarEntradasToolStripMenuItem_Click);
            // 
            // registrarTalleresToolStripMenuItem
            // 
            this.registrarTalleresToolStripMenuItem.Name = "registrarTalleresToolStripMenuItem";
            this.registrarTalleresToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.registrarTalleresToolStripMenuItem.Text = "Registrar Talleres";
            this.registrarTalleresToolStripMenuItem.Click += new System.EventHandler(this.registrarTalleresToolStripMenuItem_Click);
            // 
            // registrarVehiculosToolStripMenuItem
            // 
            this.registrarVehiculosToolStripMenuItem.Name = "registrarVehiculosToolStripMenuItem";
            this.registrarVehiculosToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.registrarVehiculosToolStripMenuItem.Text = "Registrar Vehiculos";
            this.registrarVehiculosToolStripMenuItem.Click += new System.EventHandler(this.registrarVehiculosToolStripMenuItem_Click);
            // 
            // registrarMantenimientosToolStripMenuItem
            // 
            this.registrarMantenimientosToolStripMenuItem.Name = "registrarMantenimientosToolStripMenuItem";
            this.registrarMantenimientosToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.registrarMantenimientosToolStripMenuItem.Text = "Registrar Mantenimientos";
            this.registrarMantenimientosToolStripMenuItem.Click += new System.EventHandler(this.registrarMantenimientosToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 354);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AyudaToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem registrarArticulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarEntradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarTalleresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarVehiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarMantenimientosToolStripMenuItem;
    }
}

