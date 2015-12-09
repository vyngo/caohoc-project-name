using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            double[] d1 = new double[350];
            double[] d2 = new double[400];
            double[] d3 = new double[350];
            double[] d4 = new double[400];
            int index = 0;
            for (int i = 0; i < d1.Length; i++) 
            {
                d1[i] = this.series.getData()[index];
                index++;
            }
            for (int i = 0; i < d2.Length; i++)
            {
                d2[i] = this.series.getData()[index];
                index++;
            }
            for (int i = 0; i < d3.Length; i++)
            {
                d3[i] = this.series.getData()[index];
                index++;
            }
            for (int i = 0; i < d4.Length; i++)
            {
                d4[i] = this.series.getData()[index];
                index++;
            }
            double dis12 = DTWDistance.Distance(d1, d2);
            double dis21 = DTWDistance.Distance(d2, d1);
            this.println("Dist12: " + dis12 + " vs " + Distance.distance(d1, d2));
            this.println("Dist21: " + dis21 + " vs " + Distance.distance(d2, d1));

            this.println("Dist34: " + DTWDistance.Distance(d3, d4) + " vs " + Distance.distance(d3, d4));
            this.println("Dist43: " + DTWDistance.Distance(d4, d3) + " vs " + Distance.distance(d4, d3));
        }
    }
}
