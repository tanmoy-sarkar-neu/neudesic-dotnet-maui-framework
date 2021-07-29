using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Infrastructure.Http
{
    public interface IIdentityService
    {
        // TODO: @Sangeetha - Change the return type accordingly
        Task<string> GetToken();
    }
}