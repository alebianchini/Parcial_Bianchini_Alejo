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
            Comercio.PrecargaListaClientes();
            Comercio.PrecargaListaProductos();
            Comercio.PrecargaListaEmpelados();
            //List<Cliente> auxLista = Comercio.ListaClientes;
            //List<Producto> auxListaP = Comercio.ListaProductos;
            //dgvClientes.DataSource = auxLista;
            dgvProductos.DataSource = Comercio.ListaProductos;
            //dgvCarrito.DataSource = Comercio.CompraEnCurso.Productos;



            /*
            FormLogin auxForm = new FormLogin();
            if (auxForm.ShowDialog() == DialogResult.Yes)
            {
                //auxForm.ShowDialog();
                login = true;            
            }
            else
            {
                this.Close();
            }*/
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Producto auxProducto = new Producto(11, "Pasteles", 180, 50, Producto.ECategoria.almacen);
            MessageBox.Show(Comercio.AgregarNuevoProducto(11, "Pasteles", 180, 50, Producto.ECategoria.almacen, Comercio.ListaProductos));
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;
            dgvProductos.AutoResizeColumns();

        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAltaProducto auxForm = new FormAltaProducto();
            auxForm.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool asd = int.TryParse(txtCantidad.Text, out int cantidad);
            Producto auxProducto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            if(!Comercio.AgregarArticuloAlCarrito(new ArticuloCompra(cantidad, auxProducto, (auxProducto.PrecioUnitario * cantidad), auxProducto.PrecioUnitario)))
            {
                MessageBox.Show($"La cantidad de {auxProducto.Descripcion} solicitada excede el stock disponible!");
            }
            else
            {
                this.dgvCarrito.DataSource = null;
                this.dgvCarrito.DataSource = Comercio.CompraEnCurso.Productos;
                dgvCarrito.AutoResizeColumns();
            }
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            FormFinalizarCompra auxForm = new FormFinalizarCompra();
            auxForm.ShowDialog();
            
            this.dgvCarrito.DataSource = null;
            this.dgvCarrito.DataSource = Comercio.CompraEnCurso.Productos;
            dgvCarrito.AutoResizeColumns(); 
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Comercio.ListaProductos;
            dgvProductos.AutoResizeColumns();
            //MessageBox.Show(Comercio.ListaVentas[0].Vendedor.Nombre);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        //Comercio.FinalizarCompraActual();
        //    this.dgvCarrito.DataSource = null;
        //    this.dgvCarrito.DataSource = Comercio.CompraEnCurso.Productos;
        //    dgvCarrito.AutoResizeColumns(); 
        //    dgvProductos.DataSource = null;
        //    dgvProductos.DataSource = Comercio.ListaProductos;
        //    dgvProductos.AutoResizeColumns();
        //    MessageBox.Show(Comercio.ListaVentas[0].Vendedor.Nombre);
    }
}
