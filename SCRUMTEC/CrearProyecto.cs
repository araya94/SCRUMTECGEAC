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
    public partial class CrearProyecto : Form
    {
        int rol;
        int idUsuario;

        public CrearProyecto(int rolP,int idUsuarioP)
        {
            InitializeComponent();
            rol =rolP;
            idUsuario = idUsuarioP;
        }

        private void button_cancelarCrearProyecto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_CrearProyecto_Click(object sender, EventArgs e)
        {
            String nombre_proyecto = this.textBox_nombreProyecto.Text.Trim(); // Trim() elimina los espacios en blanco del principio y el final
            String descripcion_proyecto = this.textBox_descripcionProyecto.Text.Trim();

            if (nombre_proyecto.Length >= 5 & nombre_proyecto.Length <= 25)
            {

                ConexionMetodos ConexionDocumentos = new ConexionMetodos();
                if (rol == 1)
                {
                    if (ConexionMetodos.insertarProyecto(nombre_proyecto, descripcion_proyecto, idUsuario) > 0)
                    {
                        MessageBox.Show("Proyecto creado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Ya existe un proyecto con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }

                this.Close();
            }
        }



    }
}
