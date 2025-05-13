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
    public class AddCarHandlers
    {
        private readonly IRepositoryBase<Car> _rpc;

        public AddCarHandlers(IRepositoryBase<Car> rpc)
        {
            _rpc = rpc;
        }
        public async Task Handle (AddCarCommands command)
        {
            await _rpc.AddItemAsync(new Car()
            {
                BrandId = command.BrandId,
                Model = command.Model,
                CoverImageUrl = command.CoverImageUrl,
                Km = command.Km,
                Transmisson = command.Transmisson,
                Seat = command.Seat,
                Luggage = command.Luggage,
                Fuel = command.Fuel,
                BigImageUrl = command.BigImageUrl,

            });
        }
    }
}
