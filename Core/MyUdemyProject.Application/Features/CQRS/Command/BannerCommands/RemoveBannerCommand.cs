using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Command.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int BannerId { get; set; }
    }
}
