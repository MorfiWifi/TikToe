using Application.Interfaces;
using Dto.Game;
using Dto.Game.Action;

namespace Application.Services;

public class ActionService : IActionService
{
    public PagedResponseDto<ActionPlayedDto> GetHistory(Guid gameId, SearchRequestDto search)
    {
        return new PagedResponseDto<ActionPlayedDto>()
        {
            Data =
            [
                new ActionPlayedDto { Username = "master", Date = DateTime.Now, Turn = 'X', X = 0, Y = 0, }
            ],
            Page = 1,
            Code = 200,
            PageSize = 10,
            IsOk = true
        };
    }
}