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
        List<int> listaId = new List<int>();
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
            frmEditarUserStory editar_userstory = new frmEditarUserStory(listaId.ElementAt(lstUserStory.SelectedIndex), ID_Proyecto, rol);
            editar_userstory.Show();
            this.Close();
        }

        private void Index_UserStory_Load(object sender, EventArgs e)
        {
            DataSet UserStory = ConexionMetodos.obtenerUserStory_IDProyecto(ID_Proyecto);
            lstUserStory.DataSource = UserStory.Tables[0].DefaultView;
            lstUserStory.ValueMember = "Nombre";
            int a = UserStory.Tables[0].Rows.Count;
            for (int i=0;i<a;i++)
            {
                int id = Convert.ToInt32(UserStory.Tables[0].Rows[i][0]);
                listaId.Add(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearUserStory crearUser = new CrearUserStory(ID_Proyecto);
            crearUser.Show();
        }
    }
}
