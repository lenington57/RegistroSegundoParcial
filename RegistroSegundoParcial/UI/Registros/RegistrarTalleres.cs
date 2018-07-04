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
    public partial class RegistrarTalleres : Form
    {
        public RegistrarTalleres()
        {
            InitializeComponent();
        }

        private Talleres LlenaClase()
        {
            Talleres talleres  = new Talleres();

            talleres.TallerId = Convert.ToInt32(TallerIdNumericUpDown.Value);
            talleres.Nombre = NombreTextBox.Text;

            return talleres;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TallerIdNumericUpDown.Value);
            Talleres talleres = TalleresBLL.Buscar(id);
            if (talleres != null)
            {
                NombreTextBox.Text = talleres.Nombre;
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            TallerIdNumericUpDown.Value = 0;
            NombreTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Talleres talleres;
            bool Paso = false;

            talleres = LlenaClase();
            
            if (TallerIdNumericUpDown.Value == 0)
                Paso = TalleresBLL.Guardar(talleres);
            else
                Paso = TalleresBLL.Modificar(LlenaClase());
            
            if (Paso)
                MessageBox.Show("Guardado", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TallerIdNumericUpDown.Value);

            if (TalleresBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RegistrarTalleres_Load(object sender, EventArgs e)
        {

        }
    }
}
