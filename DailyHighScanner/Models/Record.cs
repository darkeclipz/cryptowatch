using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyHighScanner
{
    class DailyHighRecord
    {
        public string Symbol { get; set; }
        public string Exchange { get; set; }
        public double Volume { get; set; }
        public decimal Last { get; set; }
        public decimal High { get; set; }
        public decimal PHigh { get; set; }
    }
}
