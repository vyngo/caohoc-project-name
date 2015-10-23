using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.common
{
    class Utils
    {
        public static double max(double[] a) {
        double ret = double.MinValue;
        foreach (double d in a) {
            if (d > ret) {
                ret = d;
            }
        }
        return ret;
    }

        public static double min(double[] a) {
        double ret = double.MaxValue;
        foreach (double d in a) {
            if (d < ret) {
                ret = d;
            }
        }
        return ret;
    }
    }
}
