﻿using Cryptowatch.App;
using Cryptowatch.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cryptowatch.Data
{
    class Poloniex
    {
        public static List<Ticker> Ticker()
        {
            try
            {
                string url = @"https://poloniex.com/public?command=returnTicker";
                var client = new HttpClient();
                var content = client.GetAsync(url).Result;
                var tickerData = content.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(tickerData);
                var tickers = new List<Ticker>();
                foreach (var market in data)
                {
                    if (Globals.Settings.ScannerOnlyBtcMarkets && !Regex.IsMatch(market.Name, "BTC_") && market.Name != "USDT_BTC")
                    {
                        continue;
                    }

                    tickers.Add(new Ticker
                    {
                        Id = market.Value.id,
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
                return tickers;
            }
            catch
            {
                throw;
            }
        }

        public static List<Candlestick> Chart(Symbol symbol, PeriodType period, int numberOfCandles = 30)
        {
            DateTime DateTimeFromUnixDate(long unixDate)
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var timeSpan = TimeSpan.FromSeconds(unixDate);
                var localDateTime = epoch.Add(timeSpan).ToLocalTime();
                return localDateTime;
            }

            string url = $@"https://poloniex.com/public?command=returnChartData&currencyPair={symbol.Name}&start=1495497600&end=9999999999&period={(int)period}";
            var client = new HttpClient();
            var content = client.GetAsync(url).Result;
            var tickerData = content.Content.ReadAsStringAsync().Result;
            dynamic data = JsonConvert.DeserializeObject(tickerData);
            var candlesticks = new List<Candlestick>();
            foreach (var candle in data)
            {
                candlesticks.Add(new Candlestick
                {
                    Date = DateTimeFromUnixDate((long)candle.date.Value),
                    High = candle.high.Value,
                    Low = candle.low.Value,
                    Open = candle.open.Value,
                    Close = candle.close.Value,
                    Volume = candle.volume.Value,
                    QuoteVolume = candle.quoteVolume.Value,
                    WeightedAverage = candle.weightedAverage.Value
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

            return candlesticks.Skip(candlesticks.Count - numberOfCandles).Take(numberOfCandles).ToList();
        }
    }

    public enum PeriodType : int
    {
        _5Min = 300,
        _15Min = 900,
        _30Min = 1800,
        _2Hr = 7200,
        _D = 86400
    }
}
