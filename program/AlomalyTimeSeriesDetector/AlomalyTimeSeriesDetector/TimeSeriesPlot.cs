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
        public TimeSeriesPlot( NTimeSeries series)
        {
            this.series = series;
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

            PointPairList list = new PointPairList();

            List<double> index = new List<double>();
            List<double> value = new List<double>();
            for (int i = 0; i < size; i++)
            {
                index.Add(i);
                value.Add(data.ElementAt(i));
            }

            list.Add(index.ToArray(), value.ToArray());
            LineItem myCurve = myPane.AddCurve("series", list, Color.Blue, SymbolType.None);
            timeSeriesChart.AxisChange();
            timeSeriesChart.Invalidate();
        }

    }
}
