using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Alpaca.Markets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AlpacaAccountHub.Data.SymbolData;
using RestSharp;
using RestClient = RestSharp.RestClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using AlpacaAccountHub.AlpacaRequests;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Data.ApiKeys;
using AlpacaAccountHub.UpdateAccount;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AlpacaAccountHub.PolygonRequests
{
    public class Snapshot
    {
        Assets tradeable = new Assets();
        
        public Task<TickerDetails> SingleTicker(string symbol)
        {
          
            TickerDetails tickerDetails = new TickerDetails();
            TickerDetails tickerDetailsData = new TickerDetails();
            string uri =
                $"https://api.polygon.io/v2/snapshot/locale/us/markets/stocks/tickers/{symbol.ToUpper()}?apiKey={LiveSecrets.API_KEY }";
            Console.WriteLine(symbol);

           // string response = "";


            var client =
                new RestClient(uri)
                {
                    Timeout = -1
                };
/*
            using (StreamReader json =
                new StreamReader(
                    @"C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Data\SymbolData\SingleTicker.json")
            )
            {
                response = json.ReadToEnd();
            }
*/
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var responseContent = JObject.Parse(response.Content);

            var tickerResponse = responseContent.GetValue("ticker");
            string tickerData = JsonConvert.SerializeObject(tickerResponse);
            var tickerContent = JObject.Parse(tickerData);
            var ticker = JsonConvert.DeserializeObject<TickerDetails>(tickerData);

            tickerDetails.ticker = ticker.ticker;

            var lastTradeResponse = tickerContent.GetValue("lastTrade");
            string lastTradeData = JsonConvert.SerializeObject(lastTradeResponse);
            var lastTrade = JsonConvert.DeserializeObject<LastTrade>(lastTradeData);
            tickerDetails.lastTradePrice = lastTrade.p;

            //get previous day for stock
            var prevDayResponse = tickerContent.GetValue("prevDay");
            string prevDayData = JsonConvert.SerializeObject(prevDayResponse);
            var prevDay = JsonConvert.DeserializeObject<PrevDay>(prevDayData);
            tickerDetails.previousDayVolume = prevDay.v;
            tickerDetails.previousDayClose = prevDay.c;
            tickerDetails.previousDayHigh = prevDay.h;

            //get minute data for stock
            var minuteResponse = tickerContent.GetValue("min");
            string minuteData = JsonConvert.SerializeObject(minuteResponse);
            var minute = JsonConvert.DeserializeObject<Min>(minuteData);
            tickerDetails.minuteClose = minute.c;

            var todayResponse = tickerContent.GetValue("day");
            string todayData = JsonConvert.SerializeObject(todayResponse);
            var today = JsonConvert.DeserializeObject<Day>(todayData);
            tickerDetails.todaysOpen = today.o;

            var todaysChangeResponse = tickerContent.GetValue("todaysChange");
            string todaysChangeData = JsonConvert.SerializeObject(todaysChangeResponse);
            var newTodaysChangeData = todaysChangeData.Replace("\"","");
            tickerDetails.todaysChange = newTodaysChangeData;
            

            var todaysChangePercResponse = tickerContent.GetValue("todaysChangePerc");
            string todaysChangePercData = JsonConvert.SerializeObject(todaysChangePercResponse);
            var newTodaysChangePercData = todaysChangePercData.Replace("\"","");
            tickerDetails.todaysChangePerc = newTodaysChangePercData;

            var assetsTradeable = tradeable.AssetTradable(tickerDetails.ticker);
            tickerDetails.tradable = assetsTradeable;

            var tickerDetailsJson = JsonConvert.SerializeObject(tickerDetails);
            tickerDetailsData =
                System.Text.Json.JsonSerializer.Deserialize<TickerDetails>(tickerDetailsJson);


            return Task.FromResult(tickerDetailsData);
        }

        public Task<List<Symbols>> TopTwenty()
        {

            TickerDetails tickerDetails = new TickerDetails();
            List<Symbols> topStocks = new List<Symbols>();
            var tickerDetailsData = new TickerDetails();
            Symbols symbols = new Symbols();
            symbols.tickerDetails = new List<TickerDetails>();
            string response = "";

            var client =
                new RestClient(
                    "https://api.polygon.io/v2/snapshot/locale/us/markets/stocks/gainers?apiKey=PK9IDH096J9W59XIWVGR")
                {
                    Timeout = -1
                };
            var request = new RestRequest(Method.GET);
           // IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            
            using (StreamReader json =
                new StreamReader(
                    @"C:\Day Trading\alpaca\Watchlists\BlazorWatchlist\pennyStockWatchlist\Data\SymbolData\Gainer-test.json")
            )
            {
                response = json.ReadToEnd();
            }
            
            var responseContent = JObject.Parse(response);

        
            int count = 0;
            for (int i = 0; i < 20; i++)
            {

                var tickersResponse = responseContent.GetValue("tickers");
                string tickersData = JsonConvert.SerializeObject(tickersResponse);
                
                var tickersContent = JArray.Parse(tickersData);

                var ticker = JsonConvert.DeserializeObject<List<TickerDetails>>(tickersData);

                tickerDetails.ticker = ticker[i].ticker;
                tickerDetails.todaysChange = ticker[i].todaysChange;
                tickerDetails.todaysChangePerc = ticker[i].todaysChangePerc;

                var tickerContent = JObject.Parse(tickersContent[i].ToString());

                //get the price of the last trade
                var lastTradeResponse = tickerContent.GetValue("lastTrade");
                string lastTradeData = JsonConvert.SerializeObject(lastTradeResponse);
                var lastTrade = JsonConvert.DeserializeObject<LastTrade>(lastTradeData);
                tickerDetails.lastTradePrice = lastTrade.p;

                //get previous day for stock
                var prevDayResponse = tickerContent.GetValue("prevDay");
                string prevDayData = JsonConvert.SerializeObject(prevDayResponse);
                var prevDay = JsonConvert.DeserializeObject<PrevDay>(prevDayData);
                tickerDetails.previousDayVolume = prevDay.v;
                tickerDetails.previousDayClose = prevDay.c;

                //get minute data for stock
                var minuteResponse = tickerContent.GetValue("min");
                string minuteData = JsonConvert.SerializeObject(minuteResponse);
                var minute = JsonConvert.DeserializeObject<Min>(minuteData);
                tickerDetails.minuteClose = minute.c;

                //do not add to top gainers list if the stock is over $5 a share or if had less than 500k shares prev day

                if (tickerDetails.previousDayClose >= 5.00 || tickerDetails.previousDayVolume < 500000)
                {
                    continue;
                }
                else
                {
                    //convert retrieved date to TickerDetails class
                    var tickerDetailsJson = JsonConvert.SerializeObject(tickerDetails);
                    tickerDetailsData =
                        JsonSerializer.Deserialize<TickerDetails>(tickerDetailsJson);
                    symbols.tickerDetails.Add(tickerDetailsData);
                    count++;

                }
            }
        
            topStocks.Add(symbols);
            return Task.FromResult(topStocks);
          // return topStocks;

        }

        public Task<List<Symbols>> RunTopTwenty()
        {

            while (true)
            {
                Thread.Sleep(5000);
                return TopTwenty();
            }

        }
    }
}

