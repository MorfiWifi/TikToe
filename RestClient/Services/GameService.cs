using System.Net.Http.Json;
using Dto.Game;
using Dto.Game.Game;
using RestClient.Extensions;
using RestClient.Interfaces;

namespace RestClient.Services;

public class GameService : IGameService
{
    private readonly HttpClient _httpClient;

    public GameService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ResponseDto<GameStateDto>> PlayAction(Guid gameId, PlayActionDto action)
    {
        return await _httpClient.PostAsJsonAsync<PlayActionDto , ResponseDto<GameStateDto>>($"/api/v1/Games/PlayAction/{gameId}", action);
    }

    public async Task<ResponseDto<GameStateDto>> JoinGameById(Guid gameId, RequestDto request)
    {
        return await _httpClient.PostAsJsonAsync<RequestDto, ResponseDto<GameStateDto>>($"/api/v1/Games/JoinGame/{gameId}", request);
    }

    public async Task<ResponseDto<GameStateDto>> FindGameById(Guid gameId, RequestDto request)
    {
        return await _httpClient.PostAsJsonAsync<RequestDto,ResponseDto<GameStateDto>>($"/api/v1/Games/GetGame/{gameId}", request);
    }

    public async Task<ResponseDto<GameStateDto>> CreateNewGame(RequestDto request)
    {
        return await _httpClient.PostAsJsonAsync<RequestDto , ResponseDto<GameStateDto>>("/api/v1/Games/CreateGame", request );
    }

    public async Task<PagedResponseDto<GameStateDto>> SearchHistory(SearchRequestDto search)
    {
        return await _httpClient.PostAsJsonAsync<SearchRequestDto,PagedResponseDto<GameStateDto>>("/api/v1/Games/MyGames", search);
    }
}