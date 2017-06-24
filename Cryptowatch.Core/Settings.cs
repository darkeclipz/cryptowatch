using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptowatch.Core
{
    public class Settings
    {
        public static readonly string SettingsFilepath = @"Cryptowatch.Settings.json";

        public Settings()
        {
            IV = new byte[8];
            var rng = new Random();
            rng.NextBytes(IV);
        }

        public int ScannerRefreshIntervalMs { get; set; } = 5000;

        public int ChartRefreshIntervalMs { get; set; } = 5000;

        public string PoloniexApiKey { get; set; } = "none";

        public string PoloniexApiSecret { get; set; } = "none";

        public int ScannerFilterTopVolumeCount = 40;

        public string DatabaseConnectionString { get; set; } = @"Data Source=.\SQLEXPRESS;Initial Catalog=Cryptowatch;Integrated Security=True;MultipleActiveResultSets=True";

        public bool ScannerOnlyBtcMarkets { get; set; }

        public int ApiTimeoutMs { get; set; } = 5000;

        public byte[] IV { get; set; }

        public int ChartPeriodsToShow = 40;
        public bool ChartSMA10 = true;
        public bool ChartSMA20 = true;
        public bool ChartVolume = true;

        public bool ChartResistanceLevels { get; set; } = false;
        public bool ChartSupportLevels { get; set; } = false;
        public int ChartNumberOfLevels { get; set; } = 3;

        public static Settings Load(string filepath)
        {
            var json = File.ReadAllText(filepath);
            var settings = JsonConvert.DeserializeObject<Settings>(json);
            settings.PoloniexApiKey = StringUtil.Decrypt(settings.PoloniexApiKey, settings.IV);
            settings.PoloniexApiSecret = StringUtil.Decrypt(settings.PoloniexApiSecret, settings.IV);
            settings.DatabaseConnectionString = StringUtil.Decrypt(settings.DatabaseConnectionString, settings.IV);
            return settings;
        }

        public void Save(string filepath)
        {
            var settings = (Settings)this.MemberwiseClone();
            settings.PoloniexApiKey = StringUtil.Crypt(settings.PoloniexApiKey, settings.IV);
            settings.PoloniexApiSecret = StringUtil.Crypt(settings.PoloniexApiSecret, settings.IV);
            settings.DatabaseConnectionString = StringUtil.Crypt(settings.DatabaseConnectionString, settings.IV);
            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(filepath, json);
        }
    }

    public static class StringUtil
    {
        private static byte[] key = new byte[8] { 0x88, 0x25, 0xfc, 0xbe, 0xc6, 0xd7, 0xe2, 0x47 };

        public static string Crypt(this string text, byte[] iv)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(this string text, byte[] iv)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
    }
}
