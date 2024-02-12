namespace Application;

public class BookRequest
{
    public int Id { get; set; }
    public DateTime StartBook { get; set; }
    public DateTime EndBook { get; set; }

    public int RoomId { get; set; }
    public List<PassengerRequest>? Passengers { get; set; }
    public ContactRequest? Contact { get; set; }
}
