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
    public partial class NuevoRelease : Form
    {
        int idProyecto;
        public NuevoRelease(int ID_Proyecto)
        {
            idProyecto = ID_Proyecto;
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            String objetivo = rtxtDescripcion.Text;

            ConexionMetodos conn = new ConexionMetodos();
            int estado = conn.insertarRelease(nombre,objetivo, idProyecto);

            if (estado == 1)
            {
                MessageBox.Show("Release creado correctamente");
            }

            this.Close();
        }
    }
}
