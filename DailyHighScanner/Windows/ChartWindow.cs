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

namespace DailyHighScanner
{
    public partial class ChartWindow : Form
    {
        private Symbol _symbol { get; set; } = new Symbol();
        private Timer _timer { get; set; }
        public PeriodType PeriodType { get; private set; }
        public string PeriodTitle { get; private set; }
        private bool _updating = false;

        public ChartWindow(PeriodType periodType, string periodTitle)
        {
            InitializeComponent();
            InitializeTimer();
            PeriodType = periodType;
            PeriodTitle = periodTitle;
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = Globals.Settings.ChartRefreshIntervalMs;
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

        public void SelectSymbol(Symbol symbol)
        {
            stockChart.Visible = false;
            _updating = false;
            _symbol = symbol;
            this.Text = $"{_symbol.Name}@{_symbol.Exchange} ({PeriodTitle})";
            statusLabel.Text = "LOADING CHART";
            UpdateChart();
        }

        public void UpdateChart()
        {
            if (_updating) return;

            if(string.IsNullOrEmpty(_symbol.Name))
            {
                return;
            }

            Task.Run(new Action(() =>
            {
                try
                {
                    _updating = true;
                    string symbol = _symbol.Name;
                    var data = Poloniex.Chart(_symbol, PeriodType, Globals.Settings.ChartPeriodsToShow);
                    if(symbol != _symbol.Name)
                    {
                        return;
                    }
                    var test = data;
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

                        var timespan = data.Skip(1).Take(1).FirstOrDefault().Date - data.First().Date;

                        if(Globals.Settings.ChartVolume)
                        {
                            // Volume series
                            var volumeSeries = new Series("volume");
                            stockChart.Series.Add(volumeSeries);
                            stockChart.Series["volume"].ChartType = SeriesChartType.Column;
                            stockChart.Series["volume"].YAxisType = AxisType.Secondary;
                            stockChart.Series["volume"].Color = Color.GhostWhite;
                            stockChart.ChartAreas[0].AxisY2.Minimum = 0;
                            stockChart.ChartAreas[0].AxisY2.Maximum = data.Max(d => d.Volume) * 1.5;
                            stockChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;
                            for (int i = 0; i < data.Count; i++)
                            {
                                stockChart.Series["volume"].Points.AddXY(data[i].Date, data[i].Volume);
                            }
                            stockChart.Series["volume"].Points.AddXY(data.Last().Date.AddMinutes(timespan.TotalMinutes), 0);
                        }

                        if(Globals.Settings.ChartSMA10)
                        {
                            // Average 1
                            var avgSeries = new Series("average");
                            stockChart.Series.Add(avgSeries);
                            stockChart.Series["average"].ChartType = SeriesChartType.Line;
                            stockChart.Series["average"]["LineTension"] = "1";
                            stockChart.Series["average"].Color = Color.Red;
                            for (int i = 0; i < data.Count; i++)
                            {
                                if (data[i].SMA10 == 0) continue;
                                stockChart.Series["average"].Points.AddXY(data[i].Date, data[i].SMA10);
                            }
                        }

                        if(Globals.Settings.ChartSMA20)
                        {
                            // Average 2
                            var avgSeries2 = new Series("average2");
                            stockChart.Series.Add(avgSeries2);
                            stockChart.Series["average2"].ChartType = SeriesChartType.Line;
                            stockChart.Series["average2"]["LineTension"] = "1";
                            stockChart.Series["average2"].Color = Color.Blue;
                            for (int i = 0; i < data.Count; i++)
                            {
                                if (data[i].SMA20 == 0) continue;
                                stockChart.Series["average2"].Points.AddXY(data[i].Date, data[i].SMA20);
                            }
                        }

                        // Resistance
                        if(Globals.Settings.ChartResistanceLevels)
                        {
                            var resistance = data.Take(data.Count - 3).Where(d => d.Close > d.Open).OrderByDescending(d => d.High).Take(Globals.Settings.ChartNumberOfLevels).ToList();
                            for (int i = 0; i < Globals.Settings.ChartNumberOfLevels; i++)
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
                                        stockChart.Series[name].Points.AddXY(data[j].Date, resistance[i].High);
                                    }
                                }
                            }
                        }

                        // Support
                        if (Globals.Settings.ChartSupportLevels)
                        {
                            var support = data.Take(data.Count - 3).Where(d => d.Close < d.Open && d.Close < data.Last().Close).OrderByDescending(d => d.Low).Take(Globals.Settings.ChartNumberOfLevels).ToList();
                            for (int i = 0; i < Globals.Settings.ChartNumberOfLevels; i++)
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
                                        stockChart.Series[name].Points.AddXY(data[j].Date, support[i].Low);
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
                        stockChart.Series["price"]["PriceUpColor"] = "DarkGreen";
                        stockChart.Series["price"]["PriceDownColor"] = "DarkRed";
                        stockChart.Series["price"].Color = Color.DarkSlateGray;
                        //stockChart.Series["price"].BorderColor = Color.Transparent;

                        var min = data.Min(d => d.Low);
                        stockChart.ChartAreas[0].AxisY.Minimum = min - (min / 100);
                        stockChart.ChartAreas[0].AxisY.Maximum = data.Max(d => d.High); ;
                        for (int i = 0; i < data.Count; i++)
                        {
                            stockChart.Series["price"].Points.AddXY(data[i].Date, data[i].High);
                            stockChart.Series["price"].Points[i].YValues[1] = data[i].Low;
                            stockChart.Series["price"].Points[i].YValues[2] = data[i].Open;
                            stockChart.Series["price"].Points[i].YValues[3] = data[i].Close;
                        }

                        // Other
                        toolStripLabel.Text = $"Last update: {DateTime.Now.ToString("HH:mm:ss")}";
                        stockChart.Visible = true;
                    }));
                    _updating = false;
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

        private void stockChart_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            //stockChart.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            stockChart.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

            // ...
        }
    }
}
