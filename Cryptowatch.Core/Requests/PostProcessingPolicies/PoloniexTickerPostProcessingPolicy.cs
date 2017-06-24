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

                    var lastOf5MinChart = db.Candlesticks.Where(c => c.Symbol == t.Name && c.Period == ChartPeriod._5Min).OrderByDescending(c => c.Date).FirstOrDefault();
                    if (lastOf5MinChart!= null && lastOf5MinChart.Timestamp < DateTime.Now && (lastOf5MinChart.Timestamp + TimeSpan.FromSeconds((int)ChartPeriod._5Min)) > DateTime.Now)
                    {
                        lastOf5MinChart.Close = t.Last;
                        db.Candlesticks.Attach(lastOf5MinChart);
                        db.Entry(lastOf5MinChart).State = System.Data.Entity.EntityState.Modified;
                    }

                    var lastOf15MinChart = db.Candlesticks.Where(c => c.Symbol == t.Name && c.Period == ChartPeriod._15Min).OrderByDescending(c => c.Date).FirstOrDefault();
                    if (lastOf15MinChart != null && lastOf15MinChart.Timestamp < DateTime.Now && (lastOf15MinChart.Timestamp + TimeSpan.FromSeconds((int)ChartPeriod._15Min)) > DateTime.Now)
                    {
                        lastOf15MinChart.Close = t.Last;
                        db.Candlesticks.Attach(lastOf15MinChart);
                        db.Entry(lastOf15MinChart).State = System.Data.Entity.EntityState.Modified;
                    }

                    var lastOf30MinChart = db.Candlesticks.Where(c => c.Symbol == t.Name && c.Period == ChartPeriod._30Min).OrderByDescending(c => c.Date).FirstOrDefault();
                    if (lastOf30MinChart != null && lastOf30MinChart.Timestamp < DateTime.Now && (lastOf30MinChart.Timestamp + TimeSpan.FromSeconds((int)ChartPeriod._30Min)) > DateTime.Now)
                    {
                        lastOf30MinChart.Close = t.Last;
                        db.Candlesticks.Attach(lastOf30MinChart);
                        db.Entry(lastOf30MinChart).State = System.Data.Entity.EntityState.Modified;
                    }

                    var lastOf2HourChart = db.Candlesticks.Where(c => c.Symbol == t.Name && c.Period == ChartPeriod._2Hr).OrderByDescending(c => c.Date).FirstOrDefault();
                    if (lastOf2HourChart != null && lastOf2HourChart.Timestamp < DateTime.Now && (lastOf2HourChart.Timestamp + TimeSpan.FromSeconds((int)ChartPeriod._2Hr)) > DateTime.Now)
                    {
                        lastOf2HourChart.Close = t.Last;
                        db.Candlesticks.Attach(lastOf2HourChart);
                        db.Entry(lastOf2HourChart).State = System.Data.Entity.EntityState.Modified;
                    }

                    var lastOfDailyChart = db.Candlesticks.Where(c => c.Symbol == t.Name && c.Period == ChartPeriod._D).OrderByDescending(c => c.Date).FirstOrDefault();
                    if (lastOfDailyChart != null && lastOfDailyChart.Timestamp < DateTime.Now && (lastOfDailyChart.Timestamp + TimeSpan.FromSeconds((int)ChartPeriod._D)) > DateTime.Now)
                    {
                        lastOfDailyChart.Close = t.Last;
                        db.Candlesticks.Attach(lastOfDailyChart);
                        db.Entry(lastOfDailyChart).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
