using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Models
{
    public class Ticker
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Exchange { get; set; }
        public decimal Last { get; set; }
        public decimal LowestAsk { get; set; }
        public decimal HighestBid { get; set; }
        public decimal High24Hour { get; set; }
        public decimal Low24Hour { get; set; }
        public double PercentChange { get; set; }
        public double BaseVolume { get; set; }
        public double QuoteVolume { get; set; }
        public bool IsFrozen { get; set; }
    }
}
