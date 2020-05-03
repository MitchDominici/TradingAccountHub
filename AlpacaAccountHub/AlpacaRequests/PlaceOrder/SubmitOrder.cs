using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Data.ApiKeys;
using AlpacaAccountHub.Data.SymbolData;
using AlpacaAccountHub.Data.ApiKeys;
using AlpacaAccountHub.Pages;
using AlpacaAccountHub.UpdateAccount;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AlpacaAccountHub.AlpacaRequests
{
    public class SubmitOrder
    {

        SubmittedOrder OrderDetails = new SubmittedOrder();
        SubmittedOrder OrderDetailsData = new SubmittedOrder();
      
        public Task<SubmittedOrder > PlaceOrder(OrdersData order, string type, string timeInForce, string side)
        {
           
            string price = "";

            var symbol = order.symbol.Replace("\"", "").ToUpper();

            if (order.limitPrice == null)
            {
                price = $" \"stop_price\": \"{order.stopPrice}\"\r\n  \r\n}} ";
            }
            else
            {
                price = $" \"limit_price\": \"{order.limitPrice}\"\r\n \r\n}} ";
            }


            var client = new RestClient("https://paper-api.alpaca.markets/v2/orders ");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("APCA-API-KEY-ID", PaperSecrets.API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", PaperSecrets.API_SECRET);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\r\n  \"side\": \"{side}\",\r\n " +
                                                     $" \"symbol\": \"{symbol}\",\r\n " +
                                                     $" \"type\": \"{type}\",\r\n " +
                                                     $" \"qty\": \"{order.quantity}\",\r\n " +
                                                     $" \"time_in_force\": \"{timeInForce}\",\r\n  " +
                                                     price, 
                                                     ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            var responseContent = JObject.Parse(response.Content);

            SubmittedOrder submittedOrder = JsonConvert.DeserializeObject<SubmittedOrder>(response.Content);

            OrderDetails.submitted_at = submittedOrder.submitted_at;
            OrderDetails.filled_at = submittedOrder.filled_at;
            OrderDetails.symbol = submittedOrder.symbol;
            OrderDetails.id = submittedOrder.id;
            OrderDetails.limit_price = submittedOrder.limit_price;
            OrderDetails.side = submittedOrder.side;
            OrderDetails.qty = submittedOrder.qty;
            OrderDetails.submitted = true;

            var OrderDetailsJson = JsonConvert.SerializeObject(OrderDetails);
            OrderDetailsData =
                System.Text.Json.JsonSerializer.Deserialize<SubmittedOrder>(OrderDetailsJson);

            return Task.FromResult(OrderDetailsData);
        }

        public Task<SubmittedOrder> CancelOrder(string orderID)
        {
            

            var client = new RestClient($"https://paper-api.alpaca.markets/v2/orders/{orderID} ");
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("APCA-API-KEY-ID", PaperSecrets.API_KEY);
            request.AddHeader("APCA-API-SECRET-KEY", PaperSecrets.API_SECRET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            OrderDetails.submitted = false;
            OrderDetails.canceled = response.IsSuccessful;

            var OrderDetailsJson = JsonConvert.SerializeObject(OrderDetails);
            OrderDetailsData =
                System.Text.Json.JsonSerializer.Deserialize<SubmittedOrder>(OrderDetailsJson);

            return Task.FromResult(OrderDetailsData);

            
        }


    }
}
