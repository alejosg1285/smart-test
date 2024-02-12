using Domain;

namespace Application;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Hotel, Hotel>();
        CreateMap<Hotel, HotelDto>();
        CreateMap<Room, RoomDto>();
        CreateMap<RoomRequest, Room>();
        CreateMap<BookRequest, Book>();
        CreateMap<PassengerRequest, Passenger>();
        CreateMap<ContactRequest, Contact>();
    }
}
