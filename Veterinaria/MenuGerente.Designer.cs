namespace Veterinaria
{
    partial class MenuGerente
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonClientes = new System.Windows.Forms.Button();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.buttonUsuarios = new System.Windows.Forms.Button();
            this.buttonProductos = new System.Windows.Forms.Button();
            this.buttonServicios = new System.Windows.Forms.Button();
            this.buttonVentas = new System.Windows.Forms.Button();
            this.buttonMascotas = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu Principal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Apellido:";
            // 
            // buttonClientes
            // 
            this.buttonClientes.Location = new System.Drawing.Point(14, 331);
            this.buttonClientes.Name = "buttonClientes";
            this.buttonClientes.Size = new System.Drawing.Size(75, 23);
            this.buttonClientes.TabIndex = 5;
            this.buttonClientes.Text = "Clientes";
            this.buttonClientes.UseVisualStyleBackColor = true;
            this.buttonClientes.Click += new System.EventHandler(this.buttonClientes_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(447, 165);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.ReadOnly = true;
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 7;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(447, 210);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.ReadOnly = true;
            this.textBoxApellido.Size = new System.Drawing.Size(100, 20);
            this.textBoxApellido.TabIndex = 8;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(447, 120);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 9;
            // 
            // buttonUsuarios
            // 
            this.buttonUsuarios.Location = new System.Drawing.Point(118, 331);
            this.buttonUsuarios.Name = "buttonUsuarios";
            this.buttonUsuarios.Size = new System.Drawing.Size(75, 23);
            this.buttonUsuarios.TabIndex = 10;
            this.buttonUsuarios.Text = "Usuarios";
            this.buttonUsuarios.UseVisualStyleBackColor = true;
            this.buttonUsuarios.Click += new System.EventHandler(this.buttonUsuarios_Click);
            // 
            // buttonProductos
            // 
            this.buttonProductos.Location = new System.Drawing.Point(222, 331);
            this.buttonProductos.Name = "buttonProductos";
            this.buttonProductos.Size = new System.Drawing.Size(75, 23);
            this.buttonProductos.TabIndex = 11;
            this.buttonProductos.Text = "Productos";
            this.buttonProductos.UseVisualStyleBackColor = true;
            this.buttonProductos.Click += new System.EventHandler(this.buttonProductos_Click);
            // 
            // buttonServicios
            // 
            this.buttonServicios.Location = new System.Drawing.Point(326, 331);
            this.buttonServicios.Name = "buttonServicios";
            this.buttonServicios.Size = new System.Drawing.Size(75, 23);
            this.buttonServicios.TabIndex = 12;
            this.buttonServicios.Text = "Servicios";
            this.buttonServicios.UseVisualStyleBackColor = true;
            this.buttonServicios.Click += new System.EventHandler(this.buttonServicios_Click);
            // 
            // buttonVentas
            // 
            this.buttonVentas.Location = new System.Drawing.Point(534, 331);
            this.buttonVentas.Name = "buttonVentas";
            this.buttonVentas.Size = new System.Drawing.Size(75, 23);
            this.buttonVentas.TabIndex = 13;
            this.buttonVentas.Text = "Ventas";
            this.buttonVentas.UseVisualStyleBackColor = true;
            this.buttonVentas.Click += new System.EventHandler(this.buttonVentas_Click);
            // 
            // buttonMascotas
            // 
            this.buttonMascotas.Location = new System.Drawing.Point(430, 331);
            this.buttonMascotas.Name = "buttonMascotas";
            this.buttonMascotas.Size = new System.Drawing.Size(75, 23);
            this.buttonMascotas.TabIndex = 14;
            this.buttonMascotas.Text = "Mascotas";
            this.buttonMascotas.UseVisualStyleBackColor = true;
            this.buttonMascotas.Click += new System.EventHandler(this.buttonMascotas_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(638, 331);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 15;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Veterinaria.Properties.Resources._5831a17a290077c646a48c4db78a81bb_perfil_de_usuario_icono_azul_by_vexels;
            this.pictureBox1.Location = new System.Drawing.Point(40, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MenuGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 368);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonMascotas);
            this.Controls.Add(this.buttonVentas);
            this.Controls.Add(this.buttonServicios);
            this.Controls.Add(this.buttonProductos);
            this.Controls.Add(this.buttonUsuarios);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.buttonClientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MenuGerente";
            this.Text = "MenuGerente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuGerente_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonClientes;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button buttonUsuarios;
        private System.Windows.Forms.Button buttonProductos;
        private System.Windows.Forms.Button buttonServicios;
        private System.Windows.Forms.Button buttonVentas;
        private System.Windows.Forms.Button buttonMascotas;
        private System.Windows.Forms.Button buttonSalir;
    }
}