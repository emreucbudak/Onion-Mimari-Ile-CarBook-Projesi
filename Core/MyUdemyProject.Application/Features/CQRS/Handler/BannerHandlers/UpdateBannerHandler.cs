using MyUdemyProject.Application.Features.CQRS.Command.BannerCommands;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.BannerHandlers
{
    public class UpdateBannerHandler
    {
        private IRepositoryBase<Banner> _repository;

        public UpdateBannerHandler(IRepositoryBase<Banner> repository)
        {
            _repository = repository;
        }
        public async Task HandleBanner(UpdateBannerCommand command) {
            var x = await _repository.GetItemAsync(b=> b.BannerId == command.BannerId);
            x.VideoUrl = command.VideoUrl;
            x.VideoDescription = command.VideoDescription;
            x.Title = command.Title;
            x.Description = command.Description;
            
            await _repository.UpdateItemAsync(x);
        }
    }
}
