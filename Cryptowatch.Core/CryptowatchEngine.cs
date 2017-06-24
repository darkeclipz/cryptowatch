using Cryptowatch.Core.Db;
using Cryptowatch.Core.Requests;
using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cryptowatch.Core
{
    public class CryptowatchEngine
    {
        private Settings _settings { get; set; }
        private Symbol _symbol { get; set; }
        private object _symbolLock = false;

        public CryptowatchEngine()
        {
            InitializeSettings();

            using (var db = new CryptowatchDbContext())
            {
                db.DataRequests.Where(d => d.Status == RequestStatus.Pending)
                    .ToList()
                    .ForEach(d =>
                    {
                        d.Status = RequestStatus.Cancelled;
                        db.DataRequests.Attach(d);
                        db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    });

                db.SaveChanges();
            }

            Task.Run(new Action(() => Execute()));
        }

        public void SetSymbol(Symbol symbol)
        {
            lock(_symbolLock)
            {
                _symbol = symbol;
            }

            using (var db = new CryptowatchDbContext())
            {
                db.DataRequests.Where(d => d.Status == RequestStatus.Enqueued && d.Type == RequestType.Chart)
                    .ToList()
                    .ForEach(d =>
                    {
                        d.Status = RequestStatus.Cancelled;
                        db.DataRequests.Attach(d);
                        db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                    });

                db.DataRequests.Add(CreateChartRequest(symbol.Name, ChartPeriod._5Min));
                db.DataRequests.Add(CreateChartRequest(symbol.Name, ChartPeriod._15Min));
                db.DataRequests.Add(CreateChartRequest(symbol.Name, ChartPeriod._30Min));
                db.DataRequests.Add(CreateChartRequest(symbol.Name, ChartPeriod._2Hr));
                db.DataRequests.Add(CreateChartRequest(symbol.Name, ChartPeriod._D));

                db.SaveChanges();
            }
        }

        public void Execute()
        {
            while (true)
            {
                using (var db = new CryptowatchDbContext())
                {
                    db.DataRequests
                        .Where(d => d.Status == Models.RequestStatus.Enqueued && d.DateExecuteAt <= DateTime.Now)
                        .OrderByDescending(d => d.Priority)
                        .ThenByDescending(d => d.DateCreated)
                        .Take(5)
                        .ToList()
                        .ForEach(r =>
                        {
                            r.Status = RequestStatus.Pending;
                            db.DataRequests.Attach(r);
                            db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            try
                            {
                                var request = RequestFactory.CreateRequest(r);
                                request.Execute(r);
                                r.Status = Models.RequestStatus.OK;
                            }
                            catch (Exception ex)
                            {
                                r.ExceptionMessage = ex.Message;
                                if (ex.InnerException != null)
                                {
                                    r.ExceptionMessage += $" ({ex.InnerException.Message})";
                                }
                                r.Status = Models.RequestStatus.Error;
                            }

                            r.DateExecuted = DateTime.Now;
                            db.DataRequests.Attach(r);
                            db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        });

                    #region Refresh ticker
                    if(db.DataRequests.Count(d => d.Status == Models.RequestStatus.Enqueued && d.Type == Models.RequestType.Ticker) == 0)
                    {
                        var tickerRequest = new DataRequest
                        {
                            DateExecuted = DateTime.Now,
                            DateExecuteAt = DateTime.Now.AddMilliseconds(Globals.Settings.ScannerRefreshIntervalMs),
                            Status = RequestStatus.Enqueued,
                            Type = RequestType.Ticker,
                            ExceptionMessage = String.Empty,
                            JsonResult = String.Empty
                        };

                        db.DataRequests.Add(tickerRequest);
                        db.SaveChanges();
                    }
                    #endregion

                    #region Refresh charts
                    string symbol = _symbol?.Name;
                    if (!string.IsNullOrEmpty(symbol)
                        && db.DataRequests.Count(d => d.Status == RequestStatus.Enqueued
                        && d.Type == RequestType.Chart
                        && d.Parameter2 == ((int)ChartPeriod._5Min).ToString()
                        && d.Parameter1 == symbol) == 0)
                    {
                        var chartRequest = CreateChartRequest(symbol, ChartPeriod._5Min);
                        chartRequest.DateExecuteAt += TimeSpan.FromMilliseconds(Globals.Settings.ChartRefreshIntervalMs);
                        db.DataRequests.Add(chartRequest);
                        db.SaveChanges();
                    }

                    if (!string.IsNullOrEmpty(symbol) 
                        && db.DataRequests.Count(d => d.Status == RequestStatus.Enqueued 
                        && d.Type == RequestType.Chart 
                        && d.Parameter2 == ((int)ChartPeriod._15Min).ToString() 
                        && d.Parameter1 == symbol) == 0)
                    {
                        var chartRequest = CreateChartRequest(symbol, ChartPeriod._15Min);
                        chartRequest.DateExecuteAt += TimeSpan.FromMilliseconds(Globals.Settings.ChartRefreshIntervalMs);
                        db.DataRequests.Add(chartRequest);
                        db.SaveChanges();
                    }

                    if (!string.IsNullOrEmpty(symbol)
                        && db.DataRequests.Count(d => d.Status == RequestStatus.Enqueued
                        && d.Type == RequestType.Chart
                        && d.Parameter2 == ((int)ChartPeriod._30Min).ToString()
                        && d.Parameter1 == symbol) == 0)
                    {
                        var chartRequest = CreateChartRequest(symbol, ChartPeriod._30Min);
                        chartRequest.DateExecuteAt += TimeSpan.FromMilliseconds(Globals.Settings.ChartRefreshIntervalMs);
                        db.DataRequests.Add(chartRequest);
                        db.SaveChanges();
                    }

                    if (!string.IsNullOrEmpty(symbol)
                        && db.DataRequests.Count(d => d.Status == RequestStatus.Enqueued
                        && d.Type == RequestType.Chart
                        && d.Parameter2 == ((int)ChartPeriod._2Hr).ToString()
                        && d.Parameter1 == symbol) == 0)
                    {
                        var chartRequest = CreateChartRequest(symbol, ChartPeriod._2Hr);
                        chartRequest.DateExecuteAt += TimeSpan.FromMilliseconds(Globals.Settings.ChartRefreshIntervalMs);
                        db.DataRequests.Add(chartRequest);
                        db.SaveChanges();
                    }

                    if (!string.IsNullOrEmpty(symbol)
                        && db.DataRequests.Count(d => d.Status == RequestStatus.Enqueued
                        && d.Type == RequestType.Chart
                        && d.Parameter2 == ((int)ChartPeriod._D).ToString()
                        && d.Parameter1 == symbol) == 0)
                    {
                        var chartRequest = CreateChartRequest(symbol, ChartPeriod._D);
                        chartRequest.DateExecuteAt += TimeSpan.FromMilliseconds(Globals.Settings.ChartRefreshIntervalMs);
                        db.DataRequests.Add(chartRequest);
                        db.SaveChanges();
                    }
                    #endregion
                }

                Thread.Sleep(1000);
            }
        }

        private DataRequest CreateChartRequest(string symbol, ChartPeriod period)
        {
            var chartRequest = new DataRequest
            {
                DateExecuted = DateTime.Now,
                DateExecuteAt = DateTime.Now,
                Status = RequestStatus.Enqueued,
                Type = RequestType.Chart,
                ExceptionMessage = String.Empty,
                JsonResult = String.Empty
            };
            chartRequest.Parameter1 = symbol;
            chartRequest.Parameter2 = ((int)period).ToString();
            return chartRequest;
        }

        public void InitializeSettings()
        {
            _settings = Settings.Load(Settings.SettingsFilepath);
        }
    }
}
