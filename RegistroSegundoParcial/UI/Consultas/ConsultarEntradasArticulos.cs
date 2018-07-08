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
    public partial class ConsultarEntradasArticulos : Form
    {
        public ConsultarEntradasArticulos()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Entradas, bool>> filtro = ea => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID de la Entrada.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = ea => ea.EntradaId == id;
                    break;
                case 1://Filtrando por la Fecha de la Entrada.
                    filtro = ea => ea.Fecha >= DesdeDateTimePicker.Value && ea.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 2://Filtrando por Nombre del Artículo.
                    filtro = ea => ea.Articulo.Equals(CriterioTextBox.Text) && ea.Fecha >= DesdeDateTimePicker.Value && ea.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 3://Filtrando por Cantidad de Entrada del Artículo.
                    filtro = ea => ea.Cantidad.Equals(CriterioTextBox.Text) && ea.Fecha >= DesdeDateTimePicker.Value && ea.Fecha <= HastaDateTimePicker.Value; 
                    break;
            }

            EntradasArticulosConsultaDataGridView.DataSource = EntradasBLL.GetList(filtro);
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroComboBox.SelectedIndex == 1)
            {
                CriterioTextBox.Visible = false;
                CriterioLabel.Visible = false;
            }
            else
            {
                CriterioTextBox.Visible = true;
                CriterioLabel.Visible = true;
            }
        }
    }
}
