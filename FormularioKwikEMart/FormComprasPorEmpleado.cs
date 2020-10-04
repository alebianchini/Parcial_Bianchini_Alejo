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
    public partial class FormComprasPorEmpleado : Form
    {
        public FormComprasPorEmpleado()
        {
            InitializeComponent();
        }

        private void FormComprasPorEmpleado_Load(object sender, EventArgs e)
        {
            cbEmpleado.DataSource = Comercio.ListaEmpleados;

            if (((Empleado)cbEmpleado.SelectedItem).Nombre.Equals("Apu"))
            {
                pbEmpleado.Image = Properties.Resources.apu;
            }
            else
            {
                pbEmpleado.Image = Properties.Resources.Sanjay;
            }
       
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            dgvComprasPorEmpleado.DataSource = null;
            dgvComprasPorEmpleado.DataSource = Comercio.ListaEmpleados.Find(x => x.Equals(cbEmpleado.SelectedItem)).ListaTransacciones;

            if (((Empleado)cbEmpleado.SelectedItem).Nombre.Equals("Apu"))
            {
                pbEmpleado.Image = Properties.Resources.apu;
            }
            else
            {
                pbEmpleado.Image = Properties.Resources.Sanjay;
            }
        }
    }
}
