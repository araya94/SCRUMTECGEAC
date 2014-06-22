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
    public partial class frmAgregarTarea : Form
    {
        int idUserStory;
        public frmAgregarTarea(int ID_UserStory)
        {
            idUserStory = ID_UserStory;
            InitializeComponent();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int duracion = 0;
            if (cmbDuracion.SelectedIndex == 0)
            {
                duracion = 1;
            }
            else if(cmbDuracion.SelectedIndex == 1)
            {
                duracion = 2;
            }
            else if (cmbDuracion.SelectedIndex == 2)
            {
                duracion = 4;
            }
            else if (cmbDuracion.SelectedIndex == 3)
            {
                duracion = 8;
            }
            else if (cmbDuracion.SelectedIndex == 4)
            {
                duracion = 16;
            }
            else if (cmbDuracion.SelectedIndex == 5)
            {
                duracion = 24;
            }
            else if (cmbDuracion.SelectedIndex == 6)
            {
                duracion = 48;
            }
            else if (cmbDuracion.SelectedIndex == 7)
            {
                duracion = 96;
            }
            else if (cmbDuracion.SelectedIndex == 8)
            {
                duracion = 192;
            }
            else if (cmbDuracion.SelectedIndex == 9)
            {
                duracion = 384;
            }
            else if (cmbDuracion.SelectedIndex == 10)
            {
                duracion = 720;
            }
            else if (cmbDuracion.SelectedIndex == 11)
            {
                duracion = 1440;
            }
            else if (cmbDuracion.SelectedIndex == 12)
            {
                duracion = 2880;
            }
            ConexionMetodos.insertarTarea(idUserStory, txtNombreTarea.Text, rtxtDescripcion.Text, duracion,0);
            MessageBox.Show("Tarea creadada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            frmAgregarTarea agregar = new frmAgregarTarea(idUserStory);
            agregar.Show();
        }

        private void frmAgregarTarea_Load(object sender, EventArgs e)
        {
            cmbDuracion.Items.Add("1 Hora");
            cmbDuracion.Items.Add("2 Horas");
            cmbDuracion.Items.Add("4 Horas");
            cmbDuracion.Items.Add("8 Horas");
            cmbDuracion.Items.Add("16 Horas");
            cmbDuracion.Items.Add("1 Dia");
            cmbDuracion.Items.Add("2 Dia");
            cmbDuracion.Items.Add("4 Dia");
            cmbDuracion.Items.Add("8 Dias");
            cmbDuracion.Items.Add("16 Dias");
            cmbDuracion.Items.Add("1 Mes");
            cmbDuracion.Items.Add("2 Meses");
            cmbDuracion.Items.Add("4 Meses");
            cmbDuracion.Items.Add("8 Meses");

            cmbDuracion.SelectedIndex = 0;
        }
    }
}
