namespace Cryptowatch.App.Windows
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartNumberOfLevels = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.chartResistanceLevels = new System.Windows.Forms.CheckBox();
            this.chartSupportLevels = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.updateIntervalCharts = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chartVolume = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chartEMA20 = new System.Windows.Forms.CheckBox();
            this.chartPeriods = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.chartEMA10 = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.scannerOnlyBtcMarkets = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.updateIntervalScanner = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.filterTopVolume = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.connectionString = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.poloniexApiKey = new System.Windows.Forms.TextBox();
            this.poloniexApiSecret = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.apiTimeout = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumberOfLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalCharts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeriods)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalScanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterTopVolume)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apiTimeout)).BeginInit();
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(513, 275);
            this.tabControl.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartNumberOfLevels);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.chartResistanceLevels);
            this.tabPage3.Controls.Add(this.chartSupportLevels);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.updateIntervalCharts);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.chartVolume);
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Controls.Add(this.chartEMA20);
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
            // chartNumberOfLevels
            // 
            this.chartNumberOfLevels.Location = new System.Drawing.Point(342, 170);
            this.chartNumberOfLevels.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.chartNumberOfLevels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.chartNumberOfLevels.Name = "chartNumberOfLevels";
            this.chartNumberOfLevels.Size = new System.Drawing.Size(120, 20);
            this.chartNumberOfLevels.TabIndex = 14;
            this.chartNumberOfLevels.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(266, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "# of Levels:";
            // 
            // chartResistanceLevels
            // 
            this.chartResistanceLevels.AutoSize = true;
            this.chartResistanceLevels.Location = new System.Drawing.Point(240, 136);
            this.chartResistanceLevels.Name = "chartResistanceLevels";
            this.chartResistanceLevels.Size = new System.Drawing.Size(109, 17);
            this.chartResistanceLevels.TabIndex = 12;
            this.chartResistanceLevels.Text = "Resistance levels";
            this.chartResistanceLevels.UseVisualStyleBackColor = true;
            // 
            // chartSupportLevels
            // 
            this.chartSupportLevels.AutoSize = true;
            this.chartSupportLevels.Location = new System.Drawing.Point(369, 136);
            this.chartSupportLevels.Name = "chartSupportLevels";
            this.chartSupportLevels.Size = new System.Drawing.Size(93, 17);
            this.chartSupportLevels.TabIndex = 11;
            this.chartSupportLevels.Text = "Support levels";
            this.chartSupportLevels.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "m/s";
            // 
            // updateIntervalCharts
            // 
            this.updateIntervalCharts.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updateIntervalCharts.Location = new System.Drawing.Point(159, 50);
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
            this.updateIntervalCharts.TabIndex = 9;
            this.updateIntervalCharts.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Update interval charts:";
            // 
            // chartVolume
            // 
            this.chartVolume.AutoSize = true;
            this.chartVolume.Location = new System.Drawing.Point(23, 193);
            this.chartVolume.Name = "chartVolume";
            this.chartVolume.Size = new System.Drawing.Size(61, 17);
            this.chartVolume.TabIndex = 7;
            this.chartVolume.Text = "Volume";
            this.chartVolume.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(23, 170);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Bollinger bands";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // chartEMA20
            // 
            this.chartEMA20.AutoSize = true;
            this.chartEMA20.Location = new System.Drawing.Point(23, 147);
            this.chartEMA20.Name = "chartEMA20";
            this.chartEMA20.Size = new System.Drawing.Size(64, 17);
            this.chartEMA20.TabIndex = 5;
            this.chartEMA20.Text = "EMA 20";
            this.chartEMA20.UseVisualStyleBackColor = true;
            // 
            // chartPeriods
            // 
            this.chartPeriods.Location = new System.Drawing.Point(159, 13);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Periods:";
            // 
            // chartEMA10
            // 
            this.chartEMA10.AutoSize = true;
            this.chartEMA10.Location = new System.Drawing.Point(23, 124);
            this.chartEMA10.Name = "chartEMA10";
            this.chartEMA10.Size = new System.Drawing.Size(64, 17);
            this.chartEMA10.TabIndex = 2;
            this.chartEMA10.Text = "EMA 10";
            this.chartEMA10.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.scannerOnlyBtcMarkets);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.updateIntervalScanner);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.filterTopVolume);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(505, 249);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Scanner";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // scannerOnlyBtcMarkets
            // 
            this.scannerOnlyBtcMarkets.AutoSize = true;
            this.scannerOnlyBtcMarkets.Location = new System.Drawing.Point(12, 82);
            this.scannerOnlyBtcMarkets.Name = "scannerOnlyBtcMarkets";
            this.scannerOnlyBtcMarkets.Size = new System.Drawing.Size(111, 17);
            this.scannerOnlyBtcMarkets.TabIndex = 8;
            this.scannerOnlyBtcMarkets.Text = "Only BTC markets";
            this.scannerOnlyBtcMarkets.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "m/s";
            // 
            // updateIntervalScanner
            // 
            this.updateIntervalScanner.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updateIntervalScanner.Location = new System.Drawing.Point(157, 45);
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
            this.updateIntervalScanner.TabIndex = 6;
            this.updateIntervalScanner.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Update interval scanner:";
            // 
            // filterTopVolume
            // 
            this.filterTopVolume.Location = new System.Drawing.Point(157, 13);
            this.filterTopVolume.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.filterTopVolume.Name = "filterTopVolume";
            this.filterTopVolume.Size = new System.Drawing.Size(120, 20);
            this.filterTopVolume.TabIndex = 1;
            this.filterTopVolume.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Filter top volume #";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.connectionString);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 249);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Database";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // connectionString
            // 
            this.connectionString.Location = new System.Drawing.Point(129, 12);
            this.connectionString.Name = "connectionString";
            this.connectionString.Size = new System.Drawing.Size(363, 20);
            this.connectionString.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Connection string:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.apiTimeout);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(505, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "API";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.poloniexApiKey);
            this.groupBox1.Controls.Add(this.poloniexApiSecret);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 130);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Poloniex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "API key:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonTestPoloniexApi);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "API secret:";
            // 
            // poloniexApiKey
            // 
            this.poloniexApiKey.Location = new System.Drawing.Point(99, 28);
            this.poloniexApiKey.Name = "poloniexApiKey";
            this.poloniexApiKey.Size = new System.Drawing.Size(375, 20);
            this.poloniexApiKey.TabIndex = 3;
            // 
            // poloniexApiSecret
            // 
            this.poloniexApiSecret.Location = new System.Drawing.Point(99, 60);
            this.poloniexApiSecret.Name = "poloniexApiSecret";
            this.poloniexApiSecret.PasswordChar = '*';
            this.poloniexApiSecret.Size = new System.Drawing.Size(375, 20);
            this.poloniexApiSecret.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "The API key and secret will be saved encrypted in the settings file.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(461, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "m/s";
            // 
            // apiTimeout
            // 
            this.apiTimeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.apiTimeout.Location = new System.Drawing.Point(335, 211);
            this.apiTimeout.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.apiTimeout.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.apiTimeout.Name = "apiTimeout";
            this.apiTimeout.Size = new System.Drawing.Size(120, 20);
            this.apiTimeout.TabIndex = 12;
            this.apiTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(267, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Timeout:";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 331);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumberOfLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalCharts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeriods)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalScanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterTopVolume)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apiTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox poloniexApiSecret;
        private System.Windows.Forms.TextBox poloniexApiKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chartEMA20;
        private System.Windows.Forms.NumericUpDown chartPeriods;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chartEMA10;
        private System.Windows.Forms.CheckBox chartVolume;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.NumericUpDown filterTopVolume;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown updateIntervalCharts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown updateIntervalScanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox connectionString;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox scannerOnlyBtcMarkets;
        private System.Windows.Forms.NumericUpDown chartNumberOfLevels;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chartResistanceLevels;
        private System.Windows.Forms.CheckBox chartSupportLevels;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown apiTimeout;
        private System.Windows.Forms.Label label13;
    }
}