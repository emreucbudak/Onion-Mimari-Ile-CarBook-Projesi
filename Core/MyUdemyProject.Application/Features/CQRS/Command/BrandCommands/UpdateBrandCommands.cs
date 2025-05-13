using MyUdemyProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Command.BrandCommands
{
    public class UpdateBrandCommands
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

    }
}
