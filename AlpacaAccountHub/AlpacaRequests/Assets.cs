using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Data.ApiKeys;
using AlpacaAccountHub.Data.SymbolData;
using AlpacaAccountHub.UpdateAccount;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace AlpacaAccountHub.AlpacaRequests
{
    public class Assets
    {
      
        public string AssetTradable(string ticker)
        {

            TickerDetails tickerDetails = new TickerDetails();
            TickerDetails tickerDetailsData = new TickerDetails();

            var client = new RestClient($"https://paper-api.alpaca.markets/v2/assets/{ticker}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APCA-API-KEY-ID", LiveSecrets.API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", LiveSecrets.API_SECRET);
            IRestResponse response = client.Execute(request);

            TickerDetails tradableResponse = JsonConvert.DeserializeObject<TickerDetails>(response.Content);

            tickerDetails.tradable = tradableResponse.tradable;

            var tickerDetailsJson = JsonConvert.SerializeObject(tickerDetails);
            tickerDetailsData =
                System.Text.Json.JsonSerializer.Deserialize<TickerDetails>(tickerDetailsJson);

            return tickerDetails.tradable;
        }
    }
}
