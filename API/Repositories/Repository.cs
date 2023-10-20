using API.Model;
using Azure.Core;
using Newtonsoft.Json;
using RestSharp;

namespace API.Repositories
{
    public class Repository
    {
       public static Beer GetBeer()
        {
            var client = new RestClient("https://beers-list.p.rapidapi.com/beers/italy");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "504dd9ffacmsh56fecf99d897dafp120702jsn8bbd59f4e77f");
            request.AddHeader("X-RapidAPI-Host", "beers-list.p.rapidapi.com");
            RestResponse response = client.Execute(request);
            Beer beer = JsonConvert.DeserializeObject<Beer>(response.Content);
            return beer;
        }
    }
}
