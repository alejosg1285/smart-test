using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Hotel
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }
    [MaxLength(250)]
    [Required]
    public string? Description { get; set; }
    [MaxLength(70)]
    [Required]
    public string? Address { get; set; }
    [MaxLength(50)]
    [Required]
    public string? City { get; set; }
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public ICollection<Room> Rooms { get; } = new List<Room>();
}
