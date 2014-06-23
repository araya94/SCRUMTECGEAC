using SCRUMTEC;
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
        int id_proyecto;
        int id_sprint;



        public CrearUserStory(int id_proyectoP, int id_sprintP)
        {
            this.id_proyecto = id_proyectoP;
            this.id_sprint = id_sprintP;
            InitializeComponent();
            this.radioButton.Checked = true;

        }

        public CrearUserStory(int id_proyectoP)
        {
            this.id_proyecto = id_proyectoP;

            InitializeComponent();
            this.radioButton.Checked = true;
        }

        private void CrearUserStory_Load(object sender, EventArgs e)
        {

        }

        //Cancelar
        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        //Insertar User Story
        private void button2_Click(object sender, EventArgs e)
        {

            String nombre_user_story = this.textBox1.Text.Trim();
            String descripcion_user_story = this.textBox2.Text.Trim();
            String prioridad = getPrioridadSeleccionada();

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


        private String getPrioridadSeleccionada()
        {

            string prioridad = "";

            if (this.radioButton.Checked) { prioridad = radioButton.Text; }
            else if (this.radioButton2.Checked) { prioridad = radioButton2.Text; }
            else { prioridad = radioButton3.Text; }

            return prioridad;

        }


    }
}
