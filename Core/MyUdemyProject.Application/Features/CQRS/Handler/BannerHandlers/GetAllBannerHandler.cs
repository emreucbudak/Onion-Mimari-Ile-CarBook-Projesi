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
        public Task<IEnumerable<Banner>> GetBannerHandle() {
            var x = _rp.GetAllAsync(false);
            return x;
        }
    }
}
