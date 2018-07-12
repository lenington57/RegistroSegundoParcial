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

        //Métodos
        private Talleres LlenaClase()
        {
            Talleres talleres  = new Talleres();

            talleres.TallerId = Convert.ToInt32(TallerIdNumericUpDown.Value);
            talleres.Nombre = NombreTextBox.Text;

            return talleres;
        }

        private void Limpiar()
        {
            TallerIdNumericUpDown.Value = 0;
            NombreTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox,
                    "Debes escribir un Nombre para el Taller");
                HayErrores = true;
            }

            return HayErrores;
        }


        //Programación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TallerIdNumericUpDown.Value);
            Talleres talleres = TalleresBLL.Buscar(id);
            if (talleres != null)
            {
                NombreTextBox.Text = talleres.Nombre;
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
            Talleres talleres;
            bool Paso = false;


            if (HayErrores())
            {
                MessageBox.Show("Debe llenar éste campo!!!", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            talleres = LlenaClase();

            if (TallerIdNumericUpDown.Value == 0)
                Paso = TalleresBLL.Guardar(talleres);
            else
            {
                int id = Convert.ToInt32(TallerIdNumericUpDown.Value);
                talleres = TalleresBLL.Buscar(id);

                if (talleres != null)
                {
                    Paso = TalleresBLL.Modificar(LlenaClase());
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
            int id = Convert.ToInt32(TallerIdNumericUpDown.Value);

            Talleres talleres = TalleresBLL.Buscar(id);
            if (talleres != null)
            {
                if (TalleresBLL.Eliminar(id))
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

            private void RegistrarTalleres_Load(object sender, EventArgs e)
        {

        }
    }
}
