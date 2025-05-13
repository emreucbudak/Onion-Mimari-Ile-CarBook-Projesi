using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUdemyProject.Application.Features.CQRS.Command.BannerCommands;
using MyUdemyProject.Application.Features.CQRS.Handler.BannerHandlers;
using MyUdemyProject.Application.Features.CQRS.Queries.BannerQueries;

namespace MyUdemyProject.BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerHandler crt;
        private readonly GetAllBannerHandler gtl;
        private readonly GetBannerFromIdHandler gtb;
        private readonly RemoveBannerHandler rmv;
        private readonly UpdateBannerHandler updt;

        public BannerController(CreateBannerHandler crt, GetAllBannerHandler gtl, GetBannerFromIdHandler gtb, RemoveBannerHandler rmv, UpdateBannerHandler updt)
        {
            this.crt = crt;
            this.gtl = gtl;
            this.gtb = gtb;
            this.rmv = rmv;
            this.updt = updt;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBanner()
        {
            var x = await gtl.GetBannerHandle();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerForId(BannerQueriesForId bannerQueriesForId)
        {
            var x = await gtb.GetBannerFromIdHandle(bannerQueriesForId);
            return Ok(x);
        }
        [HttpPost]
        public async Task<IActionResult> AddBanner (CreateBannerCommand cm)
        {
            await crt.AddBannerHandler(cm);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBanner (RemoveBannerCommand cm)
        {
            await rmv.RemoveHandler(cm);
            return Ok();
        }
        [HttpPut] 
        public async Task<IActionResult> UpdateBanner (UpdateBannerCommand cm)
        {
            await updt.HandleBanner(cm);
            return Ok();
        }
    }
}
