using Data.Interfaces;
using Action = Domain.Action;

namespace Data.Repositories;

public class ActionRepository(TickToeDbContext context)  : BaseRepository<Action>(context) , IActionRepository
{
    
}