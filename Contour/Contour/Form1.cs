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

namespace Contour
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Массив значений x
        private double[] x;
        private double[] xpol;


        // Для массива Y
        private double[] y;
        private double[] ypol;

        // Для массива Y
        private double[] z;
        /// Левая граница графика
        private double XMin;

        /// Правая граница графика
        private double XMax;
        private double ZMin;

        private double ZMax;


        /// Шаг графика
        private double Step=0.2;
        private double zStep;


        void CreateChart()
        {
            // Создаём новую область для построения графика
            ChartArea area = new ChartArea();
            // Даём ей имя (чтобы потом добавлять графики)
            area.Name = "myGraph";
            // Задаём левую и правую границы оси X
            area.AxisX.Minimum = XMin;
            area.AxisX.Maximum = XMax;

            // Определяем шаг сетки
            area.AxisX.MajorGrid.Interval = Step;
            // Добавляем область в диаграмму
            Graphic.ChartAreas.Add(area);
            Graphic.Titles.Add("f(x,z)=  arcsin(z/sin(x))");
            // Создаём легенду, которая будет показывать названия
            Legend legend = new Legend();
            Graphic.Legends.Add(legend);
        }

        void CreateSeries()
        {
            // Создаём объект графика
            Series series = new Series();
            // Ссылаемся на область для построения графика
            series.ChartArea = "myGraph";
            // Задаём тип графика 
            series.ChartType = SeriesChartType.Line;
            // Указываем ширину линии графика
            series.BorderWidth = Convert.ToInt32(textBox2.Text);
            series.MarkerStyle = MarkerStyle.Circle;
    
            Graphic.Series.Add(series);


          
        }
        void CalcFunction(double z)
        {
            // Количество точек графика
            int count = (int)Math.Ceiling((XMax - XMin) / Step)
                        + 1;
            // Создаём массивы нужных размеров
            xpol = new double[count];
            ypol = new double[count];
            x = new double[2*count];
            y = new double[2 * count];

            // Расчитываем точки для графиков функции
            for (int i = 0; i < count; i++)
            {
                // Вычисляем значение X
                x[i] = XMin + Step * i;
                xpol[i] = XMin + Step * i;

                // Вычисляем значение
                y[i] = Math.Acos(z / Math.Sin(x[i]));
                ypol[i] = Math.Acos(z / Math.Sin(x[i]));


            }
            double[] xneg = Transform(xpol);
            double[] yneg = Transform(ypol);


            for (int k = count; k < 2*count; k++)
            {
                // Вычисляем значение X
                x[k] = xneg[k-count];
                // Вычисляем значение функций в точке 
                y[k] = -yneg[k-count];
              


            }
         
        }

        public static double[] Transform(double[] a){
            double[] temp = new double[a.Length];
            for(int i=0; i<a.Length; i++)
            {
                temp[i] = a[a.Length - 1 - i];
            }
            return temp;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void build_Click(object sender, EventArgs e)
        {
            Graphic.Titles.Clear();
            Graphic.ChartAreas.Clear();
            Graphic.Series.Clear();
            Graphic.Legends.Clear();
            
            XMin = Convert.ToDouble(x0.Text);
            XMax = Convert.ToDouble(xn.Text);
            ZMin = Convert.ToDouble(z0.Text);
            ZMax = Convert.ToDouble(zn.Text);
            zStep = Convert.ToDouble(zstep.Text);
            int zCount = (int)Math.Ceiling((ZMax - ZMin) / zStep) + 1;
            z = new double[zCount];
            CreateChart();
            for (int c = 0; c < zCount; c++)
            {
                z[c] = ZMin + zStep * c;
                CreateSeries();
                CalcFunction(z[c]);
                Graphic.Series[c].Points.DataBindXY(x, y);
                z[c] = ZMin + zStep * c;
                Graphic.Series[c].LegendText = "z = " + z[c] + ";";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Graphic_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
