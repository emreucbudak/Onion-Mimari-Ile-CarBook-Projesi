using MyUdemyProject.Application.Features.CQRS.Command.BannerCommands;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.BannerHandlers
{
    public class RemoveBannerHandler
    {
        private readonly IRepositoryBase<Banner> _repository;

        public RemoveBannerHandler(IRepositoryBase<Banner> repository)
        {
            _repository = repository;
        }
        public async Task RemoveHandler(RemoveBannerCommand rm) {

            var x = await _repository.GetItemAsync(b=> b.BannerId == rm.BannerId);
            await _repository.RemoveItemAsync(x);
        }
    }
}
