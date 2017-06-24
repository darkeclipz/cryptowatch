using Cryptowatch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Core.Db
{
    public class CryptowatchDbContext : DbContext
    {
        public CryptowatchDbContext() : base(Globals.Settings.DatabaseConnectionString) { }
        
        public DbSet<Candlestick> Candlesticks { get; set; }
        public DbSet<DataRequest> DataRequests { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<DailyHighRecord> DailyHighRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticker>().Property(e => e.Last).HasPrecision(16, 8);
            modelBuilder.Entity<Ticker>().Property(e => e.LowestAsk).HasPrecision(16, 8);
            modelBuilder.Entity<Ticker>().Property(e => e.HighestBid).HasPrecision(16, 8);
            modelBuilder.Entity<Ticker>().Property(e => e.High24Hour).HasPrecision(16, 8);
            modelBuilder.Entity<Ticker>().Property(e => e.Low24Hour).HasPrecision(16, 8);

            modelBuilder.Entity<Candlestick>().Property(c => c.High).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.Low).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.Open).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.Close).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.WeightedAverage).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.SMA10).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.SMA20).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.UpperBand).HasPrecision(16, 8);
            modelBuilder.Entity<Candlestick>().Property(c => c.LowerBand).HasPrecision(16, 8);
        }
    }
}
