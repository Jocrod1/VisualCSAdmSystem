using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteComprobante : Form
    {
        private int _IdVenta;

        public int IdVenta
        {
            get { return _IdVenta; }
            set { _IdVenta = value; }
        }

        public frmReporteComprobante()
        {
            InitializeComponent();
        }

        private void frmReporteComprobante_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet.Reporte_Factura' table. You can move, or remove it, as needed.
            try
            {
                this.Reporte_FacturaTableAdapter.Fill(this.DataSet.Reporte_Factura, IdVenta);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
