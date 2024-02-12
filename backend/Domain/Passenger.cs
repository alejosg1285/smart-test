using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Passenger
{
    public int Id { get; set; }
    [MaxLength(30)]
    [Required]
    public string? Name { get; set; }
    [MaxLength(30)]
    [Required]
    public string? LastName { get; set; }
    [Required]
    public GenreEnum Genre { get; set; }
    [MaxLength(20)]
    [Required]
    public string? IdentificationType { get; set; }
    [MaxLength(20)]
    [Required]
    public string? IdentificationNumber { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Email { get; set; }
    [MaxLength(10)]
    [Required]
    public string? PhoneNumber { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}
