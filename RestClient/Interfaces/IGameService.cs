using Dto.Game;
using Dto.Game.Game;

namespace RestClient.Interfaces;

public interface IGameService
{
    Task<ResponseDto<GameStateDto>> PlayAction(Guid gameId, PlayActionDto action);
    Task<ResponseDto<GameStateDto>> JoinGameById(Guid gameId, RequestDto request);
    Task<ResponseDto<GameStateDto>> FindGameById(Guid gameId, RequestDto request);
    Task<ResponseDto<GameStateDto>> CreateNewGame(RequestDto request);
    Task<PagedResponseDto<GameStateDto>> SearchHistory(SearchRequestDto search);
}