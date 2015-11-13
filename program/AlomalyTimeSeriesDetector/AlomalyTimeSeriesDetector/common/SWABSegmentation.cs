using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector.common
{
    class SWABSegmentation
    {
        private RichTextBox box;
        public SWABSegmentation(RichTextBox box)
        {
            this.box = box;
        }
        public List<NSubsequence> segmentation(NTimeSeries series, double e1, int w)
        {
            List<NSubsequence> ret = new List<NSubsequence>();
            int lower_bound = w / 2;
            int upper_bound = 2 * w;
            List<double> data = series.getData();
            int size = data.Count;
            Buffer buffer = new Buffer(0, w - 1);
            while (buffer.end < size)
            {
                List<double> temp = new List<double>();
                for (int i = buffer.begin; i <= buffer.end; i++)
                {
                    temp.Add(data[i]);
                }
                List<NSubsequence> subTemp = segmentationForBuffer(buffer.begin, temp, e1);
                NSubsequence asub = getFirstSubsequence(subTemp);
                asub.setStart(buffer.begin + asub.getStart());
                asub.setEnd(buffer.begin + asub.getEnd());
                ret.Add(asub);
                buffer.begin = asub.getEnd() + 1;

                int nexEnd = bestLine(e1, buffer.end, data);
                if (nexEnd >= size - 1)
                {// segment remain
                    List<Double> temp1 = new List<Double>();
                    for (int i = buffer.begin; i <= size - 1; i++)
                    {
                        temp1.Add(data[i]);
                    }
                    List<NSubsequence> remain = segmentationForBuffer(buffer.begin, temp1, e1);
                    foreach (NSubsequence s in remain)
                    {
                        NSubsequence a = new NSubsequence(buffer.begin + s.getStart(), buffer.begin + s.getEnd());
                        ret.Add(a);
                    }
                    buffer.end = size;// halt
                }
                else
                {
                    int newsize = nexEnd - buffer.begin + 1;
                    if (newsize < lower_bound)
                    {
                        nexEnd = lower_bound + buffer.begin - 1;
                    }
                    else if (newsize > upper_bound)
                    {
                        nexEnd = upper_bound + buffer.begin - 1;
                    }
                    buffer.end = nexEnd;
                }

                this.WriteLine("==========BUFFER==========");
                this.WriteLine("buffer: " + buffer.begin + " - " + buffer.end);
            }
            return ret;
        }

        private NSubsequence getFirstSubsequence(List<NSubsequence> sub)
        {
            int start = int.MaxValue;
            int end = 0;
            foreach (NSubsequence s in sub)
            {
                if (s.getStart() < start)
                {
                    start = s.getStart();
                    end = s.getEnd();
                }
            }
            return new NSubsequence(start, end);
        }

        private int bestLine(double maxError, int start, List<double> data)
        {
            double error = double.MinValue;
            int l = 3;// initial length
            int s = start;
            int size = data.Count;
            int ret = start;
            while (error <= maxError)
            {
                int e = s + l - 1;
                if (e >= size - 1)
                {
                    ret = size - 1;
                    return ret;
                }
                List<double> subList = data.GetRange(s, e - s + 1);
                double[] y = subList.ToArray();
                double[] x = new double[l];
                for (int i = 0; i < l; i++)
                {
                    x[i] = 0 + i;//start + i;
                }
                double[] reg = LinearRegression.regress(x, y);
                error = reg[2];
                ret = e - 1;
                l++;
            }
            return ret;
        }

        private class Buffer
        {

            public int begin;
            public int end;

            public Buffer(int begin, int end)
            {
                this.begin = begin;
                this.end = end;
            }
        }

        private List<NSubsequence> segmentationForBuffer(int start, List<double> data, double e1)
        {
            List<NSubsequence> ret = new List<NSubsequence>();
            List<double> mergeCost = new List<double>();
            int length = data.Count;
            int i;
            this.WriteLine("Init subsequence with length 2");
            for (i = 0; i < length - 1; i += 2)
            {
                ret.Add(new NSubsequence(i, i + 1));
            }
            int sizeOfSub = ret.Count;
            this.WriteLine("Calculate merge cost list");
            for (i = 0; i < sizeOfSub - 1; i++)
            {
                NSubsequence temp = new NSubsequence(ret[i].getStart(), ret[(i + 1)].getEnd());
                mergeCost.Add(calculateErrorForBuffer(start, data, temp));
            }
            while (true)
            {
                MinMergCost cost = min(mergeCost);
                if (cost.min > e1)
                {
                    break;
                }
                this.WriteLine("min cost: " + cost.min + ", min index: " + cost.index);
                this.WriteLine("Size subsequence: " + ret.Count + ", Size merge cost: " + mergeCost.Count);
                NSubsequence m = ret[(cost.index)];
                NSubsequence mPlus1 = ret[cost.index + 1];
                m.setEnd(mPlus1.getEnd());
                if (cost.index + 1 < ret.Count)
                {
                    ret.RemoveAt(cost.index + 1);
                }
                //update merger_code
                if (cost.index + 1 < mergeCost.Count() && cost.index < ret.Count() - 1)
                {
                    mergeCost.RemoveAt(cost.index + 1);
                    double costi = calculateErrorForBuffer(start, data, m);
                    mergeCost[cost.index] = costi;
                }
                else
                {
                    mergeCost[cost.index] = double.MaxValue;
                }
                if (cost.index - 1 >= 0)
                {
                    NSubsequence mMinus1 = ret[(cost.index - 1)];
                    NSubsequence temp = new NSubsequence(mMinus1.getStart(), m.getEnd());
                    mergeCost[(cost.index - 1)] = calculateErrorForBuffer(start, data, temp);
                }
            }
            return ret;
        }

        private double calculateErrorForBuffer(int start, List<double> data, NSubsequence seq)
        {
            int s = seq.getStart();
            int e = seq.getEnd();
            int l = seq.getLength();

            List<double> subList = data.GetRange(s, e - s + 1);
            double[] y = subList.ToArray();
            double[] x = new double[l];
            for (int i = 0; i < l; i++)
            {
                x[i] = 0 + 0 + i; //start + s + i;
            }
            double[] reg = LinearRegression.regress(x, y);
            return reg[2];
        }

        private void WriteLine(string msg)
        {
            this.box.AppendText(msg + "\n");
        }

        private SWABSegmentation.MinMergCost min(List<double> data)
        {
            double min = double.MaxValue;
            int index = 0;
            int size = data.Count;
            for (int i = 0; i < size; i++)
            {
                if (min > data[i])
                {
                    min = data[(i)];
                    index = i;
                }
            }
            return new SWABSegmentation.MinMergCost(index, min);
        }

        private class MinMergCost
        {

            public int index;
            public double min;

            public MinMergCost(int index, double min)
            {
                this.index = index;
                this.min = min;
            }
        }
    }
}
