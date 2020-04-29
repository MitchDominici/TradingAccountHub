using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpacaAccountHub.Data.AlpacaAccount
{
    public class PositionsData
    {
        public string asset_id { get; set; }
        public string symbol { get; set; }
        public string exchange { get; set; }
        public string asset_class { get; set; }
        public string avg_entry_price { get; set; }
        public string qty { get; set; }
        public string side { get; set; }
        public string market_value { get; set; }
        public string cost_basis { get; set; }
        public string unrealized_pl { get; set; }
        public string unrealized_plpc { get; set; }
        public string unrealized_intraday_pl { get; set; }
        public string unrealized_intraday_plpc { get; set; }
        public string current_price { get; set; }
        public string lastday_price { get; set; }
        public string change_today { get; set; }

        public int numPositions { get; set; }
    }

    public class PositionsList
    {
        public List<PositionsData> positionsList { get; set; }
    }
}
