using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.common
{
    class PAA
    {
        public static double[] run(double[] C, int w)
        {
            double[] D;
            int q = 0;
            int k = 0;
            int count = 0;
            double sum = 0;
            double sum2 = 0;
            if (C.Length % w == 0)
            {
                q = Convert.ToInt32(C.Length / w);
                D = new double[q];
                for (int i = 0; i < C.Length; i += w)
                {
                    for (int j = i; j < i + w; j++)
                    {
                        sum = sum + C[j];
                    }
                    D[k] = sum / w;
                    sum = 0;
                    k++;
                }
            }
            else
            {
                q = Convert.ToInt32((C.Length / w) + 1);
                D = new double[q];
                for (int i = 0; i < C.Length - w; i += w)
                {
                    for (int j = i; j < i + w; j++)
                    {
                        sum = sum + C[j];
                    }
                    D[k] = sum / w;
                    sum = 0;
                    k++;
                }
                for (int i = (q - 1) * w; i < C.Length; i++)
                {
                    sum2 = sum2 + C[i];
                    count++;
                }
                D[k] = sum2 / count;
            }
            return D;
        }
        //--------------------------------------------------------------------------------
    }
}
