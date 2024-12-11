using System;

namespace Dto.Game.Action;

public class ActionPlayedDto
{
    public string Username { get; set; } = string.Empty;
    public char Turn { get; set; }
    public DateTime Date { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}