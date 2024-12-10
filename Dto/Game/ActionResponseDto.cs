namespace Dto.Game;

public class ActionResponseDto
{
    public bool GameEnded { get; set; }
    public string PlayerTurn { get; set; } = string.Empty;
    public GameStateDto? GameState { get; set; } 
}