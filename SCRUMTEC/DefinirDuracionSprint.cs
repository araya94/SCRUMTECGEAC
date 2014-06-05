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
    public partial class DefinirDuracionSprint : Form
    {
        public DefinirDuracionSprint()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDuracion_Click(object sender, EventArgs e)
        {

        }

        private void btnDefinir_Click(object sender, EventArgs e)
        {
            if (txtDuracion.Text. =! null )
            {
                //insertarUsuario(String nombre, String usuario, String contrasena, String email, int proyecto, int rol);
                if (ConexionMetodos.insertarUsuario(txtNombre.Text, txtUsuario.Text, txtContraseña.Text, txtEmail.Text, (cBProyecto.SelectedIndex + 1), (cBRol.SelectedIndex + 1)) > 0)
                {
                    MessageBox.Show("Usuario Creado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                    //MenuPrincipal Menu = new MenuPrincipal();
                    //Menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas deben de ser igual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
