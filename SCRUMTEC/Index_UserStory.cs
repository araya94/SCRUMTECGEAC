using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCRUMTEC
{
    public partial class Index_UserStory : Form
    {
        public Index_UserStory()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmEditarUserStory editar_userstory = new frmEditarUserStory;
            editar_userstory.Show();
        }

        private void Index_UserStory_Load(object sender, EventArgs e)
        {
            //METODO ALAMBRADO RECORDAR ARREGLAR
            int idSpring = 1;
            DataSet UserStory = ConexionMetodos.obtenerUserStory_IDSpring(idSpring);

            lstUserStory.DataSource = UserStory.Tables[0].DefaultView;
            lstUserStory.ValueMember = "Nombre";
            lstUserStory.ValueMember = "Prioridad";
        }
    }
}
