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
using System.Media;
using System.Security.Cryptography;
using System.IO;

namespace FormularioKwikEMart
{
    public partial class FormPrincipal : Form
    {
        bool menuIsActive = false;
        SoundPlayer splayer;
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

            if (!Comercio.ListaVentas.Any())
            {
                Comercio.PrecargaListaVentas();
            }
            
            splayer = new SoundPlayer(@"..\Sounds\cajaResgistradora.wav");
            this.menuStrip1.Visible = false;
            dgvProductos.DataSource = Comercio.ListaProductos;
            this.txbPrecioFinal.Text = "";
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Comercio.AgregarNuevoProducto(11, "Pasteles", 180, 50, Producto.ECategoria.almacen, Comercio.ListaProductos));
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAltaProducto auxForm = new FormAltaProducto();
            auxForm.ShowDialog();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;
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
                this.txbPrecioFinal.Text = $"${Comercio.CompraEnCurso.PrecioTotal.ToString()}";
            }
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            FormFinalizarCompra formCompra = new FormFinalizarCompra();

            if (Comercio.CompraEnCurso.Productos.Count >= 1)
            {
                if (formCompra.ShowDialog() == DialogResult.OK)
                {
                    this.dgvCarrito.DataSource = null;
                    dgvProductos.DataSource = null;
                    dgvProductos.DataSource = Comercio.ListaProductos;

                    splayer.Play();
                    this.txbPrecioFinal.Text = "";

                    MessageBox.Show("Gracias!! Vuelva prontosss");
                }
                else
                {
                    MessageBox.Show("Compra interrumpida\nLimpie el carrito si quiere comenzar una nueva compra\no prosiga con la compra en curso");
                }
            }
            else
            {
                MessageBox.Show("Aún no hay nada cargado al carrito");
            }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Comercio.LimpiarCarrito();
            dgvCarrito.DataSource = null;
            this.txbPrecioFinal.Text = "";
        }

        private void hideTimer_Tick(object sender, EventArgs e)
        {
            var p = this.menuStrip1.PointToClient(MousePosition);
            if (menuIsActive)
                return;
            if (menuStrip1.ClientRectangle.Contains(p))
                return;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
                if (item.DropDown.Visible)
                    return;
            this.menuStrip1.Visible = false;
        }

        private void showTimer_Tick(object sender, EventArgs e)
        {
            var p = this.PointToClient(MousePosition);
            if (this.ClientRectangle.Contains(p) && p.Y < 10)
                this.menuStrip1.Visible = true;
        }

        private void menuStrip1_MenuActivate_1(object sender, EventArgs e)
        {
            menuIsActive = true;
        }

        private void menuStrip1_MenuDeactivate_1(object sender, EventArgs e)
        {
            menuIsActive = false;
            this.BeginInvoke(new Action(() => { this.menuStrip1.Visible = false; }));
        }

        private void rellenarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSumarStock formSumarStock = new FormSumarStock();
            formSumarStock.ShowDialog();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;
        }
    }
}
