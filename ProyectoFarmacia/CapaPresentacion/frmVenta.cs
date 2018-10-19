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
            this.txtcliente.Text = IdCliente;
        }

        DataRow SelectedArt;

        public void SetArticulo(int IdIngreso,string Nombre, decimal PrecioCompra, decimal PrecioVenta, DateTime FechaProduccion, DateTime FechaVencimiento,int StockActual, int StockInicial)
        {
            this.txtarticulo.Text = Nombre;
            this.txtsubtotal.Text = Convert.ToString(PrecioVenta);
            //this.txtdescuento.Text= Convert.ToString(Descuento);
            this.txtstockactual.Text = Convert.ToString(StockActual);

            SelectedArt = this.DtDetalle.NewRow();

            SelectedArt["IdIngreso"] = IdIngreso;
            SelectedArt["Nombre"] = Nombre;
            SelectedArt["PrecioCompra"] = PrecioCompra;
            SelectedArt["PrecioVenta"] = PrecioVenta;
            SelectedArt["fecha_produccion"] = FechaProduccion;
            SelectedArt["fecha_vencimiento"] = FechaProduccion;
            SelectedArt["StockActual"] = StockActual;
            SelectedArt["StockInicial"] = StockInicial;

        }

        public frmVenta()
        {
            InitializeComponent();
            
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtidventa.Text = string.Empty;
            this.txtcliente.Text = string.Empty;
            this.dtFecha.Text = string.Empty;
            this.label4.Text = "0,0";
            this.crearTabla();
        }

        private void limpiarDetalle()
        {
            this.txtarticulo.Text = string.Empty;
            this.txtcantidad.Text = string.Empty;
            this.txtimpuesto.Text = string.Empty;
            this.txtstockactual.Text = string.Empty;
            this.txtsubtotal.Text = string.Empty;
        }

        //habilitar controles
        private void Habilitar(bool valor)
        {
            //this.txtidventa.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.txtcantidad.ReadOnly = !valor;
            this.txtdescuento.ReadOnly = !valor;

            this.btnbuscararticulo.Enabled = valor;
            this.btnbuscarcliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnEliminar.Enabled = valor;
        }



        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }




        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.Buscar_Fechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }




        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.Mostrar_Detalle(this.txtidventa.Text);

        }



        private void crearTabla()
        {
            this.DtDetalle = new DataTable("Detalle");
            this.DtDetalle.Columns.Add("IdIngreso", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("Nombre", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("PrecioCompra", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.DtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.DtDetalle.Columns.Add("StockActual", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("StockInicial", System.Type.GetType("System.Int32"));


            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.DtDetalle;

        }





        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.btnbuscarcliente.Focus();
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

        private void frmVenta_Load(object sender, EventArgs e)
        {
            //posiciones del form
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

                try
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string IdVenta;
                        string Rpta = "";

                        foreach (DataGridViewRow row in dataListado.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                IdVenta = Convert.ToString(row.Cells[1].Value);
                                Rpta = NVenta.Eliminar(Convert.ToInt32(IdVenta));

                                if (Rpta.Equals("OK"))
                                {
                                    this.MensajeOk("Se Eliminó Correctamente el Ingreso");
                                }
                                else
                                {
                                    this.MensajeError(Rpta);
                                }

                            }
                        }
                        this.Mostrar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IdVenta"].Value);
            this.txtcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            //this.IdTrabajador = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            this.txtsubtotal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["SubTotal"].Value);
            this.txtimpuesto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuesto"].Value);
            this.label4.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                string rpta = "";
                if (this.txtcliente.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                    errorIcono.SetError(txtcliente, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {

                        rpta = NVenta.Insertar(txtcliente.Text,IdTrabajador.ToString(), dtFecha.Value,subtotal,0, TotalPagado, DtDetalle);

                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }


                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        decimal subtotal;
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.txtcliente.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtcliente, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in DtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["IdDetalleIngreso"]) == Convert.ToInt32(this.txtarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(txtcantidad.Text)<=Convert.ToInt32(txtstockactual.Text))
                    {

                        //PENDIENTE PERRO CALIENTE CON ESTO 
                        //aqui convierto el porcentaje y lo multiplico por el precio y lo vuelvo el total pagado

                        subtotal = (Convert.ToInt32(txtcantidad.Text) *Convert.ToDecimal(this.txtsubtotal.Text)) - Convert.ToDecimal(this.txtdescuento.Text);
                        TotalPagado = TotalPagado + subtotal;
                        this.label4.Text = TotalPagado.ToString("#0.00#");

                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.DtDetalle.NewRow();
                        /*
                        row["IdIngreso"] = 0;
                        row["Nombre"] = this.txtarticulo.Text;
                        row["PrecioCompra"] = Convert.ToDecimal(this.txtcantidad.Text);
                        row["PrecioCompra"] = Convert.ToDecimal(this.txtcantidad.Text);
                        row["Precio"] = TotalPagado;
                        //row["SubTotal"] = Convert.ToDecimal(this.txtsubtotal.Text);
                        row["Descuento"] = Convert.ToDecimal(this.txtdescuento.Text);
                        */
                        this.DtDetalle.Rows.Add(SelectedArt);
                        SelectedArt = DtDetalle.NewRow();
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay productos suficientes!");
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.DtDetalle.Rows[indiceFila];
                //Disminuir el totalPAgado
                this.TotalPagado = this.TotalPagado - Convert.ToDecimal(row["SubTotal"].ToString());
                this.label4.Text = TotalPagado.ToString("#0.00#");
                //Removemos la fila
                this.DtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btncomprobante_Click(object sender, EventArgs e)
        {
            frmReporteComprobante frm = new frmReporteComprobante();
            frm.IdVenta = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdVenta"].Value);

            frm.ShowDialog();
        }

        private void txtidventa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtidventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtstockactual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtsubtotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtimpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtdescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
