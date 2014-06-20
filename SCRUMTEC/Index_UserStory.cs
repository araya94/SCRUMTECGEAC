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
        public Index_UserStory(int id_proyecto, int rol)
        {
            InitializeComponent();
            this.ID_Proyecto = id_proyecto;
            this.rol = rol;
        }

        public Index_UserStory(int id_proyecto, int id_sprint, int rol)
        {
            InitializeComponent();
            this.ID_Proyecto = id_proyecto;
            this.ID_Sprint = id_sprint;
            this.rol = rol;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // The index:
            int ListItemIndex;

            ListItemIndex = lstUserStory.SelectedIndex;


            frmEditarUserStory editar_userstory = new frmEditarUserStory(ListItemIndex+1,ID_Proyecto);
            editar_userstory.Show();
        }

        private void Index_UserStory_Load(object sender, EventArgs e)
        {
            //METODO ALAMBRADO RECORDAR ARREGLAR
            
            DataSet UserStory = ConexionMetodos.obtenerUserStory_IDProyecto(ID_Proyecto);

            
            lstUserStory.DataSource = UserStory.Tables[0].DefaultView;
            
            lstUserStory.ValueMember = "Nombre";
            lstUserStory.ValueMember = "id";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearUserStory crearUser = new CrearUserStory(ID_Proyecto);
            crearUser.Show();
        }
    }
}
