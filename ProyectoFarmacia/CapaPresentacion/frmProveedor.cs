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
    public partial class frmProveedor : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmProveedor()
        {
            InitializeComponent();

        }





        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtRepresentanteLegal.Text = string.Empty;
            this.txtDireccionFiscal.Text = string.Empty;

            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdproveedor.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDocumento.ReadOnly = !valor;
            this.txtRepresentanteLegal.ReadOnly = !valor;
            this.txtDireccionFiscal.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[6].Visible = false;
            //this.dataListado.Columns[8].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {

            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarRepresentanteLegal
        private void BuscarRepresentanteLegal()
        {
            this.dataListado.DataSource = NProveedor.Buscar_Representante_Legal(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProveedor.Buscar_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (cbBuscar.Text.Equals("Representante Legal"))
            {

                this.BuscarRepresentanteLegal();

            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {

                this.BuscarNombre();

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtIdproveedor.ReadOnly = true;
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {

                //La variable que almacena si se inserto 
                //o se modifico la tabla
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtDocumento.Text == string.Empty || txtDireccionFiscal.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtDocumento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccionFiscal, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un Proveedor
                        Rpta = NProveedor.Insertar(this.txtNombre.Text.Trim().ToUpper(),txtDireccionFiscal.Text, 
                                                    txtDocumento.Text,txtRepresentanteLegal.Text, txtCorreo.Text , txtTelefono.Text);

                    }
                    else
                    {
                        //Vamos a modificar un Proveedor
                        Rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text), 
                                                    this.txtNombre.Text.Trim().ToUpper(), txtDireccionFiscal.Text,
                                                        txtDocumento.Text, txtRepresentanteLegal.Text, txtCorreo.Text, txtTelefono.Text);
                    }
                    //Si la respuesta fue OK, fue porque se modifico 
                    //o inserto el Proveedor
                    //de forma correcta
                    if (Rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizó de forma correcta el registro");
                        }

                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(Rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdproveedor.Text = "";

                }

            }



            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }




        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            //Si no ha seleccionado un Proveedor no puede modificar
            if (!this.txtIdproveedor.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.txtIdproveedor.ReadOnly = true;
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Editar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdproveedor.Text = string.Empty;
        
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["NombreProveedor"].Value);
            this.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Documento"].Value);
            this.txtDireccionFiscal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["DireccionFiscal"].Value);
            this.txtRepresentanteLegal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["RepresentanteLegal"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //quitar comentarios cuando exista el form ReporteProveedor
            //Reportes.FrmReporteProveedor frm = new Reportes.FrmReporteProveedor();
            //frm.Texto = txtBuscar.Text;
            //frm.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (cbBuscar.Text.Equals("Representante Legal"))
            {

                this.BuscarRepresentanteLegal();

            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {

                this.BuscarNombre();

            }

        }

    }

}
