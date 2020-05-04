using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlpacaAccountHub.Data.AlpacaAccount;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace AlpacaAccountHub
{
    class PollingService : BackgroundService
    {
        private Timer _timer;

       

        public  Task<PositionsData> SinglePosition(string symbol)
        {
            PositionsData positionsInfo = new PositionsData();
            PositionsData positionsData = new PositionsData();
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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
