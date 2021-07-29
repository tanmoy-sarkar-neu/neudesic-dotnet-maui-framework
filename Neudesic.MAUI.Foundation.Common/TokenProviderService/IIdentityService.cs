using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Common.TokenProviderService
{
    public interface IIdentityService
    { 
        Task<string> GetAccessTokenAsync();
    }
}
