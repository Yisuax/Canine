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
    public partial class MenuAlmacen : Form
    {
        public MenuAlmacen()
        {
            InitializeComponent();
            cargarNombreUsuario();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonProductos_Click(object sender, EventArgs e)
        {
            ListaProductos productos = new ListaProductos();
            productos.Show();
            this.Hide();
        }

        private void buttonServicios_Click(object sender, EventArgs e)
        {
            ListaServicios servicios = new ListaServicios();
            servicios.Show();
            this.Hide();
        }

        private void buttonES_Click(object sender, EventArgs e)
        {
            Entrada_Salida entrada_Salida = new Entrada_Salida();
            entrada_Salida.Show();
            this.Hide();
        }

        void cargarNombreUsuario()
        {
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM usuarios WHERE ID =" + Login.id, conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);
            textBoxID.Text = dt.Rows[0]["ID"].ToString().Trim();
            textBoxNombre.Text = dt.Rows[0]["nombre"].ToString().Trim();
            textBoxApellido.Text = dt.Rows[0]["apellido"].ToString().Trim();
        }
    }
}
