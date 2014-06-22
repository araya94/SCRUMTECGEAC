using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScrumTEC;

namespace SCRUMTEC
{
    public partial class Index_UserStory : Form
    {
        int ID_Proyecto;
        int ID_Sprint;
        int rol;
        List<UserStory> list_userstory;
        public Index_UserStory(int id_proyecto, int rol)
        {
            this.ID_Proyecto = id_proyecto;
            this.rol = rol;
            InitializeComponent();
            
        }

        public Index_UserStory(int id_proyecto, int id_sprint, int rol)
        {
            this.ID_Proyecto = id_proyecto;
            this.ID_Sprint = id_sprint;
            this.rol = rol;
            InitializeComponent();
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // The index:
            int ListItemIndex = lstUserStory.SelectedIndex;
            //DataRow dr = UserStory.Tables[0].Rows[ListItemIndex];
            int id = Convert.ToInt32(list_userstory[ListItemIndex].id);

            frmEditarUserStory editar_userstory = new frmEditarUserStory(id,ID_Proyecto, rol);
            editar_userstory.Show();
           
        }

        private void Index_UserStory_Load(object sender, EventArgs e)
        {
            //METODO ALAMBRADO RECORDAR ARREGLAR
            
            list_userstory = ConexionMetodos.obtenerUserStory_IDProyecto(ID_Proyecto);

            
            lstUserStory.DataSource = list_userstory.ToList();
            
            lstUserStory.ValueMember = "Nombre";
            //lstUserStory.ValueMember = "id";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearUserStory crearUser = new CrearUserStory(ID_Proyecto);
            crearUser.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionMetodos con = new ConexionMetodos();
           
            con.eliminarUserStory(Convert.ToInt32(list_userstory[lstUserStory.SelectedIndex].id));

            list_userstory.RemoveAt(lstUserStory.SelectedIndex);
            lstUserStory.DataSource = list_userstory.ToList();

            lstUserStory.ValueMember = "Nombre";
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            list_userstory = ConexionMetodos.obtenerUserStory_IDProyecto(ID_Proyecto);


            lstUserStory.DataSource = list_userstory.ToList();

            lstUserStory.ValueMember = "Nombre";
        }
    }
}
