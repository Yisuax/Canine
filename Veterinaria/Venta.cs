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
    public partial class Venta : Form
    {
        List<int> lp = new List<int>();
        public Venta()
        {
            InitializeComponent();
            cargarFolio();
            cargarNombreUsuario();
            cargarFecha();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        void cargarFolio()
        {
            
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM venta ORDER BY folio DESC", conexion);
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

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuCaja caja = new MenuCaja();
            caja.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void cargarCobros()
        {
            float total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                total += float.Parse(dataGridView1.Rows[i].Cells["precio"].Value.ToString()) * float.Parse(dataGridView1.Rows[i].Cells["cantidad"].Value.ToString());
            }
            labelSub.Text = "Subtotal: " + total;
            labelTotal.Text = "Total: " + (total + (total * .16));
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM productos WHERE id='" + textBoxProducto.Text.Trim() + "'", conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);
            bool b = false;
            int j = 0;
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("No existe ese producto ingrese otro");
            }
            else
            {
                foreach (int i in lp)
                {
                    if (i == int.Parse(textBoxProducto.Text.Trim()))
                    {
                        b = true;
                        break;
                    }
                    j++;
                }
                if (b == true)
                {
                    string temp = dataGridView1.Rows[j].Cells["cantidad"].Value.ToString();
                    int n = int.Parse(temp);
                    n += int.Parse(textBoxCantidad.Text.Trim());
                    dataGridView1.Rows[j].Cells["cantidad"].Value = n.ToString();
                }
                else
                {
                    dataGridView1.Rows.Add(dt.Rows[0]["ID"].ToString().Trim(), dt.Rows[0]["nombre"].ToString().Trim(), 
                        dt.Rows[0]["descripcion"].ToString().Trim(), dt.Rows[0]["precio_venta"].ToString().Trim(),textBoxCantidad.Text.Trim());
                    lp.Add(int.Parse(dt.Rows[0]["ID"].ToString().Trim()));
                }
                cargarCobros();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            lp.Remove(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            bool b = true;
            ClaseVenta venta = new ClaseVenta();
            venta.setFecha(DateTime.Now);
            venta.setIDCliente(int.Parse(textBoxCliente.Text.Trim()));
            venta.setIDUsuario(int.Parse(textBoxID.Text.Trim()));
            int resultado = ClaseVenta.AgregarVenta(venta);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ClaseDetalleVenta detalleVenta = new ClaseDetalleVenta();
                detalleVenta.setFolioVenta(int.Parse(textBoxFolio.Text.Trim()));
                detalleVenta.setIDProducto(int.Parse(dataGridView1.Rows[i].Cells["id"].Value.ToString()));
                detalleVenta.setCantidad(int.Parse(dataGridView1.Rows[i].Cells["cantidad"].Value.ToString()));
                detalleVenta.setPrecio(int.Parse(dataGridView1.Rows[i].Cells["precio"].Value.ToString()));
                int resultado2 = ClaseDetalleVenta.AgregarDetalleVenta(detalleVenta);
                if (resultado2 < 0)
                {
                    b = false;
                }
            }
            if (resultado > 0 && b == true)
            {
                MessageBox.Show("Venta realizada correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar la Venta", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cargarFolio();
        }
    }
}
