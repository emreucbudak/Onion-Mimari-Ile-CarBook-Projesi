using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUdemyProject.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarQueriesId
    {
        public GetCarQueriesId(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
