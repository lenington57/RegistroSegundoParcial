using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistroSegundoParcial.BLL;
using RegistroSegundoParcial.Entidades;

namespace RegistroSegundoParcial.UI.Consultas
{
    public partial class ConsultarVehiculos : Form
    {
        public ConsultarVehiculos()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Vehiculos, bool>> filtro = v => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Vehículo.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = v => v.VehiculoId == id;
                    break;
                case 1://Filtrando por la Descripción del Vehículo.
                    filtro = v => v.Descripcion.Contains(CriterioTextBox.Text);
                    break;
                case 2://Filtrando por Costo Total de Mantenimiento del Vehículo.
                    filtro = v => v.TotalMantenimiento.Equals((double)Convert.ToDouble(CriterioTextBox.Text));
                    break;
            }

            VehiculosConsultaDataGridView.DataSource = VehiculosBLL.GetList(filtro);
        }
    }
}
