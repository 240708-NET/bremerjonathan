namespace wordscramble;

using wordscramble.service;
using static System.StringComparison;
using static wordscramble.service.Puzzler;

public class Program
{
    public static void Main(string[] args)
    {
        var puzzler = new Puzzler();
        var puzzle = puzzler.NewPuzzle();
        string? input = "";
        do
        {
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("\nBelow are permutated letters of a word:\n");
            PrintPuzzle(puzzle, Peek(input));
            Console.Write("\nGuess the word (p=peek,q=quit): ");
            input = Console.ReadLine();
            if(Correct(input, puzzle)) {
                puzzle = puzzler.NewPuzzle();
            }
        } while (!Quit(input));
    }

    private static bool Correct(string? guess, Puzzle puzzle)
    {
        return string.Equals(guess, puzzle.word, OrdinalIgnoreCase);
    }

    private static bool Peek(string? input)
    {
        return string.Equals(input, "p", OrdinalIgnoreCase);
    }

    private static bool Quit(string? input)
    {
        return string.Equals(input, "q", OrdinalIgnoreCase);
    }

    private static void PrintPuzzle(Puzzle puzzle, bool peek)
    {
        var output = string.Join(" ", puzzle.wordPermutation.ToList()).ToUpper();
        output += peek ? " => " + puzzle.word : "";
        Console.WriteLine(output);
    }

}