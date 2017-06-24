using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Models
{
    public class DataRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public RequestType Type { get; set; }
        public RequestStatus Status { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateExecuteAt { get; set; }
        public DateTime DateExecuted { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string Parameter4 { get; set; }
        public string Parameter5 { get; set; }
        public string JsonResult { get; set; }
        public RequestPriority Priority { get; set; } = RequestPriority.Normal;
    }

    public enum RequestPriority
    {
        Normal,
        High
    }

    public enum RequestStatus
    {
        Enqueued,
        Pending,
        OK,
        Error,
        Cancelled
    }

    public enum RequestType
    {
        Chart,
        Ticker
    }
}
