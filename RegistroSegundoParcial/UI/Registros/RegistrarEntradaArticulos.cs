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

        //Métodos
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
            entradas.ArticuloId = Convert.ToInt32(ArticuloComboBox.SelectedValue);
            entradas.Cantidad = Convert.ToDouble(CantidadTextBox.Text);

            return entradas;
        }

        private void Limpiar()
        {
            EntradaIdNumericUpDown.Value = 0;
            ArticuloComboBox.SelectedIndex = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            CantidadTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(CantidadTextBox.Text))
            {
                MyErrorProvider.SetError(CantidadTextBox,
                    "Debes escribir una Cantidad para el Artículo");
                HayErrores = true;
            }           

            return HayErrores;
        }


        //Programación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            Entradas entradas = EntradasBLL.Buscar(id);
            if (entradas != null)
            {
                FechaDateTimePicker.Value = entradas.Fecha;
                ArticuloComboBox.SelectedValue = entradas.ArticuloId;
                CantidadTextBox.Text = entradas.Cantidad.ToString();
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
            Entradas entradas;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Debe llenar éste campo!!!", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entradas = LlenaClase();

            if (EntradaIdNumericUpDown.Value == 0)
                Paso = EntradasBLL.Guardar(entradas);
            else
            {
                int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
                entradas = EntradasBLL.Buscar(id);

                if (entradas != null)
                {
                    Paso = EntradasBLL.Modificar(LlenaClase());
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            Entradas entradas = EntradasBLL.Buscar(id);

            if (entradas != null)
            {
                if (EntradasBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }    
        
    }
}
