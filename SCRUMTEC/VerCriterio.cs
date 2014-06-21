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
    public partial class VerCriterio : Form
    {
        int id;
        public VerCriterio(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void VerCriterio_Load(object sender, EventArgs e)
        {
            ConexionMetodos con = new ConexionMetodos();
            Criterio criterio = con.obtenerCriterio_x_ID(id);
            lblNombre.Text = criterio.nombre;
            rtxtDescripcion.Enabled = false;
            txtEstado.Enabled = false;
            rtxtDescripcion.Text = criterio.descripcion;

            String estado;
            if (criterio.estado == "True")
            {
                estado = "Completo";
            }
            else {
                estado = "Pendiente";
            }
            txtEstado.Text = estado;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
