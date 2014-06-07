﻿using System;
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
        public Principal(int rolP,int idUsuarioP)
        {
            InitializeComponent();
            rol =rolP;
            idUsuario = idUsuarioP;
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
            DataSet Proyectos = ConexionMetodos.CargarProyectosxUsuario(idUsuario);

            listBox1.DataSource = Proyectos.Tables[0].DefaultView;
            listBox1.ValueMember = "Nombre";

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AsociarUserASprint ventana = new AsociarUserASprint(1);
            //ventana.ShowDialog();
        }
    }
}
