using System.Collections.Generic;

namespace Dto.Game;

public class PagedResponseDto<T> : ResponseDto<List<T>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}