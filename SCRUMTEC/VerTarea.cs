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
    public partial class VerTarea : Form
    {
        int id;
        public VerTarea(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void VerTarea_Load(object sender, EventArgs e)
        {
            ConexionMetodos con = new ConexionMetodos();
            Tarea tarea = con.obtenerTarea_x_ID(id);
            lblNombre.Text = tarea.nombre;
            rtxtDescripcion.Enabled = false;
            rtxtDescripcion.Text = tarea.descripcion;
            txtDuracion.Enabled = false;
            txtDuracion.Text = tarea.duracion + " dias";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rtxtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
