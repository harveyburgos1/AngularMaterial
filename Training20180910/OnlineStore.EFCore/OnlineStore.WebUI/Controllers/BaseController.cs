using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineStore.WebUI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected async Task<HttpResponseMessage> SendRequest(string url)
        {
            var discovery = await DiscoveryClient
              .GetAsync("https://localhost:44350");
            if (discovery.IsError)
            {
                Console.WriteLine(discovery.Error);

                return null;
            }

            var tokenClient = new TokenClient(discovery.TokenEndpoint, "onlinestore", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("onlinestoreapi");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return null;
            }

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return null;
            }
            return response;

        }
    }
}
