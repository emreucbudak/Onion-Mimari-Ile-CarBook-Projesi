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
    public class AddBrandHandler
    {
        private readonly IRepositoryBase<Brand> _rp;

        public AddBrandHandler(IRepositoryBase<Brand> rp)
        {
            _rp = rp;
        }
        public async Task AddHandler (AddBrandCommands addBrandCommands)
        {
            await _rp.AddItemAsync(new Brand()
            {
                Name = addBrandCommands.Name,
            });
        }
    }
}
