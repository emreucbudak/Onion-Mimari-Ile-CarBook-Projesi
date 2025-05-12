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
    public class CreateBannerHandler
    {
        private readonly IRepositoryBase<Banner> _rp;

        public CreateBannerHandler(IRepositoryBase<Banner> rp)
        {
            _rp = rp;
        }
        public async Task AddBannerHandler (CreateBannerCommand handler)
        {
            await _rp.AddItemAsync(new Banner()
            {
                Title = handler.Title,
                Description = handler.Description,
                VideoDescription = handler.VideoDescription,
                VideoUrl = handler.VideoUrl,

            });
        }
    }
}
