using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRUMTEC
{
    class Criterio
    {
        public String id
        {
            get;
            set;
        }
        public int FK_UserStory
        {
            get;
            set;
        }
        public String nombre
        {
            get;
            set;
        }
        public String descripcion
        {
            get;
            set;
        }
        public String estado
        {
            get;
            set;
        }

        public Criterio(String id, String nombre, String descripcion, String estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.estado = estado;
        }
    }
}
