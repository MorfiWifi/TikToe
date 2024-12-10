using Common.Enums;
using Dto;

namespace Application.Interfaces;

public interface ITickToeHandler
{
    /// <summary>
    /// find out winner or game status base on current sate
    /// </summary>
    /// <param name="state">state of game</param>
    /// <returns>state enum</returns>
    GameStatusEnum GetGameStatus(GameStateDto state);
}