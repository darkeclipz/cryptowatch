using Cryptowatch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Data
{
    class Bittrex
    {
        public static List<Ticker> Ticker()
        {
            //string url = @"https://poloniex.com/public?command=returnTicker";
            //var client = new HttpClient();
            //var content = client.GetAsync(url).Result;
            //var tickerData = content.Content.ReadAsStringAsync().Result;
            //dynamic data = JsonConvert.DeserializeObject(tickerData);
            var tickers = new List<Ticker>();
            //foreach (var market in data)
            //{
            //    tickers.Add(new Ticker
            //    {
            //        Id = market.Value.id,
            //        Name = market.Name,
            //        Timestamp = DateTime.Now,
            //        Last = market.Value.last,
            //        LowestAsk = market.Value.lowestAsk,
            //        HighestBid = market.Value.highestBid,
            //        PercentChange = market.Value.percentChange,
            //        BaseVolume = market.Value.baseVolume,
            //        QuoteVolume = market.Value.quoteVolume,
            //        IsFrozen = market.Value.isFrozen == "1" ? true : false,
            //        High24Hour = market.Value.high24Hour,
            //        Low24Hour = market.Value.low24Hour
            //    });
            //}
            return tickers;
        }
    }
}
