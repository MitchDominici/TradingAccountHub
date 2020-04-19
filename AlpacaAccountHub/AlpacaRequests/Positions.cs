using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlpacaAccountHub.Data.AlpacaAccount;
using Newtonsoft.Json;
using RestSharp;

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
            request.AddHeader("APCA-API-KEY-ID", LiveSecrets.API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", LiveSecrets.API_SECRET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            var positions = JsonConvert.DeserializeObject<List<PositionsData>>(response.Content);
            positionsInfo.numPositions = positions.Count;

            var positionsJson = JsonConvert.SerializeObject(positionsInfo);
            positionsInfo =
                System.Text.Json.JsonSerializer.Deserialize<PositionsData>(positionsJson);

            return Task.FromResult(positionsData);
        }
    }
}
