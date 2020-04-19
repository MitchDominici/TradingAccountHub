using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlpacaAccountHub.Data.AlpacaAccount
{
    public class OrdersData
    {
        [Required]
        public string symbol { get; set;  }

        [Required]
        public string quantity { get; set; }

        public string side{ get; set; }

        public string sideBUY { get; set; } 

        public string sideSELL { get; set; }

        [Required]
        public string type { get; set; }

        [Required]
        public string timeInForce { get; set; }

        [Required]
        public string limitPrice { get; set; }

        public string stopPrice { get; set; }
    }

    public class SymbolLookup
    {
        public string ticker { get; set;  }
    }

    public class SubmittedOrder
    {

        public string id { get; set; }
        public string client_order_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime submitted_at { get; set; }
        public object filled_at { get; set; }
        public object expired_at { get; set; }
        public object canceled_at { get; set; }
        public object failed_at { get; set; }
        public object replaced_at { get; set; }
        public object replaced_by { get; set; }
        public object replaces { get; set; }
        public string asset_id { get; set; }
        public string symbol { get; set; }
        public string asset_class { get; set; }
        public string qty { get; set; }
        public string filled_qty { get; set; }
        public object filled_avg_price { get; set; }
        public string order_class { get; set; }
        public string order_type { get; set; }
        public string type { get; set; }
        public string side { get; set; }
        public string time_in_force { get; set; }
        public string limit_price { get; set; }
        public object stop_price { get; set; }
        public string status { get; set; }
        public bool extended_hours { get; set; }
        public object legs { get; set; }
        public bool submitted { get; set; }
        public bool canceled { get; set; }
    }
}
