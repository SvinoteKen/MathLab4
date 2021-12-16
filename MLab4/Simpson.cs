using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLab4
{
    class Simpson
    {
        static double func(double x)
        {
            return Math.Log(Math.Sin(Math.Abs(x)));
        }
        static double integral(double x1, double x2) 
        {
            double h;
            h = x2 - x1;
            return h / 6 * (func(x1) + 4 * func(x1 + h / 2) + func(x2));
        }
        static bool isCorrectByRunge(double Ihi, double Ih2i, double epsilon) 
        {
            return (Math.Abs(Ihi - Ih2i) / 15) < epsilon;
        }
        static double partial(double a, double b, double h) 
        {
            double result = 0;
            double i = a;
            while (i < b) {
                result += integral(i, i + h);
                i += h; 
            }
            return result;
        }
        public double Simpsons_(double a,double b,double epsilon,int step)
        {
            double minH = 0.001;
            List<double> partitions = new List<double>();
            partitions.Add(a);
            double result = 0;
            double h = 0;
            h = (b - a) / step;
            for (int i = 0; i < step; i++) 
            {
                double fromt = a + h * i;
                double partialWithBigH = partial(fromt, fromt + h, h);
                double partialWithSmallH;
                double hDecreased = h;
                while (true)
                {
                    bool needToDecreaseH;
                    partialWithSmallH = partial(fromt, fromt + h, hDecreased / 2);
                    if (isCorrectByRunge(partialWithBigH, partialWithSmallH, epsilon) == false && (hDecreased > minH))
                    {
                        needToDecreaseH = true;
                    }
                    else
                    {
                        needToDecreaseH = false;
                    }
                    if (needToDecreaseH) {
                        hDecreased /= 2;
                    }
                    else
                    {
                        break;
                    }
                }
                result += Math.Abs(partialWithSmallH);
                double k = hDecreased;
                while (k <= h)
                {
                    partitions.Add(fromt + k);
                    k += hDecreased;
                }
            }
            MessageBox.Show("Число разбиений: " + partitions.Count().ToString());
            return result;
        }
    }
}
