namespace AlomalyTimeSeriesDetector
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotSaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sWABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadraticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variableLengthMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extreamPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.variableLengthWithWDTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.hotSaxToolStripMenuItem,
            this.sWABToolStripMenuItem,
            this.quadraticToolStripMenuItem,
            this.variableLengthMethodToolStripMenuItem,
            this.extreamPointToolStripMenuItem,
            this.variableLengthWithWDTToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.loadDataToolStripMenuItem.Text = "Load Data";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // hotSaxToolStripMenuItem
            // 
            this.hotSaxToolStripMenuItem.Name = "hotSaxToolStripMenuItem";
            this.hotSaxToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.hotSaxToolStripMenuItem.Text = "Hot Sax";
            this.hotSaxToolStripMenuItem.Click += new System.EventHandler(this.hotSaxToolStripMenuItem_Click);
            // 
            // sWABToolStripMenuItem
            // 
            this.sWABToolStripMenuItem.Name = "sWABToolStripMenuItem";
            this.sWABToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.sWABToolStripMenuItem.Text = "SWAB";
            this.sWABToolStripMenuItem.Click += new System.EventHandler(this.sWABToolStripMenuItem_Click);
            // 
            // quadraticToolStripMenuItem
            // 
            this.quadraticToolStripMenuItem.Name = "quadraticToolStripMenuItem";
            this.quadraticToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.quadraticToolStripMenuItem.Text = "Quadratic";
            this.quadraticToolStripMenuItem.Click += new System.EventHandler(this.quadraticToolStripMenuItem_Click);
            // 
            // variableLengthMethodToolStripMenuItem
            // 
            this.variableLengthMethodToolStripMenuItem.Name = "variableLengthMethodToolStripMenuItem";
            this.variableLengthMethodToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.variableLengthMethodToolStripMenuItem.Text = "Variable Length Method";
            this.variableLengthMethodToolStripMenuItem.Click += new System.EventHandler(this.variableLengthMethodToolStripMenuItem_Click);
            // 
            // extreamPointToolStripMenuItem
            // 
            this.extreamPointToolStripMenuItem.Name = "extreamPointToolStripMenuItem";
            this.extreamPointToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.extreamPointToolStripMenuItem.Text = "Extream Point";
            this.extreamPointToolStripMenuItem.Click += new System.EventHandler(this.extreamPointToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is demo application for finding anomalies subsequences in time series data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "2015 - 2016";
            // 
            // variableLengthWithWDTToolStripMenuItem
            // 
            this.variableLengthWithWDTToolStripMenuItem.Name = "variableLengthWithWDTToolStripMenuItem";
            this.variableLengthWithWDTToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.variableLengthWithWDTToolStripMenuItem.Text = "Variable Length With WDT";
            this.variableLengthWithWDTToolStripMenuItem.Click += new System.EventHandler(this.variableLengthWithWDTToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(802, 352);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Anomaly Detector For Time Series ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem hotSaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sWABToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadraticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variableLengthMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extreamPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variableLengthWithWDTToolStripMenuItem;
    }
}

