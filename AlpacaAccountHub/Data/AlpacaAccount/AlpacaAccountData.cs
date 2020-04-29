using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlpacaAccountHub.Data
{
    public class AlpacaAccountData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public string id { get; set; }
        public decimal dayTradingPower { get; set; }

        public decimal equity { get; set; }
        public long numberOfDayTrades { get; set; }

        public DateTime today { get; set; }

       
    }
}
