using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineStore.EFCore.Web.Services
{
    public interface IOnlineStoreHttpClient
    {
        Task<HttpClient> GetClient();
    }
}
