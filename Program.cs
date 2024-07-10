
class Program
{
    static void Main(string[] args)
    {
        string word = GetWord();
        string scrambledWord = ScrambleWord(word);
        string? answer = null;

        for(bool match = false; !match;)
        {
            Console.Write("Enter the word for scrambled letters '{0}': ", scrambledWord);
            answer = Console.ReadLine();
            match = string.Equals(word, answer, StringComparison.OrdinalIgnoreCase);
            if(match == true)
            {
                Console.WriteLine("Correct!");
            }
        }
    }

    private static string GetWord() {
        string[] words = {"one", "two"};
        string[] word = Random.Shared.GetItems(words, 1);
        return word[0];
    }

    private static string ScrambleWord(string word) {
        char[] chars = word.ToCharArray();
        Random.Shared.Shuffle(chars);
       return new string(chars);
    }

}
