using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector.common
{
    class Utils
    {
        public static double max(double[] a)
        {
            double ret = double.MinValue;
            foreach (double d in a)
            {
                if (d > ret)
                {
                    ret = d;
                }
            }
            return ret;
        }

        public static double min(double[] a)
        {
            double ret = double.MaxValue;
            foreach (double d in a)
            {
                if (d < ret)
                {
                    ret = d;
                }
            }
            return ret;
        }
        public static double median(List<double> s)
        {
            List<double> a = s.OrderBy(d => d).ToList();
            int size = a.Count;
            int mid = size / 2;
            return a[mid];
        }

        public static bool isOverLap(NSubsequence n1, NSubsequence n2) {
            bool e1 = n1.getStart() >= n2.getStart() && n1.getStart() <= n2.getEnd();
            bool e2 = n2.getStart() >= n1.getStart() && n2.getStart() <= n1.getEnd();
            return e1 || e2;
        }
    }
}
