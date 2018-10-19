using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class frmPreguntas : Form
    {
        public frmPreguntas()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCorreoPregunta.Clear();
            txtIdPregunta.Clear();
            txtTelefonoPregunta.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro desea salir?", "Confirmación de salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                //aqui evitar cierre del form
            }
            else
            {
                this.Close();
            }
        }







        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }




        private void btnContinuar_Click(object sender, EventArgs e)
        {


            //validar el formato del correo
            if (!(email_bien_escrito(txtCorreoPregunta.Text)))
            {
                MessageBox.Show("ERROR,ingrese un correo valido");
                errorIcono.SetError(txtCorreoPregunta, "Ingrese un Valor");

            }
            else
            {
                DataTable Datos = CapaNegocio.NTrabajador.Buscar_Cedula(this.txtIdPregunta.Text);
                //Evaluar si existe el Usuario
                if (Datos.Rows.Count == 0)
                {

                    MessageBox.Show("Ingrese un ID correcto", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string Correo = Datos.Rows[0][6].ToString();
                    string telefono = Datos.Rows[0][7].ToString();
                    string Password = Datos.Rows[0][5].ToString();

                    if (Correo == txtCorreoPregunta.Text && telefono == txtTelefonoPregunta.Text)
                    {
                        MessageBox.Show("Su Clave es:" + Password, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Las respuestas son erroneas" + Correo + " " + telefono, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //validar si las preguntas coinciden

                    //abrir el otro form
                }
            }
        }









        private void txtTelefonoPregunta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtIdPregunta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmLogin frmLog = new frmLogin();
            frmLog.Show();
            this.Hide();
        }
    }
}
