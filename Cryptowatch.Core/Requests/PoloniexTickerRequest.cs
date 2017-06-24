using Cryptowatch.Core.Requests.HttpRequests;
using Cryptowatch.Core.Requests.PostProcessingPolicies;
using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Core.Requests
{
    public class PoloniexTickerRequest : IDataRequest
    {
        public IHttpRequest HttpRequest { get; set; } = new PoloniexTickerHttpRequest();
        public IPostProcessingPolicy ProcessingPolicy { get; set; } = new PoloniexTickerPostProcessingPolicy();

        public void Execute(DataRequest request)
        {
            request.JsonResult = HttpRequest.Execute(request);
            ProcessingPolicy.Process(request);
        }
    }
}
