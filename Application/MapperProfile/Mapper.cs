using Application.Interfaces;
using Domain;
using Dto.Game;

namespace Application.MapperProfile;

public static class Mapper
{
    public static GameStateDto ToGameStateDto(GameStatus gameStatus , ITickToeHandler tickToeHandler)
    {
        var result = new GameStateDto
        {
            Cells =
            [
                [' ', ' ', ' '],
                [' ', ' ', ' '],
                [' ', ' ', ' ']
            ]
        };
        
        for (int i = 0; i < 9; i++)
        {
            var col = i / 3;
            var row = i % 3;
            
            result.Cells[col][row] = gameStatus.Board[i];
            result.Id = gameStatus.Id;
            result.Turn = gameStatus.Turn;
            result.UserTurn = gameStatus.Turn == 'o' ? gameStatus.OPlayer : gameStatus.XPlayer;
        }

        result.Status = tickToeHandler.GetGameStatus(result.Cells);

        return result;
    }
}