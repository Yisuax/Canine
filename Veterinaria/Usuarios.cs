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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            llenarGrid();
            comboBoxArea.SelectedIndex = 0;
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuGerente gerente = new MenuGerente();
            gerente.Show();
            this.Hide();
        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            ClaseUsuarios usuarios = new ClaseUsuarios();
            usuarios.setNombre(textBoxNombre.Text.Trim());
            usuarios.setApellido(textBoxApellido.Text.Trim());
            usuarios.setCorreo(textBoxCorreo.Text.Trim());
            usuarios.setEdad(int.Parse(textBoxEdad.Text.Trim()));
            if(radioButtonF.Checked)
            {
                usuarios.setSexo("F");
            }
            else
            {
                usuarios.setSexo("M");
            }
            usuarios.setDomicilio(textBoxDomicilio.Text.Trim());
            usuarios.setTelefono(int.Parse(textBoxTelefono.Text.Trim()));
            usuarios.setRFC(textBoxRFC.Text.Trim());
            usuarios.setArea(comboBoxArea.Text.Trim());
            usuarios.setClave(textBoxClave.Text.Trim());
            usuarios.setActivo(true);
            int resultado = ClaseUsuarios.AgregarUsuarios(usuarios);

            if (resultado > 0)
            {
                MessageBox.Show("Usuario guardado correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Usuario", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("Select * from usuarios WHERE usuarios.nombre = '" + textBoxUsuarios.Text.Trim() + "'", 
                Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ClaseUsuarios usuarios = new ClaseUsuarios();
            usuarios.setID(int.Parse(textBoxID.Text.Trim()));
            usuarios.setNombre(textBoxNombre.Text.Trim());
            usuarios.setApellido(textBoxApellido.Text.Trim());
            usuarios.setCorreo(textBoxCorreo.Text.Trim());
            usuarios.setEdad(int.Parse(textBoxEdad.Text.Trim()));
            if (radioButtonF.Checked)
            {
                usuarios.setSexo("F");
            }
            else
            {
                usuarios.setSexo("M");
            }
            usuarios.setDomicilio(textBoxDomicilio.Text.Trim());
            usuarios.setTelefono(int.Parse(textBoxTelefono.Text.Trim()));
            usuarios.setRFC(textBoxRFC.Text.Trim());
            usuarios.setArea(comboBoxArea.Text.Trim());
            usuarios.setClave(textBoxClave.Text.Trim());
            usuarios.setActivo(true);
            if (ClaseUsuarios.ActualizarUsuarios(usuarios) > 0)
            {
                MessageBox.Show("Los datos del Usuario se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Usuario actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ClaseUsuarios.EliminarUsuarios(int.Parse(textBoxID.Text.Trim())) > 0)
                {
                    MessageBox.Show("Usuario Eliminado Correctamente!", "Usuario Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Usuario", "Usuario No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            comboBoxArea.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBoxClave.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        void llenarGrid()
        {
            MySqlCommand cm = new MySqlCommand("Select * from usuarios", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
