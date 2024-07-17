namespace WordScramble.Repository;

using static System.AppDomain;
using static System.IO.Path;

// This implementation reads words from a Line-Separated-Values (LSV) file.
public class LsvWordRepository : IWordRepository
{
    static readonly string path = Combine(CurrentDomain.BaseDirectory, "words.txt");
    static readonly Dictionary<int, string> words;

    static LsvWordRepository()
    {
        if (words != null)
        {
            return;
        }

        words = [];

        using var reader = new StreamReader(path);
        string? line;
        for (int i = 0; (line = reader.ReadLine()) != null; i++)
        {
            words.Add(i, line);
        }
    }

    public string PickWord()
    {
        int randKey = Random.Shared.Next(words.Count + 1);
        return words[randKey];
    }

}