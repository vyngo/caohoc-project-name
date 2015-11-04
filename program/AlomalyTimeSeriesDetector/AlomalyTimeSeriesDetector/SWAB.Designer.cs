namespace AlomalyTimeSeriesDetector
{
    partial class SWAB
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
            this.swab_maxerror_label = new System.Windows.Forms.Label();
            this.swab_maxerror_textBox = new System.Windows.Forms.TextBox();
            this.swab_buffersize_label = new System.Windows.Forms.Label();
            this.swab_buffersize_textBox = new System.Windows.Forms.TextBox();
            this.swab_choosefile_button = new System.Windows.Forms.Button();
            this.swab_run_button = new System.Windows.Forms.Button();
            this.swab_plot_button = new System.Windows.Forms.Button();
            this.swab_richTextBox = new System.Windows.Forms.RichTextBox();
            this.swab_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.swab_numDataPoint_label = new System.Windows.Forms.Label();
            this.swab_numDataPoint_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // swab_maxerror_label
            // 
            this.swab_maxerror_label.AutoSize = true;
            this.swab_maxerror_label.Location = new System.Drawing.Point(299, 32);
            this.swab_maxerror_label.Name = "swab_maxerror_label";
            this.swab_maxerror_label.Size = new System.Drawing.Size(52, 13);
            this.swab_maxerror_label.TabIndex = 0;
            this.swab_maxerror_label.Text = "Max Error";
            // 
            // swab_maxerror_textBox
            // 
            this.swab_maxerror_textBox.Location = new System.Drawing.Point(357, 29);
            this.swab_maxerror_textBox.Name = "swab_maxerror_textBox";
            this.swab_maxerror_textBox.Size = new System.Drawing.Size(100, 20);
            this.swab_maxerror_textBox.TabIndex = 1;
            // 
            // swab_buffersize_label
            // 
            this.swab_buffersize_label.AutoSize = true;
            this.swab_buffersize_label.Location = new System.Drawing.Point(530, 32);
            this.swab_buffersize_label.Name = "swab_buffersize_label";
            this.swab_buffersize_label.Size = new System.Drawing.Size(58, 13);
            this.swab_buffersize_label.TabIndex = 2;
            this.swab_buffersize_label.Text = "Buffer Size";
            // 
            // swab_buffersize_textBox
            // 
            this.swab_buffersize_textBox.Location = new System.Drawing.Point(594, 30);
            this.swab_buffersize_textBox.Name = "swab_buffersize_textBox";
            this.swab_buffersize_textBox.Size = new System.Drawing.Size(100, 20);
            this.swab_buffersize_textBox.TabIndex = 3;
            // 
            // swab_choosefile_button
            // 
            this.swab_choosefile_button.Location = new System.Drawing.Point(185, 74);
            this.swab_choosefile_button.Name = "swab_choosefile_button";
            this.swab_choosefile_button.Size = new System.Drawing.Size(75, 23);
            this.swab_choosefile_button.TabIndex = 4;
            this.swab_choosefile_button.Text = "Choose";
            this.swab_choosefile_button.UseVisualStyleBackColor = true;
            this.swab_choosefile_button.Click += new System.EventHandler(this.swab_choosefile_button_Click);
            // 
            // swab_run_button
            // 
            this.swab_run_button.Location = new System.Drawing.Point(357, 73);
            this.swab_run_button.Name = "swab_run_button";
            this.swab_run_button.Size = new System.Drawing.Size(75, 23);
            this.swab_run_button.TabIndex = 5;
            this.swab_run_button.Text = "Run";
            this.swab_run_button.UseVisualStyleBackColor = true;
            this.swab_run_button.Click += new System.EventHandler(this.swab_run_button_Click);
            // 
            // swab_plot_button
            // 
            this.swab_plot_button.Location = new System.Drawing.Point(533, 74);
            this.swab_plot_button.Name = "swab_plot_button";
            this.swab_plot_button.Size = new System.Drawing.Size(75, 23);
            this.swab_plot_button.TabIndex = 6;
            this.swab_plot_button.Text = "Plot";
            this.swab_plot_button.UseVisualStyleBackColor = true;
            this.swab_plot_button.Click += new System.EventHandler(this.swab_plot_button_Click);
            // 
            // swab_richTextBox
            // 
            this.swab_richTextBox.HideSelection = false;
            this.swab_richTextBox.Location = new System.Drawing.Point(13, 121);
            this.swab_richTextBox.Name = "swab_richTextBox";
            this.swab_richTextBox.Size = new System.Drawing.Size(901, 302);
            this.swab_richTextBox.TabIndex = 7;
            this.swab_richTextBox.Text = "";
            // 
            // swab_openFileDialog
            // 
            this.swab_openFileDialog.FileName = "openFileDialog1";
            // 
            // swab_numDataPoint_label
            // 
            this.swab_numDataPoint_label.AutoSize = true;
            this.swab_numDataPoint_label.Location = new System.Drawing.Point(30, 33);
            this.swab_numDataPoint_label.Name = "swab_numDataPoint_label";
            this.swab_numDataPoint_label.Size = new System.Drawing.Size(111, 13);
            this.swab_numDataPoint_label.TabIndex = 8;
            this.swab_numDataPoint_label.Text = "Number Of Data Point";
            // 
            // swab_numDataPoint_textbox
            // 
            this.swab_numDataPoint_textbox.Location = new System.Drawing.Point(145, 29);
            this.swab_numDataPoint_textbox.Name = "swab_numDataPoint_textbox";
            this.swab_numDataPoint_textbox.Size = new System.Drawing.Size(100, 20);
            this.swab_numDataPoint_textbox.TabIndex = 9;
            // 
            // SWAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 435);
            this.Controls.Add(this.swab_numDataPoint_textbox);
            this.Controls.Add(this.swab_numDataPoint_label);
            this.Controls.Add(this.swab_richTextBox);
            this.Controls.Add(this.swab_plot_button);
            this.Controls.Add(this.swab_run_button);
            this.Controls.Add(this.swab_choosefile_button);
            this.Controls.Add(this.swab_buffersize_textBox);
            this.Controls.Add(this.swab_buffersize_label);
            this.Controls.Add(this.swab_maxerror_textBox);
            this.Controls.Add(this.swab_maxerror_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SWAB";
            this.Text = "SWAB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label swab_maxerror_label;
        private System.Windows.Forms.TextBox swab_maxerror_textBox;
        private System.Windows.Forms.Label swab_buffersize_label;
        private System.Windows.Forms.TextBox swab_buffersize_textBox;
        private System.Windows.Forms.Button swab_choosefile_button;
        private System.Windows.Forms.Button swab_run_button;
        private System.Windows.Forms.Button swab_plot_button;
        private System.Windows.Forms.RichTextBox swab_richTextBox;
        private System.Windows.Forms.OpenFileDialog swab_openFileDialog;
        private System.Windows.Forms.Label swab_numDataPoint_label;
        private System.Windows.Forms.TextBox swab_numDataPoint_textbox;
    }
}