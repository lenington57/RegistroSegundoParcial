using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        public string nombre = "";
        public double TotalDeMantenimiento = 0;

        public RegistrarMantenimiento()
        {
            InitializeComponent();                       
            LlenarComboBox();
            CalcularFecha();
        }

        //Métodos       
        private void LlenarCampos(Mantenimiento mantenimiento)
        {
            MantenimientoIdNumericUpDown.Value = mantenimiento.MantenimientoId;
            VehiculoComboBox.SelectedValue = mantenimiento.VehiculoId;
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

            VehiculoComboBox.DataSource = VehRepositorio.GetList(c => true);
            VehiculoComboBox.ValueMember = "VehiculoId";
            VehiculoComboBox.DisplayMember = "Descripcion";

            TallerComboBox.DataSource = TallRepositorio.GetList(c => true);
            TallerComboBox.ValueMember = "TallerId";
            TallerComboBox.DisplayMember = "Nombre";

            ArticuloComboBox.DataSource = ArtRepositorio.GetList(c => true);
            ArticuloComboBox.ValueMember = "ArticuloId";
            ArticuloComboBox.DisplayMember = "Descripcion";

            CambiarPrecio();
        }

        private void FormatoMoneda(object sender, ConvertEventArgs e)
        {
            double valor = 0;
            double.TryParse(e.Value.ToString(), out valor);
            e.Value = valor.ToString("#,##.00;(#,##.00);0.00");
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void CambiarPrecio()
        {
            PrecioTextBox.DataBindings.Clear();
            Binding doBinding = new Binding("Text", ArticuloComboBox.DataSource, "Precio");
            doBinding.Format += new ConvertEventHandler(FormatoMoneda);
            PrecioTextBox.DataBindings.Add(doBinding);
        }

        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }

        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
            mantenimiento.VehiculoId = Convert.ToInt32(VehiculoComboBox.SelectedValue);
            mantenimiento.Fecha = FechaDateTimePicker.Value;
            mantenimiento.FechaProximo = ProxManteDateTimePicker.Value;
            mantenimiento.SubTotal = Convert.ToSingle(SubTotalTextBox.Text);
            mantenimiento.Itbis = Convert.ToSingle(ItbisTextBox.Text);
            mantenimiento.Total = Convert.ToSingle(TotalTextBox.Text);            

            foreach (DataGridViewRow item in MantenimientoDetalleDataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["MantenimientoId"].Value),
                    ToInt(item.Cells["VehiculoId"].Value),
                    ToInt(item.Cells["TallerId"].Value),
                    ToInt(item.Cells["ArticuloId"].Value),
                    item.Cells["Articulo"].ToString(),
                    ToDouble(item.Cells["Cantidad"].Value),
                    ToDouble(item.Cells["Precio"].Value),
                    ToDouble(item.Cells["Importe"].Value)
                );
            }

            MantenimientoDetalleDataGridView.Columns["Id"].Visible = false;
            MantenimientoDetalleDataGridView.Columns["MantenimientoId"].Visible = false;
            MantenimientoDetalleDataGridView.Columns["Articulo"].Visible = false;
            return mantenimiento;
        }

        private void Limpiar()
        {
            MantenimientoIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            VehiculoComboBox.SelectedIndex = 0;
            TallerComboBox.SelectedIndex = 0;
            ArticuloComboBox.SelectedIndex = 0;
            CantidadNumericUpDown.Value = 0;
            PrecioTextBox.Clear();
            ImporteTextBox.Clear();
            MantenimientoDetalleDataGridView.DataSource = null;
            SubTotalTextBox.Clear();
            ItbisTextBox.Clear();
            TotalTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private void CalcularFecha()
        {
            ProxManteDateTimePicker.Value = FechaDateTimePicker.Value.AddMonths(3);
        }


        private void LlenarPrecio()
        {
            List<Articulos> ListArticulos = ArticulosBLL.GetList(c => c.Descripcion == ArticuloComboBox.Text);
            foreach (var item in ListArticulos)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        private void LlenarImporte()
        {
            double cantidad, precio;

            cantidad = Convert.ToDouble(CantidadNumericUpDown.Value);
            precio = Convert.ToDouble(PrecioTextBox.Text);
            ImporteTextBox.Text = MantenimientoBLL.Importe(cantidad, precio).ToString();
        }

        private void LlenarValores()
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();

            if (MantenimientoDetalleDataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;
            }
            double Total = 0;
            double Itbis = 0;
            double SubTotal = 0;
            foreach (var item in detalle)
            {
                Total += item.Importe;
            }
            Itbis = Total * 0.18f;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }

        private void RebajarValores()
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();

            if (MantenimientoDetalleDataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;
            }
            double Total = 0;
            double Itbis = 0;
            double SubTotal = 0;
            foreach (var item in detalle)
            {
                Total -= item.Importe;
            }
            Total *= (-1);
            Itbis = Total * 0.18f;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }

        private bool ContarCantidadInventario()
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();

            if (MantenimientoDetalleDataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;
            }

            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());

            Articulos articulo = (Articulos)ArticuloComboBox.SelectedItem;

            double CantidadCotizada = 0;
            foreach (var item in detalle)
            {
                CantidadCotizada += item.Cantidad;
            }

            double CantidadArticulo = articulo.Inventario;

            bool paso = false;

            if ((int)CantidadNumericUpDown.Value > articulo.Inventario)
            {
                MyErrorProvider.SetError(CantidadNumericUpDown, "Error");
                MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Falló!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                paso = true;
            }

            CantidadArticulo -= CantidadCotizada;

            if (CantidadArticulo < CantidadCotizada)
            {
                MessageBox.Show($"Solo quedan {CantidadArticulo} del articulo deseado!!", "Articulo Agotado!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                paso = true;
            }

            return paso;
        }

        

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (MantenimientoDetalleDataGridView.RowCount == 0)
            {
                MyErrorProvider.SetError(MantenimientoDetalleDataGridView,
                    "Debe Agregar los Artículos ");
                HayErrores = true;
            }

            return HayErrores;
        }


        //Programación de los Botones
        private void AgregarButtton_Click(object sender, EventArgs e)
        {
            List<MantenimientoDetalle> detalle = new List<MantenimientoDetalle>();

            if (MantenimientoDetalleDataGridView.DataSource != null)
            {
                detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;
            }
            if (ContarCantidadInventario())
            {
                MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Falló!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CantidadNumericUpDown.Value == 0)
            {
                MessageBox.Show("Cantidad no puede ser cero!!", "Falló!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                detalle.Add(
               new MantenimientoDetalle(
                   id: 0,
                   mantenimientoId: (int)MantenimientoIdNumericUpDown.Value,
                   vehiculoId: (int)VehiculoComboBox.SelectedValue,
                   tallerId: (int)TallerComboBox.SelectedValue,
                   articuloId: (int)ArticuloComboBox.SelectedValue,
                   articulo: ArticuloComboBox.Text,
                   cantidad: (double)Convert.ToDouble(CantidadNumericUpDown.Value),
                   precio: (double)Convert.ToDouble(PrecioTextBox.Text),
                   importe: (double)Convert.ToDouble(ImporteTextBox.Text)
               ));

                MantenimientoDetalleDataGridView.DataSource = null;
                MantenimientoDetalleDataGridView.DataSource = detalle;

                LlenarValores();
            }           
        }


        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if (MantenimientoDetalleDataGridView.Rows.Count > 0 && MantenimientoDetalleDataGridView.CurrentRow != null)
            {
                List<MantenimientoDetalle> detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;

                detalle.RemoveAt(MantenimientoDetalleDataGridView.CurrentRow.Index);
                
                MantenimientoDetalleDataGridView.DataSource = null;
                MantenimientoDetalleDataGridView.DataSource = detalle;

                RebajarValores();
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
            Mantenimiento mantenimiento = MantenimientoBLL.Buscar(id);

            if (mantenimiento != null)
            {
                LlenarCampos(mantenimiento);
            }
            else
                MessageBox.Show("No se encontró!!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mantenimiento = LlenaClase();

            if (MantenimientoIdNumericUpDown.Value == 0)
            {
                Paso = MantenimientoBLL.Guardar(mantenimiento);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);
                Mantenimiento mantenimi = MantenimientoBLL.Buscar(id);

                if (mantenimi != null)
                {                    
                    Paso = MantenimientoBLL.Modificar(mantenimiento);
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Paso)
            {
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MantenimientoIdNumericUpDown.Value);

            Mantenimiento mantenimiento = MantenimientoBLL.Buscar(id);

            if (mantenimiento != null)
            {
                if (MantenimientoBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Eventos de los componentes
        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            LlenarImporte();
        }

        private void ArticuloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            if (CantidadNumericUpDown.Value != 0)
            {
                LlenarImporte();
            }
            CambiarPrecio();
        }

        //Dando click sin querer
        private void RegistrarMantenimiento_Load(object sender, EventArgs e)
        {

        }
        //Dando click sin querer
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        //Dando click sin querer

        private void ModificarVehiculo()
        {
            Mantenimiento mantenimiento = new Mantenimiento();
            var MantetAnt = MantenimientoBLL.Buscar(mantenimiento.MantenimientoId);
            Contexto contexto = new Contexto();

            List<MantenimientoDetalle> detalle = (List<MantenimientoDetalle>)MantenimientoDetalleDataGridView.DataSource;
            string NombreVeh = "";
            double TotalMant = 0;

            foreach (var item in detalle)
            {
                NombreVeh = contexto.Vehiculos.Find(item.VehiculoId).Descripcion;
            }

            foreach (var item in detalle)
            {
                TotalMant = contexto.Vehiculos.Find(item.VehiculoId).TotalMantenimiento;
            }

            double total = 0;
            total = TotalDeMantenimiento - TotalMant;

            int id = 0;

            if (nombre != NombreVeh)
            {
                //foreach (var item in mantenimiento.Detalle)
                //{
                //    contexto.Mantenimiento.Find(item.VehiculoId).Total += total;
                //}

                foreach (var item in VehiculosBLL.GetList(x=> x.VehiculoId == mantenimiento.VehiculoId))
                {
                    contexto.Mantenimiento.Find(item.VehiculoId).Total += total;
                }
            }

            //VehiculosBLL.Modificar(vehiculos);
        }
        private void MantenimientoDetalleDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TotalDeMantenimiento = double.Parse(TotalTextBox.Text);
            nombre = VehiculoComboBox.Text;
        }
        //Dando click sin querer
        private void VehiculoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Dando click sin querer
        private void label5_Click(object sender, EventArgs e)
        {

        }
        //Dando click sin querer
        private void TallerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Dando click sin querer
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
