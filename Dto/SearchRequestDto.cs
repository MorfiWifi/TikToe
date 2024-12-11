namespace Dto.Game;

public class SearchRequestDto : RequestDto
{
    public string? Query { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public string Sort { get; set; } = "asc";
    public string? OrderBy { get; set; } 
}