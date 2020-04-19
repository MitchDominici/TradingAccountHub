using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;
using Newtonsoft.Json;
using AlpacaAccountHub.Data;

namespace AlpacaAccountHub.AlpacaRequests
{
    public class AssetTradeable
    {
        private static string API_KEY = "";

        private static string API_SECRET = "";

        public async Task<AlpacaAccountData> AccountInfo()
        {
            var today = DateTime.Today;

            AlpacaAccountData accountInfo = new AlpacaAccountData();
            AlpacaAccountData accountDetailsData = new AlpacaAccountData();

            // First, open the API connection
            var client = Alpaca.Markets.Environments.Live
                .GetAlpacaTradingClient(new SecretKey(API_KEY, API_SECRET));

            var account = await client.GetAccountAsync();

            accountInfo.numberOfDayTrades = account.DayTradeCount;
            accountInfo.dayTradingPower = account.DayTradingBuyingPower;
            accountInfo.today = today;

            var accountDetailsJson = JsonConvert.SerializeObject(accountInfo);
            accountDetailsData =
                System.Text.Json.JsonSerializer.Deserialize<AlpacaAccountData>(accountDetailsJson);

            return accountDetailsData;

        }
    }
}
