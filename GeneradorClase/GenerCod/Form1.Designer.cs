﻿namespace GenerCod
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.tipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.get = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.set = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btn_generar = new System.Windows.Forms.Button();
            this.btn_borrar = new System.Windows.Forms.Button();
            this.richtxt = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la clase";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(136, 12);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(145, 22);
            this.txt_nombre.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo,
            this.nombre,
            this.get,
            this.set});
            this.dataGrid.Location = new System.Drawing.Point(12, 67);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(602, 150);
            this.dataGrid.TabIndex = 2;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Items.AddRange(new object[] {
            "int",
            "string",
            "double",
            "bool",
            "float",
            "char"});
            this.tipo.Name = "tipo";
            this.tipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // get
            // 
            this.get.HeaderText = "GET";
            this.get.Name = "get";
            // 
            // set
            // 
            this.set.HeaderText = "SET";
            this.set.Name = "set";
            // 
            // btn_generar
            // 
            this.btn_generar.Location = new System.Drawing.Point(94, 262);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(123, 45);
            this.btn_generar.TabIndex = 3;
            this.btn_generar.Text = "Generar";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // btn_borrar
            // 
            this.btn_borrar.Location = new System.Drawing.Point(401, 262);
            this.btn_borrar.Name = "btn_borrar";
            this.btn_borrar.Size = new System.Drawing.Size(123, 45);
            this.btn_borrar.TabIndex = 4;
            this.btn_borrar.Text = "Borrar";
            this.btn_borrar.UseVisualStyleBackColor = true;
            this.btn_borrar.Click += new System.EventHandler(this.btn_borrar_Click);
            // 
            // richtxt
            // 
            this.richtxt.Location = new System.Drawing.Point(12, 340);
            this.richtxt.Name = "richtxt";
            this.richtxt.Size = new System.Drawing.Size(602, 355);
            this.richtxt.TabIndex = 5;
            this.richtxt.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 707);
            this.Controls.Add(this.richtxt);
            this.Controls.Add(this.btn_borrar);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Generador de Clases";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn get;
        private System.Windows.Forms.DataGridViewCheckBoxColumn set;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Button btn_borrar;
        private System.Windows.Forms.RichTextBox richtxt;
    }
}

