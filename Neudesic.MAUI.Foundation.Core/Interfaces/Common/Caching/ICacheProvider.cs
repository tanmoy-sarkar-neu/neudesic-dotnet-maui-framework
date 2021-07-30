namespace Neudesic.MAUI.Foundation.Core.Interfaces.Common.Caching
{
    public interface ICacheProvider
    {
        public string GetValue(string key);

        public string SetValue(string key, string value);
    }
}