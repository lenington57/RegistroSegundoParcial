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

        //Métodos
        private Articulos LlenaClase()
        {
            Articulos articulos = new Articulos();

            articulos.ArticuloId = Convert.ToInt32(ArtículoIdNumericUpDown.Value);
            articulos.Descripcion = DescripcionTextBox.Text;
            articulos.Costo = Convert.ToDouble(CostoTextBox.Text);
            articulos.Precio = Convert.ToDouble(PrecioTextBox.Text);
            articulos.PorcientoGanacia = Convert.ToDouble(PctGananciaTextBox.Text);
            articulos.Inventario = 0;

            return articulos;
        }

        private void Limpiar()
        {
            ArtículoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
            CostoTextBox.Clear();
            PrecioTextBox.Clear();
            PctGananciaTextBox.Clear();
            InventarioTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox,
                    "Debes escribir una Decripción para el Artículo");
                HayErrores = true;
            }

            if (String.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MyErrorProvider.SetError(CostoTextBox,
                    "Debes digitar un Costo para el Artículo");
                HayErrores = true;
            }

            if (String.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                MyErrorProvider.SetError(PrecioTextBox,
                    "Debes digitar un Precio para el Artículo");
                HayErrores = true;
            }            

            if (String.IsNullOrWhiteSpace(PctGananciaTextBox.Text) && String.IsNullOrWhiteSpace(CostoTextBox.Text))
            {
                MyErrorProvider.SetError(CostoTextBox,
                    "Debes digitar un Costo que desea del Artículo");
                HayErrores = true;
            }

            if (String.IsNullOrWhiteSpace(PctGananciaTextBox.Text) && String.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                MyErrorProvider.SetError(PrecioTextBox,
                    "Debes digitar un Precio para el Artículo");
                HayErrores = true;
            }

            return HayErrores;
        }


        //Programación de los Botones
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
                MessageBox.Show("No se encontró", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Articulos articulos;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Debe llenar todos los campos que se indican!!!", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            articulos = LlenaClase();

            if (ArtículoIdNumericUpDown.Value == 0)
                Paso = ArticulosBLL.Guardar(articulos);
            else
                Paso = ArticulosBLL.Modificar(LlenaClase());

            if (Paso)
            {
                MessageBox.Show("Guardado", "Exito",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArtículoIdNumericUpDown.Value);

            Articulos articulos = ArticulosBLL.Buscar(id);
            if (articulos != null)
            {
                if (ArticulosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }

                else
                    MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PrecioTextBox.Text != string.Empty)
            {
                double costo, precio;
                costo = ToDouble(CostoTextBox.Text);
                precio = ToDouble(PrecioTextBox.Text);
                PctGananciaTextBox.Text = ArticulosBLL.PorcientoGanancia(costo, precio).ToString();
            }
        }

        private void CostoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PrecioTextBox.Text != string.Empty)
            {
                double costo, precio;
                costo = ToDouble(CostoTextBox.Text);
                precio = ToDouble(PrecioTextBox.Text);
                PctGananciaTextBox.Text = ArticulosBLL.PorcientoGanancia(costo, precio).ToString();
            }               
            
        }

        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }
    }
}
