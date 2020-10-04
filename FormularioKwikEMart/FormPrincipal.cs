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
    public partial class FormPrincipal : Form
    {
        bool login = false;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Comercio.ListaProductos.Any())
            {
                Comercio.PrecargaListaProductos();
            }

            if (!Comercio.ListaClientes.Any())
            {
                Comercio.PrecargaListaClientes();
            }

            dgvProductos.DataSource = Comercio.ListaProductos;
            this.txbPrecioFinal.Text = "0";
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Comercio.AgregarNuevoProducto(11, "Pasteles", 180, 50, Producto.ECategoria.almacen, Comercio.ListaProductos));
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAltaProducto auxForm = new FormAltaProducto();
            auxForm.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool asd = int.TryParse(txbCantidad.Text, out int cantidad);
            Producto auxProducto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            if(!Comercio.AgregarArticuloAlCarrito(new ArticuloCompra(cantidad, auxProducto, (auxProducto.PrecioUnitario * cantidad), auxProducto.PrecioUnitario)))
            {
                MessageBox.Show($"La cantidad de {auxProducto.Descripcion} solicitada excede el stock disponible!");
            }
            else
            {
                this.dgvCarrito.DataSource = null;
                this.dgvCarrito.DataSource = Comercio.CompraEnCurso.Productos;
                this.txbPrecioFinal.Text = Comercio.CompraEnCurso.PrecioTotal.ToString();
            }
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            FormFinalizarCompra auxForm = new FormFinalizarCompra();
            auxForm.ShowDialog();
            
            this.dgvCarrito.DataSource = null;
            this.dgvCarrito.DataSource = Comercio.CompraEnCurso.Productos;
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;

            MessageBox.Show("Gracias!! Vuelva prontosss");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comprasPorEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormComprasPorEmpleado formComprasPorEmpleado = new FormComprasPorEmpleado();
            formComprasPorEmpleado.ShowDialog();
        }

        private void stockTotalDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"El stock total de productos es: {Comercio.GetStockTotalLista()}");
        }

        private void productosConBajoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Comercio.GetProductosBajoStock().Any())
            {
                MessageBox.Show("No hay productos con bajo stock");
            }
            else
            {
                FormBajoStock formBajoStock = new FormBajoStock();
                formBajoStock.ShowDialog();
            }
        }

        private void cerrarSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comercio.ClearSesiónEmpleadoActivo();
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}
