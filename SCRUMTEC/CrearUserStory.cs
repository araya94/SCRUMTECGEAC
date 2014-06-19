using ScrumTEC.Conexión;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumTEC
{
    public partial class CrearUserStory : Form
    {
        public CrearUserStory()
        {
            InitializeComponent();
        }

        private void CrearUserStory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            String nombre_user_story = this.textBox1.Text.Trim(); 
            String descripcion_user_story = this.textBox2.Text.Trim();
            String prioridad = "";
            int id_proyecto = 0;
            int id_sprint = 0;

            if (nombre_user_story.Length >= 5 & nombre_user_story.Length <= 25)
            {

                ConexionMetodos ConexionDocumentos = new ConexionMetodos();
                if (ConexionMetodos.insertarUserStory(nombre_user_story, descripcion_user_story, prioridad, id_proyecto, id_sprint) > 0)
                {
                    MessageBox.Show("UserStoty creado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Ya existe un user story con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }


            this.Close();

        }




    }
}
