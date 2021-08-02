using System;
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
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<T> GetValueAsync<T>(string key);

        /// <summary>
        ///  Set value in cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetValueAsync<T>(string key, T value);

        /// <summary>
        /// Delete key from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task DeleteKeyAsync(string key);

        /// <summary>
        /// Delete all keys from cache
        /// </summary>
        /// <returns></returns>
        public Task ClearAsync();
    }
}