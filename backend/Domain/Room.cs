using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Room
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }
    [MaxLength(250)]
    [Required]
    public string? Description { get; set; }
    [Required]
    public int Capacity { get; set; }
    [MaxLength(25)]
    [Required]
    public string? TypeRoom { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public decimal Taxes { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Location { get; set; }
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public int HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
    public ICollection<Book> Books { get; } = new List<Book>();
}
