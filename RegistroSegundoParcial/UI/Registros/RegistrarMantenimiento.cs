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
    public partial class RegistrarMantenimiento : Form
    {
        public RegistrarMantenimiento()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarCampos(Mantenimiento mantenimiento)
        {
            MantenimientoIdNumericUpDown.Value = mantenimiento.MantenimientoId;
            FechaDateTimePicker.Value = mantenimiento.Fecha;
            ProxManteDateTimePicker.Value = mantenimiento.FechaProximo;
            SubTotalTextBox.Text = mantenimiento.SubTotal.ToString();
            ItbisTextBox.Text = mantenimiento.Itbis.ToString();
            TotalTextBox.Text = mantenimiento.Total.ToString();

            MantenimientoDetalleDataGridView.DataSource = mantenimiento.Detalle;

            MantenimientoDetalleDataGridView.Columns["Id"].Visible = false;
            MantenimientoDetalleDataGridView.Columns["MantenimientoId"].Visible = false;
        }

        private void LlenarComboBox()
        {
            Repositorio<Vehiculos> VehRepositorio = new Repositorio<Vehiculos>(new Contexto());
            Repositorio<Talleres> TallRepositorio = new Repositorio<Talleres>(new Contexto());
            Repositorio<Articulos> ArtRepositorio = new Repositorio<Articulos>(new Contexto());

            VehiculoComboBox.DataSource = ArtRepositorio.GetList(c => true);
            VehiculoComboBox.ValueMember = "VehiculoId";
            VehiculoComboBox.DisplayMember = "Descripcion";

            TallerComboBox.DataSource = ArtRepositorio.GetList(c => true);
            TallerComboBox.ValueMember = "TallerId";
            TallerComboBox.DisplayMember = "Nombre";

            ArticuloComboBox.DataSource = ArtRepositorio.GetList(c => true);
            ArticuloComboBox.ValueMember = "ArticuloId";
            ArticuloComboBox.DisplayMember = "Descripcion";
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
            mantenimiento.Fecha = FechaDateTimePicker.Value;
            mantenimiento.FechaProximo = ProxManteDateTimePicker.Value;
            mantenimiento.SubTotal = Convert.ToInt32(SubTotalTextBox.Text);
            mantenimiento.Itbis = Convert.ToInt32(ItbisTextBox.Text);
            mantenimiento.Total = Convert.ToInt32(TotalTextBox.Text);            

            foreach (DataGridViewRow item in MantenimientoDetalleDataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["MantenimientoId"].Value),
                    ToInt(item.Cells["VehiculoId"].Value),
                    ToInt(item.Cells["TallerId"].Value),
                    ToInt(item.Cells["ArticuloId"].Value),
                    "Articulo",
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                );
            }

            return mantenimiento;
        }


        private void RegistrarMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void AgregarButtton_Click(object sender, EventArgs e)
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();

            if (MantenimientoDetalleDataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;
            }

            detalle.Add(
                new MantenimientoDetalle(
                    id: 0,
                    mantenimientoId: (int)MantenimientoIdNumericUpDown.Value,
                    vehiculoId: (int)VehiculoComboBox.SelectedValue,
                    tallerId: (int)TallerComboBox.SelectedValue,
                    articuloId: (int)ArticuloComboBox.SelectedValue,
                    articulo: ArticuloComboBox.Text,
                    cantidad: (int)Convert.ToInt32(CantidadNumericUpDown.Value),
                    precio: (int)Convert.ToInt32(PrecioTextBox.Text),
                    importe: (int)Convert.ToInt32(ImporteTextBox.Text)
                ));
            
            MantenimientoDetalleDataGridView.DataSource = null;
            MantenimientoDetalleDataGridView.DataSource = detalle;
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if (MantenimientoDetalleDataGridView.Rows.Count > 0 && MantenimientoDetalleDataGridView.CurrentRow != null)
            {
                List<MantenimientoDetalle> detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;
                
                detalle.RemoveAt(MantenimientoDetalleDataGridView.CurrentRow.Index);
                
                MantenimientoDetalleDataGridView.DataSource = null;
                MantenimientoDetalleDataGridView.DataSource = detalle;
                
            }
        }
    }
}
