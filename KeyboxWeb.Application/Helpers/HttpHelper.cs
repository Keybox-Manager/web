using KeyboxWeb.Core.Interfaces.Helpers;
using KeyboxWeb.Core.Interfaces.Markers;
using KeyboxWeb.Core.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace KeyboxWeb.Application.Helpers;

public sealed class HttpHelper<T> : IHttpHelper<T> where T : IModel
{
    private readonly HttpClient _httpClient;
    private readonly KeyboxAPI _api;

    public HttpHelper(HttpClient httpClient, IOptions<KeyboxAPI> api)
    {
        _httpClient = httpClient;
        _api = api.Value;
        _httpClient.BaseAddress = new Uri($"{_api.Url}/{typeof(T).Name}");

        //Нужно будет добавить проверки, чтобы отловить ошибки
        //https://metanit.com/sharp/net/2.7.php
    }

    public async Task AddAsync(T model)
    {
        await _httpClient.PostAsJsonAsync("Add", model);
    }

    public async Task DeleteAsync(int id)
    {
        await _httpClient.DeleteAsync($"Delete/{id}");
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<T>>($"Get") ?? [];
    }

    public async Task<T?> GetAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<T>($"Get/{id}");
    }

    public async Task UpdateAsync(T model)
    {
        await _httpClient.PutAsJsonAsync("Update", model);
    }
}