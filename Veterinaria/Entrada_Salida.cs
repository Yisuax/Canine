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
    public partial class Entrada_Salida : Form
    {
        List<int> lp = new List<int>();
        public Entrada_Salida()
        {
            InitializeComponent();
            cargarFecha();
            cargarNombreUsuario();
            cargarFolio();
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuAlmacen almacen = new MenuAlmacen();
            almacen.Show();
            this.Hide();
        }

        void cargarFolio()
        {

            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM entrada_salida ORDER BY folio DESC", conexion);
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

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlDataAdapter comando = new MySqlDataAdapter("SELECT * FROM productos WHERE id='" + textBoxProducto.Text.Trim() + "'", conexion);
            DataTable dt = new DataTable();
            comando.Fill(dt);
            bool b = false;
            int j = 0;
            if (dt.Rows.Count == 0)
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
                        dt.Rows[0]["descripcion"].ToString().Trim(), textBoxCantidad.Text.Trim());
                    lp.Add(int.Parse(dt.Rows[0]["ID"].ToString().Trim()));
                }
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
            int resultado2;
            ClaseES claseES = new ClaseES();
            claseES.setFecha(DateTime.Now);
            claseES.setIDUsuario(int.Parse(textBoxID.Text.Trim()));
            if(radioButtonE.Checked)
            {
                claseES.setTipo("Entrada");
            }
            else
            {
                claseES.setTipo("Salida");
            }
            int resultado = ClaseES.AgregarES(claseES);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ClaseDetalleVenta detalleVenta = new ClaseDetalleVenta();
                if (claseES.getTipo() == "Entrada")
                {
                    ClaseDetalleEntrada detalleEntrada = new ClaseDetalleEntrada();
                    detalleEntrada.setFolioES(int.Parse(textBoxFolio.Text.Trim()));
                    detalleEntrada.setIDProducto(int.Parse(dataGridView1.Rows[i].Cells["id"].Value.ToString()));
                    detalleEntrada.setCantidad(int.Parse(dataGridView1.Rows[i].Cells["cantidad"].Value.ToString()));
                    resultado2 = ClaseDetalleEntrada.AgregarDetalleEntrada(detalleEntrada);
                    if (resultado2 < 0)
                    {
                        b = false;
                    }
                }
                else
                {
                    ClaseDetalleSalida detalleSalida = new ClaseDetalleSalida();
                    detalleSalida.setFolioES(int.Parse(textBoxFolio.Text.Trim()));
                    detalleSalida.setIDProducto(int.Parse(dataGridView1.Rows[i].Cells["id"].Value.ToString()));
                    detalleSalida.setCantidad(int.Parse(dataGridView1.Rows[i].Cells["cantidad"].Value.ToString()));
                    resultado2 = ClaseDetalleSalida.AgregarDetalleSalida(detalleSalida);
                    if (resultado2 < 0)
                    {
                        b = false;
                    }
                }
            }
            if (resultado > 0 && b == true)
            {
                MessageBox.Show("Movimiento realizado correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo realizar el movimiento", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cargarFolio();
        }
    }
}
