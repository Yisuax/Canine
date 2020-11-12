using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinaria
{
    public partial class MenuGerente : Form
    {
        public MenuGerente()
        {
            InitializeComponent();
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM usuarios WHERE ID =" + Login.id, conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);
            textBoxID.Text = dt.Rows[0]["ID"].ToString().Trim();
            textBoxNombre.Text = dt.Rows[0]["nombre"].ToString().Trim();
            textBoxApellido.Text = dt.Rows[0]["apellido"].ToString().Trim();
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
            this.Hide();
        }

        private void buttonMascotas_Click(object sender, EventArgs e)
        {
            Mascotas mascotas = new Mascotas();
            mascotas.Show();
            this.Hide();
        }

        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
            this.Hide();
        }

        private void MenuGerente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonProductos_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
            this.Hide();
        }

        private void buttonServicios_Click(object sender, EventArgs e)
        {
            Servicios servicios = new Servicios();
            servicios.Show();
            this.Hide();
        }

        private void buttonVentas_Click(object sender, EventArgs e)
        {
            ReporteVenta venta = new ReporteVenta();
            venta.Show();
            this.Hide();
        }
    }
}
