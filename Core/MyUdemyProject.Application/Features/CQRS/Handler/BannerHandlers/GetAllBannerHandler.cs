using MyUdemyProject.Application.Features.CQRS.Result.BannerResults;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.BannerHandlers
{
    public class GetAllBannerHandler
    {
        private readonly IRepositoryBase<Banner> _rp;

        public GetAllBannerHandler(IRepositoryBase<Banner> rp)
        {
            _rp = rp;
        }
        public async Task<IEnumerable<GetBannerResults>> GetBannerHandle() {
            var x = await  _rp.GetAllAsync(false);
            return x.Select(x => new GetBannerResults()
            {
                BannerId = x.BannerId,
                Description = x.Description,
                VideoDescription = x.VideoDescription,
                Title = x.Title,
                VideoUrl = x.VideoUrl,
            });
            
        }
    }
}
