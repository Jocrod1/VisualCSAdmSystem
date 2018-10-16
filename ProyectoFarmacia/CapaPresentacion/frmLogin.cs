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
                    frm.Apellidos = Datos.Rows[0][1].ToString();
                    frm.Nombre = Datos.Rows[0][2].ToString();
                    frm.Acceso = Datos.Rows[0][3].ToString();

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
            Application.Exit();
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
    }
}
