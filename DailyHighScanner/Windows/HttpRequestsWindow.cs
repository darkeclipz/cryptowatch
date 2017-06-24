using Cryptowatch.Core.Db;
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
    public partial class HttpRequestsWindow : Form
    {
        public Timer _timer { get; set; }

        public HttpRequestsWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            var _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            using (var db = new CryptowatchDbContext())
            {
                if(db.DataRequests.Count() == 0)
                {
                    return;
                }

                var data = db.DataRequests
                    .OrderByDescending(d => d.DateCreated)
                    .Take(40)
                    .ToList();

                dataGridView.DataSource = data;
            }
        }
    }
}
