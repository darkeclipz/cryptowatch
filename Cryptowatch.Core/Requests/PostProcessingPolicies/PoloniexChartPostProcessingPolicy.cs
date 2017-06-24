using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptowatch.Models;
using Newtonsoft.Json;
using Cryptowatch.Core.Db;

namespace Cryptowatch.Core.Requests.PostProcessingPolicies
{
    public class PoloniexChartPostProcessingPolicy : IPostProcessingPolicy
    {
        public void Process(DataRequest request)
        {
            DateTime DateTimeFromUnixDate(long unixDate)
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var timeSpan = TimeSpan.FromSeconds(unixDate);
                var localDateTime = epoch.Add(timeSpan).ToLocalTime();
                return localDateTime;
            }

            dynamic data = JsonConvert.DeserializeObject(request.JsonResult);
            var candlesticks = new List<Candlestick>();
            foreach (var candle in data)
            {
                candlesticks.Add(new Candlestick
                {
                    Timestamp = DateTime.Now,
                    Date = DateTimeFromUnixDate((long)candle.date.Value),
                    High = (decimal)candle.high.Value,
                    Low = (decimal)candle.low.Value,
                    Open = (decimal)candle.open.Value,
                    Close = (decimal)candle.close.Value,
                    Volume = (long)candle.volume.Value,
                    QuoteVolume = (long)candle.quoteVolume.Value,
                    WeightedAverage = (decimal)candle.weightedAverage.Value,
                    Period = (ChartPeriod)int.Parse(request.Parameter2),
                    Symbol = request.Parameter1
                });
            }

            for(int i = 10; i < candlesticks.Count; i++)
            {
                var sma10 = candlesticks.Skip(i - 10).Take(10).Sum(s => s.Close) / 10;
                candlesticks[i].SMA10 = sma10;
            }

            for (int i = 20; i < candlesticks.Count; i++)
            {
                var sma20 = candlesticks.Skip(i - 20).Take(20).Sum(s => s.Close) / 20;
                candlesticks[i].SMA20 = sma20;
            }

            using (var db = new CryptowatchDbContext())
            {
                db.Candlesticks
                    .ToList()
                    .Where(c => c.Symbol == candlesticks.FirstOrDefault().Symbol
                        && c.Period == candlesticks.FirstOrDefault().Period)
                    .ToList()
                    .ForEach(c => db.Entry(c).State = System.Data.Entity.EntityState.Deleted);

                foreach(var candlestick in candlesticks
                    .Skip(candlesticks.Count - Globals.Settings.ChartPeriodsToShow)
                    .Take(Globals.Settings.ChartPeriodsToShow).ToList())
                {
                    db.Candlesticks.Add(candlestick);
                }

                db.SaveChanges();
            }
        }
    }
}
