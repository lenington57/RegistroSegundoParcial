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
    public partial class RegistrarVehiculos : Form
    {
        public RegistrarVehiculos()
        {
            InitializeComponent();
        }

        //Métodos
        private Vehiculos LlenaClase()
        {
            Vehiculos vehiculos = new Vehiculos();

            vehiculos.VehiculoId = Convert.ToInt32(VehiculoIdNumericUpDown.Value);
            vehiculos.Descripcion = DescripcionTextBox.Text;
            vehiculos.TotalMantenimiento = 0;

            return vehiculos;
        }

        private void Limpiar()
        {
            VehiculoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
            MantenimientoTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox,
                    "Debes escribir una Descripción para el Vehículo");
                HayErrores = true;
            }

            return HayErrores;
        }


        //Programación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VehiculoIdNumericUpDown.Value);
            Vehiculos vehiculos = VehiculosBLL.Buscar(id);

            if (vehiculos != null)
            {
                DescripcionTextBox.Text = vehiculos.Descripcion;
                MantenimientoTextBox.Text = vehiculos.TotalMantenimiento.ToString();
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
            Vehiculos vehiculos;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Debe llenar éste campo!!!", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vehiculos = LlenaClase();

            if (VehiculoIdNumericUpDown.Value == 0)
                Paso = VehiculosBLL.Guardar(vehiculos);
            else
            {
                int id = Convert.ToInt32(VehiculoIdNumericUpDown.Value);
                vehiculos = VehiculosBLL.Buscar(id);

                if (vehiculos != null)
                {
                    Paso = VehiculosBLL.Modificar(LlenaClase());
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
            int id = Convert.ToInt32(VehiculoIdNumericUpDown.Value);
            Vehiculos vehiculos = VehiculosBLL.Buscar(id);

            if (vehiculos != null)
            {
                if (VehiculosBLL.Eliminar(id))
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

    }
}
