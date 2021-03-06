﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (txbDescripcion.Text != "" && txbPrecio.Text != "" && txbStock.Text != "" && cbCategoria.Text != "")
            {
                Comercio.AgregarNuevoProducto(Comercio.ListaProductos.Count + 1, txbDescripcion.Text, Convert.ToInt32(txbStock.Text), Convert.ToDouble(txbPrecio.Text), (Producto.ECategoria)cbCategoria.SelectedItem);
                this.Close();
            }
            else
            {
                MessageBox.Show("Primero ingrese datos en los campos");
            }    
        }

        private void txbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), "^[A-Za-z ]+$"))
            {
                e.Handled = true;
            }
        }

        private void txbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
