namespace FormularioKwikEMart
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
            this.txbStock.Location = new System.Drawing.Point(331, 64);
            this.txbStock.Name = "txbStock";
            this.txbStock.Size = new System.Drawing.Size(121, 20);
            this.txbStock.TabIndex = 1;
            this.txbStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbStock_KeyPress);
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(331, 115);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbCategoria.TabIndex = 3;
            // 
            // lbForDesc
            // 
            this.lbForDesc.AutoSize = true;
            this.lbForDesc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForDesc.Location = new System.Drawing.Point(16, 61);
            this.lbForDesc.Name = "lbForDesc";
            this.lbForDesc.Size = new System.Drawing.Size(73, 21);
            this.lbForDesc.TabIndex = 4;
            this.lbForDesc.Text = "Nombre";
            // 
            // lbForPrecio
            // 
            this.lbForPrecio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForPrecio.Location = new System.Drawing.Point(16, 102);
            this.lbForPrecio.Name = "lbForPrecio";
            this.lbForPrecio.Size = new System.Drawing.Size(85, 55);
            this.lbForPrecio.TabIndex = 5;
            this.lbForPrecio.Text = "Precio p/Unidad";
            // 
            // lbForStock
            // 
            this.lbForStock.AutoSize = true;
            this.lbForStock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForStock.Location = new System.Drawing.Point(272, 61);
            this.lbForStock.Name = "lbForStock";
            this.lbForStock.Size = new System.Drawing.Size(53, 21);
            this.lbForStock.TabIndex = 6;
            this.lbForStock.Text = "Stock";
            // 
            // lbForCategory
            // 
            this.lbForCategory.AutoSize = true;
            this.lbForCategory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForCategory.Location = new System.Drawing.Point(234, 112);
            this.lbForCategory.Name = "lbForCategory";
            this.lbForCategory.Size = new System.Drawing.Size(91, 21);
            this.lbForCategory.TabIndex = 7;
            this.lbForCategory.Text = "Categoría";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(157, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nuevo Producto";
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(107, 64);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(121, 20);
            this.txbDescripcion.TabIndex = 0;
            this.txbDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbDescripcion_KeyPress);
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(107, 115);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(121, 20);
            this.txbPrecio.TabIndex = 2;
            this.txbPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPrecio_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(179, 157);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(128, 43);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // FormAltaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(488, 212);
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
            this.Text = "Agregue su nuevo Producto";
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