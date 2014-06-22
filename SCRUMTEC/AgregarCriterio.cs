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
    public partial class frmAgregarCriterio : Form
    {
        int idUserStory;

        public frmAgregarCriterio(int ID_UserStory)
        {
            idUserStory = ID_UserStory;
            InitializeComponent();
        }


        private void AgregarCriterio_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add("Completado");
            cmbEstado.Items.Add("Pendiente");

            cmbEstado.SelectedIndex = 0;

            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedItem.Equals("Completado"))
            {
                //POR EL MOMENTO EL FK_USER STORY ESTA ALAMBRADO RECORDAR CAMBIAR CUANDO SE UNA TODA LA LOGICA
                ConexionMetodos.insertarCriterio(idUserStory, txtNombreCriterio.Text, rtxtDescripcion.Text, 1);
                MessageBox.Show("Criterio creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cmbEstado.SelectedItem.Equals("Pendiente"))
            {
                ConexionMetodos.insertarCriterio(idUserStory, txtNombreCriterio.Text, rtxtDescripcion.Text, 0);
                MessageBox.Show("Criterio creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Inesperado, intentelo mas tarde", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
