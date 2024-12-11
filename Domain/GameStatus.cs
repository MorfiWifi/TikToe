using System;

namespace Domain;

public class GameStatus
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Board { get; set; } = "         ";
    public string XPlayer { get; set; } = string.Empty;
    public string OPlayer { get; set; } = string.Empty;
    public char Turn { get; set; } = 'x';
    public DateTime? EndedAt { get; set; }
}