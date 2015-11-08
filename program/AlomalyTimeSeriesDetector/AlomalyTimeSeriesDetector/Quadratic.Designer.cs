namespace AlomalyTimeSeriesDetector
{
    partial class Quadratic
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
            this.quadratic_numDataPoint_label = new System.Windows.Forms.Label();
            this.quadratic_numDataPoint_textBox = new System.Windows.Forms.TextBox();
            this.quadratic_e1_label = new System.Windows.Forms.Label();
            this.quadratic_e1_textBox = new System.Windows.Forms.TextBox();
            this.quadratic_e2_label = new System.Windows.Forms.Label();
            this.quadratic_e2_textBox = new System.Windows.Forms.TextBox();
            this.quadratic_chooseFile_button = new System.Windows.Forms.Button();
            this.quadratic_run_button = new System.Windows.Forms.Button();
            this.quadratic_button_plot = new System.Windows.Forms.Button();
            this.quadratic_richTextBox = new System.Windows.Forms.RichTextBox();
            this.quadratic_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // quadratic_numDataPoint_label
            // 
            this.quadratic_numDataPoint_label.AutoSize = true;
            this.quadratic_numDataPoint_label.Location = new System.Drawing.Point(32, 36);
            this.quadratic_numDataPoint_label.Name = "quadratic_numDataPoint_label";
            this.quadratic_numDataPoint_label.Size = new System.Drawing.Size(111, 13);
            this.quadratic_numDataPoint_label.TabIndex = 0;
            this.quadratic_numDataPoint_label.Text = "Number Of Data Point";
            // 
            // quadratic_numDataPoint_textBox
            // 
            this.quadratic_numDataPoint_textBox.Location = new System.Drawing.Point(149, 33);
            this.quadratic_numDataPoint_textBox.Name = "quadratic_numDataPoint_textBox";
            this.quadratic_numDataPoint_textBox.Size = new System.Drawing.Size(100, 20);
            this.quadratic_numDataPoint_textBox.TabIndex = 1;
            // 
            // quadratic_e1_label
            // 
            this.quadratic_e1_label.AutoSize = true;
            this.quadratic_e1_label.Location = new System.Drawing.Point(281, 36);
            this.quadratic_e1_label.Name = "quadratic_e1_label";
            this.quadratic_e1_label.Size = new System.Drawing.Size(85, 13);
            this.quadratic_e1_label.TabIndex = 2;
            this.quadratic_e1_label.Text = "Regression Error";
            // 
            // quadratic_e1_textBox
            // 
            this.quadratic_e1_textBox.Location = new System.Drawing.Point(372, 33);
            this.quadratic_e1_textBox.Name = "quadratic_e1_textBox";
            this.quadratic_e1_textBox.Size = new System.Drawing.Size(100, 20);
            this.quadratic_e1_textBox.TabIndex = 3;
            // 
            // quadratic_e2_label
            // 
            this.quadratic_e2_label.AutoSize = true;
            this.quadratic_e2_label.Location = new System.Drawing.Point(491, 36);
            this.quadratic_e2_label.Name = "quadratic_e2_label";
            this.quadratic_e2_label.Size = new System.Drawing.Size(131, 13);
            this.quadratic_e2_label.TabIndex = 4;
            this.quadratic_e2_label.Text = "Non-Self Match Threshold";
            // 
            // quadratic_e2_textBox
            // 
            this.quadratic_e2_textBox.Location = new System.Drawing.Point(628, 33);
            this.quadratic_e2_textBox.Name = "quadratic_e2_textBox";
            this.quadratic_e2_textBox.Size = new System.Drawing.Size(100, 20);
            this.quadratic_e2_textBox.TabIndex = 5;
            // 
            // quadratic_chooseFile_button
            // 
            this.quadratic_chooseFile_button.Location = new System.Drawing.Point(149, 81);
            this.quadratic_chooseFile_button.Name = "quadratic_chooseFile_button";
            this.quadratic_chooseFile_button.Size = new System.Drawing.Size(75, 23);
            this.quadratic_chooseFile_button.TabIndex = 6;
            this.quadratic_chooseFile_button.Text = "Choose";
            this.quadratic_chooseFile_button.UseVisualStyleBackColor = true;
            this.quadratic_chooseFile_button.Click += new System.EventHandler(this.quadratic_chooseFile_button_Click);
            // 
            // quadratic_run_button
            // 
            this.quadratic_run_button.Location = new System.Drawing.Point(372, 81);
            this.quadratic_run_button.Name = "quadratic_run_button";
            this.quadratic_run_button.Size = new System.Drawing.Size(75, 23);
            this.quadratic_run_button.TabIndex = 7;
            this.quadratic_run_button.Text = "Run";
            this.quadratic_run_button.UseVisualStyleBackColor = true;
            this.quadratic_run_button.Click += new System.EventHandler(this.quadratic_run_button_Click);
            // 
            // quadratic_button_plot
            // 
            this.quadratic_button_plot.Location = new System.Drawing.Point(628, 81);
            this.quadratic_button_plot.Name = "quadratic_button_plot";
            this.quadratic_button_plot.Size = new System.Drawing.Size(75, 23);
            this.quadratic_button_plot.TabIndex = 8;
            this.quadratic_button_plot.Text = "Plot";
            this.quadratic_button_plot.UseVisualStyleBackColor = true;
            this.quadratic_button_plot.Click += new System.EventHandler(this.quadratic_button_plot_Click);
            // 
            // quadratic_richTextBox
            // 
            this.quadratic_richTextBox.HideSelection = false;
            this.quadratic_richTextBox.Location = new System.Drawing.Point(12, 125);
            this.quadratic_richTextBox.Name = "quadratic_richTextBox";
            this.quadratic_richTextBox.Size = new System.Drawing.Size(830, 327);
            this.quadratic_richTextBox.TabIndex = 9;
            this.quadratic_richTextBox.Text = "";
            // 
            // quadratic_openFileDialog
            // 
            this.quadratic_openFileDialog.FileName = "openFileDialog1";
            // 
            // Quadratic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 464);
            this.Controls.Add(this.quadratic_richTextBox);
            this.Controls.Add(this.quadratic_button_plot);
            this.Controls.Add(this.quadratic_run_button);
            this.Controls.Add(this.quadratic_chooseFile_button);
            this.Controls.Add(this.quadratic_e2_textBox);
            this.Controls.Add(this.quadratic_e2_label);
            this.Controls.Add(this.quadratic_e1_textBox);
            this.Controls.Add(this.quadratic_e1_label);
            this.Controls.Add(this.quadratic_numDataPoint_textBox);
            this.Controls.Add(this.quadratic_numDataPoint_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Quadratic";
            this.Text = "Quadratic Segmentation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label quadratic_numDataPoint_label;
        private System.Windows.Forms.TextBox quadratic_numDataPoint_textBox;
        private System.Windows.Forms.Label quadratic_e1_label;
        private System.Windows.Forms.TextBox quadratic_e1_textBox;
        private System.Windows.Forms.Label quadratic_e2_label;
        private System.Windows.Forms.TextBox quadratic_e2_textBox;
        private System.Windows.Forms.Button quadratic_chooseFile_button;
        private System.Windows.Forms.Button quadratic_run_button;
        private System.Windows.Forms.Button quadratic_button_plot;
        private System.Windows.Forms.RichTextBox quadratic_richTextBox;
        private System.Windows.Forms.OpenFileDialog quadratic_openFileDialog;
    }
}