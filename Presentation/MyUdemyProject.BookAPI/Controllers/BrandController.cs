using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUdemyProject.Application.Features.CQRS.Command.BrandCommands;
using MyUdemyProject.Application.Features.CQRS.Handler.BrandHandlers;
using MyUdemyProject.Application.Features.CQRS.Queries.BrandQueries;

namespace MyUdemyProject.BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AddBrandHandler _add;
        private readonly GetAllBrandHandlers _all;
        private readonly GetBrandWithIdHandler _getBrandWithId;
        private readonly RemoveBrandHandlers _remove;
        private readonly UpdateBrandHandler _update;

        public BrandController(AddBrandHandler add, GetAllBrandHandlers all, GetBrandWithIdHandler getBrandWithId, RemoveBrandHandlers remove, UpdateBrandHandler update)
        {
            _add = add;
            _all = all;
            _getBrandWithId = getBrandWithId;
            _remove = remove;
            _update = update;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands ()
        {
            var x = await _all.Handle();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandWithId(int id) {
            BrandQueriesWithId bqww = new BrandQueriesWithId() { Id = id};
            var x = await _getBrandWithId.BrandHandler(bqww);
            return Ok(x);
        }
        [HttpPost]
        public async Task<IActionResult> AddBrands (AddBrandCommands adm)
        {
            await _add.AddHandler(adm);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrands (RemoveBrandCommands rm)
        {
            await _remove.RemoveHandler(rm);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrands (UpdateBrandCommands update)
        {
            await _update.UpdateHandler(update);
            return Ok();
        }
    }
}
