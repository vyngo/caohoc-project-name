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
    public partial class ExtreamPointForm : Form
    {
        private NTimeSeries series = null;
        private List<NSubsequence> segments = null;
        private int from = 0;
        private int to = 0;
        public ExtreamPointForm()
        {
            InitializeComponent();
        }

        private void extreamPoint_chooseFile_button_Click(object sender, EventArgs e)
        {
            this.extreamPoint_log_richTextBox.Text = "";
            DialogResult result = this.extreamPoint_openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = this.extreamPoint_openFileDialog.FileName;
                if (string.IsNullOrEmpty(file))
                {
                    MessageBox.Show(this, "File is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ReadDataFromFile readData = new ReadDataFromFile(file);
                if (!String.IsNullOrEmpty(this.extreamPoint_numDataPoints_textBox.Text))
                {
                    string numDataText = this.extreamPoint_numDataPoints_textBox.Text;
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
                    this.to = from + this.series.getNumberOfDataPoint() - 1;
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
            this.extreamPoint_log_richTextBox.AppendText(msg + "\n");
        }

        private void extreamPoint_plot_button_Click(object sender, EventArgs e)
        {
            if (this.series == null)
            {
                MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.segments == null)
            {
                MessageBox.Show(this, "There is no segments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NTimeSeries tmp = new NTimeSeries();
            for (int i = 0; i < this.series.getData().Count; i++)
            {
                tmp.addData(this.series.getData()[i]);
            }
            TimeSeriesPlot plot = new TimeSeriesPlot(tmp, null, segments);
            plot.Show();
        }

        private void extreamPoint_run_button_Click(object sender, EventArgs e)
        {
            Stopwatch stNor = new Stopwatch();
            stNor.Start();
            try
            {
                if (this.series == null)
                {
                    MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (String.IsNullOrEmpty(this.exxtreamPoint_ratio_textBox.Text))
                {
                    MessageBox.Show(this, "Max Error is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double r = double.Parse(this.exxtreamPoint_ratio_textBox.Text);
                if (String.IsNullOrEmpty(this.extreamPoint_minLength_textBox.Text))
                {
                  //  MessageBox.Show(this, "Minimum length is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  //  return;
                    this.extreamPoint_minLength_textBox.Text = "0";
                }
                int minLength = int.Parse(this.extreamPoint_minLength_textBox.Text);
                NTimeSeries tmp = new NTimeSeries();
                for (int i = 0; i < this.series.getData().Count; i++)
                {
                    tmp.addData(this.series.getData()[i]);
                }
                ExtreamePointSegmentation seg = new ExtreamePointSegmentation(this.extreamPoint_log_richTextBox);
                this.segments = seg.segmentation(tmp, r, minLength);
                println("===========RESULT=================");
                println("Number of segments: " + this.segments.Count);
                foreach (NSubsequence s in this.segments)
                {
                    println(s.getStart() + "-" + s.getEnd() + " length: " + (s.getEnd() - s.getStart() + 1));
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                stNor.Stop();
                string timeNor = stNor.Elapsed.ToString();
                this.println("Time: " + timeNor);
            }
            println("Finish Extream Point");
        }
    }
}
