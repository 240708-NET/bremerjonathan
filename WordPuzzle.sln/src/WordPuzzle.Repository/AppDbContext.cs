using Microsoft.EntityFrameworkCore;
using WordPuzzle.Model;

namespace WordPuzzle.Repository;

public class AppDbContext(string connectionstring) : DbContext {
    private readonly string _connectionString = connectionstring;
    public DbSet<User> Users { get; set; }
    public DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}