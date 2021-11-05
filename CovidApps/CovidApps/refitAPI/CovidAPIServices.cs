using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
namespace CovidApps.api.covid19
{
  
    public interface CovidAPIServices
    {
        [Get("/country/{country}?from={from}&to={to}")] 
        Task<List<json.covid19.JsonCovidRecord>> GetCovidRecord([AliasAs("country")] string country, [AliasAs("from")] string from,
            [AliasAs("to")] string to);
  
    }
   
}
