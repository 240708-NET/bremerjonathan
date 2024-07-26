namespace WordPuzzle.Migrations;

using Microsoft.EntityFrameworkCore;
using WordPuzzle.Model;

public class WordPuzzleDbContext(DbContextOptions<WordPuzzleDbContext> options) : DbContext(options)
{
    DbSet<Word> Words { get; set; }
    DbSet<User> Users { get; set; }
}