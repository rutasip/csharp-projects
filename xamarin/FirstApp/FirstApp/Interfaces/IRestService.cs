using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Interfaces
{
    public interface IRestService
    {
        Task<List<Quote>> GetQuotes();
        Task<bool> PostQuote(Quote quote);
    }
}
