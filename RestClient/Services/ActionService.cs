using Dto.Game;
using Dto.Game.Action;
using RestClient.Extensions;
using RestClient.Interfaces;

namespace RestClient.Services;

public class ActionService : IActionService
{
    private readonly HttpClient _httpClient;

    public ActionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<PagedResponseDto<ActionPlayedDto>> GetHistory(Guid gameId, SearchRequestDto search)
    {
        return await _httpClient.PostAsJsonAsync<SearchRequestDto , PagedResponseDto<ActionPlayedDto>>($"/api/v1/Actions/List/{gameId}", search);
    }
}