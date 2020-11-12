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
    public partial class ListaProductos : Form
    {
        public ListaProductos()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("Select * from productos WHERE nombre = '" + textBoxProducto.Text.Trim() + "'",
                Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("Select * from usuarios WHERE id ='" + Login.id + "'", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0]["area"].ToString() == "Gerente")
            {
                MenuGerente gerente = new MenuGerente();
                gerente.Show();
                this.Hide();
            }
            else if (dt.Rows[0]["area"].ToString() == "Veterinaria")
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
        }

        void llenarGrid()
        {
            MySqlCommand cm = new MySqlCommand("Select * from productos", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
