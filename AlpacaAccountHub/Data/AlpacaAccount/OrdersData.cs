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

        [Required]
        string side { get; set; }

        [Required]
        string type { get; set; }

        [Required]
        string timeInForce { get; set; }

        [Required]
        string limitPrice { get; set; }

        string stopPrice { get; set; }
    }

    public class SymbolLookup
    {
        public string ticker { get; set;  }
    }
}
