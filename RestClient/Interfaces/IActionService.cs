using Dto.Game;
using Dto.Game.Action;

namespace RestClient.Interfaces;

public interface IActionService
{
    Task<PagedResponseDto<ActionPlayedDto>> GetHistory(Guid gameId, SearchRequestDto search);
}