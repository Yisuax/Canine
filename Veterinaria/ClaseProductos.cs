using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseProductos
    {
        int ID;
        string Nombre;
        string Descripcion;
        string Marca;
        float PrecioVenta;
        float PrecioCompra;
        int Existencia;
        bool Activo;

        public ClaseProductos()
        {

        }
        public ClaseProductos(int id, string nombre, string descripcion, string marca, int precioVenta, int precioCompra, int existencia, bool activo)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Marca = marca;
            PrecioVenta = precioVenta;
            PrecioCompra = precioCompra;
            Existencia = existencia;
            Activo = activo;
        }
        public void setID(int i)
        {
            ID = i;
        }
        public void setNombre(string n)
        {
            Nombre = n;
        }
        public void setDescripcion(string d)
        {
            Descripcion = d;
        }
        public void setMarca(string m)
        {
            Marca = m;
        }
        public void setPrecioVenta(float p)
        {
            PrecioVenta = p;
        }
        public void setPrecioCompra(float p)
        {
            PrecioCompra = p;
        }
        public void setExistencia(int e)
        {
            Existencia = e;
        }
        public void setActivo(bool a)
        {
            Activo = a;
        }
        public int getID()
        {
            return ID;
        }
        public string getNombre()
        {
            return Nombre;
        }
        public string getDescripcion()
        {
            return Descripcion;
        }
        public string getMarca()
        {
            return Marca;
        }
        public float getPrecioVenta()
        {
            return PrecioVenta;
        }
        public float getPrecioCompra()
        {
            return PrecioCompra;
        }
        public int getExistencia()
        {
            return Existencia;
        }
        public bool getActivo()
        {
            return Activo;
        }
        public static int AgregarProductos(ClaseProductos productos)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into productos (id, nombre, descripcion, marca, precio_venta, precio_compra, existencia, " +
                "activo) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                productos.ID, productos.Nombre, productos.Descripcion, productos.Marca, productos.PrecioVenta, productos.PrecioCompra, productos.Existencia, productos.Activo), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static int ActualizarProductos(ClaseProductos productos)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update productos set nombre='{0}', descripcion='{1}', marca='{2}', precio_venta='{3}', precio_compra='{4}', existencia='{5}', activo='{6}' where ID='{7}'",
                 productos.Nombre, productos.Descripcion, productos.Marca, productos.PrecioVenta, productos.PrecioCompra, productos.Existencia, productos.Activo, productos.ID), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
        }

        public static int EliminarProductos(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update productos set activo='0' where ID={0}", pId), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
    }
}
