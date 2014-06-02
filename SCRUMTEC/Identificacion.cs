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
    public partial class Identificacion : Form
    {
        public Identificacion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<int> Lista = ConexionMetodos.Autentificar(txtUsuario.Text, txtContraseña.Text);
            int rol = Lista.ElementAt(0);
            int idUsuario = Lista.ElementAt(1);
            String rolS = null;
            if ((rol > 0) & (txtUsuario.Text != ""))
            {//Verifica que el usuario y la contraseña sean válidos
                if (rol == 1) rolS = "SysAdmin";
                if (rol == 2) rolS = "Product Owner";
                if (rol == 3) rolS = "Scrum Master";
                if (rol == 4) rolS = "Developer";
                if (rol == 5) rolS = "Tester";
                MessageBox.Show("Sesión Iniciada - " + rolS);
                this.Hide();
                Principal Menu = new Principal(rol,idUsuario);
                Menu.ShowDialog();
            }
            else
                MessageBox.Show("Datos Inválidos");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void Identificacion_Load(object sender, EventArgs e)
        {

        }
    }
}
