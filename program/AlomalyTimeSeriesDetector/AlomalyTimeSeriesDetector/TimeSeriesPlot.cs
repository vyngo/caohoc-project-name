using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlomalyTimeSeriesDetector.entity;
using ZedGraph;

namespace AlomalyTimeSeriesDetector
{
    public partial class TimeSeriesPlot : Form
    {
        NTimeSeries series;
        List<NSubsequence> anomalies;
        public TimeSeriesPlot( NTimeSeries series)
        {
            this.series = series;
            InitializeComponent();
        }

        public TimeSeriesPlot(NTimeSeries series, List<NSubsequence> anomalies) 
        {
            this.series = series;
            this.anomalies = anomalies;
            InitializeComponent();
        }

        private void TimeSeriesPlot_Load(object sender, EventArgs e)
        {
            Drawing(this.series);
        }

        private void Drawing(NTimeSeries timeSeriesInput)
        {
            int size = timeSeriesInput.getNumberOfDataPoint();
            List<Double> data = timeSeriesInput.getData();
            timeSeriesChart.GraphPane.CurveList.Clear();
            GraphPane myPane = timeSeriesChart.GraphPane;
            myPane.Title.Text = "series";
            myPane.XAxis.Title.Text = "Index";// "Thời gian cột X";
            myPane.YAxis.Title.Text = "Value";// "Tiêu đề cột Y";
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = size;
            myPane.YAxis.Scale.MagAuto = false;
            myPane.XAxis.Scale.MagAuto = false;

            timeSeriesChart.AxisChange();
           
            if(this.anomalies != null && this.anomalies.Count > 0){
                bool first = true;
                bool afirst = true;
                
                foreach (NSubsequence sub in this.anomalies) 
                {
                    List<double> anomalIndex = new List<double>();
                    List<double> anomalValue = new List<double>();
                    for (int i = sub.getStart(); i <= sub.getEnd(); i++) {
                        anomalIndex.Add(i);
                        anomalValue.Add(data[i]);
                    }
                    PointPairList anomalList = new PointPairList();
                    anomalList.Add(anomalIndex.ToArray(), anomalValue.ToArray());
                    if (afirst)
                    {
                        myPane.AddCurve("anomal series", anomalList, Color.Red, SymbolType.None);
                        afirst = false;
                    }
                    else
                    {
                        myPane.AddCurve("", anomalList, Color.Red, SymbolType.None);
                    }
                }
               
                int j = 0;
                List<double> index = new List<double>();
                List<double> value = new List<double>();
                while (j < size)
                {
                    
                    NSubsequence tmp = isInAnormalSeries(j);
                    if (tmp == null)
                    {
                        index.Add(j);
                        value.Add(data[j]);
                        j++;
                    }
                    else
                    {
                        if (index.Count > 0 && value.Count > 0) {
                            PointPairList normalList = new PointPairList();
                            normalList.Add(index.ToArray(), value.ToArray());
                            if (first)
                            {
                                myPane.AddCurve("series", normalList, Color.Blue, SymbolType.None);
                                afirst = false;
                            }
                            else
                            {
                                myPane.AddCurve("", normalList, Color.Blue, SymbolType.None);
                            }

                        }
                        index.Clear();
                        value.Clear();
                        j += tmp.getEnd() - tmp.getStart() + 1;// jump out of anormal subsequence
                    }
                }
                if (index.Count > 0 && value.Count > 0) {// print tail
                    PointPairList normalList = new PointPairList();
                    normalList.Add(index.ToArray(), value.ToArray());
                    if (first)
                    {
                        myPane.AddCurve("series", normalList, Color.Blue, SymbolType.None);
                        afirst = false;
                    }
                    else
                    {
                        myPane.AddCurve("", normalList, Color.Blue, SymbolType.None);
                    }
                    index.Clear();
                    value.Clear();
                }
            }else{
                List<double> index = new List<double>();
                List<double> value = new List<double>();
                for (int i = 0; i < size; i++)
                {
                    index.Add(i);
                    value.Add(data.ElementAt(i));
                }
                PointPairList list = new PointPairList();
                list.Add(index.ToArray(), value.ToArray());
                myPane.AddCurve("series", list, Color.Blue, SymbolType.None);

            }
            
            timeSeriesChart.AxisChange();
            timeSeriesChart.Invalidate();
        }

        private NSubsequence isInAnormalSeries(int i) {
            foreach (NSubsequence sub in this.anomalies)
            {
                if (sub.getStart() <= i && sub.getEnd() >= i)
                {
                    NSubsequence ret = new NSubsequence(sub.getStart(), sub.getEnd());
                    return ret;
                }
            }
            return null;
        }
    }
}
