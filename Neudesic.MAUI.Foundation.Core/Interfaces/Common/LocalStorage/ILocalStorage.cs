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
        public Task SetItemAsync();

        public Task<object> GetItemAsync();

        public Task RemoveItemAsync(string key);

        public Task ClearAsync();
    }
}