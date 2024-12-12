using Application.Interfaces;
using Common.Enums;
using Dto.Game;

namespace Application.Services;

public class TickToeHandler : ITickToeHandler
{
    private const char XCharacter = 'x';
    private const char OCharacter = 'o';


    public GameStatusEnum GetGameStatus(char[][]? cells)
    {
        if (cells is null)
            throw new Exception("invalid state");

        for (int col = 0; col < 3; col++)
        {
            //coll base
            if (cells[col].All(x => x == XCharacter))
                return GameStatusEnum.WinnerX;
            if (cells[col].All(x => x == OCharacter))
                return GameStatusEnum.WinnerO;

            //row base
            if (cells[0][col] == cells[1][col] && cells[1][col] == cells[2][col] && cells[2][col] != ' ')
            {
                return cells[0][col] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;
            }
        }

        //cross A
        if (cells[0][0] == cells[1][1] && cells[1][1] == cells[2][2] && cells[2][2] != ' ')
            return cells[0][0] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;
        //cross B
        if (cells[0][2] == cells[1][1] && cells[1][1] == cells[2][0] && cells[2][0] != ' ')
            return cells[0][2] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;

        //empty cell exist to play
        for (var i = 0; i < 9; i++)
        {
            var col = i / 3;
            var row = i % 3;

            if (cells[col][row] == ' ')
                return GameStatusEnum.ShouldContinue;
        }


        return GameStatusEnum.Draw;
    }

    public (int y, int x) FindNextMove(char[][]? cells)
    {
        if (cells is null)
            throw new ExceptionDto("invalid game state");

        List<(int, int)> emptyCells = [];

        for (var i = 0; i < 9; i++)
        {
            var col = i / 3;
            var row = i % 3;
            
            if (cells[col][row] == ' ')
                emptyCells.Add((col, row));
        }

        if (emptyCells.Count == 0)
            throw new ExceptionDto("no move to be played");

        var index = Random.Shared.Next(emptyCells.Count);

        return emptyCells[index];
    }
}