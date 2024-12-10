using System.Collections.Generic;

namespace Dto;

/// <summary>
/// generic response from server
/// </summary>
public class ResponseDto
{
    public bool IsOk { get; set; }
    public int Code { get; set; }
    public IEnumerable<string> Errors { get; set; } = [];
}

/// <inheritdoc />
public class ResponseDto<T> : ResponseDto
{
    public T? Data { get; set; }
}