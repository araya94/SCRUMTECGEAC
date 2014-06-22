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
        int idRelease;
        int idSprint;
        int idUserStory;

        Button BotonProyecto;
        DataSet Proyectos;
        DataSet Releases;
        DataSet Sprints;


        public Principal(int rolP, int idUsuarioP)
        {

            InitializeComponent();
            rol = rolP;
            idUsuario = idUsuarioP;
            Proyectos = ConexionMetodos.CargarProyectosxUsuario(idUsuario);

            if (rol == 1)
            {
                userStoryToolStripMenuItem.Visible = false;
                releaseToolStripMenuItem.Visible = false;
                sprintToolStripMenuItem.Visible = false;
                userStoryToolStripMenuItem1.Visible = false;
                sprintToolStripMenuItem1.Visible = false;
                tareasToolStripMenuItem.Visible = false;
                definirDuraciónSprintToolStripMenuItem.Visible = false;
            }
            if (rol == 2)
            {
                nuevoProyectoToolStripMenuItem.Visible = false;
                crearUsuarioToolStripMenuItem.Visible = false;
                sprintToolStripMenuItem.Visible = false;
                userStoryToolStripMenuItem1.Visible = false;
                sprintToolStripMenuItem1.Visible = false;
                tareasToolStripMenuItem.Visible = false;
                definirDuraciónSprintToolStripMenuItem.Visible = false;
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
                definirDuraciónSprintToolStripMenuItem.Visible = false;
            }
            if (rol == 5)
            {
                nuevoProyectoToolStripMenuItem.Visible = false;
                crearUsuarioToolStripMenuItem.Visible = false;
                userStoryToolStripMenuItem.Visible = false;
                releaseToolStripMenuItem.Visible = false;
                definirDuraciónSprintToolStripMenuItem.Visible = false;
            }

            CrearBotones(panel1, Proyectos);
            BotonAtras.Enabled = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;

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
                else if (panelActual.Name == "panel3") { BotonProyecto.Click += new System.EventHandler(CargarUserStory_click); }
                else if (panelActual.Name == "panel4") { BotonProyecto.Click += new System.EventHandler(CargarTareas_click); }
                panelActual.Controls.Add(BotonProyecto);
            }
        }

        private void agregarHistoriasDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoProyectoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            CrearProyecto ventana = new CrearProyecto(rol, idUsuario);
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
            else { panel1.Visible = true; panel2.Visible = false; }
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
            NumeroBoton = NumeroBoton.Remove(0, 5);
            int ID_Boton = Convert.ToInt32(NumeroBoton);

            DataRow ID_Proyecto = Proyectos.Tables[0].Rows[ID_Boton];
            idProyecto = Convert.ToInt32(ID_Proyecto["id"].ToString());

            Releases = ConexionMetodos.CargarReleases(idProyecto);
            CrearBotones(panel2, Releases);

            panel2.Visible = true;
            panel1.Visible = false;

            BotonAtras.Enabled = true;
        }

        public void CargarSprints_click(Object sender, System.EventArgs e)
        {

            label1.Text = "Seleccione un Sprint o una opción válida para continuar";

            Button B = (Button)sender;
            String NumeroBoton = B.Name;
            NumeroBoton = NumeroBoton.Remove(0, 5);
            int ID_Boton = Convert.ToInt32(NumeroBoton);

            DataRow ID_Release = Releases.Tables[0].Rows[ID_Boton];
            idRelease = Convert.ToInt32(ID_Release["id"].ToString());

            Sprints = ConexionMetodos.CargarSprints(idRelease);
            CrearBotones(panel3, Sprints);

            panel3.Visible = true;
            panel2.Visible = false;
        }

        public void CargarUserStory_click(Object sender, System.EventArgs e)
        {

            label1.Text = "Seleccione un UserStory o una opción válida para continuar";

            Button B = (Button)sender;
            String NumeroBoton = B.Name;
            NumeroBoton = NumeroBoton.Remove(0, 5);
            int ID_Boton = Convert.ToInt32(NumeroBoton);

            DataRow ID_Sprint = Sprints.Tables[0].Rows[ID_Boton];
            idSprint = Convert.ToInt32(ID_Sprint["id"].ToString());

            DataSet UserStories = ConexionMetodos.CargarUserStories(idSprint);
            CrearBotones(panel4, UserStories);

            panel4.Visible = true;
            panel3.Visible = false;
        }



        public void CargarTareas_click(Object sender, System.EventArgs e)
        {
            label1.Text = "Seleccione una Tarea o una opción válida para continuar";
            panel5.Visible = true;
            panel4.Visible = false;
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
            Index_UserStory indexUser = new Index_UserStory(idProyecto, rol);
            indexUser.Show();
        }

        private void userStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            else if (panel3.Visible == true)
            {
                CargarPanelAnterior(panel3);
                label1.Text = "Seleccione un Release o una opción válida para continuar";
                panel3.Visible = false;
                panel2.Visible = true;
            }

            else if (panel4.Visible == true)
            {
                CargarPanelAnterior(panel4);
                label1.Text = "Seleccione un Sprint o una opción válida para continuar";
                panel4.Visible = false;
                panel3.Visible = true;
            }

            else if (panel5.Visible == true)
            {
                CargarPanelAnterior(panel5);
                label1.Text = "Seleccione un User Story o una opción válida para continuar";
                panel5.Visible = false;
                panel4.Visible = true;
            }
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

        private void nuevoReleaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoRelease NuevoRelease = new NuevoRelease(idProyecto);
            NuevoRelease.Show();
        }

        private void nuevoSprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefinirSprints NuevoSprint = new DefinirSprints(idRelease);
            NuevoSprint.Show();
        }

        private void definirDuraciónSprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void definirDuraciónSprintToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DefinirDuracionSprint NuevaDuracion = new DefinirDuracionSprint(idProyecto);
            NuevaDuracion.Show();
        }

    }
}