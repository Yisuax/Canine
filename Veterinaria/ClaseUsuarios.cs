using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseUsuarios
    {
        int ID;
        string Nombre;
        string Apellido;
        string Correo;
        int Edad;
        string Sexo;
        string Domicilio;
        int Telefono;
        string RFC;
        string Area;
        string Clave;
        bool Activo;

        public ClaseUsuarios()
        {

        }
        public ClaseUsuarios(int id, string nombre, string apellido, string correo, int edad, string sexo, string domicilio, 
            int telefono, string rfc, string area, string clave, bool activo)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Edad = edad;
            Sexo = sexo;
            Domicilio = domicilio;
            Telefono = telefono;
            RFC = rfc;
            Area = area;
            Clave = clave;
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
        public void setApellido(string a)
        {
            Apellido = a;
        }
        public void setCorreo(string c)
        {
            Correo = c;
        }
        public void setEdad(int e)
        {
            Edad = e;
        }
        public void setSexo(string s)
        {
            Sexo = s;
        }
        public void setDomicilio(string d)
        {
            Domicilio = d;
        }
        public void setTelefono(int t)
        {
            Telefono = t;
        }
        public void setRFC(string r)
        {
            RFC = r;
        }
        public void setArea(string a)
        {
            Area = a;
        }
        public void setClave(string c)
        {
            Clave = c;
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
        public string getApellido()
        {
            return Apellido;
        }
        public string getCorreo()
        {
            return Correo;
        }
        public int getEdad()
        {
            return Edad;
        }
        public string getSexo()
        {
            return Sexo;
        }
        public string getDomicilio()
        {
            return Domicilio;
        }
        public int getTelefono()
        {
            return Telefono;
        }
        public string getRFC()
        {
            return RFC;
        }
        public string getArea()
        {
            return Area;
        }
        public string getClave()
        {
            return Clave;
        }
        public bool getActivo()
        {
            return Activo;
        }
        public static int AgregarUsuarios(ClaseUsuarios usuarios)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into usuarios (id, nombre, apellido, correo, edad, sexo, " +
                "domicilio, telefono, RFC, area, clave, activo) " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                usuarios.ID, usuarios.Nombre, usuarios.Apellido, usuarios.Correo, usuarios.Edad, usuarios.Sexo, usuarios.Domicilio, usuarios.Telefono, usuarios.RFC, usuarios.Area, usuarios.Clave, usuarios.Activo), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static List<ClaseUsuarios> BuscarUsuarios(string pNombre)
        {
            List<ClaseUsuarios> _lista = new List<ClaseUsuarios>();
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM usuarios where Nombre ='{0}'", pNombre), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClaseUsuarios usuarios = new ClaseUsuarios();
                usuarios.ID = _reader.GetInt32(0);
                usuarios.Nombre = _reader.GetString(1);
                usuarios.Apellido = _reader.GetString(2);
                usuarios.Correo = _reader.GetString(3);
                usuarios.Edad = _reader.GetInt32(4);
                usuarios.Sexo = _reader.GetString(5);
                usuarios.Domicilio = _reader.GetString(6);
                usuarios.Telefono = _reader.GetInt32(7);
                usuarios.RFC = _reader.GetString(8);
                usuarios.Area = _reader.GetString(9);
                usuarios.Clave = _reader.GetString(10);
                usuarios.Activo = _reader.GetBoolean(11);
                

                _lista.Add(usuarios);
            }
            conexion.Close();
            return _lista;
        }
        public static List<ClaseUsuarios> MostrarUsuarios()
        {
            List<ClaseUsuarios> _lista = new List<ClaseUsuarios>();
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM usuarios"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClaseUsuarios usuarios = new ClaseUsuarios();
                usuarios.ID = _reader.GetInt32(0);
                usuarios.Nombre = _reader.GetString(1);
                usuarios.Apellido = _reader.GetString(2);
                usuarios.Correo = _reader.GetString(3);
                usuarios.Edad = _reader.GetInt32(4);
                usuarios.Sexo = _reader.GetString(5);
                usuarios.Domicilio = _reader.GetString(6);
                usuarios.Telefono = _reader.GetInt32(7);
                usuarios.RFC = _reader.GetString(8);
                usuarios.Area = _reader.GetString(9);
                usuarios.Clave = _reader.GetString(10);
                usuarios.Activo = _reader.GetBoolean(11);


                _lista.Add(usuarios);
            }
            conexion.Close();
            return _lista;
        }
        public static int ActualizarUsuarios(ClaseUsuarios usuarios)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update usuarios set nombre='{0}', apellido='{1}', correo='{2}', edad='{3}', sexo='{4}', domicilio='{5}', telefono='{6}',  RFC='{7}', area='{8}', clave='{9}', activo='{10}' where ID='{11}'",
                 usuarios.Nombre, usuarios.Apellido, usuarios.Correo, usuarios.Edad, usuarios.Sexo, usuarios.Domicilio, usuarios.Telefono, usuarios.RFC, usuarios.Area, usuarios.Clave, usuarios.Activo, usuarios.ID), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
        }

        public static int EliminarUsuarios(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update usuarios set activo='0' where ID={0}", pId), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
    }
}
