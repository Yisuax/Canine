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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuGerente gerente = new MenuGerente();
            gerente.Show();
            this.Hide();
        }

        private void Productos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            ClaseProductos productos = new ClaseProductos();
            productos.setNombre(textBoxNombre.Text.Trim());
            productos.setDescripcion(textBoxDescripcion.Text.Trim());
            productos.setMarca(textBoxMarca.Text.Trim());
            productos.setPrecioVenta(float.Parse(textBoxVenta.Text.Trim()));
            productos.setPrecioCompra(float.Parse(textBoxCompra.Text.Trim()));
            productos.setExistencia(int.Parse(textBoxExistencia.Text.Trim()));
            productos.setActivo(true);
            int resultado = ClaseProductos.AgregarProductos(productos);

            if (resultado > 0)
            {
                MessageBox.Show("Producto guardado correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Producto", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ClaseProductos productos = new ClaseProductos();
            productos.setID(int.Parse(textBoxID.Text.Trim()));
            productos.setNombre(textBoxNombre.Text.Trim());
            productos.setDescripcion(textBoxDescripcion.Text.Trim());
            productos.setMarca(textBoxMarca.Text.Trim());
            productos.setPrecioVenta(float.Parse(textBoxVenta.Text.Trim()));
            productos.setPrecioCompra(float.Parse(textBoxCompra.Text.Trim()));
            productos.setExistencia(int.Parse(textBoxExistencia.Text.Trim()));
            productos.setActivo(true);
            if (ClaseProductos.ActualizarProductos(productos) > 0)
            {
                MessageBox.Show("Los datos del Producto se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
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

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Producto actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ClaseProductos.EliminarProductos(int.Parse(textBoxID.Text.Trim())) > 0)
                {
                    MessageBox.Show("Producto Eliminado Correctamente!", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Producto", "Producto No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxVenta.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxCompra.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxExistencia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
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
