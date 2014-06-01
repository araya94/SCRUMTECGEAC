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
    public partial class CreaUsuario : Form
    {
        int rol;
        int idUsuario;
        public CreaUsuario(int rolP,int idUsuarioP)
        {
            InitializeComponent();
            rol =rolP;
            idUsuario = idUsuarioP;
            ConexionMetodos ConexionDocumentos = new ConexionMetodos();
            List<String> Proyectos = ConexionMetodos.BuscarProyectos();
            for (int x = 0; x < Proyectos.Count; x++)
            {
                cBProyecto.Items.Add(Proyectos.ElementAt(x));
            }
            List<String> Roles = ConexionMetodos.BuscarRoles();
            for (int x = 0; x < Roles.Count; x++)
            {
                cBRol.Items.Add(Roles.ElementAt(x));
            }
        }

        private void lblCrea_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cBTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        /*
         * Nombre:btnCrear_Click
         * Propósito:Verificar que un usuario se pueda crear y llamar método para crearlo
         * Entrada:El evento
         * Salida: Mensaje de éxito o error
         * Creado por: Cristian Araya
         * Fecha de Creacion: 22/05/2013
         * Ultima Modificacion Hecha por:
         * Fecha Ultima Modificacion:
         */
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == txtConfirmarcionContraseña.Text)
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

        private void txtConfirmarcionContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
