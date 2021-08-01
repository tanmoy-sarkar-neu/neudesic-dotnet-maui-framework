using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Core.Interfaces.Common.Caching
{
    /// <summary>
    /// Contract for cache
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Get value from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<string> GetValueAsync(string key);

        /// <summary>
        /// Set value in cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<string> SetValueAsync(string key, string value);

        /// <summary>
        /// Delete key from cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<string> DeleteKeyAsync(string key, string value);

        /// <summary>
        /// Delete all keys from cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<string> DeleteAllAsync(string key, string value);
    }
}