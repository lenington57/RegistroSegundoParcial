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
    public partial class ConsultarTalleres : Form
    {
        public ConsultarTalleres()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Talleres, bool>> filtro = t => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Taller.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = t => t.TallerId == id;
                    break;
                case 1://Filtrando por el Nombre del Taller.
                    filtro = t => t.Nombre.Contains(CriterioTextBox.Text);
                    break;
            }

            TalleresConsultaDataGridView.DataSource = TalleresBLL.GetList(filtro);
        }

        private void dataGridViewConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
