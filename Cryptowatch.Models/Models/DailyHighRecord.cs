using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Models
{
    public class DailyHighRecord
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Symbol { get; set; }
        public string Exchange { get; set; }
        public double Volume { get; set; }
        public decimal Last { get; set; }
        public decimal High { get; set; }
        public decimal PHigh { get; set; }
    }
}
