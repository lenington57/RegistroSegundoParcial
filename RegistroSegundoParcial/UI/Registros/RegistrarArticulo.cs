using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroSegundoParcial.Entidades;
using RegistroSegundoParcial.BLL;

namespace RegistroSegundoParcial.UI.Registros
{
    public partial class RegistrarArticulo : Form
    {
        public RegistrarArticulo()
        {
            InitializeComponent();
        }

        private Articulos LlenaClase()
        {
            Articulos articulos = new Articulos();

            articulos.ArticuloId = Convert.ToInt32(ArtículoIdNumericUpDown.Value);
            articulos.Descripcion = DescripcionTextBox.Text;
            articulos.Costo = Convert.ToInt32(CostoTextBox.Text);
            articulos.Precio = Convert.ToInt32(PrecioTextBox.Text);
            articulos.PorcientoGanacia = Convert.ToInt32(PctGananciaTextBox.Text);
            articulos.Inventario = 0;

            return articulos;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArtículoIdNumericUpDown.Value);
            Articulos articulos = ArticulosBLL.Buscar(id);

            if (articulos != null)
            {
                DescripcionTextBox.Text = articulos.Descripcion;
                CostoTextBox.Text = articulos.Costo.ToString();
                PrecioTextBox.Text = articulos.Precio.ToString();
                PctGananciaTextBox.Text = articulos.PorcientoGanacia.ToString();
                InventarioTextBox.Text = articulos.Inventario.ToString();
            }
            else
                MessageBox.Show("No se encontró", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ArtículoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
            CostoTextBox.Clear();
            PrecioTextBox.Clear();
            PctGananciaTextBox.Clear();
            InventarioTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Articulos articulos;
            bool Paso = false;

            articulos = LlenaClase();

            if (ArtículoIdNumericUpDown.Value == 0)
                Paso = ArticulosBLL.Guardar(articulos);
            else
                Paso = ArticulosBLL.Modificar(LlenaClase());

            if (Paso)
                MessageBox.Show("Guardado", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArtículoIdNumericUpDown.Value);

            if (ArticulosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
