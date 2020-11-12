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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string id;
        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter(string.Format("SELECT * FROM usuarios WHERE ID ='{0}' AND clave ='{1}'", int.Parse(textBoxID.Text.Trim()), textBoxClave.Text.Trim()), conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                id = dt.Rows[0]["ID"].ToString().Trim();
                if (dt.Rows[0]["area"].ToString() == "Gerente")
                {
                    MenuGerente gerente = new MenuGerente();
                    gerente.Show();
                    this.Hide();
                }
                else if(dt.Rows[0]["area"].ToString() == "Veterinaria")
                {
                    MenuVeterinarios veterinarios = new MenuVeterinarios();
                    veterinarios.Show();
                    this.Hide();
                }
                else if (dt.Rows[0]["area"].ToString() == "Caja")
                {
                    MenuCaja caja = new MenuCaja();
                    caja.Show();
                    this.Hide();
                }
                else if (dt.Rows[0]["area"].ToString() == "Almacen")
                {
                    MenuAlmacen almacen = new MenuAlmacen();
                    almacen.Show();
                    this.Hide();
                }
                else if (dt.Rows[0]["area"].ToString() == "Compras")
                {
                    
                }
                else if (dt.Rows[0]["area"].ToString() == "Grooming")
                {
                    MenuGrooming grooming = new MenuGrooming();
                    grooming.Show();
                    this.Hide();
                }
                MessageBox.Show("Haz iniciado sesion!!!");
            }
            else
            {
                MessageBox.Show("Usuario y/o contrasena incorrectos!!!");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
