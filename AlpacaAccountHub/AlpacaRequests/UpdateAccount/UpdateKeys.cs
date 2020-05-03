using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlpacaAccountHub.Data;
using AlpacaAccountHub.Data.ApiKeys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AlpacaAccountHub.UpdateAccount
{
    public class UpdateKeys
    {
        private readonly ApplicationDbContext _context;

        public UpdateKeys(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddKey( string[] apiKeys)
        {
            try
            {
                var removeKeys = _context.AlpacaApiKey.Max(i => i.id);
                var keyId = _context.AlpacaApiKey.Single(i => i.id == removeKeys);
                _context.AlpacaApiKey.Remove(keyId);
            }
            catch (Exception e)
            {

            }
            _context.AlpacaApiKey.Add(new AlpacaApiKey { API_KEY = apiKeys[0], API_SECRET = apiKeys[1],paper_KEY = apiKeys[2], paper_SECRET = apiKeys[3]});
            
            _context.SaveChanges();
        }

        public List<AlpacaApiKey> DisplayKey()
        {
            var keys = _context.AlpacaApiKey.ToList();
            return keys;
        }

    }
}
