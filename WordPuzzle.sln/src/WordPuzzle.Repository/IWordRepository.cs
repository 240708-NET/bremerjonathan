using WordPuzzle.Model;

namespace WordPuzzle.Repository;

public interface IWordRepository
{
    Word GetAnyWord();
    int AddWord(Word word);
    int AddWords(ISet<Word> words);
}