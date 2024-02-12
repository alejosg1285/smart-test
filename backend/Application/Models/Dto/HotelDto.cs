namespace Application;

public class HotelDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public bool IsActive { get; set; }
    public ICollection<RoomDto> Rooms { get; set; } = new List<RoomDto>();
}
