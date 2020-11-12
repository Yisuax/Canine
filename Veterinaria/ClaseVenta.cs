using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseVenta
    {
        int Folio;
        DateTime Fecha;
        int IDUsuario;
        int IDCliente;

        public ClaseVenta()
        {

        }
        public ClaseVenta(int folio, DateTime fecha,int idUsuario, int idCliente)
        {
            Folio = folio;
            Fecha = fecha;
            IDUsuario = idUsuario;
            IDCliente = idCliente;
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
        public void setIDCliente(int c)
        {
            IDCliente = c;
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
        public int fetIDCliente()
        {
            return IDCliente;
        }
        public static int AgregarVenta(ClaseVenta venta)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into venta (folio, fecha, id_usuario, id_cliente)" +
                " values('{0}','{1}','{2}','{3}')",
                venta.Folio, venta.Fecha.ToString("yyyy-MM-dd"), venta.IDUsuario, venta.IDCliente), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
