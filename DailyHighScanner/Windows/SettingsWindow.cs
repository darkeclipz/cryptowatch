using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyHighScanner.Windows
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            try
            {
                updateIntervalScanner.Value = Globals.Settings.ScannerRefreshIntervalMs;
                updateIntervalCharts.Value = Globals.Settings.ChartRefreshIntervalMs;
                chartPeriods.Value = Globals.Settings.ChartPeriodsToShow;
                poloniexApiKey.Text = Globals.Settings.PoloniexApiKey;
                poloniexApiSecret.Text = Globals.Settings.PoloniexApiSecret;
                chartEMA10.Checked = Globals.Settings.ChartSMA10;
                chartEMA20.Checked = Globals.Settings.ChartSMA20;
                chartVolume.Checked = Globals.Settings.ChartVolume;
                filterTopVolume.Value = Globals.Settings.ScannerFilterTopVolumeCount;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Globals.Settings.ScannerRefreshIntervalMs = (int)updateIntervalScanner.Value;
                Globals.Settings.ChartRefreshIntervalMs = (int)updateIntervalCharts.Value;
                Globals.Settings.ChartPeriodsToShow = (int)chartPeriods.Value;
                Globals.Settings.PoloniexApiKey = poloniexApiKey.Text;
                Globals.Settings.PoloniexApiSecret = poloniexApiSecret.Text;
                Globals.Settings.ChartSMA10 = chartEMA10.Checked;
                Globals.Settings.ChartSMA20 = chartEMA20.Checked;
                Globals.Settings.ChartVolume = chartVolume.Checked;
                Globals.Settings.ScannerFilterTopVolumeCount = (int)filterTopVolume.Value;

                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Testing API credentials...", "API Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chartEMA10_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
