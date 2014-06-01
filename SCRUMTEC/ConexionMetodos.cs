using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SCRUMTEC
{
    class ConexionMetodos
    {
        /*
         * Nombre:Autentificar
         * Propósito:Permitir el ingreso al sistema con un usuario y una contraseña válida por medio de un store procedure
         * Entrada:El usuario y la contraseña
         * Salida: un entero con el resultado de la operacion
         * Creado por: Cristian Araya
         * Fecha de Creacion: 01/06/2014
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static int Autentificar(String pUsuario, String pContraseña)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("autentificacion", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@usuario", pUsuario);
                Comando.Parameters.AddWithValue("@contraseña", pContraseña);
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    resultado = lector.GetInt32(1);
                }
                Conn.Close();
                return resultado;
            }
        }

        /*
         * Nombre: insertarUsuario
         * Propósito:Permitir el ingreso de un usuario al sistema
         * Entrada: usuario, contrasena,proyecto, rol
         * Salida: un entero con el resultado de la operacion
         * Creado por: Cristian Araya
         * Fecha de Creacion: 21/05/2013
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static int insertarUsuario(String nombre, String usuario, String contrasena, String email, int proyecto, int rol)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("insertarUsuario", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@usuario", usuario);
                Comando.Parameters.AddWithValue("@contrasena", contrasena);
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@email", email);
                Comando.Parameters.AddWithValue("@proyecto", proyecto);
                Comando.Parameters.AddWithValue("@rol", rol);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        /*
         * Nombre:BuscarProyectos
         * Propósito:Permitir la busqueda de todos los proyectos que existen por medio de un store procedure
         * Entrada:Ninguna
         * Salida: Lista con los proyectos
         * Creado por: Cristian Araya
         * Fecha de Creacion: 22/05/2014
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static List<String> BuscarProyectos()
        {
            List<String> Lista = new List<String>();
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("buscarProyectos", Conn);
                Comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    String Documento = lector.GetString(1);
                    Lista.Add(Documento);
                }
                Conn.Close();
                return Lista;
            }
        }

        /*
        * Nombre:BuscarRoles
        * Propósito:Permitir la busqueda de los roles disponibles
        * Entrada:Ninguna
        * Salida: Lista con los roles
        * Creado por: Cristian Araya
        * Fecha de Creacion: 22/05/2014
        * Ultima Modificacion Hecha por:
        * Fecha Ultima Modificacion:
        */
        public static List<String> BuscarRoles()
        {
            List<String> Lista = new List<String>();
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("buscarRoles", Conn);
                Comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    String Documento = lector.GetString(1);
                    Lista.Add(Documento);
                }
                Conn.Close();
                Lista.RemoveAt(0);
                return Lista;
            }
        }
    }
}