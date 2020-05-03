using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;
using AlpacaAccountHub.Data;
using Newtonsoft.Json;
using AlpacaAccountHub.Data;
using AlpacaAccountHub.Data.AlpacaAccount;
using AlpacaAccountHub.Data.ApiKeys;
using AlpacaAccountHub.Data.SymbolData;
using AlpacaAccountHub.UpdateAccount;

namespace AlpacaAccountHub.AlpacaRequests
{
    public class AlpacaAccountInfo
    {
       
        public async Task<AlpacaAccountData> AccountInfo()
        {
           
            
            var today = DateTime.Today;

            AlpacaAccountData accountInfo = new AlpacaAccountData();
            AlpacaAccountData accountDetailsData = new AlpacaAccountData();

            // First, open the API connection
            var client = Alpaca.Markets.Environments.Live
                .GetAlpacaTradingClient(new SecretKey(LiveSecrets.API_KEY,LiveSecrets.API_SECRET));

            var account = await client.GetAccountAsync();

            accountInfo.numberOfDayTrades = account.DayTradeCount;
            accountInfo.dayTradingPower = account.DayTradingBuyingPower;
            accountInfo.today = today;
            accountInfo.equity = account.Equity;


            var accountDetailsJson = JsonConvert.SerializeObject(accountInfo);
            accountDetailsData =
                System.Text.Json.JsonSerializer.Deserialize<AlpacaAccountData>(accountDetailsJson);


            return accountDetailsData;
        }
    }
}

