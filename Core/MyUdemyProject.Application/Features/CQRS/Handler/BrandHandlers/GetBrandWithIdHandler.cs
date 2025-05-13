using MyUdemyProject.Application.Features.CQRS.Queries.BrandQueries;
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
    public class GetBrandWithIdHandler
    {
        private readonly IRepositoryBase<Brand> _brandRepository;

        public GetBrandWithIdHandler(IRepositoryBase<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<GetBrandResults> BrandHandler (BrandQueriesWithId bq)
        {
            var x = await _brandRepository.GetItemAsync(b => b.BrandId == bq.Id);
            return new GetBrandResults()
            {
                BrandId = x.BrandId,
                Name = x.Name,
            };
        }
    }
}
