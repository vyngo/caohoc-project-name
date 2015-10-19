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
    public partial class HotSaxForm : Form
    {
        private NTimeSeries series = null;
        private List<NSubsequence> anomalies = new List<NSubsequence>();
        public HotSaxForm()
        {
            InitializeComponent();
        }

        private void subsequenceLength_label_Click(object sender, EventArgs e)
        {

        }

        private void loadData_button_Click(object sender, EventArgs e)
        {
            DialogResult result = hotSax_openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = hotSax_openFileDialog.FileName;
                if (string.IsNullOrEmpty(file))
                {
                    MessageBox.Show("File is not valid", "Error");
                    return;
                }
                ReadDataFromFile readData = new ReadDataFromFile(file);
                this.series = readData.read();
                
            }
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            if (this.series == null) {
                MessageBox.Show("There is no file", "Error");
                return;
            }
        }

        private void plot_button_Click(object sender, EventArgs e)
        {
            if (this.series == null)
            {
                MessageBox.Show("There is no file", "Error");
                return;
            }
        }
    }
}
