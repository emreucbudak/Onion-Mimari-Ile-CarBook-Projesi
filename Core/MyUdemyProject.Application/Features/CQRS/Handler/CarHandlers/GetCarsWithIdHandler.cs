using MyUdemyProject.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarsWithIdHandler
    {
        private readonly IRepositoryBase<Car> _rp;

        public GetCarsWithIdHandler(IRepositoryBase<Car> rp)
        {
            _rp = rp;
        }
        public async Task<GetCarWithIdResults> Handle(GetCarQueriesId idd)
        {
            var x = await _rp.GetItemAsync(b => b.CarId == idd.Id);
            return new GetCarWithIdResults()
            {
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CarId = x.CarId,
                Transmisson = x.Transmisson,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
            };
        }
    }
}
