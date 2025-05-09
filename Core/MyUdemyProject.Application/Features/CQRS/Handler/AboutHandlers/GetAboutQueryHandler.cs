using MyUdemyProject.Application.Features.CQRS.Result.AboutResults;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepositoryBase<About> rp;

        public GetAboutQueryHandler(IRepositoryBase<About> rp)
        {
            this.rp = rp;
        }
        public async Task<IEnumerable<GetAllAboutResult>> Handle (bool v)
        {
            var x =  await rp.GetAllAsync(v);
            return x.Select(x => new GetAllAboutResult()
            {
                AboutId = x.AboutId,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                Description = x.Description,
            });

        }
    }
}
