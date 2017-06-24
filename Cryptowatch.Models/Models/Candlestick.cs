using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Models
{
    public class Candlestick
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Timestamp { get; set; }

        public DateTime Date { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public long QuoteVolume { get; set; }
        public decimal WeightedAverage { get; set; }

        public decimal SMA10 { get; set; }
        public decimal SMA20 { get; set; }
        public decimal UpperBand { get; set; }
        public decimal LowerBand { get; set; }

        public string Symbol { get; set; }
        public string Exchange { get; set; }
        public ChartPeriod Period { get; set; }
    }

    public enum ChartPeriod : int
    {
        _5Min = 300,
        _15Min = 900,
        _30Min = 1800,
        _2Hr = 7200,
        _D = 86400
    }
}
