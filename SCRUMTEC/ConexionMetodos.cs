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
        public static List<int> Autentificar(String pUsuario, String pContraseña)
        {
            List<int> Lista = new List<int>();
            int resultado = -1;
            int id = 0;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("autentificacion", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@usuario", pUsuario);
                Comando.Parameters.AddWithValue("@contraseña", pContraseña);
                SqlDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    id = lector.GetInt32(0);
                    resultado = lector.GetInt32(1);
                    Lista.Add(id);
                    Lista.Add(resultado);
                }
                Conn.Close();
                return Lista;
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
        * Nombre:CargarProyectos
        * Propósito:Permitir la busqueda de los proyectos que pertenecen a un Usuario especifico
        * Entrada:Id del usuario
        * Salida: Un DataSet con los proyectos pertenecientes a el Usuario 
        * Creado por: Guillermo Arce
        * Fecha de Creacion: 03/06/2014
        * Ultima Modificacion Hecha por:
        * Fecha Ultima Modificacion:
        */
        public static DataSet CargarProyectosxUsuario(int ID_Usuario)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("CargarProyectosUsuario", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@IDUsuario", ID_Usuario);

               
                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.Proyecto");

                Conn.Close();
                return DataSet1;

                /* ESTE ES EL STORED PROCEDURE DE CARGAR PROYECTOS X USUARIO PARA QUE LO APUNTEN POR AHI...
                 
                create procedure CargarProyectosUsuario
                @IDUsuario int
                as
                begin
                begin try
		            begin transaction

			            Select * from dbo.Proyecto P
				            inner join dbo.Usuario_Proyecto UP on UP.FKUsuario = @IDUsuario
					            where P.id = UP.FKProyecto

		            commit transaction
	            end try
	            begin catch
		            select ERROR_NUMBER() as ErrorNumber;
		            return -1;
		            rollback transaction
	            end catch 
            end
              
            */
            
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

        /*--------------------------- ESTEBAN ----------------------------------------------------------*/
        /*
         * Nombre: editarUserStoriE
         * Propósito:Permitir editar un UserStorie
         * Entrada: id, nombre, prioridad
         * Salida: un entero con el resultado de la operacion
         * Creado por: Esteban Segura Benavides
         * Fecha de Creacion: 1/06/2013
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static int actualizarUserStorie(int id, string nombre, string prioridad)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_ACTUALIZAR_USERSTORIE", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", id);
                Comando.Parameters.AddWithValue("@NOMBRE", nombre);
                Comando.Parameters.AddWithValue("@PRIORIDAD", prioridad);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }


        /*
             * Nombre: eliminarUserStoriE
             * Propósito:Permitir eliminar un UserStorie
             * Entrada: id
             * Salida: un entero con el resultado de la operacion
             * Creado por: Esteban Segura Benavides
             * Fecha de Creacion: 1/06/2013
             * Ultima Modificacion Hecha por:
             * Fecha Ultima Modificacion:
             */
        public static int eliminarUserStorie(int id)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_ELIMINAR_USERSTORIE", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", id);

                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }


        /*
            * Nombre: insertarCriterio
            * Propósito:Permitir insertar criterio a un UserStorie
            * Entrada: id, nombre, prioridad
            * Salida: un entero con el resultado de la operacion
            * Creado por: Esteban Segura Benavides
            * Fecha de Creacion: 4/06/2013
            * Ultima Modificacion Hecha por:
            * Fecha Ultima Modificacion:
            */
        public static int insertarCriterio(int fk_userstory, string nombre, string descripcion, int estado)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_INGRESAR_CRITERIO", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@FK_USERSTORY", fk_userstory);
                Comando.Parameters.AddWithValue("@NOMBRE", nombre);
                Comando.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                Comando.Parameters.AddWithValue("@ESTADO", estado);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        public static int insertarTarea(int fk_userstory, string nombre, string descripcion, string duracion)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_INGRESAR_TAREA", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@FK_USERSTORY", fk_userstory);
                Comando.Parameters.AddWithValue("@NOMBRE", nombre);
                Comando.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                Comando.Parameters.AddWithValue("@DURACION", duracion);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }
    }
}