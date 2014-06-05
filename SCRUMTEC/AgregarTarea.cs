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
    public partial class frmAgregarTarea : Form
    {
        public frmAgregarTarea()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConexionMetodos.insertarTarea(1, txtNombreTarea.Text, rtxtDescripcion.Text, txtDuracion.Text);
            MessageBox.Show("Tarea creadada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
