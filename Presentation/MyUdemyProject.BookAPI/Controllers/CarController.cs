using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUdemyProject.Application.Features.CQRS.Command.CarCommands;
using MyUdemyProject.Application.Features.CQRS.Handler.CarHandlers;
using MyUdemyProject.Application.Features.CQRS.Queries.CarQueries;

namespace MyUdemyProject.BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AddCarHandlers add;
        private readonly UpdateCarHandlers update;
        private readonly RemoveCarHandlers remove;
        private readonly GetAllCarsHandlers getAll;
        private readonly GetCarsWithIdHandler get;

        public CarController(AddCarHandlers add, UpdateCarHandlers update, RemoveCarHandlers remove, GetAllCarsHandlers getAll, GetCarsWithIdHandler get)
        {
            this.add = add;
            this.update = update;
            this.remove = remove;
            this.getAll = getAll;
            this.get = get;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var x = await getAll.Handle();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarsById (int id)
        {
            GetCarQueriesId gcq = new GetCarQueriesId(id);
            var x = await get.Handle(gcq);
            return Ok(x);
        }
        [HttpPost]
        public async Task<IActionResult> AddCars(AddCarCommands addd )
        {
            await add.Handle(addd);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCars (UpdateCarCommands updated )
        {
            await update.UpdateHandler(updated);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCars (RemoveCarCommands removee)
        {
            await remove.RemoveHandle(removee);
            return Ok();
        }
    }
}
