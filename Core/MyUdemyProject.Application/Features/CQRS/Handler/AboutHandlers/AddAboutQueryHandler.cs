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
    public class AddAboutQueryHandler
    {
        private readonly IRepositoryBase<About> _repository;

        public AddAboutQueryHandler(IRepositoryBase<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAboutCommand com)
        {
           await  _repository.AddItemAsync(new About()
            {
                Title = com.Title,
                Description = com.Description,
                ImageUrl = com.ImageUrl,
            });
        }
    }
}
