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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        void login() {
            DataTable Datos = CapaNegocio.NTrabajador.Buscar_Cedula(this.txtUsername.Text);
            //Evaluar si existe el Usuario
            if (Datos.Rows.Count == 0){

                MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else{

                string Id = Datos.Rows[0][0].ToString();
                string Password = Datos.Rows[0][5].ToString();
                bool IDV = txtUsername.Text == Id;
                bool PassV = txtPassword.Text == Password;

                if (IDV && PassV) {

                    frmPrincipal frm = new frmPrincipal();
                    frm.Idtrabajador = Datos.Rows[0][0].ToString();
                    frm.Nombre = Datos.Rows[0][1].ToString();
                    frm.Acceso = int.Parse(Datos.Rows[0][4].ToString());

                    frm.Show();
                    this.Hide();
                }
                else{
                    MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }





        private void Salir()
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



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                login();
            }
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmPreguntas formPreg = new frmPreguntas();
            formPreg.Show();
            this.Hide();


        }
    }
}
