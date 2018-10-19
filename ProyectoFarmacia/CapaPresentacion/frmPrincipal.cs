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
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;

        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public int Acceso;

        public frmPrincipal()
        {
            InitializeComponent();
        }


        private class Usuario {
            int NivelAcceso;

            public int Nivel_Acceso
            {
                get { return NivelAcceso; }
                set { NivelAcceso = value; }
            }
        }


        private class Administrador : Usuario {


             public Administrador()
            {
                Nivel_Acceso = 0;
            }

        }


        private class Trabajador : Usuario
        {


            public Trabajador()
            {
                Nivel_Acceso = 1;
            }

        }



        Trabajador trab = new Trabajador();
        Administrador admi = new Administrador();


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
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




        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MnuMantenimiento_Click(object sender, EventArgs e)
        {

        }





        private void GestionUsuario()
        {

                this.MnuProcesos.Enabled = true;
                this.MnuRegistros.Enabled = true;

                int NivelAcceso_Trabajador;
                int NivelAcceso_Administrador;
                NivelAcceso_Trabajador = trab.Nivel_Acceso;
                NivelAcceso_Administrador = admi.Nivel_Acceso;

                if (NivelAcceso_Administrador == 0)   //Este tipo de acceso es Administrador
            {

                this.MnuProcesos.Enabled = true;
                this.MnuRegistros.Enabled = true;

            }
                else if (NivelAcceso_Trabajador == 1)  //Este tipo de acceso es Trabajador
            {

                this.MnuProcesos.Enabled = true;
                this.trabajadoresToolStripMenuItem.Enabled = false;
                this.MnuRegistros.Enabled = true;

            }
            else
            {

                this.MnuProcesos.Enabled = false;
                this.MnuRegistros.Enabled = false;

            }
        }




        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void articulosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmArticulo frm = frmArticulo.GetInstancia();  //este metodo se encarga de revisar si no existe la instancia, la crea, y si ya existe, la devuelve (return)
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.NombreTrabajador = this.Nombre;
            frm.Idtrabajador = this.Idtrabajador;
            frm.Show();
        }




        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.IdTrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acercade acerca = new Acercade();
            acerca.MdiParent = this;
            acerca.Show();
        }
    }
}
