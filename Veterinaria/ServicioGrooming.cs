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
    public partial class ServicioGrooming : Form
    {
        List<int> lp = new List<int>();
        public ServicioGrooming()
        {
            InitializeComponent();
            cargarFecha();
            cargarFolio();
            cargarNombreUsuario();
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuGrooming menu = new MenuGrooming();
            menu.Show();
            this.Hide();
        }

        void cargarFolio()
        {

            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM grooming ORDER BY folio DESC", conexion);
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

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            lp.Remove(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM servicios WHERE id='" + textBoxServicio.Text.Trim() + "'", conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No existe ese producto ingrese otro");
            }
            else
            {
                dataGridView1.Rows.Add(dt.Rows[0]["ID"].ToString().Trim(), dt.Rows[0]["nombre"].ToString().Trim(),
                        dt.Rows[0]["descripcion"].ToString().Trim(), dt.Rows[0]["precio"].ToString().Trim());
                lp.Add(int.Parse(dt.Rows[0]["ID"].ToString().Trim()));
                cargarCobros();
            }
        }

        void cargarCobros()
        {
            float total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                total += float.Parse(dataGridView1.Rows[i].Cells["precio"].Value.ToString());
            }
            labelSub.Text = "Subtotal: " + total;
            labelTotal.Text = "Total: " + (total + (total * .16));
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            bool b = true;
            ClaseGrooming grooming = new ClaseGrooming();
            grooming.setFecha(DateTime.Now);
            grooming.setIDMascota(int.Parse(textBoxMascota.Text.Trim()));
            grooming.setIDUsuario(int.Parse(textBoxID.Text.Trim()));
            int resultado = ClaseGrooming.AgregarServicioGrooming(grooming);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ClaseDetalleGrooming detalleGrooming = new ClaseDetalleGrooming();
                detalleGrooming.setFolioGrooming(int.Parse(textBoxFolio.Text.Trim()));
                detalleGrooming.setIDServicio(int.Parse(dataGridView1.Rows[i].Cells["id"].Value.ToString()));
                detalleGrooming.setPrecio(int.Parse(dataGridView1.Rows[i].Cells["precio"].Value.ToString()));
                int resultado2 = ClaseDetalleGrooming.AgregarDetalleGrooming(detalleGrooming);
                if (resultado2 < 0)
                {
                    b = false;
                }
            }
            if (resultado > 0 && b == true)
            {
                MessageBox.Show("Servicio realizado correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar el servicio", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cargarFolio();
        }
    }
}
