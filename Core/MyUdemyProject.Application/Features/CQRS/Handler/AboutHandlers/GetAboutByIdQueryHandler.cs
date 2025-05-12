using MyUdemyProject.Application.Features.CQRS.Queries.AboutQueries;
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
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepositoryBase<About> _rp;

        public GetAboutByIdQueryHandler(IRepositoryBase<About> rp)
        {
            _rp = rp;
        }
        public async  Task<GetAboutByIdQueryResult> HandlerById (GetAboutByIdQuery inf)
        {
            var x = await _rp.GetItemAsync(b => b.AboutId == inf.Id);
            return new GetAboutByIdQueryResult()
            {
                AboutId = x.AboutId,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
            };
        }
    }
}
