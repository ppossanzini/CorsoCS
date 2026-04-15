
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CorsoCS.Handlers.Model;
public class DB(DbContextOptions<DB> options) : DbContext(options)
{
  public DbSet<Note> Notes { get; set; }
  
}


public class DBContextFactory : IDesignTimeDbContextFactory<DB>
{
  public DB CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<DB>();
    optionsBuilder.UseSqlite();
    return new DB(optionsBuilder.Options);
  }
}