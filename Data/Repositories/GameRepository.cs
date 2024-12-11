using Data.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class GameRepository(TickToeDbContext context)  : BaseRepository<GameStatus>(context) , IGameRepository
{
    
}