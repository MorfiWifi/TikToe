using Dto.Game;

namespace Application.Interfaces;

public interface IGameService
{
    /// <summary>
    /// find game for given user
    /// </summary>
    /// <param name="gameId"></param>
    /// <param name="username"></param>
    /// <returns></returns>
    public bool GameExists(Guid gameId , string username);

    ActionResponseDto PlayAction(Guid gameId, PlayActionDto action);
}