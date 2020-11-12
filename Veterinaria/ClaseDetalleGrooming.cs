using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseDetalleGrooming
    {
        int FolioGrooming;
        int IDServicio;
        float Precio;
        public ClaseDetalleGrooming()
        {

        }
        public ClaseDetalleGrooming(int folioGrooming, int idServicio, float precio)
        {
            FolioGrooming = folioGrooming;
            IDServicio = idServicio;
            Precio = precio;
        }
        public void setFolioGrooming(int g)
        {
            FolioGrooming = g;
        }
        public void setIDServicio(int s)
        {
            IDServicio = s;
        }
        public void setPrecio(float p)
        {
            Precio = p;
        }
        public int getFolioGrooming()
        {
            return FolioGrooming;
        }
        public int getIDServicio()
        {
            return IDServicio;
        }
        public float getPrecio()
        {
            return Precio;
        }
        public static int AgregarDetalleGrooming(ClaseDetalleGrooming detalleGrooming)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into detalle_grooming (folio_grooming, id_servicio, precio)" +
                " values('{0}','{1}','{2}')",
                detalleGrooming.FolioGrooming, detalleGrooming.IDServicio, detalleGrooming.Precio), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
