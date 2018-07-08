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
    public partial class ConsultarArticulos : Form
    {
        public ConsultarArticulos()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> filtro = a => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Artículo.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = a => a.ArticuloId == id;
                    break;
                case 1://Filtrando por la Fecha de Vencimiento del Artículo.
                    filtro = a => a.Descripcion.Contains(CriterioTextBox.Text);
                    break;
                case 2://Filtrando por Costo del Artículo.
                    filtro = a => a.Costo.Equals(CriterioTextBox.Text);
                    break;
                case 3://Filtrando por Precio del Artículo.
                    filtro = a => a.Precio.Equals(CriterioTextBox.Text);
                    break;
                case 4://Filtrando por PorcientoGanacia del Artículo.
                    filtro = a => a.PorcientoGanacia.Equals(CriterioTextBox.Text);
                    break;
                case 5://Filtrando por Cantidad en el Inventario del Artículo.
                    filtro = a => a.Inventario.Equals(CriterioTextBox.Text);
                    break;
            }

            ArticulosConsultaDataGridView.DataSource = ArticulosBLL.GetList(filtro);
        }

        private void HastaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DesdeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
