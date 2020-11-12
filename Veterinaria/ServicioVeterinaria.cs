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
    public partial class ServicioVeterinaria : Form
    {
        public ServicioVeterinaria()
        {
            InitializeComponent();
            cargarFecha();
            cargarFolio();
            cargarNombreUsuario();
        }

        private void ServicioVeterinaria_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuVeterinarios menu = new MenuVeterinarios();
            menu.Show();
            this.Hide();
        }

        void cargarFolio()
        {

            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM consulta ORDER BY folio DESC", conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                textBoxFolio.Text = "1";
            }
            else
            {
                int actual = int.Parse(dt.Rows[0]["folio"].ToString().Trim()) + 1;
                textBoxFolio.Text = actual.ToString();
            }
        }

        void cargarNombreUsuario()
        {
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM usuarios WHERE ID =" + Login.id, conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);
            textBoxID.Text = dt.Rows[0]["ID"].ToString().Trim();
            textBoxNombre.Text = dt.Rows[0]["nombre"].ToString().Trim();
        }

        void cargarFecha()
        {
            labelFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            ClaseConsulta consulta = new ClaseConsulta();
            consulta.setFecha(DateTime.Now);
            consulta.setIDMascota(int.Parse(textBoxMascota.Text.Trim()));
            consulta.setIDUsuario(int.Parse(textBoxID.Text.Trim()));
            consulta.setPreescripcion(textBoxPres.Text.Trim());
            int resultado = ClaseConsulta.AgregarConsulta(consulta);
            if (resultado > 0)
            {
                MessageBox.Show("Consulta realizada correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar la Consulta", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cargarFolio();
        }
    }
}
