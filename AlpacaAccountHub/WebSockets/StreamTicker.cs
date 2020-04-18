using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using WebSocket4Net;
using System.Security.Authentication;
using Newtonsoft.Json;
using AlpacaAccountHub.Data.SymbolData;


namespace AlpacaAccountHub.WebSockets
{
    public class StreamTicker
    {
        WebSocket websocket;
        StreamMessage message = new StreamMessage();
        StreamMessage messageData = new StreamMessage();

        static void Stream()
        {
            new StreamTicker().Start();
        }
        public void Start()
        {
            this.websocket = new WebSocket("wss://socket.polygon.io/stocks", sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);
            this.websocket.Opened += websocket_Opened;
            this.websocket.Error += websocket_Error;
            this.websocket.Closed += websocket_Closed;
            this.websocket.MessageReceived += websocket_MessageReceived;
            this.websocket.Open();
            Console.ReadKey();
        }
        private void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Connected!");
            this.websocket.Send("{\"action\":\"auth\",\"params\":\"{your alpaca api key here}\"}");
            this.websocket.Send("{\"action\":\"subscribe\",\"params\":\"T.AAPL\"}");
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
           
            
        }
    }
}
