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
    public partial class AsociarUserAUserStory : Form
    {
        private int idProyecto;
        private int idUserStory;

        public AsociarUserAUserStory(int idProyecto, int idUserStory)
        {
            this.idProyecto = idProyecto;
            this.idUserStory = idUserStory;
            InitializeComponent();
            cargarDevelopersPorProyecto(idProyecto);
            cargarTestersPorProyecto(idProyecto);
        }

        private void cargarDevelopersPorProyecto(int idProyecto)
        {

            DataSet Developers = ConexionMetodos.obtenerDevelopersAsociadosProyecto(idProyecto);
            comboBox_developers.DataSource = Developers.Tables["Developers"];
            comboBox_developers.ValueMember = "id";
            comboBox_developers.DisplayMember = "nombre";      
        
        }

        private void cargarTestersPorProyecto(int idProyecto)
        {
            DataSet Testers = ConexionMetodos.obtenerTestersAsociadosProyecto(idProyecto);

            comboBox_testers.DataSource = Testers.Tables["Testers"];
            comboBox_testers.ValueMember = "id";
            comboBox_testers.DisplayMember = "nombre";
        }

        private void button_asociar_Click(object sender, EventArgs e)
        {
            Object id_developer =  comboBox_developers.SelectedValue;
            Object id_tester =     comboBox_testers.SelectedValue;

            int idUsuarioProyecto = (int)id_developer;
            ConexionMetodos.insertarAsociacionUserUserStory(idUserStory, idUsuarioProyecto);
     
            idUsuarioProyecto = (int)id_tester;
            ConexionMetodos.insertarAsociacionUserUserStory(idUserStory, idUsuarioProyecto);
         

            this.Close();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
