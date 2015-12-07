using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.common
{
    class DTWDistance
    {
        public double Distance(double[] t1, double[] t2)
        {
                return Dtw(t1, t2);
                //ParallelDTW(t1, t2);
            
        }
        
        public double Dtw(double[] t1, double[] t2)
        {
            return SimpleDtw(t1, t2);
        }

        private double SimpleDtw(double[] _x, double[] _y)
        {
            double v;
            double[,] f = new double[_x.Length, _y.Length];
            Pos[,] path = new Pos[_x.Length, _y.Length];
            for (int i = 0; i < _x.Length; i++)
            {
                for (int j = 0; j < _y.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        f[i, j] = (_x[i] - _y[j]) * (_x[i] - _y[j]);
                    }
                    else if (i == 0 && j > 0)
                    {
                        f[i, j] = (_x[i] - _y[j]) * (_x[i] - _y[j]) + f[i, j - 1];
                        path[i, j].x = i;
                        path[i, j].y = j - 1;
                    }
                    else if (j == 0 && i > 0)
                    {
                        f[i, j] = (_x[i] - _y[j]) * (_x[i] - _y[j]) + f[i - 1, j];
                        path[i, j].x = i - 1;
                        path[i, j].y = j;
                    }
                    else
                    {
                        f[i, j] = (_x[i] - _y[j]) * (_x[i] - _y[j]);
                        // calculate previous pos
                        path[i, j].x = i - 1;
                        path[i, j].y = j - 1;
                        v = f[i - 1, j - 1];
                        if (f[i - 1, j - 1] > f[i - 1, j])
                        {
                            path[i, j].x = i - 1;
                            path[i, j].y = j;
                            v = f[i - 1, j];
                            if (f[i - 1, j] > f[i, j - 1])
                            {
                                path[i, j].x = i;
                                path[i, j].y = j - 1;
                                v = f[i, j - 1];
                            }
                        }
                        else
                        {
                            if (f[i - 1, j - 1] > f[i, j - 1])
                            {
                                path[i, j].x = i;
                                path[i, j].y = j - 1;
                                v = f[i, j - 1];
                            }
                        }
                        f[i, j] = f[i, j] + v;
                        v = 0;
                    }
                }
            }
            //GetPath(path);
            double _sum = f[_x.Length - 1, _y.Length - 1];
            if (_sum != 0)
            {
                _sum = (float)Math.Sqrt(_sum);//_path.Count;
            }
            return _sum;
        }

        //speed up DTW

        private double getEuclid(double[] _x, int indx1, double[] _y, int indx2)
        {
            double result = 0;
            result = (_x[indx1] - _y[indx2]) * (_x[indx1] - _y[indx2]);
            return result;
        }

        private double ParallelDTW(double[] s1, double[] s2)
        {
            double[,] dist = new double[s1.Length, s2.Length];
            int numBlocks = Environment.ProcessorCount * 4;

            ParallelAlgorithms.Wavefront(s1.Length, s2.Length, numBlocks, numBlocks, (start_i, end_i, start_j, end_j) =>
            {
                for (int i = start_i; i < end_i; i++)
                {
                    for (int j = start_j; j < end_j; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            dist[i, j] = getEuclid(s1, i, s2, j);
                            continue;
                        }
                        else if (i == 0)
                        {
                            dist[i, j] = getEuclid(s1,i, s2,j) + dist[i, j - 1];
                        }
                        else if (j == 0)
                        {
                            dist[i, j] = getEuclid(s1, i, s2, j) + dist[i - 1, j];
                        }
                        else
                            dist[i, j] = getEuclid(s1, i, s2, j) +
                                Math.Min(dist[i - 1, j], Math.Min(dist[i, j - 1], dist[i - 1, j - 1]));
                    }
                }
            });
            double _sum = dist[s1.Length - 1, s2.Length - 1];
            if (_sum != 0)
            {
                _sum = (float)Math.Sqrt(_sum);
            }
            return _sum;
        }
    }

    public struct Pos
    {
        public int x; // time series x
        public int y; // time series y
        public float value; // distance of x and y
    }

}
