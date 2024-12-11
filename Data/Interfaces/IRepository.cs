using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces;

public interface IRepository<T> where T : class
{
    public DbSet<T> GetDbSet ();
    
    public void SaveChanges();
    public Task SaveChangesAsync();
}