﻿using Microsoft.JSInterop;
using RealtyWeb_Server.Utils.IService;
using System.Text.Json;

namespace RealtyWeb_Server.Utils
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            var jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            var data = await jsModule.InvokeAsync<string>("get", key);
            if (string.IsNullOrEmpty(data))
            {
                return null!;
            }
            return JsonSerializer.Deserialize<T>(data)!;
        }

        public async Task<string> GetStringAsync(string key)
        {
            var jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            return await jsModule.InvokeAsync<string>("get", key);
        }

        public async Task RemoveAsync(string key)
        {
            var jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            await jsModule.InvokeAsync<string>("remove", key);
        }

        public async Task SetAsync<T>(string key, T item) where T : class
        {
            var jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            var data = JsonSerializer.Serialize(item);
            await jsModule.InvokeVoidAsync("set", key, data);
        }

        public async Task SetStringAsync(string key, string value)
        {
            var jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/jsinterop.js");
            await jsModule.InvokeAsync<string>("set", key, value);
        }
    }
}
