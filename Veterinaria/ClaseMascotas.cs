using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    class ClaseMascotas
    {
        int ID;
        string Nombre;
        string Especie;
        string Raza;
        int Edad;
        char Sexo;
        int Propietario;
        bool Activo;

        public ClaseMascotas()
        {

        }
        public ClaseMascotas(int id, string nombre, string especie, string raza, int edad, char sexo, int propietario, bool activo)
        {
            ID = id;
            Nombre = nombre;
            Especie = especie;
            Raza = raza;
            Edad = edad;
            Sexo = sexo;
            Propietario = propietario;
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
        public void setEspecie(string e)
        {
            Especie = e;
        }
        public void setRaza(string r)
        {
            Raza = r;
        }
        public void setEdad(int e)
        {
            Edad = e;
        }
        public void setSexo(char s)
        {
            Sexo = s;
        }
        public void setPropietario(int p)
        {
            Propietario = p;
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
        public string getEspecie()
        {
            return Especie;
        }
        public string getRaza()
        {
            return Raza;
        }
        public int getEdad()
        {
            return Edad;
        }
        public char getSexo()
        {
            return Sexo;
        }
        public int getPropietario()
        {
            return Propietario;
        }
        public bool getActivo()
        {
            return Activo;
        }
        public static int AgregarMascotas(ClaseMascotas mascotas)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into mascotas (id, nombre, especie, raza, edad, sexo, " +
                "propietario, activo) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                mascotas.ID, mascotas.Nombre, mascotas.Especie, mascotas.Raza, mascotas.Edad, mascotas.Sexo, mascotas.Propietario, mascotas.Activo), conexion);
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static int ActualizarMascotas(ClaseMascotas mascotas)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update mascotas set nombre='{0}', especie='{1}', raza='{2}', edad='{3}', sexo='{4}', propietario='{5}', activo='{6}' where ID='{7}'",
                 mascotas.Nombre, mascotas.Especie, mascotas.Raza, mascotas.Edad, mascotas.Sexo, mascotas.Propietario, mascotas.Activo, mascotas.ID), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;
        }

        public static int EliminarMascotas(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = Conexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update mascotas set activo='0' where ID={0}", pId), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
    }
}
