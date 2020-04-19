using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlpacaAccountHub.Data.SymbolData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace AlpacaAccountHub.AlpacaRequests
{
    public class Assets
    {
        private static string API_KEY = "";

        private static string API_SECRET = "";

        public string AssetTradable()
        {
            TickerDetails tickerDetails = new TickerDetails();
            TickerDetails tickerDetailsData = new TickerDetails();

            var client = new RestClient("https://paper-api.alpaca.markets/v2/assets/MBRX");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APCA-API-KEY-ID", API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", API_SECRET);
            IRestResponse response = client.Execute(request);

            var responseContent = JObject.Parse(response.Content);

            var tradableResponse = responseContent.GetValue("tradable");
            string tradableData = JsonConvert.SerializeObject(tradableResponse);

            tickerDetails.tradable = tradableData;

            var tickerDetailsJson = JsonConvert.SerializeObject(tickerDetails);
            tickerDetailsData =
                System.Text.Json.JsonSerializer.Deserialize<TickerDetails>(tickerDetailsJson);

            return tickerDetails.tradable;
        }
    }
}
