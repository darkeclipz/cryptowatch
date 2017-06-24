using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptowatch.App.Windows
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
                scannerOnlyBtcMarkets.Checked = Globals.Settings.ScannerOnlyBtcMarkets;
                chartResistanceLevels.Checked = Globals.Settings.ChartResistanceLevels;
                chartSupportLevels.Checked = Globals.Settings.ChartSupportLevels;
                chartNumberOfLevels.Value = Globals.Settings.ChartNumberOfLevels;
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
                Globals.Settings.ScannerOnlyBtcMarkets = scannerOnlyBtcMarkets.Checked;
                Globals.Settings.ChartResistanceLevels = chartResistanceLevels.Checked;
                Globals.Settings.ChartSupportLevels = chartSupportLevels.Checked;
                Globals.Settings.ChartNumberOfLevels = (int)chartNumberOfLevels.Value;

                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonTestPoloniexApi(object sender, EventArgs e)
        {
            MessageBox.Show("Testing API credentials...", "API Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
