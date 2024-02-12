using Domain;

namespace Application;

public class PassengerRequest
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public GenreEnum Genre { get; set; }
    public string? IdentificationType { get; set; }
    public string? IdentificationNumber { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}
