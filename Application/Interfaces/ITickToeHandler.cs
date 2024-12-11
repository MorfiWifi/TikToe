using Common.Enums;
using Dto.Game;

namespace Application.Interfaces;

public interface ITickToeHandler
{
    /// <summary>
    /// find out winner or game status base on current sate
    /// </summary>
    /// <param name="baseState">state of game</param>
    /// <returns>state enum</returns>
    GameStatusEnum GetGameStatus(GameBaseStateDto baseState);
}