namespace AlomalyTimeSeriesDetector
{
    partial class EstimateRForm
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
            this.numDataPoint_label = new System.Windows.Forms.Label();
            this.numDataPoint_textBox = new System.Windows.Forms.TextBox();
            this.delta_label = new System.Windows.Forms.Label();
            this.delta_textBox = new System.Windows.Forms.TextBox();
            this.result_richTextBox = new System.Windows.Forms.RichTextBox();
            this.chooseData_button = new System.Windows.Forms.Button();
            this.run_button = new System.Windows.Forms.Button();
            this.choose_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // numDataPoint_label
            // 
            this.numDataPoint_label.AutoSize = true;
            this.numDataPoint_label.Location = new System.Drawing.Point(44, 47);
            this.numDataPoint_label.Name = "numDataPoint_label";
            this.numDataPoint_label.Size = new System.Drawing.Size(111, 13);
            this.numDataPoint_label.TabIndex = 0;
            this.numDataPoint_label.Text = "Number Of Data Point";
            // 
            // numDataPoint_textBox
            // 
            this.numDataPoint_textBox.Location = new System.Drawing.Point(161, 44);
            this.numDataPoint_textBox.Name = "numDataPoint_textBox";
            this.numDataPoint_textBox.Size = new System.Drawing.Size(100, 20);
            this.numDataPoint_textBox.TabIndex = 1;
            // 
            // delta_label
            // 
            this.delta_label.AutoSize = true;
            this.delta_label.Location = new System.Drawing.Point(311, 47);
            this.delta_label.Name = "delta_label";
            this.delta_label.Size = new System.Drawing.Size(32, 13);
            this.delta_label.TabIndex = 2;
            this.delta_label.Text = "Delta";
            // 
            // delta_textBox
            // 
            this.delta_textBox.Location = new System.Drawing.Point(369, 44);
            this.delta_textBox.Name = "delta_textBox";
            this.delta_textBox.Size = new System.Drawing.Size(100, 20);
            this.delta_textBox.TabIndex = 3;
            // 
            // result_richTextBox
            // 
            this.result_richTextBox.Location = new System.Drawing.Point(23, 120);
            this.result_richTextBox.Name = "result_richTextBox";
            this.result_richTextBox.Size = new System.Drawing.Size(551, 257);
            this.result_richTextBox.TabIndex = 4;
            this.result_richTextBox.Text = "";
            // 
            // chooseData_button
            // 
            this.chooseData_button.Location = new System.Drawing.Point(161, 81);
            this.chooseData_button.Name = "chooseData_button";
            this.chooseData_button.Size = new System.Drawing.Size(75, 23);
            this.chooseData_button.TabIndex = 5;
            this.chooseData_button.Text = "Choose";
            this.chooseData_button.UseVisualStyleBackColor = true;
            this.chooseData_button.Click += new System.EventHandler(this.chooseData_button_Click);
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(369, 81);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(75, 23);
            this.run_button.TabIndex = 6;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // 
            // choose_openFileDialog
            // 
            this.choose_openFileDialog.FileName = "openFileDialog1";
            // 
            // EstimateRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 404);
            this.Controls.Add(this.run_button);
            this.Controls.Add(this.chooseData_button);
            this.Controls.Add(this.result_richTextBox);
            this.Controls.Add(this.delta_textBox);
            this.Controls.Add(this.delta_label);
            this.Controls.Add(this.numDataPoint_textBox);
            this.Controls.Add(this.numDataPoint_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EstimateRForm";
            this.Text = "EstimateRForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numDataPoint_label;
        private System.Windows.Forms.TextBox numDataPoint_textBox;
        private System.Windows.Forms.Label delta_label;
        private System.Windows.Forms.TextBox delta_textBox;
        private System.Windows.Forms.RichTextBox result_richTextBox;
        private System.Windows.Forms.Button chooseData_button;
        private System.Windows.Forms.Button run_button;
        private System.Windows.Forms.OpenFileDialog choose_openFileDialog;
    }
}