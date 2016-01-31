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
    public partial class EstimateRForm : Form
    {
        private NTimeSeries series = null;
        private int from = 0;
        private int to = 0;

        public EstimateRForm()
        {
            InitializeComponent();
        }

        private void chooseData_button_Click(object sender, EventArgs e)
        {
            this.result_richTextBox.Text = "";
            DialogResult result = this.choose_openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = choose_openFileDialog.FileName;
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
                writeResult("Load data successfully: start from " + this.from + " to " + this.to);
                Console.WriteLine("Done");
            }
        }
        private void writeResult(string msg)
        {
            this.result_richTextBox.AppendText(msg + "\n");
        }
    }
}
