using MyUdemyProject.Application.Features.CQRS.Command.BrandCommands;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.BrandHandlers
{
    public class RemoveBrandHandlers
    {
        private readonly IRepositoryBase<Brand> _rp;

        public RemoveBrandHandlers(IRepositoryBase<Brand> rp)
        {
            _rp = rp;
        }
        public async Task RemoveHandler (RemoveBrandCommands rm)
        {
            var x = await _rp.GetItemAsync(b=> b.BrandId == rm.BrandId);
            await _rp.RemoveItemAsync(x);
        }
    }
}
