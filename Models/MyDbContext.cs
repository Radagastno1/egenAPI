using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Fact> Facts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }

}
