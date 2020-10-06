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
    public partial class FormSumarStock : Form
    {
        public FormSumarStock()
        {
            InitializeComponent();
        }

        private void FormSumarStock_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Comercio.ListaProductos;
            Producto auxProducto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            lbCantidadActual.Text = auxProducto.Stock.ToString();
            lbProducto.Text = auxProducto.Descripcion;
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Producto auxProducto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            lbCantidadActual.Text = auxProducto.Stock.ToString();
            lbProducto.Text = auxProducto.Descripcion;
        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto auxProducto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            Comercio.AgregarStock(auxProducto.Descripcion, Convert.ToInt32(txbCantidad.Text));
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;
        }
    }
}
