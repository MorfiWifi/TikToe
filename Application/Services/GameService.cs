using Application.Interfaces;
using Dto.Game;

namespace Application.Services;

public class GameService : IGameService
{
    public bool GameExists(Guid gameId, string username)
    {
        throw new NotImplementedException();
    }

    public ActionResponseDto PlayAction(Guid gameId, PlayActionDto action)
    {
        throw new NotImplementedException();
    }
}