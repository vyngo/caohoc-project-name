using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.common
{
    class Normalize
    {
        ///--------------Min Max---------------------------
        public static double[] MinMax(double[] input, double newMin, double newMax, int lengthTimeSeriesSelect)
        {
            double[] result = new double[lengthTimeSeriesSelect];
            double min = input.Min();
            double max = input.Max();
            for (int i = 0; i < lengthTimeSeriesSelect; i++)
            {
                result[i] = ((input[i] - min) * (newMax - newMin)) / (max - min) + newMin;
            }
            return result;
        }

        public static double[] ZeroMin(double[] input, int lengthTimeSeriesSelect)
        {
            double[] result = new double[lengthTimeSeriesSelect];
            for (int i = 0; i < lengthTimeSeriesSelect; i++)
                result[i] = input[i];
            double avgInput = result.Average();
            double variance = 0.0;     
            for (int i = 0; i < lengthTimeSeriesSelect; i++)
            {
                variance += Math.Pow((result[i] - avgInput), 2);
            }
            variance = variance / result.Length;
            double standardDeviation = Math.Sqrt(variance); 

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (result[i] - avgInput) / standardDeviation;
            }
            return result;
        }
    }
}
