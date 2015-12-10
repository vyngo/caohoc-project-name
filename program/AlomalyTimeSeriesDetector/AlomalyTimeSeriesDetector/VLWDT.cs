using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlomalyTimeSeriesDetector.common;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector
{
    public partial class VLWDT : Form
    {
        private NTimeSeries series = null;
        private List<NSubsequence> anomalies = new List<NSubsequence>();
        private int from = 0;
        private int to = 0;
        public VLWDT()
        {
            InitializeComponent();
        }

        private void reset()
        {
            this.anomalies.Clear();
            this.log_richTextBox.Text = "";
            this.result_richTextBox.Text = "";
        }

        private void loadData_button_Click(object sender, EventArgs e)
        {
            reset();
            DialogResult result = this.openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                if (string.IsNullOrEmpty(file))
                {
                    MessageBox.Show(this, "File is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ReadDataFromFile readData = new ReadDataFromFile(file);
                if (!String.IsNullOrEmpty(this.numDataPoint_textBox.Text))
                {
                    string numDataText = this.numDataPoint_textBox.Text;
                    string[] arr = numDataText.Split('-');
                    if (arr.Length < 2)
                    {
                        this.to = int.Parse(arr[0]);
                    }
                    else
                    {
                        this.from = int.Parse(arr[0]);
                        this.to = int.Parse(arr[1]);
                    }
                    this.series = readData.read(from, to);
                    this.to = this.from + this.series.getNumberOfDataPoint() - 1;
                }
                else
                {
                    this.series = readData.read();
                    this.to = this.series.getNumberOfDataPoint() - 1;
                    this.from = 0;
                }
                println("Load data successfully: start from " + this.from + " to " + this.to);
                Console.WriteLine("Done");
            }
        }

        private void println(string msg)
        {
            this.log_richTextBox.AppendText(msg + "\n");
        }

        private void writeResult(string msg)
        {
            this.result_richTextBox.AppendText(msg + "\n");
        }

        private void plot_button_Click(object sender, EventArgs e)
        {
            if (this.series == null)
            {
                MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NTimeSeries tmp = new NTimeSeries();
            int l = this.series.getNumberOfDataPoint();
            for (int i = 0; i < l; i++)
            {
                tmp.addData(this.series.getData()[i]);
            }
            TimeSeriesPlot plot = new TimeSeriesPlot(tmp, this.anomalies);
            plot.Show();
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            //double[] d1 = new double[350];
            //double[] d2 = new double[400];
            //double[] d3 = new double[350];
            //double[] d4 = new double[400];
            //int index = 0;
            //for (int i = 0; i < d1.Length; i++) 
            //{
            //    d1[i] = this.series.getData()[index];
            //    index++;
            //}
            //for (int i = 0; i < d2.Length; i++)
            //{
            //    d2[i] = this.series.getData()[index];
            //    index++;
            //}
            //for (int i = 0; i < d3.Length; i++)
            //{
            //    d3[i] = this.series.getData()[index];
            //    index++;
            //}
            //for (int i = 0; i < d4.Length; i++)
            //{
            //    d4[i] = this.series.getData()[index];
            //    index++;
            //}
            //double dis12 = DTWDistance.Distance(d1, d2);
            //double dis21 = DTWDistance.Distance(d2, d1);
            //this.println("Dist12: " + dis12 + " vs " + Distance.distance(d1, d2));
            //this.println("Dist21: " + dis21 + " vs " + Distance.distance(d2, d1));

            //this.println("Dist34: " + DTWDistance.Distance(d3, d4) + " vs " + Distance.distance(d3, d4));
            //this.println("Dist43: " + DTWDistance.Distance(d4, d3) + " vs " + Distance.distance(d4, d3));
            this.run();
        }

        private void run() 
        {
            Stopwatch stTotal = new Stopwatch();
            stTotal.Start();
            reset();
            NTimeSeries tmp = new NTimeSeries();
            for (int i = 0; i < this.series.getData().Count; i++)
            {
                tmp.addData(this.series.getData()[i]);
            }
            if (String.IsNullOrEmpty(this.e1_textBox.Text))
            {
                MessageBox.Show(this, "regression error is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double e1 = double.Parse(this.e1_textBox.Text);
            List<NSubsequence> candiadates = null;
            Stopwatch stSeg = new Stopwatch();
            stSeg.Start();
            
      
                if (String.IsNullOrEmpty(this.e2_textBox.Text))
                {
                    MessageBox.Show(this, "Non-self match threshold is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double e2 = double.Parse(this.e2_textBox.Text);
                QuadradicSegmentation seg = new QuadradicSegmentation(this.log_richTextBox);
                candiadates = seg.segmentation(tmp, e1, e2);
                this.writeResult("Segmentation algorithm Quadratic");
           
            stSeg.Stop();
            this.writeResult("Time execute segmentation: " + stSeg.Elapsed.ToString());
            if (candiadates == null)
            {
                MessageBox.Show(this, "Exception in segmentations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Stopwatch stCal = new Stopwatch();
            stCal.Start();
            int k = 0;
            if (!String.IsNullOrEmpty(this.k_textBox.Text))
            {
                k = int.Parse(this.k_textBox.Text);
            }
            else
            {
                k = Convert.ToInt32(Math.Ceiling(0.05 * candiadates.Count));
            }
            
            candiadates = this.anomalFactorCal(candiadates, k);
            stCal.Stop();
            this.writeResult("Time execute calculate anomal factor: " + stCal.Elapsed.ToString());
            double a = 3.0;
            if (!String.IsNullOrEmpty(this.alpha_textBox.Text))
            {
                a = double.Parse(this.alpha_textBox.Text);
            }
            List<NSubsequence> anomaliesRaw = new List<NSubsequence>();
            foreach (NSubsequence r in candiadates)
            {
                if (r.getAnomalyFactor() > a)
                {
                    anomaliesRaw.Add(r);
                }
            }
            this.anomalies = mergeAnomalyPattern(anomaliesRaw);
            this.writeResult("========= ANOMALIES ==========");
            this.writeResult("Anomal Threshold: " + a);
            this.writeResult("The Number: " + this.anomalies.Count);
            foreach (NSubsequence an in this.anomalies)
            {
                this.writeResult("Segment: " + an.getStart() + " - " + an.getEnd() + ", anomal factor: " + an.getAnomalyFactor());
            }
            stTotal.Stop();
            this.writeResult("Time execute total: " + stTotal.Elapsed.ToString());
        }
        private List<NSubsequence> anomalFactorCal(List<NSubsequence> candidates, int k)
        {
            this.println("ANOMAL FACTOR CALCULATE...");
            if (candidates != null && candidates.Count > 0)
            {
                int lmax = int.MinValue;
                int lmin = int.MaxValue;
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
                }
                int size = candidates.Count;
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

        private List<NSubsequence> mergeAnomalyPattern(List<NSubsequence> candidates)
        {
            this.println("MERGRE RESULT...");
            int size = candidates.Count;
            List<NSubsequence> ret = new List<NSubsequence>();
            List<int> banIndex = new List<int>();
            for (int i = 0; i < size; i++)
            {
                if (banIndex.Contains(i))
                {
                    continue;
                }
                NSubsequence n = new NSubsequence(candidates[i].getStart(), candidates[i].getEnd());
                n.setAnomalyFactor(candidates[i].getAnomalyFactor());
                for (int j = 0; j < size; j++)
                {
                    if (!banIndex.Contains(j) && i != j)
                    {
                        NSubsequence tmp = candidates[j];
                        if ((tmp.getStart() >= n.getStart() && tmp.getStart() <= n.getEnd())
                                || (tmp.getStart() == n.getEnd() + 1))
                        {
                            int startMin = (tmp.getStart() >= n.getStart()) ? n.getStart() : tmp.getStart();
                            n.setStart(startMin);
                            int endMax = (tmp.getEnd() >= n.getEnd()) ? tmp.getEnd() : n.getEnd();
                            n.setEnd(endMax);
                            if (tmp.getAnomalyFactor() > n.getAnomalyFactor())
                            {
                                n.setAnomalyFactor(tmp.getAnomalyFactor());
                            }
                            banIndex.Add(j);
                        }
                        else if ((n.getStart() >= tmp.getStart() && n.getStart() <= tmp.getEnd())
                                || (n.getStart() == tmp.getEnd() + 1))
                        {
                            int startMin = (tmp.getStart() >= n.getStart()) ? n.getStart() : tmp.getStart();
                            n.setStart(startMin);
                            int endMax = (tmp.getEnd() >= n.getEnd()) ? tmp.getEnd() : n.getEnd();
                            n.setEnd(endMax);
                            if (tmp.getAnomalyFactor() > n.getAnomalyFactor())
                            {
                                n.setAnomalyFactor(tmp.getAnomalyFactor());
                            }
                            banIndex.Add(j);
                        }
                    }
                }
                candidates[i] = n;// reset
            }
            for (int i = 0; i < size; i++)
            {
                if (!banIndex.Contains(i))
                {
                    ret.Add(candidates[i]);
                }
            }
            this.println("FINISH MERGE...");
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
                    double cal = DTWDistance.Distance(a, b);
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
        private double[] getSegment(int start, int end)
        {
            return (series.getData().GetRange(start, end - start + 1)).ToArray();
        }
    }
}
