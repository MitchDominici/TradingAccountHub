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
    public class UpdateKeys: Controller
    {
        private readonly ApplicationDbContext _context;

        public UpdateKeys(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddKey( string[] apiKeys)
        {
            _context.AlpacaApiKey.Update(new AlpacaApiKey { API_KEY = apiKeys[0], API_SECRET = apiKeys[1] });
            
            _context.SaveChanges();
        }

        public List<AlpacaApiKey> DisplayKey()
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

            var keys = _context.AlpacaApiKey.ToList();
            return keys;
        }

    }
}
