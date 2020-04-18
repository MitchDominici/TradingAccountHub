using System;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;
using AlpacaAccountHub.Data;
using Newtonsoft.Json;
using AlpacaAccountHub.Data;
using AlpacaAccountHub.Data.SymbolData;

namespace AlpacaAccountHub.AlpacaRequests
{
    public class AlpacaAccountInfo
    {
        private static string API_KEY = "{your key here}";

        private static string API_SECRET = "{your secret here}";

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

