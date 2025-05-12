using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUdemyProject.Application.Features.CQRS.Handler.BannerHandlers;

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
    }
}
