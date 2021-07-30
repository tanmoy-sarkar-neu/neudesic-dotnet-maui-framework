using System;
using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Common.TokenProviderService
{
    public abstract class IdentityService : IIdentityService
    {
        // TODO: @Sangeeta - This method should take care of token expiry and getting token from cache. Depends on ITokenProvider. Change the return type accordingly.
        public virtual Task<string> GetAccessTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}
