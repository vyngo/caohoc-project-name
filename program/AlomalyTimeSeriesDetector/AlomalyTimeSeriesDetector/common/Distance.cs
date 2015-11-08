using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.common
{
    class Distance
    {
        public static double distance(double[] a, double[] b)
        {
            if (a.Length == b.Length)
            {
                return euclid(a, b);
            }
            else if (a.Length > b.Length)
            {
                double[] tmp = homothetic(a, b.Length);
                return euclid(b, tmp);
            }
            else
            {
                double[] tmp = homothetic(b, a.Length);
                return euclid(a, tmp);
            }
        }



        private static double euclid(double[] a, double[] b)
        {
            double ret = 0.0;
            double beta = 0.0;
            for (int i = 0; i < a.Length; i++)
            {
                beta += (b[i] - a[i]);
            }
            beta = beta / a.Length;
            for (int i = 0; i < a.Length; i++)
            {
                double tmp = (a[i] - b[i] - beta) * (a[i] - b[i] - beta);
                ret += tmp;
            }
            return Math.Sqrt(ret);
        }

        private static double[] homothetic(double[] data, int length)
        { // length must be smaller than or equal to data.length
            double[] ret = new double[length];
            double y_max = Utils.max(data);
            double y_min = Utils.min(data);
            double x_center = (double)(data.Length / 2);
            double y_center = (y_max + y_min) / 2.0;
            double ratio = (length * 1.0) / (data.Length * 1.0);
            double X, Y;// data after homothetic
            double x, y;// original data
            int index = 0;
            for (X = (-(length / 2)) + x_center; X < (length / 2) + x_center; X++)
            {
                x = (X - x_center) / ratio + x_center;
                int round_x = ((int)x);
                if (round_x >= data.Length - 1)
                {
                    y = -(x - round_x) * data[round_x - 1] + (-round_x + 1 + x) * data[round_x];
                   
                }
                else
                {
                    y = (x - round_x) * data[round_x + 1] + (round_x + 1 - x) * data[round_x];
                }
                Y = (y - y_center) * ratio + y_center;
                ret[index] = Y;
                index++;
            }
            return ret;
        }
    }
}
