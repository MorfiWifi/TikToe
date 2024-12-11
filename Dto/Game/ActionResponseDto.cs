namespace Dto.Game.Game;

public class ActionResponseDto
{
    public bool GameEnded { get; set; }
    public string PlayerTurn { get; set; } = string.Empty;
    public GameBaseStateDto? GameState { get; set; } 
}