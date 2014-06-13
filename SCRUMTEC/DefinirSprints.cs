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
    public partial class DefinirSprints : Form
    {
        int idRelease;

        public DefinirSprints(int idreleaseP)
        {
            idRelease = idreleaseP;
            InitializeComponent();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblCrea_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" & txtDescri.Text != "")
            {
                int idSprint;
                idSprint = ConexionMetodos.insertarSprint(txtNombre.Text, txtDescri.Text, idRelease);
                if ( idSprint > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Sprint Creado con éxito, Desea agregar los user Stories", "Éxito Sprint", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Hide();
                        //AsociarUserASprint ventana = new AsociarUserASprint(idSprint);
                        //ventana.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Hide();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
