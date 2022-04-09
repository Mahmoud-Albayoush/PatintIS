using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace PatintIS.Application.Features.Queries.GetPatintList
{
    public class GetPatintsListQuery:IRequest<List<GetPatintsListViewModel>>
    {
    }
}
