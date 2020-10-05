using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormularioKwikEMart
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (!Comercio.CredencialesUsuarios.Any())
            {
                Comercio.PrecargaListaEmpelados();
            }
            txbUsuario.Text = "Usuario";
            txbContraseña.Text = "Contraseña";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Comercio.CredencialesUsuarios.ContainsKey(txbUsuario.Text))
            {
                string pass = Comercio.CredencialesUsuarios[txbUsuario.Text];
                if (pass.Equals(txbContraseña.Text))
                {
                    Comercio.SetEmpleadoActivo(txbUsuario.Text);
                    this.DialogResult = DialogResult.OK;                   
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Retry;
                }
            }
            else
            {
                this.DialogResult = DialogResult.Retry;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txbUsuario.Text == "Usuario")
            {
                txbUsuario.Text = "";
                txbUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txbUsuario_Leave(object sender, EventArgs e)
        {
            if (txbUsuario.Text == "")
            {
                txbUsuario.Text = "Usuario";
                txbUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txbContraseña_Enter(object sender, EventArgs e)
        {
            if (txbContraseña.Text == "Contraseña")
            {
                txbContraseña.Text = "";
                txbContraseña.ForeColor = Color.LightGray;
                txbContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txbContraseña_Leave(object sender, EventArgs e)
        {
            if (txbContraseña.Text == "")
            {
                txbContraseña.Text = "Contraseña";
                txbContraseña.ForeColor = Color.LightGray;
                txbContraseña.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
