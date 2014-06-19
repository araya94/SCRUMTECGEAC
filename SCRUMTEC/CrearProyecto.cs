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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_cancelarCrearProyecto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_CrearProyecto_Click(object sender, EventArgs e)
        {
            validarNombreProyecto(this.textBox_nombreProyecto.Text);
            this.Close();
        }

        //Valida que el nombre del proyecto introducido sea un 
        private void validarNombreProyecto(String nombre_proyecto)
        {
        }

    }
}
