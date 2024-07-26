using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordPuzzle.Model;

public class EntityBase
{
    [Key]
    public int Id { get; private set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

}