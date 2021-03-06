using FirstApp.Interfaces;
using FirstApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Services
{
    public class RestServices : IRestService
    {
        public async Task<List<Quote>> GetQuotes()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://quotes.stormconsultancy.co.uk/popular.json");
            return JsonConvert.DeserializeObject<List<Quote>>(response);
        }

        public async Task<bool> PostQuote(Quote quote)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(quote);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://quotes.stormconsultancy.co.uk/popular.json", content);
            return response.IsSuccessStatusCode;
        }
    }
}
