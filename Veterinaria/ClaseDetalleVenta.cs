using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseDetalleVenta
    {
        int FolioVenta;
        int IDProducto;
        int Cantidad;
        float Precio;
        public ClaseDetalleVenta()
        {

        }
        public ClaseDetalleVenta(int folioVenta, int idProducto, int cantidad, float precio)
        {
            FolioVenta = folioVenta;
            IDProducto = idProducto;
            Cantidad = cantidad;
            Precio = precio;
        }
        public void setFolioVenta(int f)
        {
            FolioVenta = f;
        }
        public void setIDProducto(int p)
        {
            IDProducto = p;
        }
        public void setCantidad(int c)
        {
            Cantidad = c;
        }
        public void setPrecio(float p)
        {
            Precio = p;
        }
        public int getFolioVenta()
        {
            return FolioVenta;
        }
        public int getIDProducto()
        {
            return IDProducto;
        }
        public int getCantidad()
        {
            return Cantidad;
        }
        public float getPrecio()
        {
            return Precio;
        }
        public static int AgregarDetalleVenta(ClaseDetalleVenta detalleVenta)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into detalle_venta (folio_venta, id_producto, cantidad, precio)" +
                " values('{0}','{1}','{2}','{3}')",
                detalleVenta.FolioVenta, detalleVenta.IDProducto, detalleVenta.Cantidad, detalleVenta.Precio), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
    }
}
