using Cryptowatch.Core.Db;
using Cryptowatch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cryptowatch.Core.Requests.PostProcessingPolicies
{
    public class PoloniexTickerPostProcessingPolicy : IPostProcessingPolicy
    {
        public void Process(DataRequest request)
        {
            dynamic data = JsonConvert.DeserializeObject(request.JsonResult);
            var tickers = new List<Ticker>();
            foreach (var market in data)
            {
                if (Globals.Settings.ScannerOnlyBtcMarkets && !Regex.IsMatch(market.Name, "BTC"))
                {
                    continue;
                }

                tickers.Add(new Ticker
                {
                    Name = market.Name,
                    Exchange = "PLNX",
                    Timestamp = DateTime.Now,
                    Last = market.Value.last,
                    LowestAsk = market.Value.lowestAsk,
                    HighestBid = market.Value.highestBid,
                    PercentChange = market.Value.percentChange,
                    BaseVolume = market.Value.baseVolume,
                    QuoteVolume = market.Value.quoteVolume,
                    IsFrozen = market.Value.isFrozen == "1" ? true : false,
                    High24Hour = market.Value.high24hr,
                    Low24Hour = market.Value.low24hr
                });
            }
            using (var db = new CryptowatchDbContext())
            {
                db.Tickers.ToList().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted);
                foreach(var t in tickers)
                {
                    db.Tickers.Add(t);
                }
                db.SaveChanges();
            }
        }
    }
}
