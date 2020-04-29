using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Data.SymbolData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AlpacaAccountHub.AlpacaRequests
{
    public class Positions
    {
        PositionsData positionsInfo = new PositionsData();
        PositionsData positionsData = new PositionsData();

        public Task<PositionsData> AllPositions()
        {
            var client = new RestClient("https://paper-api.alpaca.markets/v2/positions ");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APCA-API-KEY-ID", PaperSecrets.API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", PaperSecrets.API_SECRET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            var positions = JsonConvert.DeserializeObject<List<PositionsData>>(response.Content);
            positionsInfo.numPositions = positions.Count;

            if (positions.Count > 0)
            {
                string openPositionsData = JsonConvert.SerializeObject(positions);
                var positionsContent = JArray.Parse(openPositionsData);
                var singlePosition = JObject.Parse(positionsContent[0].ToString());

                var singlePositionResponse = singlePosition.GetValue("symbol");
                string singlePositionData = JsonConvert.SerializeObject(singlePositionResponse);
                var newsinglePositionData = singlePositionData.Replace("\"", "");
                //var openPosition = JsonConvert.DeserializeObject<PositionsData>(newsinglePositionData);
                positionsInfo.symbol = newsinglePositionData;

               
               
            }

            var positionsJson = JsonConvert.SerializeObject(positionsInfo);
            positionsData = JsonSerializer.Deserialize<PositionsData>(positionsJson);

            return Task.FromResult(positionsData);
        }

        public Task<PositionsData> SinglePosition(string symbol)
        {
            var client = new RestClient($"https://paper-api.alpaca.markets/v2/positions/{symbol} ");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APCA-API-KEY-ID", PaperSecrets.API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", PaperSecrets.API_SECRET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            var positions = JsonConvert.DeserializeObject<PositionsData>(response.Content);

            positionsInfo.current_price = positions.current_price;
            positionsInfo.avg_entry_price = positions.avg_entry_price;
            positionsInfo.unrealized_intraday_pl = positions.unrealized_intraday_pl;
            positionsInfo.unrealized_intraday_plpc = positions.unrealized_intraday_plpc;
            positionsInfo.qty = positions.qty;

            var positionsJson = JsonConvert.SerializeObject(positionsInfo);
            positionsData =
                System.Text.Json.JsonSerializer.Deserialize<PositionsData>(positionsJson);

            return Task.FromResult(positionsData);
        }

        public async Task<PositionsData> RunSinglePosition()
        {
            

            while (true) 
            {
                var symbol = await AllPositions();
                Thread.Sleep(5000);
                var position = await SinglePosition(symbol.symbol);

            }

          
        }

    }
}
