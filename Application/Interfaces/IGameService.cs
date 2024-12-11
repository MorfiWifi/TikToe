using Dto.Game;
using Dto.Game.Game;

namespace Application.Interfaces;

public interface IGameService
{
    GameStateDto PlayAction(Guid gameId, PlayActionDto action);
    GameStateDto JoinGameById(Guid gameId, RequestDto request);
    GameStateDto FindGameById(Guid gameId, RequestDto request);
    GameStateDto CreateNewGame(RequestDto request);
    PagedResponseDto<GameStateDto> SearchHistory(SearchRequestDto search);
}