using MyUdemyProject.Application.Features.CQRS.Result.BrandResult;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.BrandHandlers
{
    public class GetAllBrandHandlers
    {
        private readonly IRepositoryBase<Brand> repositoryBase;

        public GetAllBrandHandlers(IRepositoryBase<Brand> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }
        public async Task<IEnumerable<GetBrandResults>> Handle()
        {
            var x = await repositoryBase.GetAllAsync(false);
            return x.Select(x => new GetBrandResults
            {
                BrandId = x.BrandId,
                Name = x.Name,
                
            });
        }
    }
}
