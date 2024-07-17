namespace WordScramble.Service;

using WordScramble.Model;
using WordScramble.Repository;

public class Puzzler {
    IWordRepository wordRepository = new LsvWordRepository();

    public Puzzle NewPuzzle() {
        var word = wordRepository.PickWord();
        var wordPermutation = Permute(word);
        return new Puzzle(wordPermutation, word);
    }

    private static string Permute(string str)
    {
        char[] chars = str.ToCharArray();
        Random.Shared.Shuffle(chars);
        return new string(chars);
    }
}