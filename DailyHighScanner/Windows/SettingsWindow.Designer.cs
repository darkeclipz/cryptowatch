namespace DailyHighScanner.Windows
{
    partial class SettingsWindow
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.updateIntervalCharts = new System.Windows.Forms.NumericUpDown();
            this.updateIntervalScanner = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.poloniexApiSecret = new System.Windows.Forms.TextBox();
            this.poloniexApiKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartEMA10 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chartPeriods = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalCharts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalScanner)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(449, 293);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Confirm";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update interval scanner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Update interval charts:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(513, 275);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.updateIntervalCharts);
            this.tabPage1.Controls.Add(this.updateIntervalScanner);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // updateIntervalCharts
            // 
            this.updateIntervalCharts.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updateIntervalCharts.Location = new System.Drawing.Point(154, 44);
            this.updateIntervalCharts.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.updateIntervalCharts.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updateIntervalCharts.Name = "updateIntervalCharts";
            this.updateIntervalCharts.Size = new System.Drawing.Size(120, 20);
            this.updateIntervalCharts.TabIndex = 3;
            this.updateIntervalCharts.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // updateIntervalScanner
            // 
            this.updateIntervalScanner.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updateIntervalScanner.Location = new System.Drawing.Point(154, 12);
            this.updateIntervalScanner.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.updateIntervalScanner.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updateIntervalScanner.Name = "updateIntervalScanner";
            this.updateIntervalScanner.Size = new System.Drawing.Size(120, 20);
            this.updateIntervalScanner.TabIndex = 2;
            this.updateIntervalScanner.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.poloniexApiSecret);
            this.tabPage2.Controls.Add(this.poloniexApiKey);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(505, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "API";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(421, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "The API key and secret will be saved encrypted in the settings file.";
            // 
            // poloniexApiSecret
            // 
            this.poloniexApiSecret.Location = new System.Drawing.Point(99, 43);
            this.poloniexApiSecret.Name = "poloniexApiSecret";
            this.poloniexApiSecret.PasswordChar = '*';
            this.poloniexApiSecret.Size = new System.Drawing.Size(397, 20);
            this.poloniexApiSecret.TabIndex = 4;
            // 
            // poloniexApiKey
            // 
            this.poloniexApiKey.Location = new System.Drawing.Point(99, 11);
            this.poloniexApiKey.Name = "poloniexApiKey";
            this.poloniexApiKey.Size = new System.Drawing.Size(397, 20);
            this.poloniexApiKey.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "API secret:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "API key:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "m/s";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "m/s";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Restart required if any settings are changed!";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox3);
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.chartPeriods);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.chartEMA10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(505, 249);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Charts";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chartEMA10
            // 
            this.chartEMA10.AutoSize = true;
            this.chartEMA10.Location = new System.Drawing.Point(31, 58);
            this.chartEMA10.Name = "chartEMA10";
            this.chartEMA10.Size = new System.Drawing.Size(64, 17);
            this.chartEMA10.TabIndex = 2;
            this.chartEMA10.Text = "EMA 10";
            this.chartEMA10.UseVisualStyleBackColor = true;
            this.chartEMA10.CheckedChanged += new System.EventHandler(this.chartEMA10_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Periods:";
            // 
            // chartPeriods
            // 
            this.chartPeriods.Location = new System.Drawing.Point(69, 13);
            this.chartPeriods.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.chartPeriods.Name = "chartPeriods";
            this.chartPeriods.Size = new System.Drawing.Size(120, 20);
            this.chartPeriods.TabIndex = 4;
            this.chartPeriods.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(31, 81);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "EMA 20";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(31, 104);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Bollinger bands";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(219, 58);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(61, 17);
            this.checkBox3.TabIndex = 7;
            this.checkBox3.Text = "Volume";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 331);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalCharts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalScanner)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeriods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown updateIntervalCharts;
        private System.Windows.Forms.NumericUpDown updateIntervalScanner;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox poloniexApiSecret;
        private System.Windows.Forms.TextBox poloniexApiKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown chartPeriods;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chartEMA10;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}