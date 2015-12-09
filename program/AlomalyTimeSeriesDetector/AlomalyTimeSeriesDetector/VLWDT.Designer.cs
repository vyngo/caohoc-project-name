namespace AlomalyTimeSeriesDetector
{
    partial class VLWDT
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
            this.numDataPoints_label = new System.Windows.Forms.Label();
            this.numDataPoint_textBox = new System.Windows.Forms.TextBox();
            this.e1_label = new System.Windows.Forms.Label();
            this.e1_textBox = new System.Windows.Forms.TextBox();
            this.k_label = new System.Windows.Forms.Label();
            this.k_textBox = new System.Windows.Forms.TextBox();
            this.alpha_label = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.loadData_button = new System.Windows.Forms.Button();
            this.run_button = new System.Windows.Forms.Button();
            this.plot_button = new System.Windows.Forms.Button();
            this.log_richTextBox = new System.Windows.Forms.RichTextBox();
            this.result_richTextBox = new System.Windows.Forms.RichTextBox();
            this.result_label = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // numDataPoints_label
            // 
            this.numDataPoints_label.AutoSize = true;
            this.numDataPoints_label.Location = new System.Drawing.Point(12, 39);
            this.numDataPoints_label.Name = "numDataPoints_label";
            this.numDataPoints_label.Size = new System.Drawing.Size(111, 13);
            this.numDataPoints_label.TabIndex = 0;
            this.numDataPoints_label.Text = "Number Of Data Point";
            // 
            // numDataPoint_textBox
            // 
            this.numDataPoint_textBox.Location = new System.Drawing.Point(129, 35);
            this.numDataPoint_textBox.Name = "numDataPoint_textBox";
            this.numDataPoint_textBox.Size = new System.Drawing.Size(100, 20);
            this.numDataPoint_textBox.TabIndex = 1;
            // 
            // e1_label
            // 
            this.e1_label.AutoSize = true;
            this.e1_label.Location = new System.Drawing.Point(257, 39);
            this.e1_label.Name = "e1_label";
            this.e1_label.Size = new System.Drawing.Size(85, 13);
            this.e1_label.TabIndex = 2;
            this.e1_label.Text = "Regression Error";
            // 
            // e1_textBox
            // 
            this.e1_textBox.Location = new System.Drawing.Point(348, 36);
            this.e1_textBox.Name = "e1_textBox";
            this.e1_textBox.Size = new System.Drawing.Size(100, 20);
            this.e1_textBox.TabIndex = 3;
            // 
            // k_label
            // 
            this.k_label.AutoSize = true;
            this.k_label.Location = new System.Drawing.Point(482, 39);
            this.k_label.Name = "k_label";
            this.k_label.Size = new System.Drawing.Size(14, 13);
            this.k_label.TabIndex = 4;
            this.k_label.Text = "K";
            // 
            // k_textBox
            // 
            this.k_textBox.Location = new System.Drawing.Point(502, 36);
            this.k_textBox.Name = "k_textBox";
            this.k_textBox.Size = new System.Drawing.Size(100, 20);
            this.k_textBox.TabIndex = 5;
            // 
            // alpha_label
            // 
            this.alpha_label.AutoSize = true;
            this.alpha_label.Location = new System.Drawing.Point(647, 39);
            this.alpha_label.Name = "alpha_label";
            this.alpha_label.Size = new System.Drawing.Size(97, 13);
            this.alpha_label.TabIndex = 6;
            this.alpha_label.Text = "Anomaly Threshold";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(750, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // loadData_button
            // 
            this.loadData_button.Location = new System.Drawing.Point(129, 99);
            this.loadData_button.Name = "loadData_button";
            this.loadData_button.Size = new System.Drawing.Size(75, 23);
            this.loadData_button.TabIndex = 8;
            this.loadData_button.Text = "Choose";
            this.loadData_button.UseVisualStyleBackColor = true;
            this.loadData_button.Click += new System.EventHandler(this.loadData_button_Click);
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(348, 99);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(75, 23);
            this.run_button.TabIndex = 9;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // 
            // plot_button
            // 
            this.plot_button.Location = new System.Drawing.Point(567, 99);
            this.plot_button.Name = "plot_button";
            this.plot_button.Size = new System.Drawing.Size(75, 23);
            this.plot_button.TabIndex = 10;
            this.plot_button.Text = "Plot";
            this.plot_button.UseVisualStyleBackColor = true;
            this.plot_button.Click += new System.EventHandler(this.plot_button_Click);
            // 
            // log_richTextBox
            // 
            this.log_richTextBox.HideSelection = false;
            this.log_richTextBox.Location = new System.Drawing.Point(15, 136);
            this.log_richTextBox.Name = "log_richTextBox";
            this.log_richTextBox.Size = new System.Drawing.Size(627, 362);
            this.log_richTextBox.TabIndex = 11;
            this.log_richTextBox.Text = "";
            // 
            // result_richTextBox
            // 
            this.result_richTextBox.HideSelection = false;
            this.result_richTextBox.Location = new System.Drawing.Point(650, 163);
            this.result_richTextBox.Name = "result_richTextBox";
            this.result_richTextBox.Size = new System.Drawing.Size(200, 335);
            this.result_richTextBox.TabIndex = 12;
            this.result_richTextBox.Text = "";
            // 
            // result_label
            // 
            this.result_label.AutoSize = true;
            this.result_label.Location = new System.Drawing.Point(729, 136);
            this.result_label.Name = "result_label";
            this.result_label.Size = new System.Drawing.Size(37, 13);
            this.result_label.TabIndex = 13;
            this.result_label.Text = "Result";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // VLWDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 519);
            this.Controls.Add(this.result_label);
            this.Controls.Add(this.result_richTextBox);
            this.Controls.Add(this.log_richTextBox);
            this.Controls.Add(this.plot_button);
            this.Controls.Add(this.run_button);
            this.Controls.Add(this.loadData_button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.alpha_label);
            this.Controls.Add(this.k_textBox);
            this.Controls.Add(this.k_label);
            this.Controls.Add(this.e1_textBox);
            this.Controls.Add(this.e1_label);
            this.Controls.Add(this.numDataPoint_textBox);
            this.Controls.Add(this.numDataPoints_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VLWDT";
            this.Text = "Varible Length With DTW";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numDataPoints_label;
        private System.Windows.Forms.TextBox numDataPoint_textBox;
        private System.Windows.Forms.Label e1_label;
        private System.Windows.Forms.TextBox e1_textBox;
        private System.Windows.Forms.Label k_label;
        private System.Windows.Forms.TextBox k_textBox;
        private System.Windows.Forms.Label alpha_label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button loadData_button;
        private System.Windows.Forms.Button run_button;
        private System.Windows.Forms.Button plot_button;
        private System.Windows.Forms.RichTextBox log_richTextBox;
        private System.Windows.Forms.RichTextBox result_richTextBox;
        private System.Windows.Forms.Label result_label;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}