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
    public partial class FormFinalizarCompra : Form
    {
        public FormFinalizarCompra()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormFinalizarCompra_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Comercio.ListaClientes;
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            Comercio.FinalizarCompraActual((Cliente)dgvClientes.CurrentRow.DataBoundItem);
            this.Close();
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txbDni.Text, out int dni))
            {
                if (!Comercio.AgregarCliente(new Cliente(txbNombre.Text, txbApellido.Text,dni, Comercio.ListaClientes.Count + 1)))
                {
                    MessageBox.Show("El cliente que estas tratando de ingresar ya existe en sistema, por favor, revisá los datos y volvé a intentar.");
                }
            }
            else { MessageBox.Show("DNI invalido"); }
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = Comercio.ListaClientes;
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            lbSubTotal.Text = Comercio.CompraEnCurso.PrecioTotal.ToString();
            if(((Cliente)dgvClientes.CurrentRow.DataBoundItem).Apellido.Equals("Simpson",StringComparison.OrdinalIgnoreCase))
            {
                lbDescuento.Text = "13%";
                lbPrecioTotal.Text = (Comercio.CompraEnCurso.PrecioTotal * 0.87).ToString();
            }
            else
            {
                lbDescuento.Text = "0%";
                lbPrecioTotal.Text = (Comercio.CompraEnCurso.PrecioTotal).ToString();
            }
        }
    }
}
