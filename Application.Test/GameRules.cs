using Application.Interfaces;
using Application.Services;
using Common.Enums;
using Dto.Game;
using Xunit.Abstractions;

namespace Application.Test;

public class GameRules
{

    #region Ctor

    public GameRules(ITestOutputHelper output)
    {
        _output = output;
        _tickToeHandler = new TickToeHandler();
    }
    
    #endregion
    
    private ITestOutputHelper _output;
    private ITickToeHandler _tickToeHandler;
    

    [Fact]
    public void Three_Same_Column_Winner()
    {
        var state1 = new GameBaseStateDto
        {
            Cells =
            [
                ['x', 'x', 'o'],
                ['x', 'o', 'o'],
                ['x', 'o', 'x']
            ]
        };
        
        var status = _tickToeHandler.GetGameStatus(state1.Cells);
        Assert.True(GameStatusEnum.WinnerX ==  status , "Winner should be X in state1" );


        var state2 = new GameBaseStateDto
        {
            Cells =
            [
                [ 'x', 'o' , 'o'],
                [ 'x', 'x' , 'o'],
                [ 'o', 'x' , 'o']
            ]
        };
        
        status = _tickToeHandler.GetGameStatus(state2.Cells);
        Assert.True(GameStatusEnum.WinnerO ==  status , "Winner should be O in state1" );


        var state3 = new GameBaseStateDto
        {
            Cells =
            [
                [ 'x', 'o' , 'x'],
                [ 'x', 'o' , 'o'],
                [ 'o', 'o' , 'o']
            ]
        };
        
        status = _tickToeHandler.GetGameStatus(state3.Cells);
        Assert.True(GameStatusEnum.WinnerO ==  status , "Winner should be O in state1" );
        
    }
    
    
    [Fact]
    public void Three_Same_Row_Winner()
    {
        var state1 = new GameBaseStateDto
        {
            Cells =
            [
                ['x', 'x', 'x'],
                ['o', 'x', 'o'],
                ['x', 'o', 'o']
            ]
        };
        
        var status = _tickToeHandler.GetGameStatus(state1.Cells);
        Assert.True(GameStatusEnum.WinnerX ==  status , "Winner should be X in state1" );


        var state2 = new GameBaseStateDto
        {
            Cells =
            [
                [ 'x', 'o' , 'o'],
                [ 'x', 'x' , 'x'],
                [ 'o', 'x' , 'o']
            ]
        };
        
        status = _tickToeHandler.GetGameStatus(state2.Cells);
        Assert.True(GameStatusEnum.WinnerX ==  status , "Winner should be X in state1" );


        var state3 = new GameBaseStateDto
        {
            Cells =
            [
                [ 'x', 'o' , 'x'],
                [ 'x', 'o' , 'o'],
                [ 'o', 'o' , 'o']
            ]
        };
        
        status = _tickToeHandler.GetGameStatus(state3.Cells);
        Assert.True(GameStatusEnum.WinnerO ==  status , "Winner should be O in state1" );

        
        
        
        
    }
    
    
    [Fact]
    public void Cross_Winner()
    {
        var state1 = new GameBaseStateDto
        {
            Cells =
            [
                ['x', 'x', 'x'],
                ['o', 'x', 'o'],
                ['x', 'o', 'x']
            ]
        };
        
        var status = _tickToeHandler.GetGameStatus(state1.Cells);
        Assert.True(GameStatusEnum.WinnerX ==  status , "Winner should be X in state1" );


        var state2 = new GameBaseStateDto
        {
            Cells =
            [
                [ 'x', 'o' , 'o'],
                [ 'o', 'x' , 'x'],
                [ 'o', 'x' , 'x']
            ]
        };
        
        status = _tickToeHandler.GetGameStatus(state2.Cells);
        Assert.True(GameStatusEnum.WinnerX ==  status , "Winner should be X in state1" );
        
    }
    
    
    [Fact]
    public void NO_Winner_Samples()
    {
        var state1 = new GameBaseStateDto
        {
            Cells =
            [
                ['x', 'x', ' '],
                ['o', ' ', 'o'],
                ['x', 'o', ' ']
            ]
        };
        
        var status = _tickToeHandler.GetGameStatus(state1.Cells);
        Assert.True(GameStatusEnum.ShouldContinue ==  status , "There should be no winner in state1 .. Game must go on" );
        
    }
    
    [Fact]
    public void Draw_Samples()
    {
        
        var state1 = new GameBaseStateDto
        {
            Cells =
            [
                ['o', 'x', 'o'],
                ['o', 'x', 'o'],
                ['x', 'o', 'x']
            ]
        };
        
        var status = _tickToeHandler.GetGameStatus(state1.Cells);
        Assert.True(GameStatusEnum.Draw ==  status , "should be draw in state1 , no winner!" );
    }
    
    
    [Fact]
    public void Empty_Samples()
    {
        
        var state1 = new GameBaseStateDto
        {
            Cells =
            [
                [' ', ' ', ' '],
                [' ', ' ', ' '],
                [' ', ' ', ' ']
            ]
        };
        
        var status = _tickToeHandler.GetGameStatus(state1.Cells);
        Assert.True(GameStatusEnum.ShouldContinue ==  status , $"should be draw in state1 , no winner! NOT {status}" );
    }
}