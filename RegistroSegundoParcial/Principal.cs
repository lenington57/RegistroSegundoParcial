using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroSegundoParcial.UI.Registros;
using RegistroSegundoParcial.UI.Consultas;
namespace RegistroSegundoParcial
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        //Formularios de los Registros
        private void registrarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarArticulo registrarArticulo = new RegistrarArticulo();
            registrarArticulo.MdiParent = this;
            registrarArticulo.Show();
        }

        private void registrarEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarEntradaArticulos registrarEntradaArticulos = new RegistrarEntradaArticulos();
            registrarEntradaArticulos.MdiParent = this;
            registrarEntradaArticulos.Show();
        }

        private void registrarTalleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarTalleres registrarTalleres = new RegistrarTalleres();
            registrarTalleres.MdiParent = this;
            registrarTalleres.Show();
        }

        private void registrarVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarVehiculos registrarVehiculos = new RegistrarVehiculos();
            registrarVehiculos.MdiParent = this;
            registrarVehiculos.Show();
        }

        private void registrarMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMantenimiento registrarMantenimiento = new RegistrarMantenimiento();
            registrarMantenimiento.MdiParent = this;
            registrarMantenimiento.Show();
        }

        //Formularios de las Consultas
        private void consultarArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarArticulos consultarArticulos = new ConsultarArticulos();
            consultarArticulos.MdiParent = this;
            consultarArticulos.Show();
        }

        private void consultarEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarEntradasArticulos consultarEntradasArticulos = new ConsultarEntradasArticulos();
            consultarEntradasArticulos.MdiParent = this;
            consultarEntradasArticulos.Show();
        }

        private void consultarTalleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarTalleres consultarTalleres = new ConsultarTalleres();
            consultarTalleres.MdiParent = this;
            consultarTalleres.Show();
        }

        private void consultarVehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarVehiculos consultarVehiculos = new ConsultarVehiculos();
            consultarVehiculos.MdiParent = this;
            consultarVehiculos.Show();
        }

        private void consultarMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarMantenimientos consultarMantenimientos = new ConsultarMantenimientos();
            consultarMantenimientos.MdiParent = this;
            consultarMantenimientos.Show();
        }
    }
}
