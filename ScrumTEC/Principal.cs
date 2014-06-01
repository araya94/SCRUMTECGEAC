using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumTEC
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Form dlg1 = new Form();
          //  dlg1.ShowDialog();

            CrearProyecto x = new CrearProyecto();
            x.ShowDialog();


        }

        private void agregarHistoriasDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
