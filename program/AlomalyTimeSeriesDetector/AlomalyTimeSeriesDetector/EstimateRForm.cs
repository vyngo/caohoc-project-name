﻿using System;
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

        private void run_button_Click(object sender, EventArgs e)
        {
            NTimeSeries tmp = new NTimeSeries();
            for (int i = 0; i < this.series.getData().Count; i++)
            {
                tmp.addData(this.series.getData()[i]);
            }
            if (String.IsNullOrEmpty(this.delta_textBox.Text))
            {
                MessageBox.Show(this, "Delta is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double delta = double.Parse(this.delta_textBox.Text);
            double[] arr = tmp.getData().ToArray();
            double min = Utils.min(arr);
            double max = Utils.max(arr);
            double absoluteMax = Math.Abs(max);
            double absoluteMin = Math.Abs(min);
            double maxR = double.MaxValue;
            double minR = 1.0;
            if (max * min > 0) {
                maxR = (absoluteMax > absoluteMin) ? absoluteMax / absoluteMin : absoluteMin / absoluteMax;
            }
            else if (max * min == 0)
            {
                maxR = (absoluteMax > 0) ? absoluteMax : absoluteMin;
            }
            else {
                maxR = (absoluteMax > absoluteMin) ? ((absoluteMax + absoluteMin) / absoluteMin) : ((absoluteMax + absoluteMin) / absoluteMax);
            }
            maxR = Math.Round(maxR, 2);
            writeResult("Range: " + minR + " - " + maxR);
            //ExtreamePointSegmentation seg = new ExtreamePointSegmentation(this.result_richTextBox);
            
        }
    }
}
