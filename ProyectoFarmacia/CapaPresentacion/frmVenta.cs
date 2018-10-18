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
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmVenta : Form
    {
        private bool IsNuevo = false;
        public int IdTrabajador;
        private DataTable DtDetalle;
        private decimal TotalPagado = 0;
        private static frmVenta _instancia;

        public static frmVenta GetInstancia()
        {
            if(_instancia==null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }

        public void SetCliente(string IdCliente)
        {
            //this.txtidcliente.Text = IdCliente;
        }

        public void SetArticulo(string Nombre, decimal PrecioVenta, int StockActual)
        {
            this.txtarticulo.Text = Nombre;
            this.txtsubtotal.Text = Convert.ToString(PrecioVenta);
            //this.txtdescuento.Text= Convert.ToString(Descuento);
            this.txtstockactual.Text = Convert.ToString(StockActual);

        }

        public frmVenta()
        {
            InitializeComponent();
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            frmVistaClienteVenta vista = new frmVistaClienteVenta();
            vista.ShowDialog();
        }

        private void btnbuscararticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticuloVenta vista = new frmVistaArticuloVenta();
            vista.ShowDialog();
        }
    }
}
