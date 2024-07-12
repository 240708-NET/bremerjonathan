namespace wordscramble.service;

using wordscramble.repository;

public class Puzzler {
    IWordRepository wordRepository = new LsvWordRepository();

    public Puzzle NewPuzzle() {
        var word = wordRepository.PickWord();
        var wordPermutation = Permute(word);
        return new Puzzle(wordPermutation, word);
    }

    public class Puzzle(string wordPermutation, string word)
    {
        public readonly string wordPermutation = wordPermutation, word = word;
    }

    private static string Permute(string str)
    {
        char[] chars = str.ToCharArray();
        Random.Shared.Shuffle(chars);
        return new string(chars);
    }
}