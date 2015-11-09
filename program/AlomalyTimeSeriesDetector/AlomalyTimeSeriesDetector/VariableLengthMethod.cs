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
            }
            else 
            {
                this.varlength_e2_label.Text = "Non-Self Match Threshold";
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

        private void println(string msg)
        {
            this.varlength_log_richTextBox.AppendText(msg + "\n");
        }
    }
}
