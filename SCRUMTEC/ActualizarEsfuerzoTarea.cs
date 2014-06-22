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
    public partial class ActualizarEsfuerzoTarea : Form
    {
        int idTare;
        public ActualizarEsfuerzoTarea(int idTarea)
        {
            idTare = idTarea;
            InitializeComponent();
            tBEstimado.Text = ConexionMetodos.GetEstimadoTarea(idTare);
            txtDuracion.Text = ConexionMetodos.GetEsfuerzoTarea(idTare);
        }

        private void btnDefinir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDuracion.Text))
            {
                MessageBox.Show("Tiene que llenar los campos correspondientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (ConexionMetodos.ActualizarEsfuerzo(Convert.ToInt32(txtDuracion.Text), idTare) > 0)
            {
                MessageBox.Show("Esfuerzo Actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }

            else
            {
                MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            
        }
    }
}
