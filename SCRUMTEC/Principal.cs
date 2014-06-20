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
        int idProyecto;
        Button BotonProyecto;
        DataSet Proyectos;

        public Principal(int rolP,int idUsuarioP)
        {
            
            InitializeComponent();
            rol = rolP;
            idUsuario = idUsuarioP;
            Proyectos = ConexionMetodos.CargarProyectosxUsuario(idUsuario);
            List<String> ListaNombres = new List<String>();

            if (rol == 1)
            {
                userStoryToolStripMenuItem.Visible = false;
                releaseToolStripMenuItem.Visible = false;
            }
            if (rol == 2)
            {
                nuevoProyectoToolStripMenuItem.Visible = false;
                crearUsuarioToolStripMenuItem.Visible = false;
            }
            if (rol == 3)
            {
                nuevoProyectoToolStripMenuItem.Visible = false;
                crearUsuarioToolStripMenuItem.Visible = false;
                userStoryToolStripMenuItem.Visible = false;
                releaseToolStripMenuItem.Visible = false;
            }
            if (rol == 4)
            {
                nuevoProyectoToolStripMenuItem.Visible = false;
                crearUsuarioToolStripMenuItem.Visible = false;
                userStoryToolStripMenuItem.Visible = false;
                releaseToolStripMenuItem.Visible = false;
            }
            if (rol == 5)
            {
                nuevoProyectoToolStripMenuItem.Visible = false;
                crearUsuarioToolStripMenuItem.Visible = false;
                userStoryToolStripMenuItem.Visible = false;
                releaseToolStripMenuItem.Visible = false;
            }
            
            foreach (DataRow dr in Proyectos.Tables[0].Rows)
            {
                ListaNombres.Add(Convert.ToString(dr["Nombre"]));
            }
            for (int i = 0; i < ListaNombres.Count; i++)
            {
                BotonProyecto = new Button();
                BotonProyecto.Name = "Boton" + i.ToString();
                BotonProyecto.Text = ListaNombres[i].ToString();
                BotonProyecto.Location = new System.Drawing.Point(255, 150 * i + 30);
                BotonProyecto.Size = new System.Drawing.Size(300, 120);
                BotonProyecto.BackColor = System.Drawing.Color.Silver;
                BotonProyecto.Click += new System.EventHandler(BotonProyecto_click);
                panel1.Controls.Add(BotonProyecto);          
                
            }
            panel2.Visible = false;
            
            
        }



        private void agregarHistoriasDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoProyectoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           // this.Hide(); Si lo oculta lo debe volver a mostrar depues de hacer el proyecto
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
            if (panel1.Visible == true) { panel1.Visible = false; panel2.Visible = true; }
            else { panel1.Visible = true;  panel2.Visible = false; }
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

        public void BotonProyecto_click(Object sender, System.EventArgs e)
        {
            label1.Text = "Seleccione un Release para continuar";
            Button B = (Button)sender;
            String NumeroBoton = B.Name;
            NumeroBoton = NumeroBoton.Remove(0,5);
            int ID_Boton = Convert.ToInt32(NumeroBoton);
            DataRow ID_Proyecto = Proyectos.Tables[0].Rows[ID_Boton];
            int ID = Convert.ToInt32(ID_Proyecto["id"].ToString());
            idProyecto = ID;
            Cargar_Panel_Releases(ID);
            panel2.Visible = true;
            panel1.Visible = false;
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Cargar_Panel_Releases(int idProyeto)
        {

            DataSet Releases = ConexionMetodos.CargarReleases(idProyeto);
            List<String> ListaNombres = new List<String>();
            List<String> ListaId = new List<String>();
            List<String> ListaDescripcion = new List<String>();

            foreach (DataRow dr in Releases.Tables[0].Rows)
            {
                ListaNombres.Add(Convert.ToString(dr["Nombre"]));
            }
            for (int i = 0; i < ListaNombres.Count; i++)
            {
                Button NuevoBoton = new Button();
                NuevoBoton.Name = "Boton" + i.ToString();
                NuevoBoton.Text = ListaNombres[i].ToString();
                NuevoBoton.Location = new System.Drawing.Point(255, 150 * i + 30);
                NuevoBoton.Size = new System.Drawing.Size(300, 120);
                NuevoBoton.BackColor = System.Drawing.Color.Silver;
                //NuevoBoton.Click += new System.EventHandler(NuevoBoton_click);
                panel2.Controls.Add(NuevoBoton);

            }
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crearUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreaUsuario ventana = new CreaUsuario(idProyecto, idUsuario);
            ventana.ShowDialog();
        }

        private void aministrarUserStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Index_UserStory indexUser = new Index_UserStory(idProyecto, rol);
            indexUser.Show();
        }

        private void userStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Identificacion SalirSesion = new Identificacion();
            this.Close();
            SalirSesion.Show();
        }

    }
}
