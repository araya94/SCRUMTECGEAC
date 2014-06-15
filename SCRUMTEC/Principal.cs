using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SCRUMTEC
{
    public partial class Principal : Form
    {
        int rol;
        int idUsuario;
        Button NuevoBoton = new Button();
        public Principal(int rolP,int idUsuarioP)
        {
            InitializeComponent();

            rol = rolP;
            idUsuario = idUsuarioP;
            DataSet Proyectos = ConexionMetodos.CargarProyectosxUsuario(idUsuario);
            List<String> ListaNombres = new List<String>();
            List<String> ListaId = new List<String>();
            List<String> ListaDescripcion = new List<String>();
            
            foreach (DataRow dr in Proyectos.Tables[0].Rows)
            {
                ListaNombres.Add(Convert.ToString(dr["Nombre"]));
            }
            for (int i = 0; i < ListaNombres.Count; i++)
            {
                NuevoBoton = new Button();
                NuevoBoton.Name = "Boton" + i.ToString();
                NuevoBoton.Text = ListaNombres[i].ToString();
                NuevoBoton.Location = new System.Drawing.Point(50, 150 * i + 30);
                NuevoBoton.Size = new System.Drawing.Size(300, 120);
                NuevoBoton.BackColor = System.Drawing.Color.Silver;
                //btn.Click += new System.EventHandler(btn_click);
                panel1.Controls.Add(NuevoBoton);          
                
            }
            panel2.Visible = false;
            
            
        }

        private void agregarHistoriasDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoProyectoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CrearProyecto ventana = new CrearProyecto(rol,idUsuario);
            ventana.ShowDialog();
        }

        private void agregarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaUsuario ventana = new CreaUsuario(rol, idUsuario);
            ventana.ShowDialog();
        }

        private void accionesScrumMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true) panel2.Visible = false;
            else panel2.Visible = true; 
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AsociarUserASprint ventana = new AsociarUserASprint(1);
            //ventana.ShowDialog();
        }

        public void NuevoBoton_click(Object sender, System.EventArgs e)
        {
            MessageBox.Show("Click");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
