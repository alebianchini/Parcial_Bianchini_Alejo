﻿using System;
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
    public partial class FormAltaProducto : Form
    {
        public FormAltaProducto()
        {
            InitializeComponent();
        }

        private void FormAltaProducto_Load(object sender, EventArgs e)
        {
            cbCategoria.DataSource = Enum.GetValues(typeof(Producto.ECategoria));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //obtener los datos del form y llamar al metodo agregarproducto();
        }
    }
}