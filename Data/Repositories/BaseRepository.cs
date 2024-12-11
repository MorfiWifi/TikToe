using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BaseRepository<T> (TickToeDbContext context) : IRepository<T> where T : class
{
    public DbSet<T> GetDbSet() => context.Set<T>();
    public void SaveChanges()
    {
        context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}