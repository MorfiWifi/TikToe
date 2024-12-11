namespace Dto.Game;

/// <summary>
/// containing basic fields required on server endpoints
/// </summary>
public class RequestDto
{
    public string? Username { get; set; }
    public string? Token { get; set; }
    public string? Identity { get; set; }
}