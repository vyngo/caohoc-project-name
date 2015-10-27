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
    public partial class HotSaxForm : Form
    {
        private NTimeSeries series = null;
        private List<NSubsequence> anomalies = new List<NSubsequence>();
        private int subsequencesLength = 0;
        private int numDataPoint = 0;
        private int paaLength = 0;
        private double[] anomalizedSeries;
        private double[] drawData;
        private int breakpoint = 8;
        public HotSaxForm()
        {
            InitializeComponent();
        }

        private void subsequenceLength_label_Click(object sender, EventArgs e)
        {

        }

        private void loadData_button_Click(object sender, EventArgs e)
        {
            this.hotsaxLog_richTextBox.Text = "";
            DialogResult result = hotSax_openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = hotSax_openFileDialog.FileName;
                if (string.IsNullOrEmpty(file))
                {
                    MessageBox.Show(this, "File is not valid", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                ReadDataFromFile readData = new ReadDataFromFile(file);
                this.series = readData.read();
                println("Load data successfully: " + this.series.getNumberOfDataPoint() + " points");
                Console.WriteLine("Done");
            }
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            Stopwatch stNor = new Stopwatch();
            stNor.Start();
            try{
                if (this.series == null) {
                    MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(String.IsNullOrEmpty(this.numberDataPoint_textBox.Text)){
                    MessageBox.Show(this, "number data point is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.numDataPoint = int.Parse(this.numberDataPoint_textBox.Text);
                if(String.IsNullOrEmpty(this.subsequence_texbox.Text)){
                     MessageBox.Show(this, "Subsequence length is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.subsequencesLength = int.Parse(this.subsequence_texbox.Text);
                if(String.IsNullOrEmpty(this.paaLength_textbox.Text)){
                     MessageBox.Show(this, "Paa length is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.paaLength = int.Parse(this.paaLength_textbox.Text);
                this.anomalizedSeries = Normalize.ZeroMin(this.series.getData().ToArray(), this.numDataPoint);
                this.drawData = new double[this.numDataPoint];
                for (int i = 0; i < this.numDataPoint; i++) {
                    this.drawData[i] = this.series.getData()[i];
                }
                HotSax hotsax = new HotSax(this.hotsaxLog_richTextBox);
                int anomalIndex = hotsax.run(this.anomalizedSeries, this.paaLength, this.subsequencesLength, this.breakpoint, this.drawData);
                //this.println("Anomal index: " + anomalIndex);
                NSubsequence anomaly = new NSubsequence();
                anomaly.setStart(anomalIndex);
                anomaly.setEnd(anomalIndex + this.subsequencesLength - 1);
                this.anomalies.Add(anomaly);
            }catch(Exception ex){
            }finally{
               stNor.Stop();
               string timeNor = stNor.Elapsed.ToString();
               this.println("Time: " + timeNor);
            }
            Console.WriteLine("Finish HotSax");
        }

        private void plot_button_Click(object sender, EventArgs e)
        {
            if (this.series == null)
            {
                MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            NTimeSeries tmp = new NTimeSeries();
            for (int i = 0; i < this.numDataPoint; i++) {
                tmp.addData(this.series.getData()[i]);
            }
            TimeSeriesPlot plot = new TimeSeriesPlot(tmp, this.anomalies);
            plot.Show();
        }

        private void println(string msg){
            this.hotsaxLog_richTextBox.AppendText(msg + "\n");
        }
    }
}
