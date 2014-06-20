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
    public partial class frmEditarUserStory : Form
    {
        int ID_UserStory;
        int ID_Proyecto;
        int rol;
        public frmEditarUserStory(int id, int id_proyecto, int rol)
        {
            this.ID_UserStory = id;
            this.ID_Proyecto = id_proyecto;
            InitializeComponent();
            if (rol == 2)
            {
                btnAgregar_Tarea.Enabled = false;
                btnModificar_Tarea.Enabled = false;
                btnEliminar_Tarea.Enabled = false;

                btnAgregar_Criterios.Enabled = false;
                btnModificar_Criterio.Enabled = false;
                btnEliminar_Criterios.Enabled = false;
                
            }

            if (rol == 3 || rol ==4)
            {
                txtNombreUserStorie.Enabled=false;
                cmbPrioridad.Enabled = false;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;

            }
        }

        private void btnAgregar_Criterios_Click(object sender, EventArgs e)
        {
            frmAgregarCriterio agregar_criterio = new frmAgregarCriterio();
            agregar_criterio.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
            string nombre = txtNombreUserStorie.Text;
            string prioridad = "";
            if (cmbPrioridad.SelectedIndex != -1)
            {
                prioridad = cmbPrioridad.SelectedItem.ToString();
            }
            //acualizar User Storie(int id,String nombre, String prioridad);
            if (ConexionMetodos.actualizarUserStorie(ID_UserStory, nombre, prioridad) > 0)
            {
                MessageBox.Show("User Storie Actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Index_UserStory index = new Index_UserStory(ID_Proyecto, rol);
                index.Show();
                    
                //this.Dispose();
                //MenuPrincipal Menu = new MenuPrincipal();
                //Menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error,intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditarUserStory_Load(object sender, EventArgs e)
        {
            cmbPrioridad.Items.Add("Alta");
            cmbPrioridad.Items.Add("Media");
            cmbPrioridad.Items.Add("Baja");

            ConexionMetodos con = new ConexionMetodos();
            UserStory userstory = con.obtenerUserStory_x_ID(ID_UserStory);

            txtNombreUserStorie.Text = userstory.nombre;
            cmbPrioridad.SelectedItem = userstory.prioridad;

            DataSet Tareas = ConexionMetodos.obtenerTarea_x_UserStory(ID_UserStory);


            lstTareas.DataSource = Tareas.Tables[0].DefaultView;

            lstTareas.ValueMember = "Nombre";
            lstTareas.ValueMember = "id";

            DataSet Criterios = ConexionMetodos.obtenerTarea_x_UserStory(ID_UserStory);

            lstCriterios.DataSource = Criterios.Tables[0].DefaultView;
            lstCriterios.ValueMember = "Nombre";
            
        }

        private void btnAgregar_Tarea_Click(object sender, EventArgs e)
        {
            frmAgregarTarea agregar_tarea = new frmAgregarTarea();
            agregar_tarea.Show();
            
        }
    }
}
