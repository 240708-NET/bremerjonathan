using Microsoft.EntityFrameworkCore;
using WordPuzzle.Migrations;
using WordPuzzle.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;User=sa;Password=NotPassword123;Database=WordPuzzle;TrustServerCertificate=true;"; //builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<WordPuzzleDbContext>(options => options.UseSqlServer(connectionString)); 
// var context = new AppDbContext(connectionString);
// var userRepository = new UserRepository(context);
// var wordRepository = new WordRepository(context);
// Util.AddUser(userRepository, "Bremer", "Jonathan", "bremer@raveture.com");
// Util.AddWords(userRepository, wordRepository, "bremer@raveture.com", "words.txt");
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


/*
USE [master]
GO
ALTER DATABASE [WordPuzzle] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
DROP DATABASE [WordPuzzle]
GO
*/