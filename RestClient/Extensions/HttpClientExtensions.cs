using System.Net.Http.Json;

namespace RestClient.Extensions;

public static class HttpClientExtensions
{
    public static async Task<V> PostAsJsonAsync<U, V>(this HttpClient client, string url, U request)
    {
        var response = await  client.PostAsJsonAsync(url, request, CancellationToken.None);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<V>();
            if (result is null)
                throw new HttpRequestException($"Could not read response from {url} as valid JSON.");
            return result;
        }
        else
        {
            // Log error or throw exception based on status code
            var error = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Error: {response.StatusCode}, Details: {error}");
        }
    }
    
}