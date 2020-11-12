using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseClientes
    {
        int ID;
        string Nombre;
        string Apellido;
        string Correo;
        int Edad;
        char Sexo;
        string Domicilio;
        int Telefono;
        string RFC;
        bool Activo;

        public ClaseClientes()
        {

        }
        public ClaseClientes(int id, string nombre, string apellido, string correo, int edad, char sexo, string domicilio,
            int telefono, string rfc, bool activo)
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
        public void setSexo(char s)
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
        public char getSexo()
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
        public bool getActivo()
        {
            return Activo;
        }
        public static int AgregarClientes(ClaseClientes clientes)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into clientes (id, nombre, apellido, correo, edad, sexo, " +
                "domicilio, telefono, RFC, activo) " +
                "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                clientes.ID, clientes.Nombre, clientes.Apellido, clientes.Correo, clientes.Edad, clientes.Sexo, clientes.Domicilio, clientes.Telefono, clientes.RFC, clientes.Activo), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static List<ClaseClientes> BuscarClientes(string pNombre)
        {
            List<ClaseClientes> _lista = new List<ClaseClientes>();
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM clientes where Nombre ='{0}'", pNombre), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClaseClientes clientes = new ClaseClientes();
                clientes.ID = _reader.GetInt32(0);
                clientes.Nombre = _reader.GetString(1);
                clientes.Apellido = _reader.GetString(2);
                clientes.Correo = _reader.GetString(3);
                clientes.Edad = _reader.GetInt32(4);
                clientes.Sexo = _reader.GetChar(5);
                clientes.Domicilio = _reader.GetString(6);
                clientes.Telefono = _reader.GetInt32(7);
                clientes.RFC = _reader.GetString(8);
                clientes.Activo = _reader.GetBoolean(9);
                
                _lista.Add(clientes);
            }
            conexion.Close();
            return _lista;
        }
        public static List<ClaseClientes> MostrarClientes()
        {
            List<ClaseClientes> _lista = new List<ClaseClientes>();
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM clientes"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClaseClientes clientes = new ClaseClientes();
                clientes.ID = _reader.GetInt32(0);
                clientes.Nombre = _reader.GetString(1);
                clientes.Apellido = _reader.GetString(2);
                clientes.Correo = _reader.GetString(3);
                clientes.Edad = _reader.GetInt32(4);
                clientes.Sexo = _reader.GetChar(5);
                clientes.Domicilio = _reader.GetString(6);
                clientes.Telefono = _reader.GetInt32(7);
                clientes.RFC = _reader.GetString(8);
                clientes.Activo = _reader.GetBoolean(9);

                _lista.Add(clientes);
            }
            conexion.Close();
            return _lista;
        }
        public static int ActualizarClientes(ClaseClientes clientes)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update clientes set nombre='{0}', apellido='{1}', correo='{2}', edad='{3}', sexo='{4}', domicilio='{5}', telefono='{6}',  RFC='{7}', activo='{8}' where ID='{9}'",
                 clientes.Nombre, clientes.Apellido, clientes.Correo, clientes.Edad, clientes.Sexo, clientes.Domicilio, clientes.Telefono, clientes.RFC, clientes.Activo, clientes.ID), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
        }

        public static int EliminarClientes(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update clientes set activo='0' where ID={0}", pId), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
    }
}
