using MyUdemyProject.Application.Features.CQRS.Command.CarCommands;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.CarHandlers
{
    public class UpdateCarHandlers
    {
        private readonly IRepositoryBase<Car> _rp;

        public UpdateCarHandlers(IRepositoryBase<Car> rp)
        {
            _rp = rp;
        }
        public async Task UpdateHandler(UpdateCarCommands cm)
        {
            var x = await _rp.GetItemAsync(b=> b.CarId == cm.CarId);
            x.BrandId = cm.BrandId;
            x.Model = cm.Model;
            x.CoverImageUrl = cm.CoverImageUrl;
            x.Km = cm.Km;
            x.Transmisson = cm.Transmisson;
            x.Seat = cm.Seat;
            x.Luggage = cm.Luggage;
            x.Fuel = cm.Fuel;
            x.BigImageUrl = cm.BigImageUrl;
            await _rp.UpdateItemAsync(x);
            
        }
    }
}
