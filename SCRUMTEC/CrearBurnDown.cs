using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SCRUMTEC
{
    public partial class CrearBurnDown : Form
    {
        private Chart chart2;
        int TotalHoras,idProyecto;
        public CrearBurnDown()//Ocupa el id del proyecto (idProyectoP)
        {
            //idProyecto = idProyectoP;
            //TotalHoras = ConexionMetodos.GetTotalHoras(idProyecto);
            TotalHoras = 30;
            InitializeComponent();
            CrearGraficoHoras(TotalHoras);
            this.Controls.Add(this.chart2);   //Se agrega a la ventana el grafico
        }

        private void CrearGraficoTareas() { } // Haciendo el de horas sale casi igual
        private void CrearGraficoHoras(int TotalHoras)
        {
            // Para este hay que fijar en la tabla HistorialEsfuerzo que es la nueva y hacer ahi analisis de los datos.

            // Datos que se insertan en el grafico
            int totalEspacios = 11;
            int horastemp = TotalHoras / (totalEspacios - 1);
            int[] yTotalHoras = new int[totalEspacios];
            int[] xTotalHoras = new int[totalEspacios];
            int j = 0;
            for (int i = (totalEspacios - 2); i >= -1; i--)
            {
                yTotalHoras.SetValue(horastemp * (i + 1), j);
                xTotalHoras.SetValue(horastemp * (i + 1), i + 1);
                j++;
            }

            Array xHorasInvertidas = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Array yHorasInvertidas = new[] { 29, 28, 28, 28, 28, 28, 28, 23, 21 };
            
            /*var xvals = new[]
                {
                    new DateTime(2012, 4, 4), 
                    new DateTime(2012, 4, 5), 
                    new DateTime(2012, 4, 6), 
                    new DateTime(2012, 4, 7)
                }; */

            //Informacion y caracteristicas basica del grafico
            var chart = new Chart();
            chart.Size = new Size(600, 250);
            var chartArea = new ChartArea();
            //chartArea.AxisX.LabelStyle.Format = //"dd/MMM\nhh:mm";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea.AxisY.Title = "Suma de Horas Estimadas";
            chartArea.AxisX.Title = "Linea de vida de las Iteraciones";
            chart.ChartAreas.Add(chartArea);

            // Informacion basica de las lineas
            var series = new Series();
            series.Name = "Series1";
            series.ChartType = SeriesChartType.FastLine;
            chart.Series.Add(series);


            var series2 = new Series();
            series2.Name = "Series2";
            series2.ChartType = SeriesChartType.FastLine;
            series2.XValueType = ChartValueType.DateTime;
            chart.Series.Add(series2);

            // Crear las lineas segun lo que se hizo (tareas hechas/horas trabajadas)
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.Series["Series1"].Points.DataBindXY(xTotalHoras, yTotalHoras);
            chart.Series["Series2"].Points.DataBindXY(xHorasInvertidas, yHorasInvertidas);

            chart.Invalidate(); //Crea el grafico
            chart.SaveImage("chart.png", ChartImageFormat.Png); // Lo guarda en un archivo
            chart2 = chart; //Lo asigna a la variable global para mostrarlo en la pantala

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
