using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class RoomController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomRequest room)
        {
            return HandleResult(await Mediator.Send(new CreateRoomCommand.Command{ Room = room }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, RoomRequest room)
        {
            room.Id = id;
            return HandleResult(await Mediator.Send(new UpdateRoomCommand.Command { Room = room }));
        }
    }
}