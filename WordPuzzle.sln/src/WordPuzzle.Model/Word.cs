namespace WordPuzzle.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Spelling), IsUnique=true)]
[Index(nameof(AlphabetizedSpelling))]
[Index(nameof(Length))]
public class Word(string spelling, int userId) : EntityBase
{
    [Required(AllowEmptyStrings = false)]
    public string Spelling { get; private set; } = spelling.ToLower();

    [NotMapped]
    readonly string _actualAlphabetizedSpelling = ToAlphabetizedSpelling(spelling);

    [Required(AllowEmptyStrings = false)]
    public string AlphabetizedSpelling
    {
        get => _actualAlphabetizedSpelling;
        // Validating stored AlphabetizedSpelling set by EF (EF can access this private set method)
        private set
        {
            ValidateStoredAlphabetizedSpelling(value);
        } 
    }

    [NotMapped]
    readonly int _actualLength = spelling.Length;

    public int Length
    {
        get => _actualLength;
        // Validating stored length set by EF (EF can access this private set method)
        private set
        {
            ValidateStoredLength(value);
        }
    }

    [Column("CreatorId")]
    public int UserId { get; set; } = userId; // Creator foreign key property
    public User User { get; set; } = null!; // Reference navigation to creator


    [NotMapped]
    public readonly string ShuffledSpelling = Shuffle(spelling);

    private void ValidateStoredAlphabetizedSpelling(string storedValue)
    {
        if(string.IsNullOrWhiteSpace(storedValue))
        {
            throw new ArgumentException("Stored alphabetized spelling cannot be blank");
        }
        if(!_actualAlphabetizedSpelling.Equals(storedValue))
        {
            throw new ArgumentException($"Stored alphabetized spelling '${_actualAlphabetizedSpelling}' is not equal to actual '${storedValue}'");
        }
    }

    private void ValidateStoredLength(int storedValue)
    {
        if(_actualLength != storedValue)
        {
            throw new ArgumentException($"Invalid stored length for word ${spelling} (stored=${storedValue}, actual=${_actualLength})");
        }
    }

    private static string ToAlphabetizedSpelling(string spelling)
    {
        char[] chars = spelling.ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }

    private static string Shuffle(string spelling)
    {
        char[] chars = spelling.ToCharArray();
        Random.Shared.Shuffle(chars);
        return new string(chars);
    }
   
}
