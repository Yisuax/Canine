using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server = localhost; database = veterinaria; Uid = root; pwd =; SSL Mode=None;");
            conexion.Open();
            return conexion;
        }
    }
}
