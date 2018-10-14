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

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            ////quitar comentario cuando se cree el form principal         

            //DataTable Datos = CapaNegocio.NTrabajador.Login(this.TxtUsuario.Text, this.TxtPassword.Text);
            ////Evaluar si existe el Usuario
            //if (Datos.Rows.Count == 0)
            //{
            //    MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
      
                //frmPrincipal frm = new frmPrincipal();
                //frm.Idtrabajador = Datos.Rows[0][0].ToString();
                //frm.Apellidos = Datos.Rows[0][1].ToString();
                //frm.Nombre = Datos.Rows[0][2].ToString();
                //frm.Acceso = Datos.Rows[0][3].ToString();

                //frm.Show();
                //this.Hide();

            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
