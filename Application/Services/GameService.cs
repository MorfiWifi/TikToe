using Application.Interfaces;
using Dto.Game;
using Dto.Game.Game;

namespace Application.Services;

public class GameService : IGameService
{
    public GameStateDto PlayAction(Guid gameId, PlayActionDto action)
    {
        throw new NotImplementedException();
    }

    public GameStateDto JoinGameById(Guid gameId, RequestDto request)
    {
        throw new NotImplementedException();
    }

    public GameStateDto FindGameById(Guid gameId, RequestDto request)
    {
        throw new NotImplementedException();
    }

    public GameStateDto CreateNewGame(RequestDto request)
    {
        throw new NotImplementedException();
    }

    public PagedResponseDto<GameStateDto> SearchHistory(SearchRequestDto search)
    {
        throw new NotImplementedException();
    }
}