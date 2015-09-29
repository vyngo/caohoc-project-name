namespace AlomalyTimeSeriesDetector
{
    partial class TimeSeriesPlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timeSeriesChart = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // timeSeriesChart
            // 
            this.timeSeriesChart.Location = new System.Drawing.Point(12, 12);
            this.timeSeriesChart.Name = "timeSeriesChart";
            this.timeSeriesChart.ScrollGrace = 0D;
            this.timeSeriesChart.ScrollMaxX = 0D;
            this.timeSeriesChart.ScrollMaxY = 0D;
            this.timeSeriesChart.ScrollMaxY2 = 0D;
            this.timeSeriesChart.ScrollMinX = 0D;
            this.timeSeriesChart.ScrollMinY = 0D;
            this.timeSeriesChart.ScrollMinY2 = 0D;
            this.timeSeriesChart.Size = new System.Drawing.Size(1062, 525);
            this.timeSeriesChart.TabIndex = 0;
            // 
            // TimeSeriesPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 549);
            this.Controls.Add(this.timeSeriesChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeSeriesPlot";
            this.Text = "TimeSeriesPlot";
            this.Load += new System.EventHandler(this.TimeSeriesPlot_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl timeSeriesChart;
    }
}