using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroSegundoParcial.BLL;
using RegistroSegundoParcial.DAL;
using RegistroSegundoParcial.Entidades;

namespace RegistroSegundoParcial.UI.Registros
{
    public partial class RegistrarEntradaArticulos : Form
    {
        public RegistrarEntradaArticulos()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Repositorio<Articulos> ArtRepositorio = new Repositorio<Articulos>(new Contexto());
            
            ArticuloComboBox.DataSource = ArtRepositorio.GetList(c => true);
            ArticuloComboBox.ValueMember = "ArticuloId";
            ArticuloComboBox.DisplayMember = "Descripcion";
        }

        private Entradas LlenaClase()
        {
            Entradas entradas = new Entradas();

            entradas.EntradaId = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            entradas.Fecha = FechaDateTimePicker.Value;
            entradas.Articulo = ArticuloComboBox.Text;
            entradas.Cantidad = Convert.ToInt32(CantidadTextBox.Text);

            return entradas;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            Entradas entradas = EntradasBLL.Buscar(id);
            if (entradas != null)
            {
                FechaDateTimePicker.Value = entradas.Fecha;
                ArticuloComboBox.Text = entradas.Articulo;
                CantidadTextBox.Text = entradas.Cantidad.ToString();
            }
            else
                MessageBox.Show("No se encontró", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            EntradaIdNumericUpDown.Value = 0;
            ArticuloComboBox.SelectedIndex = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            CantidadTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Entradas entradas;
            bool Paso = false;

            entradas = LlenaClase();

            if (EntradaIdNumericUpDown.Value == 0)
                Paso = EntradasBLL.Guardar(entradas);
            else
            {                
                Paso = EntradasBLL.Modificar(LlenaClase());
            }               

            if (Paso)
                MessageBox.Show("Guardado", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LlenarInventario();

            EntradasBLL.LlenarInventario(LlenaClase());
            
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);

            if (EntradasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //RebajarInventario();
        }
        
        public void LlenarInventario()
        {
            Entradas entradas =  LlenaClase();
            foreach (var item in ArticulosBLL.GetList(c => c.Descripcion == entradas.Articulo))
            {
                item.Inventario += entradas.Cantidad;
                ArticulosBLL.Modificar(item);
            }
        }

        
    }
}
