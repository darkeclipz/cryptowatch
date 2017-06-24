using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Core.Requests.HttpRequests
{
    public class PoloniexTickerHttpRequest : IHttpRequest
    {
        public string Execute(DataRequest request)
        {
            string url = @"https://poloniex.com/public?command=returnTicker";
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(Globals.Settings.ApiTimeoutMs);
            var content = client.GetAsync(url).Result;
            var tickerData = content.Content.ReadAsStringAsync().Result;
            return tickerData;
        }
    }
}
