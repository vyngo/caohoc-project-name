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
    public partial class VariableLengthMethod : Form
    {
        private NTimeSeries series = null;
        private List<NSubsequence> anomalies = new List<NSubsequence>();

        public VariableLengthMethod()
        {
            InitializeComponent();
            this.varlength_algorithm_comboBox.SelectedItem = "Quadratic";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.varlength_algorithm_comboBox.SelectedItem.Equals("SWAB"))
            {
                this.varlength_e2_label.Text = "Buffer Size";
                this.varlength_e1_label.Text = "Regression Error";
            }
            else if (this.varlength_algorithm_comboBox.SelectedItem.Equals("Quadratic"))
            {
                this.varlength_e2_label.Text = "Non-Self Match Threshold";
                this.varlength_e1_label.Text = "Regression Error";
            }
            else 
            {
                this.varlength_e2_label.Text = "Minimum Length";
                this.varlength_e1_label.Text = "Ratio";
            }
        }

        private void varlength_choose_button_Click(object sender, EventArgs e)
        {
            this.varlength_log_richTextBox.Text = "";
            DialogResult result = this.varlength_openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = varlength_openFileDialog.FileName;
                if (string.IsNullOrEmpty(file))
                {
                    MessageBox.Show(this, "File is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ReadDataFromFile readData = new ReadDataFromFile(file);
                this.series = readData.read();
                println("Load data successfully: " + this.series.getNumberOfDataPoint() + " points");
                Console.WriteLine("Done");
            }
        }

        private void varlength_run_button_Click(object sender, EventArgs e)
        {
            Stopwatch stTotal = new Stopwatch();
            stTotal.Start();
            if (String.IsNullOrEmpty(this.varlength_numDataPoint_textBox.Text))
            {
                MessageBox.Show(this, "number data point is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numDataPoint = int.Parse(this.varlength_numDataPoint_textBox.Text);
            NTimeSeries tmp = new NTimeSeries();
            for (int i = 0; i < numDataPoint && i < this.series.getData().Count; i++)
            {
                tmp.addData(this.series.getData()[i]);
            }
            if (String.IsNullOrEmpty(this.varlength_e1_textBox.Text))
            {
                MessageBox.Show(this, "regression error is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double e1 = double.Parse(this.varlength_e1_textBox.Text);
            List<NSubsequence> candiadates = null;
            Stopwatch stSeg = new Stopwatch();
            stSeg.Start();
            if (this.varlength_algorithm_comboBox.SelectedItem.Equals("SWAB"))
            {
                if (String.IsNullOrEmpty(this.varlength_e2_textBox.Text))
                {
                    MessageBox.Show(this, "Buffer size is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int w = int.Parse(this.varlength_e2_textBox.Text);
                SWABSegmentation seg = new SWABSegmentation(this.varlength_log_richTextBox);
                candiadates = seg.segmentation(tmp, e1, w);
                this.writeResult("Segmentation algorithm SWAB");
            }
            else if (this.varlength_algorithm_comboBox.SelectedItem.Equals("Quadratic"))
            {
                if (String.IsNullOrEmpty(this.varlength_e2_textBox.Text))
                {
                    MessageBox.Show(this, "Non-self match threshold is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double e2 = double.Parse(this.varlength_e2_textBox.Text);
                QuadradicSegmentation seg = new QuadradicSegmentation(this.varlength_log_richTextBox);
                candiadates = seg.segmentation(tmp, e1, e2);
                this.writeResult("Segmentation algorithm Quadratic");
            }
            else
            {
                if (String.IsNullOrEmpty(this.varlength_e1_textBox.Text))
                {
                    MessageBox.Show(this, "Ratio is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double ratio = double.Parse(this.varlength_e1_textBox.Text);
                int minLength = 0;
                if (!String.IsNullOrEmpty(this.varlength_e2_textBox.Text))
                {
                    minLength = int.Parse(this.varlength_e2_textBox.Text);
                }
                ExtreamePointSegmentation seg = new ExtreamePointSegmentation(this.varlength_log_richTextBox);
                candiadates = seg.segmentation(tmp, e1, minLength);
                this.writeResult("Segmentation algorithm Quadratic");
            }
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
            if (!String.IsNullOrEmpty(this.varlength_k_textBox.Text))
            {
                k = int.Parse(this.varlength_k_textBox.Text);
            }
            else
            {
                k = Convert.ToInt32(Math.Ceiling(0.05 * candiadates.Count));
            }
            AnomalFactorCalculator anomalCal = new AnomalFactorCalculator(tmp, this.varlength_log_richTextBox);
            candiadates = anomalCal.anomalFactorCal(candiadates, k);
            stCal.Stop();
            this.writeResult("Time execute calculate anomal factor: " + stCal.Elapsed.ToString());
            double a = 3.0;
            if (!String.IsNullOrEmpty(this.varlength_alpha_textBox.Text))
            {
                a = double.Parse(this.varlength_alpha_textBox.Text);
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

        private void varlength_plot_button_Click(object sender, EventArgs e)
        {
            if (this.series == null)
            {
                MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(this.varlength_numDataPoint_textBox.Text))
            {
                MessageBox.Show(this, "number data point is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numDataPoint = int.Parse(this.varlength_numDataPoint_textBox.Text);
            NTimeSeries tmp = new NTimeSeries();
            for (int i = 0; i < numDataPoint; i++)
            {
                tmp.addData(this.series.getData()[i]);
            }
            TimeSeriesPlot plot = new TimeSeriesPlot(tmp, this.anomalies);
            plot.Show();
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
                for (int j = i + 1; j < size; j++)
                {
                    if (!banIndex.Contains(j))
                    {
                        NSubsequence tmp = candidates[j];
                        if ((tmp.getStart() >= n.getStart() && tmp.getStart() <= n.getEnd())
                                || (tmp.getStart() == n.getEnd() + 1))
                        {
                            n.setEnd(tmp.getEnd());
                            if (tmp.getAnomalyFactor() > n.getAnomalyFactor())
                            {
                                n.setAnomalyFactor(tmp.getAnomalyFactor());
                            }
                            banIndex.Add(j);
                        }
                    }
                }
                ret.Add(n);
            }
            this.println("FINISH MERGE...");
            return ret;
        }

        private void println(string msg)
        {
            this.varlength_log_richTextBox.AppendText(msg + "\n");
        }

        private void writeResult(string msg)
        {
            this.varlength_result_richTextBox.AppendText(msg + "\n");
        }
    }
}
