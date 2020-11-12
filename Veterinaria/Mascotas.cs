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
    public partial class Mascotas : Form
    {
        public Mascotas()
        {
            InitializeComponent();
            llenarGrid();
            comboBoxEspecie.SelectedIndex = 0;
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            MenuGerente gerente = new MenuGerente();
            gerente.Show();
            this.Hide();
        }

        private void Mascotas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            ClaseMascotas mascotas = new ClaseMascotas();
            mascotas.setNombre(textBoxNombre.Text.Trim());
            mascotas.setEspecie(comboBoxEspecie.Text.Trim());
            mascotas.setRaza(textBoxRaza.Text.Trim());
            mascotas.setEdad(int.Parse(textBoxEdad.Text.Trim()));
            if (radioButtonF.Checked)
            {
                mascotas.setSexo('F');
            }
            else
            {
                mascotas.setSexo('M');
            }
            mascotas.setPropietario(int.Parse(textBoxPropietario.Text.Trim()));
            mascotas.setActivo(true);
            int resultado = ClaseMascotas.AgregarMascotas(mascotas);

            if (resultado > 0)
            {
                MessageBox.Show("Mascota guardada correctamente", "Guardado!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la Mascota", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ClaseMascotas mascotas = new ClaseMascotas();
            mascotas.setID(int.Parse(textBoxID.Text.Trim()));
            mascotas.setNombre(textBoxNombre.Text.Trim());
            mascotas.setEspecie(comboBoxEspecie.Text.Trim());
            mascotas.setRaza(textBoxRaza.Text.Trim());
            mascotas.setEdad(int.Parse(textBoxEdad.Text.Trim()));
            if (radioButtonF.Checked)
            {
                mascotas.setSexo('F');
            }
            else
            {
                mascotas.setSexo('M');
            }
            mascotas.setPropietario(int.Parse(textBoxPropietario.Text.Trim()));
            mascotas.setActivo(true);
            if (ClaseMascotas.ActualizarMascotas(mascotas) > 0)
            {
                MessageBox.Show("Los datos de la Mascota se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (MessageBox.Show("Esta Seguro que desea eliminar la Mascota actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ClaseMascotas.EliminarMascotas(int.Parse(textBoxID.Text.Trim())) > 0)
                {
                    MessageBox.Show("Mascota Eliminada Correctamente!", "Mascota Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la Mascota", "Mascota No Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        void llenarGrid()
        {
            MySqlCommand cm = new MySqlCommand("Select * from mascotas", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("Select * from mascotas WHERE nombre = '" + textBoxMascota.Text.Trim() + "'",
                Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxEspecie.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxRaza.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxEdad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "M")
            {
                radioButtonM.Select();
            }
            else
            {
                radioButtonF.Select();
            }
            textBoxPropietario.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
