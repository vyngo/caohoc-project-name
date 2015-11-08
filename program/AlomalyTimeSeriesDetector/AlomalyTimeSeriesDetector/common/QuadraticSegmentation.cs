using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector.common
{
    class QuadradicSegmentation
    {
        private RichTextBox box;

        public QuadradicSegmentation(RichTextBox box)
        {
            this.box = box;
        }

        public List<NSubsequence> segmentation(NTimeSeries series, double e1, double e2)
        {
           
            List<NSubsequence> ret = new List<NSubsequence>();
            bool halt = false;
            int start = 0;
            do
            {
                if (start >= series.getNumberOfDataPoint())
                {
                    break;
                }
                NSubsequence sequence = getASegment(start, series, e1);
                if(sequence != null){
                    WriteLine("Get a Segment: " + sequence.getStart() + " - " + sequence.getEnd());
                }
                
                ret.Add(sequence);
                int end = sequence.getEnd();
                if (end == (series.getNumberOfDataPoint() - 1))
                {
                    halt = true;
                }
                else
                {
                    start = getNextStartIndex(sequence, series, e2);
                }
            } while (!halt);
            
            return ret;
        }

        private static NSubsequence getASegment(int start, NTimeSeries series, double e1)
        {
            NSubsequence ret = null;
            bool halt = false;
            int l = 4;// initial length
            int s = start;
            do
            {
                int e = s + l - 1;
                if (e >= series.getNumberOfDataPoint() - 1)
                {
                    ret = new NSubsequence(start, series.getNumberOfDataPoint() - 1);
                    break;
                }
                List<Double> subList = series.getData().GetRange(s, e - s + 1);
                double[] y = subList.ToArray();
                double[] x = new double[l];
                for (int i = 0; i < l; i++)
                {
                    x[i] =  start + i; // 0 + i
                }
                double[] reg = QuadraticRegression.regress(x, y);
                if (reg[3] >= e1)
                {
                    halt = true;
                    ret = new NSubsequence(start, e - 1);
                }
                else
                {
                    l += 1;
                }
            } while (!halt);
            return ret;
        }

        private static int getNextStartIndex(NSubsequence se, NTimeSeries series, double e2)
        {
            int start = se.getStart();
            int end = se.getEnd();
            int i = 1;
            List<Double> imageSubSequence = series.getData().GetRange(start, end - start + 1);
            List<Double> candidateSequence = series.getData().GetRange(start + i, (end + i) - (start + i) + 1);
            while (Distance.distance(imageSubSequence.ToArray(), candidateSequence.ToArray()) <= e2
                    && i < (end - start))
            {
                i++;
            }
            return end + i;
        }

        private void WriteLine(string msg)
        {
            this.box.AppendText(msg + "\n");
        }
    }
}
