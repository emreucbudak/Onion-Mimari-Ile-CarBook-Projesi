using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Result.BrandResult
{
    public class GetBrandWithIdResults
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
