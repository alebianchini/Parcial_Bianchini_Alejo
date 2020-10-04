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
    public partial class FormBajoStock : Form
    {
        public FormBajoStock()
        {
            InitializeComponent();
        }

        private void FormBajoStock_Load(object sender, EventArgs e)
        {
            dgvBajoStock.DataSource = Comercio.GetProductosBajoStock();
        }
    }
}
