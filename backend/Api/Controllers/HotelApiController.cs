using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HotelController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateHotel(Hotel hotel)
        {
            return HandleResult(await Mediator.Send(new CreateHotelCommand.Command{ Hotel = hotel }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            return HandleResult(await Mediator.Send(new GetHotelQuery.Query{ Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Hotel hotel)
        {
            hotel.Id = id;
            return HandleResult(await Mediator.Send(new UpdateHotelCommand.Command{ Hotel = hotel }));
        }
    }
}