using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlpacaAccountHub.Data.ApiKeys
{
    public class AlpacaApiKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }

        public string User_Id { get; set; }


        public string API_KEY { get; set; }

        public string API_SECRET { get; set; }

        public string paper_KEY { get; set; }

        public string paper_SECRET { get; set; }


    }
}
