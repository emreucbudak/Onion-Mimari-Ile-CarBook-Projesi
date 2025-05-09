using MyUdemyProject.Application.Features.CQRS.Command.AboutCommands;
using MyUdemyProject.Application.Interfaces;
using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Handler.AboutHandlers
{
    public class UpdateAboutQueryHandler
    {
        private readonly IRepositoryBase<About> _rp;

        public UpdateAboutQueryHandler(IRepositoryBase<About> rp)
        {
            _rp = rp;
        }
        public async Task UpdateAboutHandler (UpdateAboutCommands cm)
        {
            var x = await _rp.GetItemAsync(b=> b.AboutId == cm.AboutId);
            x.Title = cm.Title;
            x.Description = cm.Description;
            x.ImageUrl = cm.ImageUrl;
            await _rp.UpdateItemAsync(x);

        }
    }
}
