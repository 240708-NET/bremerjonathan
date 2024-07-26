using Microsoft.EntityFrameworkCore;
using WordPuzzle.Model;

namespace WordPuzzle.Repository;

public class WordRepository(AppDbContext context) : IWordRepository
{
    private readonly AppDbContext _context = context;

    public int AddWord(Word word)
    {
        _context.Add(word);
        return _context.SaveChanges();
    }

    public int AddWords(ISet<Word> words)
    {
        _context.AddRange(words);
        return _context.SaveChanges();
    }

    public Word GetAnyWord()
    {
        FormattableString sql = $"SELECT TOP 1 * FROM Words ORDER BY NEWID()";
        return _context.Words.FromSql(sql).First();
    }

}