using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseServicios
    {
        int ID;
        string Nombre;
        string Descripcion;
        float Precio;
        bool Activo;

        public ClaseServicios()
        {

        }
        public ClaseServicios(int id, string nombre, string descripcion, float precio, bool activo)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
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
        public void setPrecio(float p)
        {
            Precio = p;
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
        public float getPrecio()
        {
            return Precio;
        }
        public bool getActivo()
        {
            return Activo;
        }
        public static int AgregarServicios(ClaseServicios servicios)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into servicios (id, nombre, descripcion, precio, activo) " +
                "values('{0}','{1}','{2}','{3}','{4}')",
                servicios.ID, servicios.Nombre, servicios.Descripcion, servicios.Precio, servicios.Activo), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static int ActualizarServicios(ClaseServicios servicios)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update servicios set nombre='{0}', descripcion='{1}', precio='{2}', activo='{3}' where ID='{4}'",
                 servicios.Nombre, servicios.Descripcion, servicios.Precio, servicios.Activo, servicios.ID), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
        }

        public static int EliminarServicios(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update servicios set activo='0' where ID={0}", pId), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
        }
    }
}
