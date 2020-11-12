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
    public partial class MenuVeterinarios : Form
    {
        public MenuVeterinarios()
        {
            InitializeComponent();
            cargarNombreUsuario();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void buttonConsulta_Click(object sender, EventArgs e)
        {
            ServicioVeterinaria servicio = new ServicioVeterinaria();
            servicio.Show();
            this.Hide();
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            ListaClientes clientes = new ListaClientes();
            clientes.Show();
            this.Hide();
        }

        private void buttonMascotas_Click(object sender, EventArgs e)
        {
            ListaMascotas mascotas = new ListaMascotas();
            mascotas.Show();
            this.Hide();
        }

        private void buttonServicios_Click(object sender, EventArgs e)
        {
            ListaServicios servicios = new ListaServicios();
            servicios.Show();
            this.Hide();
        }
    }
}
