using DailyHighScanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyHighScanner
{
    public partial class MainWindow : Form
    {
        private readonly string _settingsFilepath = @"Cryptowatch.Settings.json";
        private List<Symbol> Symbols { get; set; } = new List<Symbol>();
        private ScannerWindow _scanner;
        private ChartWindow _5minChart;
        private ChartWindow _15minChart;
        private ChartWindow _30minChart;
        private ChartWindow _2hrChart;
        private ChartWindow _dChart;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSettings();
            Initialize5MinChart();
            Initialize15MinChart();
            Initialize30MinChart();
            Initialize2HrMinChart();
            InitializeDChart();
            InitializeScanner();
        }

        private void InitializeSettings()
        {
            if(!File.Exists(_settingsFilepath))
            {
                var settings = new Settings();
                settings.Save(_settingsFilepath);
            }

            Globals.Settings = Settings.Load(_settingsFilepath);
        }

        private void Initialize5MinChart()
        {
            if(_5minChart == null || _5minChart.IsDisposed)
            {
                _5minChart = new ChartWindow(50, PeriodType._5Min, "5");
                _5minChart.MdiParent = this;
                _5minChart.Show();
            }
        }

        private void Initialize15MinChart()
        {
            if (_15minChart == null || _15minChart.IsDisposed)
            {
                _15minChart = new ChartWindow(50, PeriodType._15Min, "15");
                _15minChart.MdiParent = this;
                _15minChart.Show();
            }
        }

        private void Initialize30MinChart()
        {
            if (_30minChart == null || _30minChart.IsDisposed)
            {
                _30minChart = new ChartWindow(50, PeriodType._30Min, "30");
                _30minChart.MdiParent = this;
                _30minChart.Show();
            }
        }

        private void Initialize2HrMinChart()
        {
            if (_2hrChart == null || _2hrChart.IsDisposed)
            {
                _2hrChart = new ChartWindow(50, PeriodType._2Hr, "2H");
                _2hrChart.MdiParent = this;
                _2hrChart.Show();
            }
        }

        private void InitializeDChart()
        {
            if (_dChart == null || _dChart.IsDisposed)
            {
                _dChart = new ChartWindow(50, PeriodType._D, "D");
                _dChart.MdiParent = this;
                _dChart.Show();
            }
        }

        public void InitializeScanner()
        {
            if(_scanner == null || _scanner.IsDisposed)
            {
                _scanner = new ScannerWindow();
                _scanner.MdiParent = this;
                _scanner.Show();
                _scanner.OnTickerUpdate += scanner_OnTickerUpdate;
                _scanner.OnSymbolClick += SwitchSymbol;
            }
        }

        private void scanner_OnTickerUpdate()
        {
            Symbols = _scanner.Tickers.Select(t => new Symbol { Name = t.Name, Exchange = t.Exchange }).ToList();
            var usdtBtc = _scanner.Tickers.FirstOrDefault(t => t.Name == "USDT_BTC");
            this.Invoke(new Action(() =>
            {
                toolStripStatusLabelBtc.Text = $"USDT_BTC: {usdtBtc.Last.ToString()}";
            }));
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Daily-High Crypto Scanner (v1.0)\r\nBy DarkEclipz (June 2017)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void symbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openSymbolWindow = new OpenSymbolWindow(Symbols);
            if (openSymbolWindow.ShowDialog() == DialogResult.OK)
            {
                SwitchSymbol(openSymbolWindow.Symbol);
            }
        }

        private void SwitchSymbol(Symbol symbol)
        {
            toolStripLabelSymbol.Text = $"{symbol.Name}@{symbol.Exchange}";
            _5minChart.SelectSymbol(symbol);
            _15minChart.SelectSymbol(symbol);
            _30minChart.SelectSymbol(symbol);
            _2hrChart.SelectSymbol(symbol);
            _dChart.SelectSymbol(symbol);
        }

        private void dailyHighScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeScanner();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
