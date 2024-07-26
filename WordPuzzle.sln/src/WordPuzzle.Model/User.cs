namespace WordPuzzle.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("User")]
[Index(nameof(UserName), IsUnique=true)]
public class User(string firstName, string lastName, string userName) : EntityBase
{
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; } = firstName;

    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; } = lastName;

    [Required(AllowEmptyStrings = false)]
    public string UserName { get; set; } = userName;

    [Column("CreatorId")]
    public int? UserId { get; set; } // Creator self-referencing foreign key
    // public User? User { get; set; } // Reference navigation to creator

}