using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace SCRUMTEC
{
    public class Conexion
    {
        /*
         * Nombre:ObtenerConexion
         * Propósito: Conectarse a la base de datos
         * Entrada:
         * Salida: 
         * Creado por: Cristian Araya
         * Fecha de Creacion: 21/05/2014
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Connec = new SqlConnection("Data source = CRIS; Initial Catalog = ScrumProyecto; Integrated Security=True"); //User Id=mono; Password=123"
            Connec.Open();
            return Connec;
        }

    }
}
