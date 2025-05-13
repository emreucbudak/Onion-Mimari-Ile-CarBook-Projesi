using MyUdemyProject.Application.Features.CQRS.Result.CarResult;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.CarHandlers
{
    public class GetAllCarsHandlers
    {
        private readonly IRepositoryBase<Car> repositoryBase;

        public GetAllCarsHandlers(IRepositoryBase<Car> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }
        public async Task<IEnumerable<GetCarResults>> Handle()
        {
            var x = await repositoryBase.GetAllAsync(false);
            return x.Select(b => new GetCarResults()
            {
                Seat = b.Seat,
                BigImageUrl = b.BigImageUrl,
                BrandId = b.BrandId,
                Transmisson = b.Transmisson,
                CarId = b.CarId,
                Fuel = b.Fuel,
                CoverImageUrl = b.CoverImageUrl,
                Km = b.Km,
                Luggage = b.Luggage,
                Model = b.Model,
            });
        }
    }
}
