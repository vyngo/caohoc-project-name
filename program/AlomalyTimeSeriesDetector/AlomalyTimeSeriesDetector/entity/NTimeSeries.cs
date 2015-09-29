using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlomalyTimeSeriesDetector.entity
{
    public class NTimeSeries
    {
        private List<Double> data = null;
        private List<Double> rawData = null;

        public NTimeSeries()
        {
            data = new List<Double>();
        }

        public void clear()
        {
            if (data != null)
            {
                data.Clear();
                data = null;
            }
            if (rawData != null)
            {
                rawData.Clear();
                rawData = null;
            }
        }

        public void reInitiate()
        {
            clear();
            data = new List<Double>();
        }

        public int getNumberOfDataPoint()
        {
            return data.Count();
        }

        public void addData(double val)
        {
            if (data != null)
            {
                data.Add(val);
            }
        }

        public List<Double> getData()
        {
            return data;
        }

        public List<Double> getRawData()
        {
            return rawData;
        }

        public void zscore()
        {
            rawData = new List<Double>();
            //backup
            foreach (double a in data)
            {
                rawData.Add(a);
            }
            double mean = Mean();
            double std = Std();
            data.Clear();
            data = new List<Double>();
            foreach (double a in rawData)
            {
                double s = (a - mean) / std;
                data.Add(s);
            }
        }

        public double Mean()
        {
            double ret = 0.0;
            foreach (double a in data)
            {
                ret += a;
            }
            return ret / data.Count();
        }

        public double Std()
        {
            double ret = 0.0;
            double mean = Mean();
            foreach (double a in data)
            {
                ret += (a - mean) * (a - mean);
            }
            ret = ret / ((double)data.Count());
            return Math.Sqrt(ret);
        }
    }
}
