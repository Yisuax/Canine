using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseDetalleSalida
    {
        int FolioES;
        int IDProducto;
        int Cantidad;
        public ClaseDetalleSalida()
        {

        }
        public ClaseDetalleSalida(int folioES, int idProducto, int cantidad)
        {
            FolioES = folioES;
            IDProducto = idProducto;
            Cantidad = cantidad;
        }
        public void setFolioES(int f)
        {
            FolioES = f;
        }
        public void setIDProducto(int p)
        {
            IDProducto = p;
        }
        public void setCantidad(int c)
        {
            Cantidad = c;
        }
        public int getFolioVenta()
        {
            return FolioES;
        }
        public int getIDProducto()
        {
            return IDProducto;
        }
        public int getCantidad()
        {
            return Cantidad;
        }
        public static int AgregarDetalleSalida(ClaseDetalleSalida detalleSalida)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into detalle_salida (folio_es, id_producto, cantidad)" +
                " values('{0}','{1}','{2}')",
                detalleSalida.FolioES, detalleSalida.IDProducto, detalleSalida.Cantidad), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
