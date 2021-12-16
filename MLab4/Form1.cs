using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MLab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            List<double> ys = new List<double>();
            InitializeComponent();
            Simpson s = new Simpson();
            double re = s.Simpsons_(Math.PI/6, Math.PI/2, 0.002, 20);
            MessageBox.Show("Значение интеграла: " +re.ToString());
            var x = Generate.LinearSpaced(20, Math.PI/6, Math.PI/2);
            for (int i = 0; i < x.Length; i++) 
            {
                ys.Add(Math.Log(Math.Sin(Math.Abs(x[i]))));
                formsPlot1.Plot.AddVerticalLine(x[i], Color.Red, 1, ScottPlot.LineStyle.Solid);
            }
            formsPlot1.Plot.PlotScatter(x ,ys:ys.ToArray(),color: Color.Blue,markerSize: 5,label: "interpolation");
        }
    }
}
