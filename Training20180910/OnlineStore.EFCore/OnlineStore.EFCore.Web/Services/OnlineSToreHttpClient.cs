using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OnlineStore.EFCore.Web.Services
{
    public class OnlineStoreHttpClient : IOnlineStoreHttpClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private HttpClient _httpClient = new HttpClient();

        public OnlineStoreHttpClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<HttpClient> GetClient()
        {      
            _httpClient.BaseAddress = new Uri("https://localhost:44366/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return _httpClient;
        }        
    }
}

