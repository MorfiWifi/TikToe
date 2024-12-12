using Application.Interfaces;
using Common.Enums;
using Dto.Game;

namespace Application.Services;

public class TickToeHandler : ITickToeHandler
{
    private const char XCharacter = 'x';
    private const char OCharacter = 'o';
    
    
    public GameStatusEnum GetGameStatus(GameBaseStateDto baseState)
    {
        if(baseState.Cells is null)
            throw new Exception("invalid state");
        
        for (int col = 0; col < 3; col++)
        {
            //coll base
            if (baseState.Cells[col].All(x => x == XCharacter))
                return GameStatusEnum.WinnerX;
            if (baseState.Cells[col].All(x => x == OCharacter))
                return GameStatusEnum.WinnerO;

            //row base
            if (baseState.Cells[0][col] == baseState.Cells[1][col] && baseState.Cells[1][col] == baseState.Cells[2][col] && baseState.Cells[2][col] != ' ')
            {
                return baseState.Cells[0][col] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;
            }
        }
        
        //cross A
        if(baseState.Cells[0][0] == baseState.Cells[1][1] && baseState.Cells[1][1] == baseState.Cells[2][2] && baseState.Cells[2][2] != ' ')
            return baseState.Cells[0][0] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;
        //cross B
        if(baseState.Cells[0][2] == baseState.Cells[1][1] && baseState.Cells[1][1] == baseState.Cells[2][0] && baseState.Cells[2][0] != ' ')
            return baseState.Cells[0][2] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;

        //empty cell exist to play
        for (var i = 0; i < 9; i++)
        {
            var col = i / 3;
            var row = i % 3;
            
            if (baseState.Cells[col][row] == ' ')
                return GameStatusEnum.ShouldContinue;
        }
        
        
        return GameStatusEnum.Draw;
    }
}