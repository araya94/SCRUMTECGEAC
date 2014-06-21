using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRUMTEC
{
    class Tarea
    {
        public String id
        {
            get;
            set;
        }
        public String FK_UserStory
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
        public String duracion
        {
            get;
            set;
        }
        public String estimado
        {
            get;
            set;
        }

        public Tarea(String id,String nombre, String descripcion,String duracion) 
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.duracion = duracion;
        }
    }

    
}
