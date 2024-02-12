using Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BookController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookRequest book)
        {
            return HandleResult(await Mediator.Send(new CreateBookCommand.Command{ Book = book }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailibility(SearchAvailabilityRequest search)
        {
            return HandleResult(await Mediator.Send(new GetAvailabilityQuery.Query{ search = search }));
        }
    }
}