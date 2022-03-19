using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace Screener
{
    static class Calculatin
    {
        /// <summary>
        /// Parse plus making list of coin which prices*quantities over min price
        /// </summary>
        /// <param name="i">iterator of Pair</param>
        /// <param name="IsFutures">Is it futures or not</param>
        /// <returns>List of suitable situations</returns>
        private static async Task<List<TickerPriceQuantity>> CalculateAsync (int i,bool IsFutures)
        {
            List<TickerPriceQuantity> suitableCoins = new List<TickerPriceQuantity>();
            try
            {
                string mainJson = await BinanceAPI.Depth(BinanceAPI.ALLSYMBOLS[i] , IsFutures);
                var json = JObject.Parse(mainJson);
                var bids = json["bids"];
                var asks = json["asks"];
                for(int j = 0; j < bids.Count(); j++)
                {
                    if((double.Parse(bids[j][0].ToString() , System.Globalization.CultureInfo.InvariantCulture) * double.Parse(bids[j][1].ToString() , System.Globalization.CultureInfo.InvariantCulture)) > PriceToComparation)
                    {
                        TickerPriceQuantity tickerPriceQuantity = new TickerPriceQuantity();
                        tickerPriceQuantity.ticker = BinanceAPI.ALLSYMBOLS[i];
                        tickerPriceQuantity.price = bids[j][0].ToString();
                        tickerPriceQuantity.quantity = bids[j][1].ToString();
                        suitableCoins.Add(tickerPriceQuantity);
                    }
                }
                for(int j = 0; j < asks.Count(); j++)
                {
                    if((double.Parse(asks[j][0].ToString() , System.Globalization.CultureInfo.InvariantCulture) * double.Parse(asks[j][1].ToString() , System.Globalization.CultureInfo.InvariantCulture)) > PriceToComparation)
                    {
                        TickerPriceQuantity tickerPriceQuantity = new TickerPriceQuantity();
                        tickerPriceQuantity.ticker = BinanceAPI.ALLSYMBOLS[i];
                        tickerPriceQuantity.price = asks[j][0].ToString();
                        tickerPriceQuantity.quantity = asks[j][1].ToString();
                        suitableCoins.Add(tickerPriceQuantity);
                    }
                }
            }
            catch {}
            return suitableCoins;
        }
        /// <summary>
        /// Quantity from price in symbol
        /// </summary>
        /// <param name="symbol">Coin Pair</param>
        /// <param name="price">Price</param>
        /// <param name="IsFutures">Is it futures or not</param>
        /// <returns>Quantity</returns>
        public static async Task<string> GetQuantityFromPrice(string symbol,string price,bool IsFutures)
        {
            try
            {
                string mainJson = await BinanceAPI.Depth(symbol , IsFutures);
                var json = JObject.Parse(mainJson);
                var bids = json["bids"];
                var asks = json["asks"];
                for(int j = 0; j < bids.Count(); j++)
                {
                    if(price == bids[j][0].ToString())
                    {
                        return bids[j][1].ToString();
                    }
                }
                for(int j = 0; j < asks.Count(); j++)
                {
                    if(price == asks[j][0].ToString())
                    {
                        return asks[j][1].ToString();
                    }
                }
            }
            catch{}

            return null;
        }
        /// <summary>
        /// Making list of all suitable sutuation
        /// </summary>
        /// <param name="IsFutures">Is it futures or not</param>
        /// <returns>List of all suitable situations</returns>
        public static async Task<List<TickerPriceQuantity>> GetListOfSuitableCoins (bool IsFutures=true)
        {

            List<TickerPriceQuantity> suitableCoins = new List<TickerPriceQuantity>();
            List<Task<List<TickerPriceQuantity>>> tasks = new List<Task<List<TickerPriceQuantity>>>();
            await Task.Run(() =>
            {
                for(int i = 0; i < BinanceAPI.ALLSYMBOLS.Length; i++)
                {
                    tasks.Add(CalculateAsync(i , IsFutures));
                }
            });
            await Task.WhenAll(tasks);
            await Task.Run(() =>
            {
                for(int i = 0; i < tasks.Count; i++)
                {
                    suitableCoins.AddRange(tasks[i].Result);
                }
            });
            return suitableCoins;
        }
        /// <summary>
        /// Get price of coin
        /// </summary>
        /// <param name="symbol">Coin Pair</param>
        /// <param name="IsFutures">Is it futures or not</param>
        /// <returns>Price of coin</returns>
        public static async Task<double> GetPrice (string symbol, bool IsFutures)
        {
            string mainJson = await BinanceAPI.MarkPrice(symbol , IsFutures);
            var json = JObject.Parse(mainJson);
            return double.Parse(json["price"].ToString() , System.Globalization.CultureInfo.InvariantCulture);
        }
        public static double PriceToComparation { get; set; } = 500000;
    }
    /// <summary>
    /// Ticker Price Quantity
    /// </summary>
    public class TickerPriceQuantity
    {
        public string ticker { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }

        public string Cancat ()
        {
            return "Ticker: " + ticker + " Price: " + price + " Quantity: " + quantity + $"({Math.Round(double.Parse(price , System.Globalization.CultureInfo.InvariantCulture)* double.Parse(quantity , System.Globalization.CultureInfo.InvariantCulture))}$)\n";
        }

    }
}
