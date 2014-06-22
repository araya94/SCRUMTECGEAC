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
        int idProyecto;
        public DefinirDuracionSprint(int idP)
        {
            idProyecto = idP;
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
            if (String.IsNullOrEmpty(txtDuracion.Text))
            {
                MessageBox.Show("Tiene que llenar los campos correspondientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                
            }

            else if (ConexionMetodos.insertarDuracion(Convert.ToInt32(txtDuracion.Text), idProyecto) > 0)
            {
                MessageBox.Show("Duración Cambiada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
