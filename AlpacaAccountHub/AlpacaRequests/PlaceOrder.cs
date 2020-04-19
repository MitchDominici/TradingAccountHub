using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Pages;
using RestSharp;

namespace AlpacaAccountHub.AlpacaRequests
{
    public class PlaceOrder
    {
        private static string API_KEY = "";

        private static string API_SECRET = "";

        public void Buy(OrdersData order)
        {
            var client = new RestClient("https://paper-api.alpaca.markets/v2/orders ");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APCA-API-KEY-ID", "API_KEY");
            request.AddHeader("APCA-API-SECRET-KEY", "A/API_SECRET/bDM8s4D0j");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\r\n  \"side\": \"{order.side}\",\r\n  \"symbol\": \"{order.symbol}\",\r\n  \"type\": \"{order.type}\",\r\n  \"qty\": \"{order.quantity}\",\r\n  \"time_in_force\": \"{order.timeInForce}\",\r\n  \"limit_price\": \"{order.limitPrice}\"\r\n  \r\n}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        
    }
}
