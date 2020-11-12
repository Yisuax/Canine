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
    public partial class Clientes : Form
    {
        public Clientes()
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

        private void Clientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            ClaseClientes clientes = new ClaseClientes();
            clientes.setNombre(textBoxNombre.Text.Trim());
            clientes.setApellido(textBoxApellido.Text.Trim());
            clientes.setCorreo(textBoxCorreo.Text.Trim());
            clientes.setEdad(int.Parse(textBoxEdad.Text.Trim()));
            if (radioButtonF.Checked)
            {
                clientes.setSexo('F');
            }
            else
            {
                clientes.setSexo('M');
            }
            clientes.setDomicilio(textBoxDomicilio.Text.Trim());
            clientes.setTelefono(int.Parse(textBoxTelefono.Text.Trim()));
            clientes.setRFC(textBoxRFC.Text.Trim());
            clientes.setActivo(true);
            int resultado = ClaseClientes.AgregarClientes(clientes);

            if (resultado > 0)
            {
                MessageBox.Show("Cliente guardado correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ClaseClientes clientes = new ClaseClientes();
            clientes.setID(int.Parse(textBoxID.Text.Trim()));
            clientes.setNombre(textBoxNombre.Text.Trim());
            clientes.setApellido(textBoxApellido.Text.Trim());
            clientes.setCorreo(textBoxCorreo.Text.Trim());
            clientes.setEdad(int.Parse(textBoxEdad.Text.Trim()));
            if (radioButtonF.Checked)
            {
                clientes.setSexo('F');
            }
            else
            {
                clientes.setSexo('M');
            }
            clientes.setDomicilio(textBoxDomicilio.Text.Trim());
            clientes.setTelefono(int.Parse(textBoxTelefono.Text.Trim()));
            clientes.setRFC(textBoxRFC.Text.Trim());
            clientes.setActivo(true);
            if (ClaseClientes.ActualizarClientes(clientes) > 0)
            {
                MessageBox.Show("Los datos del Cliente se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (MessageBox.Show("Esta Seguro que desea eliminar el Usuario actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ClaseClientes.EliminarClientes(int.Parse(textBoxID.Text.Trim())) > 0)
                {
                    MessageBox.Show("Cliente Eliminado Correctamente!", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Cliente", "Cliente No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxCorreo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxEdad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "M")
            {
                radioButtonM.Select();
            }
            else
            {
                radioButtonF.Select();
            }
            textBoxDomicilio.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxTelefono.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBoxRFC.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("Select * from clientes WHERE usuarios.nombre = '" + textBoxClientes.Text.Trim() + "'",
                Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void llenarGrid()
        {
            MySqlCommand cm = new MySqlCommand("Select * from clientes", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
