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
    public partial class AsociarUserASprint : Form
    {
        int idSprint;
        List<String> listaSeleccionados = new List<String>();
        List<int> listaSeleccionadosID = new List<int>();
        List<String> listaUserS = new List<String>();
        List<int> listaUserID = new List<int>();
        public AsociarUserASprint(int idSprintP)
        {
            idSprint=idSprintP;
            InitializeComponent();
            panel1.AutoScroll = true;
            listaUserS = ConexionMetodos.GetListaUserSNombre(idSprint);
            listaUserID = ConexionMetodos.GetListaUserSId(idSprint);
            Button btn;
            //int colum = 15;
            int j = 0;
            int i = 0;
            int nombre = 0;
            for (j = 0; j < listaUserS.Count; j++)
            {
               btn = new Button();
               nombre += 1;
               btn.Name = "E" + listaUserID.ElementAt(j);
               btn.Text = listaUserS.ElementAt(j);
               btn.Location = new System.Drawing.Point(88 * (j%6), 50 * (i%6));
               btn.Size = new System.Drawing.Size(88, 50);
               btn.Click += new EventHandler(button_Click);
               btn.BackColor = Color.LightGray;
               panel1.Controls.Add(btn);
               if ((j%6) == 5) i++;
            }
        }

        protected void button_Click (object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (listaSeleccionados.Contains(button.Name) == false)
            {
                button.BackColor = Color.LightGreen;
                listaSeleccionados.Add(button.Name);
            }
            else 
            {
                button.BackColor = Color.LightGray;
                listaSeleccionados.RemoveAt(listaSeleccionados.IndexOf(button.Name));
            }
        }

        private void lblCrea_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            int q;
            for (q = 0; q < listaSeleccionados.Count; q++)
            {
                listaSeleccionadosID.Add(Convert.ToInt32(listaSeleccionados.ElementAt(q).Replace("E", "")));
            }
           
            bool verificador = true;
            int j;
            for (j = 0; j < listaSeleccionadosID.Count; j++)
            {
                if (ConexionMetodos.AsociaUser(idSprint, listaSeleccionadosID.ElementAt(j)) == -1) { verificador = false; }
                else { verificador = true; }
            }
           
            if (verificador)
            {
                MessageBox.Show("Usuario Creado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
