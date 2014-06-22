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
        DataSet UserStory;
        

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
            DataRow dr = UserStory.Tables[0].Rows[ListItemIndex];
            int id = Convert.ToInt32(dr["id"]);

            frmEditarUserStory editar_userstory = new frmEditarUserStory(id, ID_Proyecto, rol);
            editar_userstory.Show();
            this.Close();
        }

        private void Index_UserStory_Load(object sender, EventArgs e)
        {
            //METODO ALAMBRADO RECORDAR ARREGLAR

            UserStory = ConexionMetodos.obtenerUserStory_IDProyecto(ID_Proyecto);


            lstUserStory.DataSource = UserStory.Tables[0].DefaultView;

            lstUserStory.ValueMember = "Nombre";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearUserStory crearUser = new CrearUserStory(ID_Proyecto);
            crearUser.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionMetodos con = new ConexionMetodos();

            int ListItemIndex = lstUserStory.SelectedIndex;
            DataRow dr = UserStory.Tables[0].Rows[ListItemIndex];
            int id = Convert.ToInt32(dr["id"]);

            con.eliminarUserStory(id);

            MessageBox.Show("User Story eliminado con éxito");

            UserStory = ConexionMetodos.obtenerUserStory_IDProyecto(ID_Proyecto);

            lstUserStory.DataSource = UserStory.Tables[0].DefaultView;

            lstUserStory.ValueMember = "Nombre";

            
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            UserStory = ConexionMetodos.obtenerUserStory_IDProyecto(ID_Proyecto);

            lstUserStory.DataSource = UserStory.Tables[0].DefaultView;

            lstUserStory.ValueMember = "Nombre";
        }

    }
}
