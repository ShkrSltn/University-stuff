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

namespace Lab_2_Contour
{
    public partial class Form1 : Form
    {
        private double XMin = -4;
        private double XMax = 4;
        private double Step = 0.01;
        private double ZMin = -1;
        private double ZMax = 1;
        private double ZStep = 0.5;
        private int widch = 3;

        private double[] x;
        private double[] y;
        public Form1()
        {
            InitializeComponent();
        }

        private void Creat(Chart chart)
        {
            chart = new Chart();
            chart.Parent = this;
            chart.SetBounds(10, 10, ClientSize.Width - 300, ClientSize.Height - 20);

            ChartArea area = new ChartArea();
            area.Name = "Lab1";
            area.AxisX.Minimum = XMin;
            area.AxisX.Maximum = XMax;
            area.AxisX.MajorGrid.Interval = Step;
            chart.ChartAreas.Add(area);
 
            int count = (int)Math.Ceiling((ZMax - ZMin) / ZStep);
            Series[] series = new Series[count];
            for (int i = 0;i<count;i++)
            {
                series[i] = new Series();
                series[i].ChartArea = "Lab1";
                series[i].ChartType = SeriesChartType.Spline;
                series[i].BorderWidth = widch;
                chart.Series.Add(series[i]);
                series[i].LegendText = Convert.ToString(ZMin+ZStep*i);
                CalcFunction(ZMin + ZStep * i);
                chart.Series[i].Points.DataBindXY(x, y);
            }
            Legend legend = new Legend();
            chart.Legends.Add(legend);
        }
        private void CalcFunction(double z)
        {
            int count = (int)Math.Ceiling((XMax - XMin) / Step) + 1;
            List<double> X = new List<double>();
            List<double> Y = new List<double>();
            double x1;
            double y1;
            for (int i = 0; i < count; i++)
            {
                x1 = XMin + Step * i;
                y1 = 2 - Math.Pow(x1, 2) + z;
                if (y1>=0)
                {
                    X.Add(x1);
                    Y.Add(Math.Sqrt(y1));
                }
            }
            for (int i = X.Count-1; i>-1; i--)
            {
                X.Add(X.ElementAt(i));
                Y.Add(-Y.ElementAt(i));
            }
            X.Add(X.ElementAt(0));
            Y.Add(Y.ElementAt(0));

            x = X.ToArray();
            y = Y.ToArray();
        }

        private void Click_BT_1(object sender, EventArgs e)
        {
            XMax = Convert.ToDouble(RTB_xmax.Text);
            XMin = Convert.ToDouble(RTB_xmin.Text);
            XMax = Convert.ToDouble(RTB_xmax.Text);
            ZMax = Convert.ToDouble(RTB_zmax.Text);
            ZMin = Convert.ToDouble(RTB_zmin.Text);
            ZStep = Convert.ToDouble(RTB_step.Text);
            widch = Convert.ToInt16(RTB_widch.Text);

            Creat(new Chart());
        }
    }
}
