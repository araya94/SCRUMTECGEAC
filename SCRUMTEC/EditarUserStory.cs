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
    public partial class EditarUserStory : Form
    {
        public EditarUserStory()
        {
            InitializeComponent();
        }

        private void btnAgregar_Criterios_Click(object sender, EventArgs e)
        {
            frmAgregarCriterio agregar_criterio = new frmAgregarCriterio();
            agregar_criterio.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = 1;
            string nombre = txtNombreUserStorie.Text;
            string prioridad = "";
            if (cmbPrioridad.SelectedIndex != -1)
            {
                prioridad = cmbPrioridad.SelectedItem.ToString();
            }
            //acualizar User Storie(int id,String nombre, String prioridad);
            if (ConexionMetodos.actualizarUserStorie(id, nombre, prioridad) > 0)
            {
                MessageBox.Show("User Storie Actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                //this.Dispose();
                //MenuPrincipal Menu = new MenuPrincipal();
                //Menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditarUserStory_Load(object sender, EventArgs e)
        {
            cmbPrioridad.Items.Add("Alta");
            cmbPrioridad.Items.Add("Media");
            cmbPrioridad.Items.Add("Baja");
        }

        private void btnAgregar_Tarea_Click(object sender, EventArgs e)
        {
            frmAgregarTarea agregar_tarea = new frmAgregarTarea();
            agregar_tarea.Show();
        }
    }
}
