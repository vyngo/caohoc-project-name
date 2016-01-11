using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector.common
{
    class AnomalFactorCalculator
    {
        private RichTextBox log;
        private NTimeSeries series;

        public AnomalFactorCalculator(NTimeSeries series, RichTextBox log)
        {
            this.log = log;
            this.series = series;
        }
        public List<NSubsequence> anomalFactorCal(List<NSubsequence> candidates, int k, int delta)
        {
            this.println("ANOMAL FACTOR CALCULATE...");
            if (candidates != null && candidates.Count > 0)
            {
                int lmax = int.MinValue;
                int lmin = int.MaxValue;
                int sum = 0;
                foreach (NSubsequence seq in candidates)
                {
                    int length = seq.getLength();
                    if (length > lmax)
                    {
                        lmax = length;
                    }
                    if (length < lmin)
                    {
                        lmin = length;
                    }
                    sum += length;
                }
                int size = candidates.Count;
                if (delta > 0 && delta < 100) {
                    int meanLength = (sum % size == 0)? (sum / size) : ((sum / size) + 1);
                    lmin = meanLength - ((delta * meanLength) / 100);
                    lmax = meanLength + ((delta * meanLength) / 100);
                }
                double[,] distanceMatrix = distanceMatrixCal(candidates, lmin, lmax);

                List<double> kDis = new List<double>();

                for (int i = 0; i < size; i++)
                {
                    double tmp = calKDistance(i, k, distanceMatrix);

                    kDis.Add(tmp);
                }
                double median = Utils.median(kDis);
                this.println("======Median===== \n" + median);
                List<double> anomalyFactors = calAnomalyFactor(kDis, median);
                this.println("========Anomal Factor====");
                for (int i = 0; i < size; i++)
                {
                    NSubsequence n = candidates[i];
                    n.setAnomalyFactor(anomalyFactors[i]);
                }
            }
            this.println("FINISH ANOMAL FACTOR CALCULATE...");
            List<NSubsequence> ret = candidates.OrderBy(d => d.getAnomalyFactor()).ToList();
            foreach (NSubsequence r in ret) 
            {
                this.println("Segment: " + r.getStart() + " - " + r.getEnd() + ": " + r.getAnomalyFactor());
            }
            return ret;
        }



        private List<double> calAnomalyFactor(List<double> kDis, double median)
        {
            List<double> ret = new List<double>();
            int size = kDis.Count;
            for (int i = 0; i < size; i++)
            {
                ret.Add(kDis[i] / median);
            }
            return ret;
        }

        private double calKDistance(int pattern, int k, double[,] matrix)
        {
            int size = matrix.GetLength(0);// get num Row
            List<double> tmp = new List<double>();
            for (int i = 0; i < size; i++)
            {
                if (pattern != i && matrix[pattern, i] > 0.0)
                {
                    tmp.Add(matrix[pattern, i]);
                }
            }
            tmp = tmp.OrderBy(d => d).ToList();
            return tmp[k - 1];
        }

        private double[,] distanceMatrixCal(List<NSubsequence> candidates, int lmin, int lmax)
        {
            int length = candidates.Count;
            double[,] ret = new double[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    
                    if (i == j || Utils.isOverLap(candidates[i], candidates[j]))
                    {
                        ret[i, j] = 0.0;
                        continue;
                    }
                    ret[i, j] = distance(candidates[i], candidates[j], lmin, lmax);
                    ret[j, i] = ret[i, j];
                    this.println("Distance of " + i + " and " + j + " " + ret[i, j]);
                }
            }
            return ret;
        }

        private double distance(NSubsequence s1, NSubsequence s2, int lmin, int lmax)
        {
            int sj = s2.getStart();
            int si = s1.getStart();
            int ei = s1.getEnd();
            double ret = double.MaxValue;
            double[] a = getSegment(si, ei);
            int limit = series.getData().Count;
            for (int l = lmin; l <= lmax; l++)
            {
                if (sj + l <= limit)
                {
                    double[] b = getSegment(sj, sj + l - 1);
                    double cal = Distance.distance(a, b);
                    if (cal < ret)
                    {
                        ret = cal;
                    }
                }
                else
                {
                    break;
                }
            }
            return ret;
        }

        private void println(string msg)
        {
            this.log.AppendText(msg + "\n");
        }

        private double[] getSegment(int start, int end)
        {
            return (series.getData().GetRange(start, end - start + 1)).ToArray();
        }
    }
}
