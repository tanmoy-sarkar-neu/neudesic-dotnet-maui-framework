using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Core.Interfaces.Common.LocalStorage
{
    /// <summary>
    /// Contract for Local Storage
    /// </summary>
    public interface ILocalStorage
    {
        /// <summary>
        /// Persist Item in LocalStorage
        /// </summary>
        /// <returns></returns>
        public Task SetItemAsync();

        public Task<T> GetItemAsync<T>();

        public Task RemoveItemAsync(string key);

        public Task ClearAsync();
    }
}