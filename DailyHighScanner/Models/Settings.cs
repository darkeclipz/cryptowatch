using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DailyHighScanner.Models
{
    public class Settings
    {
        public int ScannerRefreshIntervalMs { get; set; } = 5000;

        public int ChartRefreshIntervalMs { get; set; } = 5000;

        public string PoloniexApiKey { get; set; } = "none";

        public string PoloniexApiSecret { get; set; } = "none";

        public int ChartPeriodsToShow = 40;

        public static Settings Load(string filepath)
        {
            var json = File.ReadAllText(filepath);
            var settings = JsonConvert.DeserializeObject<Settings>(json);
            settings.PoloniexApiKey = StringUtil.Decrypt(settings.PoloniexApiKey);
            settings.PoloniexApiSecret = StringUtil.Decrypt(settings.PoloniexApiSecret);
            return settings;
        }

        public void Save(string filepath)
        {
            var settings = (Settings)this.MemberwiseClone();
            settings.PoloniexApiKey = StringUtil.Crypt(settings.PoloniexApiKey);
            settings.PoloniexApiSecret = StringUtil.Crypt(settings.PoloniexApiSecret);
            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(filepath, json);
        }
    }

    public static class StringUtil
    {
        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public static string Crypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
    }
}
