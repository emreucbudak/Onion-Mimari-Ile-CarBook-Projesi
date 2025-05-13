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
    public class RemoveCarHandlers
    {
        private readonly IRepositoryBase<Car> _rp;

        public RemoveCarHandlers(IRepositoryBase<Car> rp)
        {
            _rp = rp;
        }
        public async Task RemoveHandle(RemoveCarCommands rm)
        {
            var x = await _rp.GetItemAsync(b=> b.CarId == rm.Id);
            await _rp.RemoveItemAsync(x);
        }
    }
}
