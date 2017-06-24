using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Core.Requests
{
    public interface IDataRequest
    {
        IHttpRequest HttpRequest { get; set; }
        IPostProcessingPolicy ProcessingPolicy { get; set; }
        void Execute(DataRequest request);
    }

    public interface IHttpRequest
    {
        string Execute(DataRequest request);
    }

    public interface IPostProcessingPolicy
    {
        void Process(DataRequest request);
    }
}
