using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaArticuloVenta : Form
    {
        public frmVistaArticuloVenta()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar() {
            this.dataListado.DataSource = NIngreso.MostrarDIngreso();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NVenta.Mostrar_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void frmVistaArticuloVenta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            int IdIngreso;
            string Nombre;
            decimal PrecioCompra,PrecioVenta;
            DateTime FechaProduccion, FechaVencimiento;
            int StockActual, StockInicial;


            IdIngreso = int.Parse(dataListado.CurrentRow.Cells["IdIngreso"].Value.ToString());
            Nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            PrecioCompra = decimal.Parse(dataListado.CurrentRow.Cells["PrecioCompra"].Value.ToString());
            PrecioVenta = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["PrecioVenta"].Value);
            FechaProduccion = Convert.ToDateTime(dataListado.CurrentRow.Cells["FechaProduccion"].Value.ToString());
            FechaVencimiento = Convert.ToDateTime(dataListado.CurrentRow.Cells["FechaVencimiento"].Value.ToString());
            StockActual = Convert.ToInt32(this.dataListado.CurrentRow.Cells["StockActual"].Value);
            StockInicial = Convert.ToInt32(this.dataListado.CurrentRow.Cells["StockInicial"].Value);

            form.SetArticulo(IdIngreso, Nombre, PrecioCompra, PrecioVenta, FechaProduccion, FechaVencimiento, StockActual, StockInicial);

            this.Hide();
        }
    }
}
