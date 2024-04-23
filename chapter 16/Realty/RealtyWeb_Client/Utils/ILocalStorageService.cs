namespace RealtyWeb_Client.Utils
{
public interface ILocalStorageService
{
    Task SetStringAsync(string key, string value);
    Task SetAsync<T>(string key, T item) where T : class;
    Task<string> GetStringAsync(string key);
    Task<T> GetAsync<T>(string key) where T : class;
    Task RemoveAsync(string key);
}
}
