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
                    MessageBox.Show(this, "File is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ReadDataFromFile readData = new ReadDataFromFile(file);
                NTimeSeries series = readData.read();
                TimeSeriesPlot plot = new TimeSeriesPlot(series);
                plot.Show();
            }
        }

        private void hotSaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotSaxForm form = new HotSaxForm();
            form.Show();
        }

        private void sWABToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SWAB form = new SWAB();
            form.Show();
        }

        private void quadraticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quadratic form = new Quadratic();
            form.Show();
        }

        private void variableLengthMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariableLengthMethod form = new VariableLengthMethod();
            form.Show();
        }

        private void extreamPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtreamPointForm form = new ExtreamPointForm();
            form.Show();
        }

        private void variableLengthWithWDTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VLWDT form = new VLWDT();
            form.Show();
        }

        private void estimateRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstimateRForm form = new EstimateRForm();
            form.Show();
        }
    }
}
