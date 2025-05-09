using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Command.AboutCommands
{
    public class RemoveAboutCommand
    {
        public int AboutId { get; set; }
    }
}
