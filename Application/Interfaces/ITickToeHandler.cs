using Common.Enums;
using Dto.Game;

namespace Application.Interfaces;

public interface ITickToeHandler
{
    /// <summary>
    /// find out winner or game status base on current sate
    /// </summary>
    /// <param name="cells">state of game</param>
    /// <returns>state enum</returns>
    GameStatusEnum GetGameStatus(char[][]? cells);

    /// <summary>
    /// find next move to be played
    /// </summary>
    /// <param name="cells"></param>
    /// <returns></returns>
    (int y, int x) FindNextMove (char[][]? cells);
}