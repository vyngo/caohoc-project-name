using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.common
{
    class QuadraticRegression
    {
        public static double[] regress(double[] x, double[] y)
        {
            if (x.Count() != y.Count())
            {
                return null;
            }
            double[] ret = new double[4];
            double[,] A = new double[3, 4];
            A[0, 0] = getSize(x);
            A[0, 1] = sumX(x);
            A[0, 2] = sumX2(x);
            A[0, 3] = sumX(y);

            A[1, 0] = A[0, 1];
            A[1, 1] = A[0, 2];
            A[1, 2] = sumX3(x);
            A[1, 3] = sumXY(x, y);

            A[2, 0] = A[0, 2];
            A[2, 1] = A[1, 2];
            A[2, 2] = sumX4(x);
            A[2, 3] = sumX2Y(x, y);

            double[] b = GaussElimination.gauss(A);
            for (int i = 0; i < 3; i++)
            {
                ret[i] = b[i];
            }
            double err = calculateError(b, x, y);
            ret[3] = err;
            return ret;
        }

        private static double calculateError(double[] b, double[] x, double[] y)
        {
            double error = 0.0;
            for (int i = 0; i < x.Count(); i++)
            {
                double tmp = (b[0] + b[1] * x[i] + b[2] * x[i] * x[i]) - y[i];
                tmp = tmp * tmp;
                error += tmp;
            }
            return error;
        }

        private static double sumX(double[] x)
        {
            double ret = 0.0;
            for (int i = 0; i < x.Count(); i++)
            {
                ret += x[i];
            }
            return ret;
        }

        private static double sumX2(double[] x)
        {
            double ret = 0.0;
            for (int i = 0; i < x.Count(); i++)
            {
                ret += x[i] * x[i];
            }
            return ret;
        }

        private static double sumX3(double[] x)
        {
            double ret = 0.0;
            for (int i = 0; i < x.Count(); i++)
            {
                ret += x[i] * x[i] * x[i];
            }
            return ret;
        }

        private static double sumX4(double[] x)
        {
            double ret = 0.0;
            for (int i = 0; i < x.Count(); i++)
            {
                ret += x[i] * x[i] * x[i] * x[i];
            }
            return ret;
        }

        private static double sumXY(double[] x, double[] y)
        {
            double ret = 0.0;
            for (int i = 0; i < y.Count(); i++)
            {
                ret += x[i] * y[i];
            }
            return ret;
        }

        private static double sumX2Y(double[] x, double[] y)
        {
            double ret = 0.0;
            for (int i = 0; i < y.Count(); i++)
            {
                ret += x[i] * x[i] * y[i];
            }
            return ret;
        }

        private static int getSize(double[] x)
        {
            return x.Count();
        }
    }
}
