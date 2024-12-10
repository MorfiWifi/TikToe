using Application.Interfaces;
using Common.Enums;
using Dto;

namespace Application.Services;

public class TickToeHandler : ITickToeHandler
{
    private const char XCharacter = 'x';
    private const char OCharacter = 'o';
    
    
    public GameStatusEnum GetGameStatus(GameStateDto state)
    {
        if(state.Cells is null)
            throw new Exception("invalid state");
        
        for (int col = 0; col < 3; col++)
        {
            //coll base
            if (state.Cells[col].All(x => x == XCharacter))
                return GameStatusEnum.WinnerX;
            if (state.Cells[col].All(x => x == OCharacter))
                return GameStatusEnum.WinnerO;

            //row base
            if (state.Cells[0][col] == state.Cells[1][col] && state.Cells[1][col] == state.Cells[2][col])
            {
                return state.Cells[0][col] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;
            }
        }
        
        //cross A
        if(state.Cells[0][0] == state.Cells[1][1] && state.Cells[1][1] == state.Cells[2][2])
            return state.Cells[0][0] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;
        //cross B
        if(state.Cells[0][2] == state.Cells[1][1] && state.Cells[1][1] == state.Cells[2][0])
            return state.Cells[0][2] == XCharacter ? GameStatusEnum.WinnerX : GameStatusEnum.WinnerO;

        //empty cell exist to play
        for (var i = 0; i < 9; i++)
        {
            var col = i / 3;
            var row = i % 3;
            
            if (state.Cells[col][row] == ' ')
                return GameStatusEnum.ShouldContinue;
        }
        
        
        return GameStatusEnum.Draw;
    }
}