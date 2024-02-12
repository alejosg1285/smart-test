using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Contact
{
    public int Id { get; set; }
    [MaxLength(30)]
    [Required]
    public string? Name { get; set; }
    [MaxLength(30)]
    [Required]
    public string? LastName { get; set; }
    [MaxLength(10)]
    [Required]
    public string? PhoneNumber { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}
