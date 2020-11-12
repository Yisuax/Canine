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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            ClaseServicios servicios = new ClaseServicios();
            servicios.setNombre(textBoxNombre.Text.Trim());
            servicios.setDescripcion(textBoxDescripcion.Text.Trim());
            servicios.setPrecio(float.Parse(textBoxPrecio.Text.Trim()));
            servicios.setActivo(true);
            int resultado = ClaseServicios.AgregarServicios(servicios);

            if (resultado > 0)
            {
                MessageBox.Show("Servicio guardado correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Servicio", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ClaseServicios servicios = new ClaseServicios();
            servicios.setID(int.Parse(textBoxID.Text.Trim()));
            servicios.setNombre(textBoxNombre.Text.Trim());
            servicios.setDescripcion(textBoxDescripcion.Text.Trim());
            servicios.setPrecio(float.Parse(textBoxPrecio.Text.Trim()));
            servicios.setActivo(true);
            if (ClaseServicios.ActualizarServicios(servicios) > 0)
            {
                MessageBox.Show("Los datos del Servicio se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Servicio actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ClaseServicios.EliminarServicios(int.Parse(textBoxID.Text.Trim())) > 0)
                {
                    MessageBox.Show("Servicio Eliminado Correctamente!", "Servicio Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Servicio", "Servicio No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuGerente gerente = new MenuGerente();
            gerente.Show();
            this.Hide();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPrecio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void Servicios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        void llenarGrid()
        {
            MySqlCommand cm = new MySqlCommand("Select * from servicios", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("Select * from servicios WHERE nombre = '" + textBoxServicio.Text.Trim() + "'",
                Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
