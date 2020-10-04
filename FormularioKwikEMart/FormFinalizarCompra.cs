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
            Comercio.FinalizarCompraActual();
        }
    }
}
