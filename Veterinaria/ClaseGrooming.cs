using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseGrooming
    {
        int Folio;
        DateTime Fecha;
        int IDUsuario;
        int IDMascota;

        public ClaseGrooming()
        {

        }
        public ClaseGrooming(int folio, DateTime fecha, int idUsuario, int idMascota)
        {
            Folio = folio;
            Fecha = fecha;
            IDUsuario = idUsuario;
            IDMascota = idMascota;
        }
        public void setFolio(int f)
        {
            Folio = f;
        }
        public void setFecha(DateTime f)
        {
            Fecha = f;
        }
        public void setIDUsuario(int u)
        {
            IDUsuario = u;
        }
        public void setIDMascota(int m)
        {
            IDMascota = m;
        }
        public int getFolio()
        {
            return Folio;
        }
        public DateTime getFecha()
        {
            return Fecha;
        }
        public int getIDUsuario()
        {
            return IDUsuario;
        }
        public int getIDMascota()
        {
            return IDMascota;
        }
        public static int AgregarServicioGrooming(ClaseGrooming grooming)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into grooming (folio, fecha, id_usuario, id_mascota)" +
                " values('{0}','{1}','{2}','{3}')",
                grooming.Folio, grooming.Fecha.ToString("yyyy-MM-dd"), grooming.IDUsuario, grooming.IDMascota), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
