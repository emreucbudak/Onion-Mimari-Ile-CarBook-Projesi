using MyUdemyProject.Application.Features.CQRS.Queries.BannerQueries;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.BannerHandlers
{
    public class GetBannerFromIdHandler
    {
        private readonly IRepositoryBase<Banner> _bannerRepository;

        public GetBannerFromIdHandler(IRepositoryBase<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<Banner> GetBannerFromIdHandle(BannerQueriesForId qr)
        {
            var x = await _bannerRepository.GetItemAsync(b => b.BannerId == qr.Id);
            return x;
        }
    }
}
