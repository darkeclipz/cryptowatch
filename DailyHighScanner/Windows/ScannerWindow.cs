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

namespace Cryptowatch.App.Windows
{
    public partial class ScannerWindow : Form
    {
        private Timer _updateTimer { get; set; }
        
        // To do: Move to settings.
        private bool filterHighVolume { get; set; } = true;
        private bool filterHighestLowest { get; set; } = true;
        private bool filterHideLosers { get; set; } = false;
        // ..

        public List<Ticker> Tickers { get; set; } = new List<Ticker>();

        public delegate void TickerUpdate();
        public TickerUpdate OnTickerUpdate;

        public delegate void SymbolClick(Symbol symbol);
        public SymbolClick OnSymbolClick;

        public ScannerWindow()
        {
            InitializeComponent();
            InitializeUpdateTimer();
            toolStripFilterHighVolume.BackColor = filterHighVolume ? Color.LightGreen : Color.Gray;
            toolStripFilterHighestLowest.BackColor = filterHighestLowest ? Color.LightGreen : Color.Gray;
            toolStripFilterHideLosers.BackColor = filterHideLosers ? Color.LightGreen : Color.Gray;
        }

        private void InitializeUpdateTimer()
        {
            _updateTimer = new Timer();
            _updateTimer.Tick += updateTimer_Tick;
            _updateTimer.Interval = 1000;
            _updateTimer.Start();
            updateTimer_Tick(this, null);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                using (var db = new CryptowatchDbContext())
                {
                    var tickers = db.Tickers.ToList();
                    if(tickers == null)
                    {
                        return;
                    }

                    if (filterHighVolume)
                    {
                        tickers = tickers.OrderByDescending(t => t.BaseVolume).Take(Globals.Settings.ScannerFilterTopVolumeCount).ToList();
                    }

                    Tickers = tickers;
                    OnTickerUpdate?.Invoke();

                    var records = CalculateDailyHighRecords(tickers);

                    if (filterHighestLowest)
                    {
                        records = records.Where(r => r.PHigh > 0.7m || r.PHigh < 0.1m).ToList();
                    }

                    if (filterHideLosers)
                    {
                        records = records.Where(r => r.PHigh > 0.1m).ToList();
                    }

                    try
                    {
                        dataGridView.Invoke(new Action(() =>
                        {
                            dataGridView.DataSource = records.OrderByDescending(r => r.PHigh).ToList();
                            dataGridView.Columns["Id"].Visible = false;
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                row.DefaultCellStyle.BackColor = Color.White;

                                if ((decimal)row.Cells["PHigh"].Value > 0.95m)
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red;
                                }
                                else if ((decimal)row.Cells["PHigh"].Value > 0.9m)
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                                }
                                else if ((decimal)row.Cells["PHigh"].Value > 0.8m)
                                {
                                    row.DefaultCellStyle.BackColor = Color.Orange;
                                }
                                else if ((decimal)row.Cells["PHigh"].Value > 0.7m)
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                                }
                                else if ((decimal)row.Cells["PHigh"].Value < 0.1m)
                                {
                                    row.DefaultCellStyle.BackColor = Color.Purple;
                                }
                            }
                            toolStripLabelStatus.Text = $"Last update: {tickers.FirstOrDefault()?.Timestamp.ToString("HH:mm:ss") ?? "never"}";
                        }));
                    }
                    catch { }
                }
            }));
        }

        private List<DailyHighRecord> CalculateDailyHighRecords(List<Ticker> tickers)
        {
            var records = tickers.Select(t => new DailyHighRecord
            {
                Symbol = t.Name,
                Exchange = t.Exchange,
                Volume = t.BaseVolume,
                High = t.High24Hour,
                Last = t.Last,
                PHigh = Math.Round( (t.Last - t.Low24Hour) / (t.High24Hour - t.Low24Hour), 3)
            });

            return records.ToList();
        }

        private void toolStripMenuItemFilterHighVolume_Click(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem)sender;
            filterHighVolume = !filterHighVolume;
            menu.Checked = filterHighVolume;
            updateTimer_Tick(this, null);
            menu.BackColor = filterHighVolume ? Color.LightGreen : Color.Gray;
        }

        private void toolStripMenuItemFilterHighestLower_Click(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem)sender;
            filterHighestLowest = !filterHighestLowest;
            menu.Checked = filterHighestLowest;
            updateTimer_Tick(this, null);
            menu.BackColor = Color.LightGreen;
            menu.BackColor = filterHighestLowest ? Color.LightGreen : Color.Gray;
        }

        private void toolStripMenuItemFilterHideLosers_Click(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem)sender;
            filterHideLosers = !filterHideLosers;
            menu.Checked = filterHideLosers;
            updateTimer_Tick(this, null);
            menu.BackColor = Color.LightGreen;
            menu.BackColor = filterHideLosers ? Color.LightGreen : Color.Gray;
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            var row = dataGridView.Rows[dataGridView.CurrentRow.Index];

            var symbol = new Symbol
            {
                Name = row.Cells["Symbol"].Value.ToString(),
                Exchange = row.Cells["Exchange"].Value.ToString()
            };
            
            OnSymbolClick?.Invoke(symbol);
        }
    }
}
