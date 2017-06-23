using DailyHighScanner.Models;
using DailyHighScanner.Windows;
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
        private Symbol SelectedSymbol { get; set; }
        private ScannerWindow _scanner;
        private ChartWindow _5minChart;
        private ChartWindow _15minChart;
        private ChartWindow _30minChart;
        private ChartWindow _2hrChart;
        private ChartWindow _dChart;
        private TradingWindow _activeTrades;
        private OrderBookWindow _orderBook;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSettings();
            InitializeCharts();
            InitializeScanner();
        }

        private void InitializeOrderBook()
        {
            if (_orderBook == null || _orderBook.IsDisposed)
            {
                _orderBook = new OrderBookWindow();
                _orderBook.MdiParent = this;
                _orderBook.Show();
            }
            else
            {
                _orderBook.Focus();
                _orderBook.WindowState = FormWindowState.Normal;
            }
        }

        private void InitializeActiveTrades()
        {
            if (_activeTrades == null || _activeTrades.IsDisposed)
            {
                _activeTrades = new TradingWindow();
                _activeTrades.MdiParent = this;
                _activeTrades.Show();
            }
            else
            {
                _activeTrades.Focus();
                _activeTrades.WindowState = FormWindowState.Normal;
            }
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
                _5minChart = new ChartWindow(PeriodType._5Min, "5");
                _5minChart.MdiParent = this;
                _5minChart.Show();
            }
            else
            {
                _5minChart.Focus();
                _5minChart.WindowState = FormWindowState.Normal;
            }

            if (SelectedSymbol != null)
            {
                _5minChart.SelectSymbol(SelectedSymbol);
            }
        }

        private void Initialize15MinChart()
        {
            if (_15minChart == null || _15minChart.IsDisposed)
            {
                _15minChart = new ChartWindow(PeriodType._15Min, "15");
                _15minChart.MdiParent = this;
                _15minChart.Show();
            }
            else
            {
                _15minChart.Focus();
                _15minChart.WindowState = FormWindowState.Normal;
            }

            if (SelectedSymbol != null)
            {
                _15minChart.SelectSymbol(SelectedSymbol);
            }
        }

        private void Initialize30MinChart()
        {
            if (_30minChart == null || _30minChart.IsDisposed)
            {
                _30minChart = new ChartWindow(PeriodType._30Min, "30");
                _30minChart.MdiParent = this;
                _30minChart.Show();
            }
            else
            {
                _30minChart.Focus();
                _30minChart.WindowState = FormWindowState.Normal;
            }

            if (SelectedSymbol != null)
            {
                _30minChart.SelectSymbol(SelectedSymbol);
            }
        }

        private void Initialize2HrMinChart()
        {
            if (_2hrChart == null || _2hrChart.IsDisposed)
            {
                _2hrChart = new ChartWindow(PeriodType._2Hr, "2H");
                _2hrChart.MdiParent = this;
                _2hrChart.Show();
            }
            else
            {
                _2hrChart.Focus();
                _2hrChart.WindowState = FormWindowState.Normal;
            }

            if (SelectedSymbol != null)
            {
                _2hrChart.SelectSymbol(SelectedSymbol);
            }
        }

        private void InitializeDChart()
        {
            if (_dChart == null || _dChart.IsDisposed)
            {
                _dChart = new ChartWindow(PeriodType._D, "D");
                _dChart.MdiParent = this;
                _dChart.Show();
            }
            else
            {
                _dChart.Focus();
                _dChart.WindowState = FormWindowState.Normal;
            }

            if (SelectedSymbol != null)
            {
                _dChart.SelectSymbol(SelectedSymbol);
            }
        }

        private void InitializeCharts()
        {
            Initialize5MinChart();
            Initialize15MinChart();
            Initialize30MinChart();
            Initialize2HrMinChart();
            InitializeDChart();
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
            else
            {
                _scanner.Focus();
                _scanner.WindowState = FormWindowState.Normal;
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

            if(!string.IsNullOrEmpty(SelectedSymbol?.Name))
            {
                var last = _scanner.Tickers.FirstOrDefault(s => s.Name == SelectedSymbol.Name).Last;
                _5minChart.UpdateLast((double)last);
                _15minChart.UpdateLast((double)last);
                _30minChart.UpdateLast((double)last);
                _2hrChart.UpdateLast((double)last);
                _dChart.UpdateLast((double)last);
            }
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
                openSymbolWindow.Close();
            }
        }

        private void SwitchSymbol(Symbol symbol)
        {
            toolStripLabelSymbol.Text = $"{symbol.Name}@{symbol.Exchange}";
            SelectedSymbol = symbol;
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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            if(settingsWindow.ShowDialog() == DialogResult.OK)
            {
                Globals.Settings.Save(_settingsFilepath);
                _scanner.SetUpdateInterval(Globals.Settings.ScannerRefreshIntervalMs);
                settingsWindow.Close();
                InitializeCharts();
            }
        }

        private void chart5minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize5MinChart();
        }

        private void chart15minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize15MinChart();
        }

        private void chart30minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize30MinChart();
        }

        private void chart2hrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize2HrMinChart();
        }

        private void chartDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeDChart();
        }

        private void tradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeActiveTrades();
        }

        private void orderBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeOrderBook();
        }
    }
}
