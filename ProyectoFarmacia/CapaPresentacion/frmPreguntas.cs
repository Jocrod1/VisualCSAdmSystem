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

            }else
            {

                //validar si las preguntas coinciden

                //abrir el otro form
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
