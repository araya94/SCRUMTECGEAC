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

            CrearBotones(panel1, Proyectos);
            BotonAtras.Enabled = false;
            panel2.Visible = false;
            //panel3.Visible = false;
            //panel4.Visible = false;
            
        }


        public void CrearBotones(Panel panelActual, DataSet Datos)
        {
            
            List<String> ListaNombres = new List<String>();
            foreach (DataRow dr in Datos.Tables[0].Rows)
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
                if (panelActual.Name == "panel1") { BotonProyecto.Click += new System.EventHandler(CargarReleases_click); }
                else if (panelActual.Name == "panel2") { BotonProyecto.Click += new System.EventHandler(CargarSprints_click); }
                //else if (panelActual.Name == "panel3") { BotonProyecto.Click += new System.EventHandler(CargarTareas_click); }
                panelActual.Controls.Add(BotonProyecto);
            }
        }
        private void agregarHistoriasDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoProyectoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close(); 
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

        public void CargarReleases_click(Object sender, System.EventArgs e)
        {
            label1.Text = "Seleccione un Release o una opción válida para continuar";
            
            Button B = (Button)sender;
            String NumeroBoton = B.Name;
            NumeroBoton = NumeroBoton.Remove(0,5);
            int ID_Boton = Convert.ToInt32(NumeroBoton);

            DataRow ID_Proyecto = Proyectos.Tables[0].Rows[ID_Boton];
            idProyecto = Convert.ToInt32(ID_Proyecto["id"].ToString());

            DataSet Releases = ConexionMetodos.CargarReleases(idProyecto);
            CrearBotones(panel2, Releases);
            
            panel2.Visible = true;
            panel1.Visible = false;

            BotonAtras.Enabled = true;
        }

        public void CargarSprints_click(Object sender, System.EventArgs e)
        {
            MessageBox.Show("Si funciona");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        }

        private void userStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Index_UserStory indexUser = new Index_UserStory(idProyecto);
            indexUser.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Identificacion CerrarSesion = new Identificacion();
            this.Close();
            CerrarSesion.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (panel2.Visible == true) 
            {
                CargarPanelAnterior(panel2);
                label1.Text = "Seleccione un Proyecto o una opción válida para continuar";
                BotonAtras.Enabled = false;
                panel2.Visible = false;
                panel1.Visible = true;
            }
            /*
            else if (panel3.Visible == true)
            {
                label1.Text = "Seleccione un Release o una opción válida para continuar";
                panel3.Visible = false;
                panel2.Visible = true;
            }

            else if (panel4.Visible == true)
            {
                label1.Text = "Seleccione un Sprint o una opción válida para continuar";
                panel4.Visible = false;
                panel3.Visible = true;
            }
            */
        }


        public void CargarPanelAnterior(Panel panelActual)
        {
            while (panelActual.Controls.Count > 1)
            {   
                foreach (Control item in panelActual.Controls)
                {
                    if (item.Name.Substring(0, 5) == "Boton") { panelActual.Controls.Remove(item); }
                }
            }
        }

    }
}
