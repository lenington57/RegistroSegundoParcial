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

        private Vehiculos LlenaClase()
        {
            Vehiculos vehiculos = new Vehiculos();

            vehiculos.VehiculoId = Convert.ToInt32(VehiculoIdNumericUpDown.Value);
            vehiculos.Descripcion = DescripcionTextBox.Text;
            vehiculos.Mantenimiento = Convert.ToInt32(MantenimientoTextBox.Text);

            return vehiculos;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VehiculoIdNumericUpDown.Value);
            Vehiculos vehiculos = VehiculosBLL.Buscar(id);

            if (vehiculos != null)
            {
                DescripcionTextBox.Text = vehiculos.Descripcion;
                MantenimientoTextBox.Text = vehiculos.Mantenimiento.ToString();
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            VehiculoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
            MantenimientoTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Vehiculos vehiculos;
            bool Paso = false;

            vehiculos = LlenaClase();

            if (VehiculoIdNumericUpDown.Value == 0)
                Paso = VehiculosBLL.Guardar(vehiculos);
            else
                Paso = VehiculosBLL.Modificar(LlenaClase());

            if (Paso)
                MessageBox.Show("Guardado", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VehiculoIdNumericUpDown.Value);

            if (VehiculosBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
