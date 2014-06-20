using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRUMTEC
{
    class UserStory
    {
        public String id {
            get;
            set;
        }
        public String nombre{
            get;
            set;
        }
        public String prioridad{
            get;
            set;
        }
        public String descripcion{
            get;
            set;
        }

        public UserStory(String id, String nombre, String prioridad, String descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.prioridad = prioridad;
            this.descripcion = descripcion;

        }


    }
}
