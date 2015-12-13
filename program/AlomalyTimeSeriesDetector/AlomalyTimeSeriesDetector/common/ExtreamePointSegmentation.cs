using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector.common
{
    class ExtreamePointSegmentation
    {
        private int globalIndex;
        private double[] originalData;
        private double RatioOfExtremePoint;
        private int MINIMUM_LENGTH;
        private RichTextBox box;
        public ExtreamePointSegmentation(RichTextBox box)
        {
            this.box = box;
        }

        public List<NSubsequence> segmentation(NTimeSeries series, double ratio, int minLength)
        {
            clearBox();
            List<NSubsequence> ret = new List<NSubsequence>();
            this.RatioOfExtremePoint = ratio;
            this.MINIMUM_LENGTH = minLength;
            this.globalIndex = 0;
            double[] tmp = series.getData().ToArray();
            double min = Utils.min(tmp);
            if (min < 0)
            {
                this.originalData = new double[tmp.Length];
                for (int i = 0; i < tmp.Length; i++)
                {
                    this.originalData[i] = tmp[i] + (-min) + 1; // scale along y to get positive value;
                }
            }
            else
            {
                this.originalData = series.getData().ToArray();
            }
            List<int> indexs = ExtractExtremePoint();
            if (indexs.IndexOf(0) < 0) {
                //int length = indexs[0] - 0 + 1;
                //if (length >= MINIMUM_LENGTH)
                //{
                    indexs.Insert(0, 0);
                //}
            }
            if (indexs.IndexOf(this.originalData.Length - 1) < 0) {
                indexs.Add(this.originalData.Length - 1);
            }
            for (int i = 0; i < indexs.Count - 2; i++)
            {
                NSubsequence sub = new NSubsequence(indexs[i], indexs[i+2]);
                ret.Add(sub);
            }
            return ret;
        }

        private List<int> ExtractExtremePoint()
        {
            // start FindFistTwo();
            List<int> extremePoint = new List<int>();

            int iMin = 0, iMax = 0, i = 0;
            while (i < originalData.Length)
            {
                if (isOutRangeMin(iMin) || isOutRangeMax(iMax))
                    break;
                if (originalData[iMin] > originalData[i])
                    iMin = i;
                if (originalData[iMax] < originalData[i])
                    iMax = i;

                i++;
            }
            // end FindFistTwo
            globalIndex = i;
            if (iMin < iMax)
            {
                extremePoint.Add(iMin); extremePoint.Add(iMax);
                iMin = FindMinimum();
                if (iMin > 0)
                    extremePoint.Add(iMin);

            }
            else
            {
                extremePoint.Add(iMax); extremePoint.Add(iMin);
            }


            while (globalIndex < originalData.Length)
            {
                iMax = FindMaximum();
                if (iMax > 0 && ((iMax - MINIMUM_LENGTH) > iMin))
                    extremePoint.Add(iMax);
                iMin = FindMinimum();

                if (iMin > 0 && ((iMin - MINIMUM_LENGTH) > iMax))
                    extremePoint.Add(iMin);

            }

            //     MessageBox.Show("Complete !!");
            return extremePoint;
        }

        private bool isOutRangeMin(int iMin)
        {
            return ((originalData[iMin] > 0) && (originalData[globalIndex] > RatioOfExtremePoint * originalData[iMin]))
                     || ((originalData[iMin] < 0) && (originalData[iMin] < RatioOfExtremePoint * originalData[globalIndex]));
        }

        private bool isOutRangeMax(int iMax)
        {
            return ((originalData[globalIndex] > 0) && (originalData[iMax] > RatioOfExtremePoint * originalData[globalIndex]))
                      || ((originalData[globalIndex] < 0) && (originalData[globalIndex] < RatioOfExtremePoint * originalData[iMax]));
        }

        private int FindMinimum()
        {
            int iMin = globalIndex;
            while (globalIndex < originalData.Length)
            {
                if (originalData[iMin] > originalData[globalIndex])
                    iMin = globalIndex;
                if (isOutRangeMin(iMin))
                    break;

                globalIndex++;
            }
            if (globalIndex < originalData.Length)
                return iMin;
            else
                return -1;
        }

        private int FindMaximum()
        {
            int iMax = globalIndex;

            while (globalIndex < originalData.Length)
            {
                if (originalData[iMax] < originalData[globalIndex])
                    iMax = globalIndex;
                if (isOutRangeMax(iMax))
                    break;
                globalIndex++;
            }
            if (globalIndex < originalData.Length)
                return iMax;
            else
                return -1;
        }

        private void WriteLine(string msg)
        {
            this.box.AppendText(msg + "\n");
        }

        private void clearBox()
        {
            this.box.Text = "";
        }
    }
}
