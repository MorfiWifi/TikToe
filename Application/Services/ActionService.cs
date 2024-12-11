using Application.Interfaces;
using Dto.Game;
using Dto.Game.Action;

namespace Application.Services;

public class ActionService: IActionService
{
    public PagedResponseDto<ActionPlayedDto> GetHistory(Guid gameId, SearchRequestDto search)
    {
        throw new NotImplementedException();
    }
}