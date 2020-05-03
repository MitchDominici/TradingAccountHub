using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using WebSocket4Net;
using System.Security.Authentication;
using AlpacaAccountHub.AlpacaRequests;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Data.ApiKeys;
using Newtonsoft.Json;
using AlpacaAccountHub.Data.SymbolData;
using AlpacaAccountHub.Data.WebSocketData;
using Newtonsoft.Json.Linq;


namespace AlpacaAccountHub.WebSockets
{
    public class HandleMessage
    {
        AlpacaApiKey keys = new AlpacaApiKey();
        public async void HandleOrder(string message)
        {
            OpenConnection getPosition = new OpenConnection();
            SubmitOrder placeOrder = new SubmitOrder();
            Second streamingDetails = new Second();
            Second streamingDetailsData = new Second();
            OrdersData order = new OrdersData();
            OrdersData OrderDetails = new OrdersData();
            OrdersData OrderDetailsData = new OrdersData();


            var positions = getPosition.AllPositions();
            foreach (var position in positions)
            {
                var pos = position.positionsList;
                foreach (var symbol in pos)
                {
                    Positions single = new Positions();
                    var openPosition = await single.SinglePosition(symbol.symbol);
                    var entryPrice = Convert.ToDouble(symbol.avg_entry_price);

                    var seconds = JArray.Parse(message);

                    foreach (var second in seconds)
                    {
                        var secondData = JsonConvert.SerializeObject(second);
                        var secondContent = JsonConvert.DeserializeObject<Second>(secondData);

                        streamingDetails.sym = secondContent.sym; // Symbol Ticker

                        if (secondData == "{\"ev\":\"status\",\"status\":\"connected\",\"message\":\"Connected Successfully\"}" || secondData == "{\"ev\":\"status\",\"status\":\"auth_timeout\",\"message\":\"No authentication request received.\"}" || secondData == "{\"ev\":\"status\",\"status\":\"auth_success\",\"message\":\"authenticated\"}" || secondData == $"{{\"ev\":\"status\",\"status\":\"success\",\"message\":\"subscribed to: A.{symbol.symbol}\"}}")
                        {
                            break;
                        }

                        

                        streamingDetails.v = secondContent.v; // Tick Volume
                        streamingDetails.av = secondContent.av; // Accumulated Volume ( Today )
                        streamingDetails.op = secondContent.op; // Todays official opening price
                        streamingDetails.vw = secondContent.vw; // VWAP (Volume Weighted Average Price)
                        streamingDetails.o = secondContent.o; // Tick Open Price
                        streamingDetails.c = secondContent.c; // Tick Close Price
                        streamingDetails.h = secondContent.h; // Tick High Price
                        streamingDetails.l = secondContent.l; // Tick Low Price
                        streamingDetails.a = secondContent.a; // Tick Average / VWAP Price
                        streamingDetails.s = secondContent.s; // Tick Start Timestamp ( Unix MS )
                        streamingDetails.e = secondContent.e; // Tick End Timestamp ( Unix MS )

                        if (secondContent.o < entryPrice)
                        {
                            var negEntryDifference = entryPrice - streamingDetails.o;
                            var negPerc = negEntryDifference / entryPrice;
                            if (negPerc >= 0.0500000)
                            {

                                order.limitPrice = Convert.ToString(streamingDetails.c);
                                order.quantity = symbol.qty;
                                order.symbol = symbol.symbol;

                                var OrderDetailsJson = JsonConvert.SerializeObject(order);
                                OrderDetailsData =
                                    System.Text.Json.JsonSerializer.Deserialize<OrdersData>(OrderDetailsJson);
                                await placeOrder.PlaceOrder(OrderDetailsData, "limit", "gtc", "sell");
                            }
                        }

                        if (streamingDetails.o > entryPrice)
                        {
                            var posEntryDifference = streamingDetails.o - entryPrice;
                            var posPerc = posEntryDifference / entryPrice;
                            if (posPerc >= 0.10)
                            {

                                order.limitPrice = Convert.ToString(streamingDetails.c);
                                order.quantity = symbol.qty;
                                order.symbol = symbol.symbol;

                                var OrderDetailsJson = JsonConvert.SerializeObject(order);
                                OrderDetailsData =
                                    System.Text.Json.JsonSerializer.Deserialize<OrdersData>(OrderDetailsJson);
                                await placeOrder.PlaceOrder(OrderDetailsData, "limit", "gtc", "sell");
                            }
                        }

                    }
                }

           

            }
        }
        
    }

}