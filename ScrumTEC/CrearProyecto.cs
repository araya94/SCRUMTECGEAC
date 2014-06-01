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
    public partial class CrearProyecto : Form
    {
        public CrearProyecto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_cancelarCrearProyecto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_CrearProyecto_Click(object sender, EventArgs e)
        {

            String nombre_proyecto = this.textBox_nombreProyecto.Text.Trim(); //Elimina los espacios en blanco del principio y el final
            String descripcion_proyecto = this.textBox_descripcionProyecto.Text.Trim();

            if (validarNombreProyecto(nombre_proyecto)){
                if (validarNombreUnicoProyecto(nombre_proyecto)) { }
                
                this.Close(); }
            
            
        }

        //Valida que el nombre del proyecto introducido sea valido:
        //La extención del nombre este entre 5 y 25
        //No exista un proyecto con el mismo nombre 
        private Boolean validarNombreProyecto(String nombre_proyecto)
        {
            //Verificar extención del string 
            if (nombre_proyecto.Length >= 5 & nombre_proyecto.Length <= 25) { return true; }

            else
                return false;
        }

        private Boolean validarNombreUnicoProyecto(String nombre_unico){

            return false;
        }
    }
}
