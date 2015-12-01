namespace AlomalyTimeSeriesDetector
{
    partial class ExtreamPointForm
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
            this.extreamPoint_numDataPoint_label = new System.Windows.Forms.Label();
            this.extreamPoint_numDataPoints_textBox = new System.Windows.Forms.TextBox();
            this.extreamPoint_ratio_label = new System.Windows.Forms.Label();
            this.exxtreamPoint_ratio_textBox = new System.Windows.Forms.TextBox();
            this.extreamPoint_minLength_label = new System.Windows.Forms.Label();
            this.extreamPoint_minLength_textBox = new System.Windows.Forms.TextBox();
            this.extreamPoint_log_richTextBox = new System.Windows.Forms.RichTextBox();
            this.extreamPoint_chooseFile_button = new System.Windows.Forms.Button();
            this.extreamPoint_run_button = new System.Windows.Forms.Button();
            this.extreamPoint_plot_button = new System.Windows.Forms.Button();
            this.extreamPoint_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // extreamPoint_numDataPoint_label
            // 
            this.extreamPoint_numDataPoint_label.AutoSize = true;
            this.extreamPoint_numDataPoint_label.Location = new System.Drawing.Point(26, 40);
            this.extreamPoint_numDataPoint_label.Name = "extreamPoint_numDataPoint_label";
            this.extreamPoint_numDataPoint_label.Size = new System.Drawing.Size(116, 13);
            this.extreamPoint_numDataPoint_label.TabIndex = 0;
            this.extreamPoint_numDataPoint_label.Text = "Number Of Data Points";
            // 
            // extreamPoint_numDataPoints_textBox
            // 
            this.extreamPoint_numDataPoints_textBox.Location = new System.Drawing.Point(159, 37);
            this.extreamPoint_numDataPoints_textBox.Name = "extreamPoint_numDataPoints_textBox";
            this.extreamPoint_numDataPoints_textBox.Size = new System.Drawing.Size(100, 20);
            this.extreamPoint_numDataPoints_textBox.TabIndex = 1;
            // 
            // extreamPoint_ratio_label
            // 
            this.extreamPoint_ratio_label.AutoSize = true;
            this.extreamPoint_ratio_label.Location = new System.Drawing.Point(358, 40);
            this.extreamPoint_ratio_label.Name = "extreamPoint_ratio_label";
            this.extreamPoint_ratio_label.Size = new System.Drawing.Size(32, 13);
            this.extreamPoint_ratio_label.TabIndex = 2;
            this.extreamPoint_ratio_label.Text = "Ratio";
            // 
            // exxtreamPoint_ratio_textBox
            // 
            this.exxtreamPoint_ratio_textBox.Location = new System.Drawing.Point(396, 37);
            this.exxtreamPoint_ratio_textBox.Name = "exxtreamPoint_ratio_textBox";
            this.exxtreamPoint_ratio_textBox.Size = new System.Drawing.Size(100, 20);
            this.exxtreamPoint_ratio_textBox.TabIndex = 3;
            // 
            // extreamPoint_minLength_label
            // 
            this.extreamPoint_minLength_label.AutoSize = true;
            this.extreamPoint_minLength_label.Location = new System.Drawing.Point(586, 40);
            this.extreamPoint_minLength_label.Name = "extreamPoint_minLength_label";
            this.extreamPoint_minLength_label.Size = new System.Drawing.Size(84, 13);
            this.extreamPoint_minLength_label.TabIndex = 4;
            this.extreamPoint_minLength_label.Text = "Minimum Length";
            // 
            // extreamPoint_minLength_textBox
            // 
            this.extreamPoint_minLength_textBox.Location = new System.Drawing.Point(687, 40);
            this.extreamPoint_minLength_textBox.Name = "extreamPoint_minLength_textBox";
            this.extreamPoint_minLength_textBox.Size = new System.Drawing.Size(100, 20);
            this.extreamPoint_minLength_textBox.TabIndex = 5;
            // 
            // extreamPoint_log_richTextBox
            // 
            this.extreamPoint_log_richTextBox.Location = new System.Drawing.Point(12, 125);
            this.extreamPoint_log_richTextBox.Name = "extreamPoint_log_richTextBox";
            this.extreamPoint_log_richTextBox.Size = new System.Drawing.Size(873, 398);
            this.extreamPoint_log_richTextBox.TabIndex = 6;
            this.extreamPoint_log_richTextBox.Text = "";
            // 
            // extreamPoint_chooseFile_button
            // 
            this.extreamPoint_chooseFile_button.Location = new System.Drawing.Point(159, 87);
            this.extreamPoint_chooseFile_button.Name = "extreamPoint_chooseFile_button";
            this.extreamPoint_chooseFile_button.Size = new System.Drawing.Size(75, 23);
            this.extreamPoint_chooseFile_button.TabIndex = 7;
            this.extreamPoint_chooseFile_button.Text = "Choose";
            this.extreamPoint_chooseFile_button.UseVisualStyleBackColor = true;
            this.extreamPoint_chooseFile_button.Click += new System.EventHandler(this.extreamPoint_chooseFile_button_Click);
            // 
            // extreamPoint_run_button
            // 
            this.extreamPoint_run_button.Location = new System.Drawing.Point(396, 87);
            this.extreamPoint_run_button.Name = "extreamPoint_run_button";
            this.extreamPoint_run_button.Size = new System.Drawing.Size(75, 23);
            this.extreamPoint_run_button.TabIndex = 8;
            this.extreamPoint_run_button.Text = "Run";
            this.extreamPoint_run_button.UseVisualStyleBackColor = true;
            this.extreamPoint_run_button.Click += new System.EventHandler(this.extreamPoint_run_button_Click);
            // 
            // extreamPoint_plot_button
            // 
            this.extreamPoint_plot_button.Location = new System.Drawing.Point(687, 87);
            this.extreamPoint_plot_button.Name = "extreamPoint_plot_button";
            this.extreamPoint_plot_button.Size = new System.Drawing.Size(75, 23);
            this.extreamPoint_plot_button.TabIndex = 9;
            this.extreamPoint_plot_button.Text = "Plot";
            this.extreamPoint_plot_button.UseVisualStyleBackColor = true;
            this.extreamPoint_plot_button.Click += new System.EventHandler(this.extreamPoint_plot_button_Click);
            // 
            // extreamPoint_openFileDialog
            // 
            this.extreamPoint_openFileDialog.FileName = "openFileDialog1";
            // 
            // ExtreamPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 535);
            this.Controls.Add(this.extreamPoint_plot_button);
            this.Controls.Add(this.extreamPoint_run_button);
            this.Controls.Add(this.extreamPoint_chooseFile_button);
            this.Controls.Add(this.extreamPoint_log_richTextBox);
            this.Controls.Add(this.extreamPoint_minLength_textBox);
            this.Controls.Add(this.extreamPoint_minLength_label);
            this.Controls.Add(this.exxtreamPoint_ratio_textBox);
            this.Controls.Add(this.extreamPoint_ratio_label);
            this.Controls.Add(this.extreamPoint_numDataPoints_textBox);
            this.Controls.Add(this.extreamPoint_numDataPoint_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtreamPointForm";
            this.Text = "ExtreamPoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label extreamPoint_numDataPoint_label;
        private System.Windows.Forms.TextBox extreamPoint_numDataPoints_textBox;
        private System.Windows.Forms.Label extreamPoint_ratio_label;
        private System.Windows.Forms.TextBox exxtreamPoint_ratio_textBox;
        private System.Windows.Forms.Label extreamPoint_minLength_label;
        private System.Windows.Forms.TextBox extreamPoint_minLength_textBox;
        private System.Windows.Forms.RichTextBox extreamPoint_log_richTextBox;
        private System.Windows.Forms.Button extreamPoint_chooseFile_button;
        private System.Windows.Forms.Button extreamPoint_run_button;
        private System.Windows.Forms.Button extreamPoint_plot_button;
        private System.Windows.Forms.OpenFileDialog extreamPoint_openFileDialog;
    }
}