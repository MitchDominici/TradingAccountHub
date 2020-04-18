using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AlpacaAccountHub.Data.SymbolData;
using Websocket.Client;

namespace AlpacaAccountHub.WebSockets
{
    public class SymbolWebsocket
    {
        public async Task<StreamMessage> Quotes()
        {
            var url = new Uri("wss://socket.polygon.io/stocks");
            var exitEvent = new ManualResetEvent(false);
            StreamMessage message = new StreamMessage();
            StreamMessage messageData = new StreamMessage();

            using (var client = new WebsocketClient(url))
            {
                client.MessageReceived.Subscribe(msg => message.message =  msg.ToString());
                await client.Start();

                client.Send("{\"action\":\"auth\",\"params\":\"{your alpaca api key here}\"}");
                client.Send("{\"action\":\"subscribe\",\"params\":\"Q.MBRX\"}");
                client.Send("{\"action\":\"subscribe\",\"params\":\"A.MBRX\"}");

                
                var messageJson = JsonConvert.SerializeObject(message);
                messageData = System.Text.Json.JsonSerializer.Deserialize<StreamMessage>(messageJson);

                exitEvent.GetSafeWaitHandle();
            }

            return await Task.FromResult(messageData);
        }
    }
}
