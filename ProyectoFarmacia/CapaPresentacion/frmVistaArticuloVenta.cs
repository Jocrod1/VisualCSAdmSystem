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

        private void dataListado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string parametro1;
            int parametro2;
            decimal parametro3, parametro4, parametro5;

            parametro1 = Convert.ToString(this.dataListado.CurrentRow.Cells["IdCliente"].Value);

            form.SetCliente(parametro1);
            this.Hide();
        }

        private void frmVistaArticuloVenta_Load(object sender, EventArgs e)
        {

        }
    }
}
