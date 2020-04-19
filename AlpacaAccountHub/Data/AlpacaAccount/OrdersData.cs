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
        public string side { get; set; }

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
}
