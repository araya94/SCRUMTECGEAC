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
            SqlConnection Conn = Conexion.ObtenerConexion();
            if (Conn != null)
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
            else 
            {
                Console.WriteLine("No se puede conectar a la base de datos");
                return null;
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
                Comando.ExecuteNonQuery();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }


        /*
         * Nombre: insertarAsociacionUserS
         * Propósito:Permitir el ingreso de una asociacion de una tarea con un usuario del proyecto
         * Entrada: id del user Storie y id del usuario
         * Salida: un entero con el resultado de la operacion
         * Creado por: Cristian Araya
         * Fecha de Creacion: 21/05/2013
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static int insertarAsociacionUserS(int userS, int usuario)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_INSERTAR_ASOCIACIONUSER", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@userS", userS);
                Comando.Parameters.AddWithValue("@usuario", usuario);
                Comando.ExecuteNonQuery();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        //insertarSprint(txtNombre.Text, txtDescri.Text, idRelease);
        /*
         * Nombre: insertarSprint
         * Propósito:Permitir el ingreso de un sprint al sistema
         * Entrada: nombre,descripcion, id del Release seleccionado
         * Salida: un entero con el id del sprint creado
         * Creado por: Cristian Araya
         * Fecha de Creacion: 05/06/2013
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static int insertarSprint(String nombre, String descripcion,int release)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_INSERTAR_SPRINT", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
                Comando.Parameters.AddWithValue("@release", release);
                Comando.ExecuteNonQuery();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        /*
         * Nombre:BuscarNombreProyecto
         * Propósito:Retorna el nombre de un proyecto dado su id
         * Entrada: id del proyecto
         * Salida: Nombre del proyecto
         * Creado por: Cristian Araya
         * Fecha de Creacion: 22/05/2014
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static String BuscarNombreProyecto(int idProyecto)
        {
            String Documento = "";
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_BUSCARNOMBRE_PROYECTO", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@proyecto", idProyecto);
                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Documento = lector.GetString(1);
                }
                Conn.Close();
                return Documento;
            }
        }

        public static String GetEsfuerzoTarea(int idTarea)
        {
            int Documento = 0;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_BUSCARESFUERZO_TAREA", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@tarea", idTarea);
                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Documento = lector.GetInt32(1);
                }
                Conn.Close();
                return Documento + "";
            }
        }

        public static String GetEstimadoTarea(int idTarea)
        {
            int Documento = 0;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_BUSCARESTIMADO_TAREA", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@tarea", idTarea);
                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Documento = lector.GetInt32(1);
                }
                Conn.Close();
                return Documento + "";
            }
        }

        public static int GetTotalHoras(int idProyecto)
        {
            int Documento = 0;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_TOTALHORAS", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@proyecto", idProyecto);
                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Documento = lector.GetInt32(0);
                }
                Conn.Close();
                return Documento;
            }
        }
        
               /*
         * Nombre: insertarDuracion
         * Propósito:Permitir el ingreso de la duracion de los sprints de un proyecto
         * Entrada: Tiempo correspondiente y el id del proyecto
         * Salida: un entero con el resultado de la operacion
         * Creado por: Cristian Araya
         * Fecha de Creacion: 05/06/2013
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static int insertarDuracion(int tiempo, int proyecto)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_ACTUALIZARTIEMPOSPRINT_PROYECTO", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@tiempo", tiempo);
                Comando.Parameters.AddWithValue("@proyecto", proyecto);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        public static int ActualizarEsfuerzo(int tiempo, int sprint)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_ACTUALIZARESFUERZO_TAREA", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@tiempo", tiempo);
                Comando.Parameters.AddWithValue("@sprint", sprint);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }


        public static int insertarSprint(string descripcion, int sprint)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_ACTUALIZARREVIEW_SPRINT", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@descrip", descripcion);
                Comando.Parameters.AddWithValue("@idSprint",sprint);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }


        public static int AsociaUser(int idSprint,int idUser)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_ACTUALIZARFKSPRI_USER", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@sprint", idSprint);
                Comando.Parameters.AddWithValue("@user", idUser);
                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
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

        public static List<int> GetListaUserSId(int idSprint)
        {
            List<int> Lista = new List<int>();
            int Documento=0;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_BUSCAR_USER_SPRINT", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@sprint", idSprint);
                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Documento = lector.GetInt32(0);
                    Lista.Add(Documento);
                }
                Conn.Close();
                return Lista;
            }
        }

        public static List<String> GetListaUserSNombre(int idSprint)
        {
            String Documento = "";
            List<String> Lista = new List<String>();
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_BUSCAR_USER_SPRINT", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@sprint", idSprint);
                SqlDataReader lector = Comando.ExecuteReader();

                while (lector.Read())
                {
                    Documento = lector.GetString(1);
                    Lista.Add(Documento);
                }
                Conn.Close();
                return Lista;
            }
        }
        //-------------------------------------------------------------------------------




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
        * Nombre:CargarProyectos
        * Propósito:Permitir la busqueda de los proyectos que pertenecen a un Usuario especifico
        * Entrada:Id del usuario
        * Salida: Un DataSet con los proyectos pertenecientes a el Usuario 
        * Creado por: Guillermo Arce
        * Fecha de Creacion: 03/06/2014
        * Ultima Modificacion Hecha por:
        * Fecha Ultima Modificacion:
        */
        public static DataSet CargarReleases(int ID_Proyecto)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("CargarReleases", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@IDProyecto", ID_Proyecto);


                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.Release");

                Conn.Close();
                return DataSet1;

            }
        }

        public static DataSet CargarSprints(int ID_Release)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("CargarSprints", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@IDRelease", ID_Release);


                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.Sprint");

                Conn.Close();
                return DataSet1;

            }
        }

        public static DataSet CargarUserStories(int ID_Sprint)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("CargarUserStories", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@IDSprint", ID_Sprint);


                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.UserStory");

                Conn.Close();
                return DataSet1;

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

        public static int insertarTarea(int fk_userstory, string nombre, string descripcion, int duracion, int esfuerzo)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_INGRESAR_TAREA", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@FK_USERSTORY", fk_userstory);
                Comando.Parameters.AddWithValue("@NOMBRE", nombre);
                Comando.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                Comando.Parameters.AddWithValue("@DURACIONESTIMADA", duracion);
                Comando.Parameters.AddWithValue("@ESFUERZOINVERTIDO", esfuerzo);

                SqlDataReader lector = Comando.ExecuteReader();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        /*
            * Nombre: obtenerUserStory_IDSpring
            * Propósito:Obtener UserStorie por Spring
            * Entrada: id_spring
            * Salida: Data Source
            * Creado por: Esteban Segura Benavides
            * Fecha de Creacion: 6/06/2013
            * Ultima Modificacion Hecha por:
            * Fecha Ultima Modificacion:
            */
        public static DataSet obtenerUserStory_IDSpring(int id_spring)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_OBTENER_USERSORY_x_ID_SPRING", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_SPRING", id_spring);
                Comando.ExecuteNonQuery();

                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.UserStory");

                Conn.Close();
                return DataSet1;
            }
        }

        public static DataSet obtenerUserStory_IDProyecto(int id_proyecto)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_OBTENER_USERSORY_x_ID_PROYECTO", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_PROYECTO", id_proyecto);
                Comando.ExecuteNonQuery();

                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.UserStory");

                Conn.Close();
                return DataSet1;
            }
        }

        public static DataSet obtenerTarea_x_UserStory(int id_userstory)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_OBTENER_TAREA_x_USERSORY", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@FK_USER_STORIE", id_userstory);
                Comando.ExecuteNonQuery();
                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.Tarea");

                Conn.Close();
                return DataSet1;
            }
        }

        public static DataSet obtenerCriterio_x_UserStory(int id_userstory)
        {
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_OBTENER_CRITERIO_x_USERSTORY", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@FK_USER_STORIE", id_userstory);
                Comando.ExecuteNonQuery();
                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.Criteri");

                Conn.Close();
                return DataSet1;
            }
        }


        public UserStory obtenerUserStory_x_ID(int id)
        {
             UserStory userstory=null;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_OBTENER_USERSORY_x_ID", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID", id);
                Comando.ExecuteNonQuery();
                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.UserStory");

                foreach (DataRow dr in DataSet1.Tables[0].Rows)
                {
                    
                    String nombre = Convert.ToString(dr["Nombre"]);
                    String prioridad = Convert.ToString(dr["Prioridad"]);

                    String id_user_story = Convert.ToString(dr["id"]);
                    String descripcion = Convert.ToString(dr["Descripcion"]);


                    userstory = new UserStory(id_user_story, nombre, prioridad, descripcion);

                }

                Conn.Close();

                return userstory;
            }
        }

        public Tarea obtenerTarea_x_ID(int id)
        {
            Tarea tarea = null;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_OBTENER_TAREA_x_ID", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_TAREA", id);
                Comando.ExecuteNonQuery();
                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.Tarea");

                foreach (DataRow dr in DataSet1.Tables[0].Rows)
                {
                    String id_tarea = Convert.ToString(dr["id"]);
                    String nombre = Convert.ToString(dr["Nombre"]);
                    String descripcion = Convert.ToString(dr["Descripción"]);


                    String duracion = Convert.ToString(dr["DuracionEstimada"]);
                    


                    tarea = new Tarea(id_tarea, nombre, descripcion,duracion);

                }

                Conn.Close();

                return tarea;
            }
        }


        public Criterio obtenerCriterio_x_ID(int id)
        {
            Criterio criterio = null;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_OBTENER_CRITERIO_x_ID", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@ID_CRITERIO", id);
                Comando.ExecuteNonQuery();
                DataSet DataSet1 = new DataSet();
                SqlDataAdapter DataAdapter1 = new SqlDataAdapter(Comando);
                DataAdapter1.Fill(DataSet1, "dbo.Criteri");

                foreach (DataRow dr in DataSet1.Tables[0].Rows)
                {
                    String id_criterio = Convert.ToString(dr["id"]);
                    String nombre = Convert.ToString(dr["Nombre"]);
                    String descripcion = Convert.ToString(dr["Descripcion"]);


                    String estado = Convert.ToString(dr["Estado"]);



                    criterio = new Criterio(id_criterio, nombre, descripcion, estado);

                }

                Conn.Close();

                return criterio ;
            }
        }
        public  int insertarRelease(string nombre, string objetivo)
        {
            int resultado = -1;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("SP_INGRESAR_RELEASE", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@NOMBRE", nombre);
                Comando.Parameters.AddWithValue("@OBJETIVO", objetivo);
                Comando.ExecuteNonQuery();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }


        //-----------------------------------------------------------------------------------------
        public static int insertarProyecto(String nombre_proyecto, String descripcion_proyecto, int id_usuario)
        {

            int resultado;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("insertarProyecto", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@nombre", nombre_proyecto);
                Comando.Parameters.AddWithValue("@descripcion", descripcion_proyecto);
                Comando.Parameters.AddWithValue("@id_usuario", id_usuario);
                resultado = Comando.ExecuteNonQuery();
                Conn.Close();
                return resultado;
            }
        }


        //-----------------------------------------------------------------------------------
        public static int insertarUserStory(String nombre_user_story, String descripcion_user_story, String prioridad, int id_proyecto, int id_sprint)
        {
            int resultado;
            using (SqlConnection Conn = Conexion.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand("insertarUserStory", Conn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@nombre", nombre_user_story);
                Comando.Parameters.AddWithValue("@descripcion", descripcion_user_story);  
                Comando.Parameters.AddWithValue("@prioridad", prioridad);
                Comando.Parameters.AddWithValue("@FKProyecto", id_proyecto);
                //Comando.Parameters.AddWithValue("@FKSprint", id_sprint);

                Comando.ExecuteNonQuery();
                resultado = 1;
                Conn.Close();
                return resultado;
            }
        }

        
    }


}