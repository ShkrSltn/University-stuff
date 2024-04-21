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

namespace Lab1
{
    public partial class Form1 : Form
    {
        Chart chart;
        ChartArea area;
        Series series;

        Color color;

        private double XMin = -4;
        private double XMax = 4;
        private double Step = 4.0/10.0;

        private double[] x;
        private double[] y;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Creat();

            CalcFunction();

            chart.Series[0].Points.DataBindXY(x, y);
        }

        private void Creat()
        {
            chart = new Chart();
            chart.Parent = this;
            chart.SetBounds(10, 10, ClientSize.Width - 300, ClientSize.Height - 20);

            area = new ChartArea();
            area.Name = "Lab1";
            area.AxisX.Minimum = XMin;
            area.AxisX.Maximum = XMax;
            area.AxisX.MajorGrid.Interval = Step;
            chart.ChartAreas.Add(area);

            series = new Series();
            series.ChartArea = "Lab1";
            series.ChartType = SeriesChartType.Spline;
            series.BorderWidth = 3;
            chart.Series.Add(series);
            series.LegendText = "y=(ln⁡(sin⁡(x^3+0.0025) ) )^(3⁄2)+0.8∙〖10〗^(-3)";

            Legend legend = new Legend();
            chart.Legends.Add(legend);
        }

        private void CalcFunction()
        {
            int count = (int)Math.Ceiling((XMax - XMin) / Step)+1;
            x = new double[count];
            y = new double[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = XMin + Step * i;
                y[i] = Math.Pow(Math.Log(Math.Sin(Math.Pow(x[i],3)+0.0025), Math.E),3/2)+0.8*Math.Pow(10,-3);
            }
        }

        private void Color_Click(object sender, EventArgs e)
        {
            Button colorB = (Button)sender;
            series.Color = colorB.BackColor;
            color = this.BackColor;
        }

        private void Click_BT_1(object sender, EventArgs e)
        {
            XMin = Convert.ToDouble(RTB_1.Text);
            XMax = Convert.ToDouble(RTB_2.Text);
            Step = XMax / 10;
            series.BorderWidth = Convert.ToInt16(RTB_3.Text);
            CalcFunction();
            area.AxisX.Minimum = XMin;
            area.AxisX.Maximum = XMax;
            chart.Series[0].Points.DataBindXY(x, y);
        }
    }
}