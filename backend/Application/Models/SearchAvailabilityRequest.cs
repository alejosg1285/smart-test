namespace Application;

public class SearchAvailabilityRequest
{
    public DateTime StartSearch { get; set; }
    public DateTime EndSearch { get; set; }
    public string? City { get; set; }
    public int Capacity { get; set; }
}
