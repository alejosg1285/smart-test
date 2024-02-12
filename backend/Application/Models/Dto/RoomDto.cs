namespace Application;

public class RoomDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Capacity { get; set; }
    public string? TypeRoom { get; set; }
    public decimal Price { get; set; }
    public decimal Taxes { get; set; }
    public string? Location { get; set; }
    public bool IsActive { get; set; }
}
