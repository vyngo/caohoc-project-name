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
    public partial class SWAB : Form
    {
        private NTimeSeries series = null;
        private List<NSubsequence> segments = null;
      
        public SWAB()
        {
            InitializeComponent();
        }

        private void swab_choosefile_button_Click(object sender, EventArgs e)
        {
            this.swab_richTextBox.Text = "";
            DialogResult result = this.swab_openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = this.swab_openFileDialog.FileName;
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
        private void println(string msg)
        {
            this.swab_richTextBox.AppendText(msg + "\n");
        }

        private void swab_run_button_Click(object sender, EventArgs e)
        {
            Stopwatch stNor = new Stopwatch();
            stNor.Start();
            try{
                if (this.series == null) {
                    MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(String.IsNullOrEmpty(this.swab_numDataPoint_textbox.Text)){
                    MessageBox.Show(this, "number data point is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int numDataPoint = int.Parse(this.swab_numDataPoint_textbox.Text);
                if(String.IsNullOrEmpty(this.swab_maxerror_textBox.Text)){
                     MessageBox.Show(this, "Max Error is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double e1 = double.Parse(this.swab_maxerror_textBox.Text);
                if(String.IsNullOrEmpty(this.swab_buffersize_textBox.Text)){
                     MessageBox.Show(this, "Buffer size is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int w = int.Parse(this.swab_buffersize_textBox.Text);
                SWABSegmentation seg = new SWABSegmentation(this.swab_richTextBox);
                NTimeSeries tmp = new NTimeSeries();
                for(int i = 0; i < numDataPoint && i < this.series.getData().Count; i++){
                    tmp.addData(this.series.getData()[i]);
                }
                this.segments = seg.segmentation(tmp, e1, w);
                println("===========RESULT=================");
                println("Number of segments: " + this.segments.Count);
                foreach (NSubsequence s in this.segments) {
                    println(s.getStart() + "-" + s.getEnd() + " length: " + (s.getEnd() - s.getStart() + 1));
                }
            }catch(Exception ex){
            }finally{
               stNor.Stop();
               string timeNor = stNor.Elapsed.ToString();
               this.println("Time: " + timeNor);
            }
            println("Finish SWAB");
        }

        private void swab_plot_button_Click(object sender, EventArgs e)
        {
            if (this.series == null) {
                    MessageBox.Show(this, "There is no file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
               }
            if (this.segments == null) {
                    MessageBox.Show(this, "There is no segments", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            if(String.IsNullOrEmpty(this.swab_numDataPoint_textbox.Text))
            {
                MessageBox.Show(this, "number data point is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int numDataPoint = int.Parse(this.swab_numDataPoint_textbox.Text);
            NTimeSeries tmp = new NTimeSeries();
            for(int i = 0; i < numDataPoint && i < this.series.getData().Count; i++){
                    tmp.addData(this.series.getData()[i]);
                }
            TimeSeriesPlot plot = new TimeSeriesPlot(tmp, null, segments);
            plot.Show();
        }
            
    }
}
