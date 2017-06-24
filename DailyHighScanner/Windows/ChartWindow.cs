using Cryptowatch.Core;
using Cryptowatch.Core.Db;
using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cryptowatch.App.Windows
{
    public partial class ChartWindow : Form
    {
        private Symbol _symbol { get; set; } = new Symbol();
        private Timer _timer { get; set; }
        public ChartPeriod PeriodType { get; private set; }
        public string PeriodTitle { get; private set; }
        private bool _updating = false;

        public ChartWindow(ChartPeriod periodType, string periodTitle)
        {
            InitializeComponent();
            InitializeTimer();
            PeriodType = periodType;
            PeriodTitle = periodTitle;
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 5000;
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        public void SetUpdateInterval(int interval)
        {
            _timer.Interval = interval;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            stockChart.Visible = false;
        }

        public void SetSymbol(Symbol symbol)
        {
            stockChart.Visible = false;
            _updating = false;
            _symbol = symbol;
            this.Text = $"{_symbol.Name}@{_symbol.Exchange} ({PeriodTitle})";
            statusLabel.Text = "LOADING CHART";
            using (var db = new CryptowatchDbContext())
            {
                if(db.Candlesticks.Count(c => c.Symbol == symbol.Name
                        && c.Period == PeriodType) == 0)
                {
                    statusLabel.Text = "NO DATA";
                    return;
                }
            }
            UpdateChart();
        }

        public void UpdateChart()
        {
            if(_updating || string.IsNullOrEmpty(_symbol.Name))
            {
                return;
            }

            string symbol = _symbol.Name;

            Task.Run(new Action(() =>
            {
                try
                {
                    if (symbol != _symbol.Name)
                    {
                        return;
                    }

                    using (var db = new CryptowatchDbContext())
                    {
                        _updating = true;
                        
                        var data = db.Candlesticks.Where(c => c.Symbol == _symbol.Name
                                        && c.Period == PeriodType)
                                        .OrderBy(c => c.Date)
                                        .ToList();
                        
                        if(data?.Count == 0)
                        {
                            _updating = false;
                            return;
                        }

                        stockChart.Invoke(new Action(() =>
                        {
                            // General chart settings
                            stockChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                            stockChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                            stockChart.Series.Clear();
                            stockChart.Legends.Clear();
                            stockChart.Titles.Clear();
                            stockChart.Titles.Add($"{_symbol.Name}, {_symbol.Exchange}, {PeriodTitle}");
                            stockChart.ChartAreas[0].AxisY.IsMarginVisible = true;
                            stockChart.ChartAreas[0].AxisX.IsMarginVisible = true;
                            stockChart.ChartAreas[0].AxisY.LabelStyle.Format = "#.########";
                            stockChart.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 8;
                            stockChart.ChartAreas[0].AxisY.LabelAutoFitMaxFontSize = 8;

                            // Volume
                            if (Globals.Settings.ChartVolume)
                            {
                                var volumeSeries = new Series("volume");
                                stockChart.Series.Add(volumeSeries);
                                stockChart.Series["volume"].ChartType = SeriesChartType.Column;
                                stockChart.Series["volume"].YAxisType = AxisType.Secondary;
                                stockChart.Series["volume"].Color = Color.GhostWhite;
                                stockChart.ChartAreas[0].AxisY2.Minimum = 0;
                                stockChart.ChartAreas[0].AxisY2.Maximum = (double)data.Max(d => d.Volume) * 1.5;
                                stockChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;
                                for (int i = 0; i < data.Count; i++)
                                {
                                    stockChart.Series["volume"].Points.AddXY(data[i].Date, data[i].Volume);
                                }
                            }

                            // SMA 10
                            if (Globals.Settings.ChartSMA10)
                            {
                                var sma10Series = new Series("sma10");
                                stockChart.Series.Add(sma10Series);
                                stockChart.Series["sma10"].ChartType = SeriesChartType.Line;
                                stockChart.Series["sma10"]["LineTension"] = "1";
                                stockChart.Series["sma10"].Color = Color.Red;
                                for (int i = 0; i < data.Count; i++)
                                {
                                    if (data[i].SMA10 == 0) continue;
                                    stockChart.Series["sma10"].Points.AddXY(data[i].Date, (float)data[i].SMA10);
                                }
                            }

                            // SMA 20
                            if (Globals.Settings.ChartSMA20)
                            {
                                var sma20Series = new Series("sma20");
                                stockChart.Series.Add(sma20Series);
                                stockChart.Series["sma20"].ChartType = SeriesChartType.Line;
                                stockChart.Series["sma20"]["LineTension"] = "1";
                                stockChart.Series["sma20"].Color = Color.Blue;
                                for (int i = 0; i < data.Count; i++)
                                {
                                    if (data[i].SMA20 == 0) continue;
                                    stockChart.Series["sma20"].Points.AddXY(data[i].Date, (float)data[i].SMA20);
                                }
                            }

                            // Resistance levels
                            if (Globals.Settings.ChartResistanceLevels)
                            {
                                var resistance = data.Take(data.Count - 3).Where(d => d.Close > d.Open).OrderByDescending(d => d.High).Take(Globals.Settings.ChartNumberOfLevels).ToList();
                                for (int i = 0; i < Globals.Settings.ChartNumberOfLevels && resistance.Count > i; i++)
                                {
                                    var name = $"resistance_{i}";
                                    var resistanceSeries = new Series(name);
                                    stockChart.Series.Add(resistanceSeries);
                                    stockChart.Series[name].ChartType = SeriesChartType.Line;
                                    stockChart.Series[name].Color = Color.LightGray;
                                    var draw = false;
                                    for (int j = 0; j < data.Count; j++)
                                    {
                                        if (data[j].High == resistance[i].High)
                                        {
                                            draw = true;
                                        }

                                        if (draw)
                                        {
                                            stockChart.Series[name].Points.AddXY(data[j].Date, (float)resistance[i].High);
                                        }
                                    }
                                }
                            }

                            // Support levels
                            if (Globals.Settings.ChartSupportLevels)
                            {
                                var support = data.Take(data.Count - 3).Where(d => d.Close < d.Open && d.Close < data.Last().Close).OrderByDescending(d => d.Low).Take(Globals.Settings.ChartNumberOfLevels).ToList();
                                for (int i = 0; i < Globals.Settings.ChartNumberOfLevels && support.Count > i; i++)
                                {
                                    var name = $"support_{i}";
                                    var resistanceSeries = new Series(name);
                                    stockChart.Series.Add(resistanceSeries);
                                    stockChart.Series[name].ChartType = SeriesChartType.Line;
                                    stockChart.Series[name].Color = Color.LightGray;
                                    var draw = false;
                                    for (int j = 0; j < data.Count; j++)
                                    {
                                        if (data[j].Low == support[i].Low)
                                        {
                                            draw = true;
                                        }

                                        if (draw)
                                        {
                                            stockChart.Series[name].Points.AddXY(data[j].Date, (float)support[i].Low);
                                        }
                                    }
                                }
                            }

                            // Price series
                            var priceSeries = new Series("price");
                            stockChart.Series.Add(priceSeries);
                            stockChart.Series["price"].ChartType = SeriesChartType.Candlestick;
                            stockChart.Series["price"]["OpenCloseStyle"] = "Triangle";
                            stockChart.Series["price"]["ShowOpenClose"] = "Both";
                            stockChart.Series["price"]["PointWidth"] = "0.5";
                            stockChart.Series["price"]["PriceUpColor"] = "Green";
                            stockChart.Series["price"]["PriceDownColor"] = "Red";
                            stockChart.Series["price"].Color = Color.DarkSlateGray;
                            var min = data.Min(d => d.Low);
                            stockChart.ChartAreas[0].AxisY.Minimum = (double)(min - (min / 100));
                            stockChart.ChartAreas[0].AxisY.Maximum = (double)(data.Max(d => d.High));
                            for (int i = 0; i < data.Count; i++)
                            {
                                stockChart.Series["price"].Points.AddXY(data[i].Date, data[i].High);
                                stockChart.Series["price"].Points[i].YValues[1] = (double)data[i].Low;
                                stockChart.Series["price"].Points[i].YValues[2] = (double)data[i].Open;
                                stockChart.Series["price"].Points[i].YValues[3] = (double)data[i].Close;
                            }

                            // Other
                            toolStripLabel.Text = $"Last update: {DateTime.Now.ToString("HH:mm:ss")}";
                            stockChart.Visible = true;
                        }));

                        _updating = false;
                    }
                }
                catch
                {
                    UpdateChart();
                }
            }));
        }

        public void UpdateLast(double last)
        {
            if (string.IsNullOrEmpty(_symbol.Name))
            {
                return;
            }

            if(stockChart.InvokeRequired)
            {
                stockChart.Invoke(new Action(() => { UpdateLastOnChart(last); }));
            }
            else
            {
                UpdateLastOnChart(last);
            }
        }

        private void UpdateLastOnChart(double @value)
        {
            try
            {
                stockChart.Series["price"].Points[stockChart.Series["price"].Points.Count - 1].YValues[3] = @value;
            }
            catch { }
        }
    }
}
