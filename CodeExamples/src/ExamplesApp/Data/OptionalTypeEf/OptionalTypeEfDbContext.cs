using Microsoft.EntityFrameworkCore;

namespace ExamplesApp.Data.OptionalTypeEf;

public class OptionalTypeEfDbContext : DbContext
{
    protected OptionalTypeEfDbContext(DbContextOptions<OptionalTypeEfDbContext> option)
        : base(option)
    {
    }

    //public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> People => Set<Author>();
}
