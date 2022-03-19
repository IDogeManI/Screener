using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Screener
{
    static class BinanceAPI
    {
        /// <summary>
        /// Get raw JSON of depth
        /// </summary>
        /// <param name="symbol">Coin Pair</param>
        /// <param name="Isfutures">On futures or not</param>
        /// <returns>Raw response</returns>
        public static async Task<string> Depth (string symbol = "BTCUSDT",bool Isfutures = true)
        {

            var parametri = "symbol=" + symbol + "&limit=100";
            string adress = (Isfutures?"https://fapi.binance.com/fapi/v1/depth?": "https://api.binance.com/api/v3/depth?") + parametri;
            var client = new RestClient(adress);
            var request = new RestRequest(adress);
            var response = await client.GetAsync(request);
            var content = response.Content; // Raw content as string
            return content;
        }
        /// <summary>
        /// Get raw JSON market price
        /// </summary>
        /// <param name="symbol">Coin Pair</param>
        /// <param name="Isfutures">On futures or not</param>
        /// <returns>Raw response</returns>
        public static async Task<string> MarkPrice (string symbol = "BTCUSDT" , bool Isfutures = true)
        {
            var parametri = "symbol=" + symbol;
            string adress = (Isfutures ? "https://fapi.binance.com/fapi/v1/ticker/price?" : "https://api.binance.com/api/v3/ticker/price?") + parametri;
            var client = new RestClient(adress);
            var request = new RestRequest(adress);
            var response = await client.GetAsync(request);
            var content = response.Content; // Raw content as string
            return content;
        }
        /// <summary>
        /// Required Coin Pairs
        /// </summary>
        public static string[] ALLSYMBOLS { get; } = {
                                       "BCHUSDT",
                                       "XRPUSDT",
                                       "EOSUSDT",
                                       "LTCUSDT",
                                       "TRXUSDT",
                                       "ETCUSDT",
                                       "LINKUSDT",
                                       "XLMUSDT",
                                       "ADAUSDT",
                                       "XMRUSDT",
                                       "DASHUSDT",
                                       "ZECUSDT",
                                       "XTZUSDT",
                                       "BNBUSDT",
                                       "ATOMUSDT",
                                       "ONTUSDT",
                                       "IOTAUSDT",
                                       "BATUSDT",
                                       "VETUSDT",
                                       "NEOUSDT",
                                       "QTUMUSDT",
                                       "IOSTUSDT",
                                       "THETAUSDT",
                                       "ALGOUSDT",
                                       "ZILUSDT",
                                       "KNCUSDT",
                                       "ZRXUSDT",
                                       "COMPUSDT",
                                       "OMGUSDT",
                                       "DOGEUSDT",
                                       "SXPUSDT",
                                       "KAVAUSDT",
                                       "BANDUSDT",
                                       "RLCUSDT",
                                       "WAVESUSDT",
                                       "MKRUSDT",
                                       "SNXUSDT",
                                       "DOTUSDT",
                                       "DEFIUSDT",
                                       "YFIUSDT",
                                       "BALUSDT",
                                       "CRVUSDT",
                                       "TRBUSDT",
                                       "YFIIUSDT",
                                       "RUNEUSDT",
                                       "SUSHIUSDT",
                                       "SRMUSDT",
                                       "EGLDUSDT",
                                       "SOLUSDT",
                                       "ICXUSDT",
                                       "STORJUSDT",
                                       "BLZUSDT",
                                       "UNIUSDT",
                                       "AVAXUSDT",
                                       "FTMUSDT",
                                       "HNTUSDT",
                                       "ENJUSDT",
                                       "FLMUSDT",
                                       "TOMOUSDT",
                                       "RENUSDT",
                                       "KSMUSDT",
                                       "NEARUSDT",
                                       "AAVEUSDT",
                                       "FILUSDT",
                                       "RSRUSDT",
                                       "LRCUSDT",
                                       "MATICUSDT",
                                       "OCEANUSDT",
                                       "CVCUSDT",
                                       "BELUSDT",
                                       "CTKUSDT",
                                       "AXSUSDT",
                                       "ALPHAUSDT",
                                       "ZENUSDT",
                                       "SKLUSDT",
                                       "GRTUSDT",
                                       "1INCHUSDT",
                                       "AKROUSDT",
                                       "CHZUSDT",
                                       "SANDUSDT",
                                       "ANKRUSDT",
                                       "LUNAUSDT",
                                       "BTSUSDT",
                                       "LITUSDT",
                                       "UNFIUSDT",
                                       "DODOUSDT",
                                       "REEFUSDT",
                                       "RVNUSDT",
                                       "SFPUSDT",
                                       "XEMUSDT",
                                       "COTIUSDT",
                                       "CHRUSDT",
                                       "MANAUSDT",
                                       "ALICEUSDT",
                                       "HBARUSDT",
                                       "ONEUSDT",
                                       "LINAUSDT",
                                       "STMXUSDT",
                                       "DENTUSDT",
                                       "CELRUSDT",
                                       "HOTUSDT",
                                       "MTLUSDT",
                                       "OGNUSDT",
                                       "NKNUSDT",
                                       "SCUSDT",
                                       "DGBUSDT",
                                       "1000SHIBUSDT",
                                       "ICPUSDT",
                                       "BAKEUSDT",
                                       "GTCUSDT",
                                       "TLMUSDT",
                                       "IOTXUSDT",
                                       "RAYUSDT",
                                       "MASKUSDT",
                                       "ATAUSDT",
                                       "DYDXUSDT",
                                       "1000XECUSDT",
                                       "CELOUSDT",
                                       "ARUSDT",
                                       "KLAYUSDT",
                                       "ARPAUSDT",
                                       "CTSIUSDT",
                                       "LPTUSDT",
                                       "ENSUSDT",
                                       "ANTUSDT",
                                       "ROSEUSDT",
                                       "DUSKUSDT",
                                       "FLOWUSDT",
                                       "IMXUSDT"};
    }
    
}
