using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUdemyProject.Application.Features.CQRS.Command.AboutCommands;
using MyUdemyProject.Application.Features.CQRS.Handler.AboutHandlers;
using MyUdemyProject.Application.Features.CQRS.Result.AboutResults;

namespace MyUdemyProject.BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly AddAboutQueryHandler addAboutQueryHandler;
        private readonly RemoveAboutQueryHandler removeAboutQueryHandler;
        private readonly UpdateAboutQueryHandler updateAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler gtl;

        public AboutsController(AddAboutQueryHandler addAboutQueryHandler, RemoveAboutQueryHandler removeAboutQueryHandler, UpdateAboutQueryHandler updateAboutQueryHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler gtl)
        {
            this.addAboutQueryHandler = addAboutQueryHandler;
            this.removeAboutQueryHandler = removeAboutQueryHandler;
            this.updateAboutQueryHandler = updateAboutQueryHandler;
            this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            this.gtl = gtl;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAbouts ()
        {
            var x =  await gtl.Handle(false);
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutsById (int id) {
            var x = await getAboutByIdQueryHandler.HandlerById(id);
            return Ok(x);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbouts (RemoveAboutCommand rm)
        {
            await removeAboutQueryHandler.Handle(rm);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddAbouts (CreateAboutCommand cm)
        {
            await addAboutQueryHandler.Handle(cm);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbouts (UpdateAboutCommands cm)
        {
            await updateAboutQueryHandler.UpdateAboutHandler(cm);
            return Ok();
        }
    }
}
