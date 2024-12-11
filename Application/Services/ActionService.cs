using Application.Interfaces;
using Data.Interfaces;
using Dto.Game;
using Dto.Game.Action;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class ActionService(IActionRepository actionRepository) : IActionService
{
    public PagedResponseDto<ActionPlayedDto> GetHistory(Guid gameId, SearchRequestDto search)
    {
        //use search to apply ordering and sorting
        search.PageSize = search.PageSize > 100 ? 100 : search.PageSize;
        
        var actions =
        actionRepository.GetDbSet()
            .Where(x=> x.Username == search.Username)
            .Where(x => x.GameStatusId == gameId)
            .AsNoTracking()
            .Skip(search.Page * search.PageSize)
            .Take(search.PageSize)
            .Select(x=> new ActionPlayedDto
            {
                Username = x.Username, 
                Date = x.CratedAt,
                Turn = x.Character,
                Y = x.Y,
                X = x.X,
            })
            .ToList();

        return new PagedResponseDto<ActionPlayedDto>()
        {
            Data = actions,
            Page = search.Page,
            PageSize = search.PageSize,
            
            Code = 200,
            IsOk = true
        };
    }
}