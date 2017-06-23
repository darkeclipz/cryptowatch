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
        public int NumberOfCandles { get; private set; }
        public PeriodType PeriodType { get; private set; }
        public string PeriodTitle { get; private set; }

        public ChartWindow(int numberOfCandles, PeriodType periodType, string periodTitle)
        {
            InitializeComponent();
            InitializeTimer();
            NumberOfCandles = numberOfCandles;
            PeriodType = periodType;
            PeriodTitle = periodTitle;
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000 * 10;
            _timer.Tick += timer_Tick;
            _timer.Start();
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
            _symbol = symbol;
            this.Text = $"{_symbol.Name}@{_symbol.Exchange} ({PeriodTitle})";
            statusLabel.Text = "LOADING CHART";
            UpdateChart();
        }

        public void UpdateChart()
        {
            if(string.IsNullOrEmpty(_symbol.Name))
            {
                return;
            }

            Task.Run(new Action(() =>
            {
                try
                {
                    _timer.Stop();
                    var data = Poloniex.Chart(_symbol, PeriodType, NumberOfCandles);
                    var test = data;
                    stockChart.Invoke(new Action(() =>
                    {
                        var series = new Series("price");
                        stockChart.Series.Clear();
                        stockChart.Legends.Clear();
                        stockChart.Series.Add(series);
                        stockChart.Titles.Clear();
                        stockChart.Titles.Add($"{_symbol.Name}, {_symbol.Exchange}, {PeriodTitle}");
                        stockChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                        stockChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                        stockChart.Series["price"].ChartType = SeriesChartType.Candlestick;
                        stockChart.Series["price"]["OpenCloseStyle"] = "Triangle";
                        stockChart.Series["price"]["ShowOpenClose"] = "Both";
                        stockChart.Series["price"]["PointWidth"] = "0.5";
                        stockChart.Series["price"]["PriceUpColor"] = "Green";
                        stockChart.Series["price"]["PriceDownColor"] = "Red";
                        stockChart.ChartAreas[0].AxisX.IsMarginVisible = false;
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
                        toolStripLabel.Text = $"Last update: {DateTime.Now.ToString("HH:mm:ss")}";
                        stockChart.Visible = true;
                    }));
                    _timer.Start();
                }
                catch(Exception ex)
                {
                    UpdateChart();
                }
            }));
        }
    }
}
