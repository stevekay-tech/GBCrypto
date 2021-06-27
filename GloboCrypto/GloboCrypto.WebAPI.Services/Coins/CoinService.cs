using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GloboCrypto.Models.Data;
using GloboCrypto.WebAPI.Services.Models;
using Microsoft.Extensions.Configuration;

namespace GloboCrypto.WebAPI.Services.Coins
{
    public class CoinService : ICoinService
    {
        private readonly HttpClient HttpClient;
        private readonly IConfiguration Configuration;

        public CoinService(IConfiguration configuration, HttpClient httpClient)
        {
            Configuration = configuration;
            HttpClient = httpClient;
        }

        private string NomicsAPIKey => Configuration["NomicsAPIKey"];

        public async Task<CoinInfo> GetCoinInfo(string coinId)
        {
            string url = $"https://api.nomics.com/v1/currencies?key={NomicsAPIKey}&ids={coinId}&attributes=id,name,description,logo_url";
            var nomicsCoin = await HttpClient.GetFromJsonAsync<NomicsCoinInfo[]>(url);
            if (nomicsCoin.Length > 0) { 
                return new CoinInfo
                {
                    Id = nomicsCoin[0].Id,
                    Name = nomicsCoin[0].Name,
                    Description = nomicsCoin[0].Description,
                    LogoUrl = nomicsCoin[0].LogoUrl
                };
            } 
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<CoinPriceInfo>> GetCoinPriceInfo(string coinIds)
        {
            throw new NotImplementedException();
        }
    }
}
