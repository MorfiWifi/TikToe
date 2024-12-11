using System;

namespace Domain;

public class Action
{
    public Guid Id { get; set; }
    public Guid GameStatusId { get; set; }
    public string Username { get; set; } = string.Empty;
    public int X { get; set; }
    public int Y { get; set; }
    public char Character { get; set; }
    public DateTime CratedAt { get; set; }
    
    public virtual GameStatus? GameStatus { get; set; }
}