namespace AlomalyTimeSeriesDetector
{
    partial class HotSaxForm
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
            this.numberDataPoint_textBox = new System.Windows.Forms.TextBox();
            this.numberDataPoint_label = new System.Windows.Forms.Label();
            this.subsequenceLength_label = new System.Windows.Forms.Label();
            this.subsequence_texbox = new System.Windows.Forms.TextBox();
            this.paaLength_label = new System.Windows.Forms.Label();
            this.paaLength_textbox = new System.Windows.Forms.TextBox();
            this.run_button = new System.Windows.Forms.Button();
            this.loadData_button = new System.Windows.Forms.Button();
            this.hotSax_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.plot_button = new System.Windows.Forms.Button();
            this.hotsaxLog_richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // numberDataPoint_textBox
            // 
            this.numberDataPoint_textBox.Location = new System.Drawing.Point(146, 23);
            this.numberDataPoint_textBox.Name = "numberDataPoint_textBox";
            this.numberDataPoint_textBox.Size = new System.Drawing.Size(100, 20);
            this.numberDataPoint_textBox.TabIndex = 0;
            // 
            // numberDataPoint_label
            // 
            this.numberDataPoint_label.AutoSize = true;
            this.numberDataPoint_label.Location = new System.Drawing.Point(12, 23);
            this.numberDataPoint_label.Name = "numberDataPoint_label";
            this.numberDataPoint_label.Size = new System.Drawing.Size(116, 13);
            this.numberDataPoint_label.TabIndex = 1;
            this.numberDataPoint_label.Text = "Number Of Data Points";
            // 
            // subsequenceLength_label
            // 
            this.subsequenceLength_label.AutoSize = true;
            this.subsequenceLength_label.Location = new System.Drawing.Point(270, 23);
            this.subsequenceLength_label.Name = "subsequenceLength_label";
            this.subsequenceLength_label.Size = new System.Drawing.Size(109, 13);
            this.subsequenceLength_label.TabIndex = 2;
            this.subsequenceLength_label.Text = "Subsequence Length";
            this.subsequenceLength_label.Click += new System.EventHandler(this.subsequenceLength_label_Click);
            // 
            // subsequence_texbox
            // 
            this.subsequence_texbox.Location = new System.Drawing.Point(395, 23);
            this.subsequence_texbox.Name = "subsequence_texbox";
            this.subsequence_texbox.Size = new System.Drawing.Size(100, 20);
            this.subsequence_texbox.TabIndex = 3;
            // 
            // paaLength_label
            // 
            this.paaLength_label.AutoSize = true;
            this.paaLength_label.Location = new System.Drawing.Point(545, 23);
            this.paaLength_label.Name = "paaLength_label";
            this.paaLength_label.Size = new System.Drawing.Size(64, 13);
            this.paaLength_label.TabIndex = 4;
            this.paaLength_label.Text = "PAA Length";
            // 
            // paaLength_textbox
            // 
            this.paaLength_textbox.Location = new System.Drawing.Point(628, 23);
            this.paaLength_textbox.Name = "paaLength_textbox";
            this.paaLength_textbox.Size = new System.Drawing.Size(100, 20);
            this.paaLength_textbox.TabIndex = 5;
            // 
            // run_button
            // 
            this.run_button.Location = new System.Drawing.Point(395, 68);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(75, 23);
            this.run_button.TabIndex = 6;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.run_button_Click);
            // 
            // loadData_button
            // 
            this.loadData_button.AutoSize = true;
            this.loadData_button.Location = new System.Drawing.Point(146, 68);
            this.loadData_button.Name = "loadData_button";
            this.loadData_button.Size = new System.Drawing.Size(75, 23);
            this.loadData_button.TabIndex = 8;
            this.loadData_button.Text = "Choose";
            this.loadData_button.UseVisualStyleBackColor = true;
            this.loadData_button.Click += new System.EventHandler(this.loadData_button_Click);
            // 
            // hotSax_openFileDialog
            // 
            this.hotSax_openFileDialog.FileName = "openFileDialog1";
            // 
            // plot_button
            // 
            this.plot_button.Location = new System.Drawing.Point(628, 68);
            this.plot_button.Name = "plot_button";
            this.plot_button.Size = new System.Drawing.Size(75, 23);
            this.plot_button.TabIndex = 7;
            this.plot_button.Text = "Plot";
            this.plot_button.UseVisualStyleBackColor = true;
            this.plot_button.Click += new System.EventHandler(this.plot_button_Click);
            // 
            // hotsaxLog_richTextBox
            // 
            this.hotsaxLog_richTextBox.Location = new System.Drawing.Point(15, 115);
            this.hotsaxLog_richTextBox.Name = "hotsaxLog_richTextBox";
            this.hotsaxLog_richTextBox.Size = new System.Drawing.Size(820, 406);
            this.hotsaxLog_richTextBox.TabIndex = 9;
            this.hotsaxLog_richTextBox.Text = "";
            // 
            // HotSaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 533);
            this.Controls.Add(this.hotsaxLog_richTextBox);
            this.Controls.Add(this.loadData_button);
            this.Controls.Add(this.plot_button);
            this.Controls.Add(this.run_button);
            this.Controls.Add(this.paaLength_textbox);
            this.Controls.Add(this.paaLength_label);
            this.Controls.Add(this.subsequence_texbox);
            this.Controls.Add(this.subsequenceLength_label);
            this.Controls.Add(this.numberDataPoint_label);
            this.Controls.Add(this.numberDataPoint_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotSaxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HotSaxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numberDataPoint_textBox;
        private System.Windows.Forms.Label numberDataPoint_label;
        private System.Windows.Forms.Label subsequenceLength_label;
        private System.Windows.Forms.TextBox subsequence_texbox;
        private System.Windows.Forms.Label paaLength_label;
        private System.Windows.Forms.TextBox paaLength_textbox;
        private System.Windows.Forms.Button run_button;
        private System.Windows.Forms.Button loadData_button;
        private System.Windows.Forms.OpenFileDialog hotSax_openFileDialog;
        private System.Windows.Forms.Button plot_button;
        private System.Windows.Forms.RichTextBox hotsaxLog_richTextBox;
    }
}