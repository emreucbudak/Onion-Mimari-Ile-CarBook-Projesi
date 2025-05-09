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
    public class RemoveAboutQueryHandler
    {
        private readonly IRepositoryBase<About> _repository;

        public RemoveAboutQueryHandler(IRepositoryBase<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAboutCommand rm) {
            var x = await _repository.GetItemAsync(b => b.AboutId == rm.AboutId);
            await _repository.RemoveItemAsync(x);
        }
    }
}
