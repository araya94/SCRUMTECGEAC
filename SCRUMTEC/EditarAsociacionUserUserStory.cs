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
    public partial class EditarAsociacionUserUserStory : Form
    {

        private int idUserStory;
        private int idProyecto;

        public EditarAsociacionUserUserStory(int idProyecto, int idUserStory, String nombreUserStory)
        {
            InitializeComponent();
            this.idProyecto = idProyecto;
            this.idUserStory = idUserStory;
            this.label_nombre_user_story.Text = "User Story: " + nombreUserStory;
            this.button_eliminar_usuario.Enabled = false;
            cargarUsuariosDelUserStory(idUserStory);
            
        }

        //Carga los developers y testers asociados al este user story
        private void cargarUsuariosDelUserStory(int idUserStory) 
        {
            DataSet Usuarios = ConexionMetodos.obtenerUsuariosAsociadosUserStory(idUserStory);
            listBox_usuarios.DataSource = Usuarios.Tables["UsuariosUserStory"];
            listBox_usuarios.ValueMember = "id";
            listBox_usuarios.DisplayMember = "nombre"; 

        
        }

        private void button_agregar_usuario_Click(object sender, EventArgs e)
        {
            AsociarUserAUserStory asociacion = new AsociarUserAUserStory(idProyecto, idUserStory);
            asociacion.ShowDialog();
        }

        private void button_eliminar_usuario_Click(object sender, EventArgs e)
        {
            int id_user_userStory = (int)listBox_usuarios.SelectedValue;
           
            ConexionMetodos.eliminarAsociacionUserUserStory(id_user_userStory);
            cargarUsuariosDelUserStory(idUserStory);
        }

        //Se cierra el formulario
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button_eliminar_usuario.Enabled = true;
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            cargarUsuariosDelUserStory(idUserStory);
        }
    }
}
