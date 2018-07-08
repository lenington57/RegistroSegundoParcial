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
    public partial class ConsultarMantenimientos : Form
    {
        public ConsultarMantenimientos()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Mantenimiento, bool>> filtro = m => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Mantenimiento.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = m => m.MantenimientoId == id;
                    break;
                case 1://Filtrando por la Fecha del Mantenimiento.
                    filtro = m => m.Fecha >= DesdeDateTimePicker.Value && m.Fecha <= HastaDateTimePicker.Value;
                    break;
                case 2://Filtrando por Fecha del Próximo Mantenimiento.
                    filtro = m => m.FechaProximo >= DesdeDateTimePicker.Value && m.FechaProximo <= HastaDateTimePicker.Value;
                    break;
                case 3://Filtrando por SubTotal del Mantenimiento.
                    filtro = m => m.SubTotal.Equals(CriterioTextBox.Text);
                    break;
                case 4://Filtrando por Cantidad Itbis del Mantenimiento.
                    filtro = m => m.Itbis.Equals(CriterioTextBox.Text);
                    break;
                case 5://Filtrando por Total del Mantenimiento.
                    filtro = m => m.Total.Equals(CriterioTextBox.Text);
                    break;
            }

            ConsultaMantenimientoDataGridView.DataSource = MantenimientoBLL.GetList(filtro);
        }

        private void comboBoxFiltrar_SelectedIndexChanged(object sender, EventArgs e)
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
