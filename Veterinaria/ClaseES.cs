using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseES
    {
        int Folio;
        DateTime Fecha;
        int IDUsuario;
        string Tipo;

        public ClaseES()
        {

        }
        public ClaseES(int folio, DateTime fecha, int idUsuario, string tipo)
        {
            Folio = folio;
            Fecha = fecha;
            IDUsuario = idUsuario;
            Tipo = tipo;
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
        public void setTipo(string t)
        {
            Tipo = t;
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
        public string getTipo()
        {
            return Tipo;
        }
        public static int AgregarES(ClaseES claseES)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into entrada_salida (folio, fecha, id_usuario, tipo)" +
                " values('{0}','{1}','{2}','{3}')",
                claseES.Folio, claseES.Fecha.ToString("yyyy-MM-dd"), claseES.IDUsuario, claseES.Tipo), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
