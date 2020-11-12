namespace Veterinaria
{
    partial class MenuAlmacen
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonServicios = new System.Windows.Forms.Button();
            this.buttonProductos = new System.Windows.Forms.Button();
            this.buttonES = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(508, 145);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 25;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(508, 235);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.ReadOnly = true;
            this.textBoxApellido.Size = new System.Drawing.Size(100, 20);
            this.textBoxApellido.TabIndex = 24;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(508, 190);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.ReadOnly = true;
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Menu Principal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Veterinaria.Properties.Resources._5831a17a290077c646a48c4db78a81bb_perfil_de_usuario_icono_azul_by_vexels;
            this.pictureBox1.Location = new System.Drawing.Point(90, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // buttonServicios
            // 
            this.buttonServicios.Location = new System.Drawing.Point(399, 333);
            this.buttonServicios.Name = "buttonServicios";
            this.buttonServicios.Size = new System.Drawing.Size(75, 23);
            this.buttonServicios.TabIndex = 36;
            this.buttonServicios.Text = "Servicios";
            this.buttonServicios.UseVisualStyleBackColor = true;
            this.buttonServicios.Click += new System.EventHandler(this.buttonServicios_Click);
            // 
            // buttonProductos
            // 
            this.buttonProductos.Location = new System.Drawing.Point(266, 333);
            this.buttonProductos.Name = "buttonProductos";
            this.buttonProductos.Size = new System.Drawing.Size(75, 23);
            this.buttonProductos.TabIndex = 35;
            this.buttonProductos.Text = "Productos";
            this.buttonProductos.UseVisualStyleBackColor = true;
            this.buttonProductos.Click += new System.EventHandler(this.buttonProductos_Click);
            // 
            // buttonES
            // 
            this.buttonES.Location = new System.Drawing.Point(90, 333);
            this.buttonES.Name = "buttonES";
            this.buttonES.Size = new System.Drawing.Size(118, 23);
            this.buttonES.TabIndex = 37;
            this.buttonES.Text = "Entrada y Salida";
            this.buttonES.UseVisualStyleBackColor = true;
            this.buttonES.Click += new System.EventHandler(this.buttonES_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(532, 333);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 38;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // MenuAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 379);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonES);
            this.Controls.Add(this.buttonServicios);
            this.Controls.Add(this.buttonProductos);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MenuAlmacen";
            this.Text = "MenuAlmacen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonServicios;
        private System.Windows.Forms.Button buttonProductos;
        private System.Windows.Forms.Button buttonES;
        private System.Windows.Forms.Button buttonSalir;
    }
}