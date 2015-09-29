using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlomalyTimeSeriesDetector.common;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                if (string.IsNullOrEmpty(file))
                {
                    MessageBox.Show("File is not valid");
                    return;
                }
                ReadDataFromFile readData = new ReadDataFromFile(file);
                NTimeSeries series = readData.read();
                TimeSeriesPlot plot = new TimeSeriesPlot(series);
                plot.Show();
            }
        }
    }
}
