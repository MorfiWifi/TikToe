using System;
using Common.Enums;

namespace Dto.Game;

public class GameStateDto : GameBaseStateDto
{
    public Guid Id { get; set; }
    public string UserTurn { get; set; } = string.Empty;
    public char Turn { get; set; }
    public GameStatusEnum Status { get; set; }
    
}