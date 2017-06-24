using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptowatch.Models;
using System.Net.Http;

namespace Cryptowatch.Core.Requests.HttpRequests
{
    public class PoloniexChartHttpRequest : IHttpRequest
    {
        public string Execute(DataRequest request)
        {
            string url = $@"https://poloniex.com/public?command=returnChartData&currencyPair={request.Parameter1}&start=1495497600&end=9999999999&period={request.Parameter2}";
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Globals.Settings.ApiTimeoutMs);
            var content = client.GetAsync(url).Result;
            var chartData = content.Content.ReadAsStringAsync().Result;
            return chartData;
        }
    }
}
