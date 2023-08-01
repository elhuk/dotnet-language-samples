using ExamplesApp.Data.OptionalType;
using Microsoft.EntityFrameworkCore;

namespace ExamplesApp.Data.OptionalTypeEf;

public class BookstoreDbContext : DbContext
{
    protected BookstoreDbContext(DbContextOptions<BookstoreDbContext> option)
        : base(option)
    {
    }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Person> People => Set<Person>();
}
