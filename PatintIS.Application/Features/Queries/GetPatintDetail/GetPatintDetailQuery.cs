using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace PatintIS.Application.Features.Queries.GetPatintDetail
{
    public class GetPatintDetailQuery:IRequest<GetPatintDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
