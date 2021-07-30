using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Common.TokenProviderService
{
    public interface ITokenProvider
    {
        Task<string> GetAccessTokenAsync();
    }
}