﻿namespace FormularioKwikEMart
{
    partial class FormAltaProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbStock = new System.Windows.Forms.TextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.lbForDesc = new System.Windows.Forms.Label();
            this.lbForPrecio = new System.Windows.Forms.Label();
            this.lbForStock = new System.Windows.Forms.Label();
            this.lbForCategory = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbStock
            // 
            this.txbStock.Location = new System.Drawing.Point(321, 62);
            this.txbStock.Name = "txbStock";
            this.txbStock.Size = new System.Drawing.Size(121, 20);
            this.txbStock.TabIndex = 2;
            // 
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(321, 114);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbCategoria.TabIndex = 3;
            // 
            // lbForDesc
            // 
            this.lbForDesc.AutoSize = true;
            this.lbForDesc.Location = new System.Drawing.Point(57, 69);
            this.lbForDesc.Name = "lbForDesc";
            this.lbForDesc.Size = new System.Drawing.Size(44, 13);
            this.lbForDesc.TabIndex = 4;
            this.lbForDesc.Text = "Nombre";
            // 
            // lbForPrecio
            // 
            this.lbForPrecio.AutoSize = true;
            this.lbForPrecio.Location = new System.Drawing.Point(16, 126);
            this.lbForPrecio.Name = "lbForPrecio";
            this.lbForPrecio.Size = new System.Drawing.Size(85, 13);
            this.lbForPrecio.TabIndex = 5;
            this.lbForPrecio.Text = "Precio p/Unidad";
            // 
            // lbForStock
            // 
            this.lbForStock.AutoSize = true;
            this.lbForStock.Location = new System.Drawing.Point(271, 70);
            this.lbForStock.Name = "lbForStock";
            this.lbForStock.Size = new System.Drawing.Size(35, 13);
            this.lbForStock.TabIndex = 6;
            this.lbForStock.Text = "Stock";
            // 
            // lbForCategory
            // 
            this.lbForCategory.AutoSize = true;
            this.lbForCategory.Location = new System.Drawing.Point(261, 122);
            this.lbForCategory.Name = "lbForCategory";
            this.lbForCategory.Size = new System.Drawing.Size(54, 13);
            this.lbForCategory.TabIndex = 7;
            this.lbForCategory.Text = "Categoría";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "INGRESE NUEVO PRODUCTO";
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(107, 63);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(121, 20);
            this.txbDescripcion.TabIndex = 9;
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(107, 115);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(121, 20);
            this.txbPrecio.TabIndex = 10;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(199, 183);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 32);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FormAltaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 248);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbForCategory);
            this.Controls.Add(this.lbForStock);
            this.Controls.Add(this.lbForPrecio);
            this.Controls.Add(this.lbForDesc);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.txbStock);
            this.Name = "FormAltaProducto";
            this.Text = "FormAltaProducto";
            this.Load += new System.EventHandler(this.FormAltaProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbStock;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label lbForDesc;
        private System.Windows.Forms.Label lbForPrecio;
        private System.Windows.Forms.Label lbForStock;
        private System.Windows.Forms.Label lbForCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Button btnAgregar;
    }
}