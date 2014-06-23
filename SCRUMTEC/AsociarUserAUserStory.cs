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

        public AsociarUserAUserStory(int idProyecto)
        {
            this.idProyecto = idProyecto;
            InitializeComponent();
            cargarDevelopersPorProyecto(idProyecto);
            cargarTestersPorProyecto(idProyecto);
        }

        private void cargarDevelopersPorProyecto(int idProyecto)
        {
           
            DataSet Developers = ConexionMetodos.obtenerDevelopersAsociadosProyecto(idProyecto);
            comboBox_developers.DataSource = Developers;
        
        }

        private void cargarTestersPorProyecto(int idProyecto)
        {
            DataSet Testers = ConexionMetodos.obtenerTestersAsociadosProyecto(idProyecto);
            comboBox_testers.DataSource = Testers;
        }

        private void button_asociar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
