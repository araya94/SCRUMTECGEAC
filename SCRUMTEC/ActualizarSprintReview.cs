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
    public partial class ActualizarSprintReview : Form
    {
        int idSprint;
        public ActualizarSprintReview(int idSprintP)
        {
            idSprint = idSprintP;
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtDescri.Text != "")
            {
                if (ConexionMetodos.insertarSprint(txtDescri.Text, idSprint)>0)
                {
                    MessageBox.Show("Sprint Review realizada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No deben haber campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
