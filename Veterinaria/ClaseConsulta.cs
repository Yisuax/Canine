using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseConsulta
    {
        int Folio;
        DateTime Fecha;
        int IDUsuario;
        int IDMascota;
        string Preescripcion;

        public ClaseConsulta()
        {

        }
        public ClaseConsulta(int folio, DateTime fecha, int idUsuario, int idMascota, string preescripcion)
        {
            Folio = folio;
            Fecha = fecha;
            IDUsuario = idUsuario;
            IDMascota = idMascota;
            Preescripcion = preescripcion;
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
        public void setPreescripcion(string p)
        {
            Preescripcion = p;
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
        public string getPreescripcion()
        {
            return Preescripcion;
        }
        public static int AgregarConsulta(ClaseConsulta consulta)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into consulta (folio, fecha, id_usuario, id_mascota, preescripcion)" +
                " values('{0}','{1}','{2}','{3}','{4}')",
                consulta.Folio, consulta.Fecha.ToString("yyyy-MM-dd"), consulta.IDUsuario, consulta.IDMascota, consulta.Preescripcion), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
