using Domain;
using Microsoft.EntityFrameworkCore;
using Action = Domain.Action;

namespace Data;

public class TickToeDbContext(DbContextOptions<TickToeDbContext> options) : DbContext(options)
{
    public DbSet<GameStatus> Games { get; set; }
    public DbSet<Action> Actions { get; set; }
}