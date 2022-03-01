using DuckDuck.ViewModels;
using DuckDuckGoProxy.Configuration;
using DuckDuckGoProxy.Integration.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DuckDuck.Client
{
    public class DuckDuckClient : HttpClient, IDuckDuckClient<DuckDuckRequest, DuckDuckResponse>
    {
        private readonly DuckDuckSource _duckDuckSource;

        public DuckDuckClient(DuckDuckSource duckDuckSource)
        {
            _duckDuckSource = duckDuckSource;
        }

        public async Task<DuckDuckResponse> GetAsync(DuckDuckRequest request)
        {
            var query = $"{_duckDuckSource.Url}?q={request.Query}&format=json";
            var result = await GetAsync(query);
            var resultString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DuckDuckResponse>(resultString);
        }
    }
}
