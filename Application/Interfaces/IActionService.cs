using Dto.Game;
using Dto.Game.Action;

namespace Application.Interfaces;

public interface IActionService
{
    PagedResponseDto<ActionPlayedDto> GetHistory(Guid gameId, SearchRequestDto search);
}