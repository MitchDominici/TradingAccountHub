using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using WebSocket4Net;
using System.Security.Authentication;
using AlpacaAccountHub.AlpacaRequests;
using AlpacaAccountHub.Data;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Data.ApiKeys;
using Newtonsoft.Json;
using AlpacaAccountHub.Data.SymbolData;
using AlpacaAccountHub.UpdateAccount;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AlpacaAccountHub.WebSockets
{
    public class OpenConnection
    {
        WebSocket websocket;
        PositionsData positionsInfo = new PositionsData();
        PositionsData positionsData = new PositionsData();
        List<PositionsList> positionsList = new List<PositionsList>();
        PositionsList newPositionsList = new PositionsList();
       
        static void Stream()
        {
            new OpenConnection().Start();
        }
        public void Start()
        {
            
            this.websocket = new WebSocket("wss://socket.polygon.io/stocks", sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);
            this.websocket.Opened += websocket_Opened;
            this.websocket.Error += websocket_Error;
            this.websocket.Closed += websocket_Closed;
            this.websocket.MessageReceived += websocket_MessageReceived;
            this.websocket.Open();
            
        }
        private void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Connected!");
            this.websocket.Send($"{{\"action\":\"auth\",\"params\":\"{LiveSecrets.API_KEY }\"}}");
            var positions = AllPositions();
            foreach (var position in positions.ToList())
            {
                var pos = position.positionsList;
                foreach (var symbol in pos)
                {
                    this.websocket.Send($"{{\"action\":\"subscribe\",\"params\":\"A.{symbol.symbol}\"}}");
                }
            }
        }
        private void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine("WebSocket Error");
            Console.WriteLine(e.Exception.Message);
        }
        private void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Connection Closed...");
            // Add Reconnect logic... this.Start()
        }
        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Debug.WriteLine(e.Message);

            HandleMessage order = new HandleMessage();
            order.HandleOrder(e.Message);

        }
        public List<PositionsList> AllPositions()
        {
            List<PositionsData> positions = new List<PositionsData>();
            newPositionsList.positionsList = new List<PositionsData>();

            var client = new RestClient("https://paper-api.alpaca.markets/v2/positions ");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APCA-API-KEY-ID", PaperSecrets.API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", PaperSecrets.API_SECRET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            try
            {
                positions = JsonConvert.DeserializeObject<List<PositionsData>>(response.Content);
            }
            catch (Newtonsoft.Json.JsonSerializationException e)
            {
            }

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

                var positionQuantityResponse = singlePosition.GetValue("qty");
                string positionQuantityData = JsonConvert.SerializeObject(positionQuantityResponse);
                var newPositionQuantityData = positionQuantityData.Replace("\"", "");

                var avgEntryPriceResponse = singlePosition.GetValue("avg_entry_price");
                string avgEntryPriceData = JsonConvert.SerializeObject(avgEntryPriceResponse);
                var newAvgEntryPriceData = avgEntryPriceData.Replace("\"", "");

                positionsInfo.avg_entry_price = newAvgEntryPriceData;
                positionsInfo.qty = newPositionQuantityData;

                var positionsJson = JsonConvert.SerializeObject(positionsInfo);
                positionsData =
                    System.Text.Json.JsonSerializer.Deserialize<PositionsData>(positionsJson);

                newPositionsList.positionsList.Add(positionsData);
            }
            positionsList.Add(newPositionsList);


            return positionsList;
        }

        public PositionsData SinglePosition(string symbol)
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

            var positionsJson = JsonConvert.SerializeObject(positionsInfo);
            positionsData =
                System.Text.Json.JsonSerializer.Deserialize<PositionsData>(positionsJson);

            return positionsData;
        }
        /*
        public PositionsData GetPositions()
        {
            var positionsList = AllPositions();
            var symbol = SinglePosition(positionsList.symbol);

            return symbol;
        }
        */

    }


}
