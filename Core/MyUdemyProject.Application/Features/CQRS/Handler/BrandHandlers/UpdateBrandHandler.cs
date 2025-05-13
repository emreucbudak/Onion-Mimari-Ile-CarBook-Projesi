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
    public class UpdateBrandHandler
    {
        private readonly IRepositoryBase<Brand> _br;

        public UpdateBrandHandler(IRepositoryBase<Brand> br)
        {
            _br = br;
        }
        public async Task UpdateHandler(UpdateBrandCommands command)
        {
            var x = await _br.GetItemAsync(b=> b.BrandId == command.BrandId);
            x.Name = command.Name;
           
            await _br.UpdateItemAsync(x);
        }
    }
}
