using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptowatch.Models;
using Cryptowatch.Core.Requests.HttpRequests;
using Cryptowatch.Core.Requests.PostProcessingPolicies;

namespace Cryptowatch.Core.Requests
{
    public class PoloniexChartRequest : IDataRequest
    {
        public IHttpRequest HttpRequest { get; set; } = new PoloniexChartHttpRequest();
        public IPostProcessingPolicy ProcessingPolicy { get; set; } = new PoloniexChartPostProcessingPolicy();

        public void Execute(DataRequest request)
        {
            request.JsonResult = HttpRequest.Execute(request);
            ProcessingPolicy.Process(request);
        }
    }
}
