using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Core.Interfaces.Common.Caching
{
    public interface ICacheProvider
    {
        public Task<string> GetValueAsync(string key);

        public Task<string> SetValueAsync(string key, string value);
    }
}