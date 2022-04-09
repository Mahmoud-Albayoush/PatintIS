using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatintIS.Application.Contracts;

namespace PatintIS.Application.Features.Queries.GetPatintList
{
    public class GetPatintsListQueryHandler : IRequestHandler<GetPatintsListQuery, List<GetPatintsListViewModel>>
    {
        private readonly IPatintRepository _patintRepository;
        private readonly IMapper _mapper;

        public GetPatintsListQueryHandler(IPatintRepository patintRepository, IMapper mapper)
        {
            this._patintRepository = patintRepository;
            this._mapper = mapper;
        }
        public async Task<List<GetPatintsListViewModel>> Handle(GetPatintsListQuery request, CancellationToken cancellationToken)
        {
            var allpatint = await _patintRepository.GetAllPatintsAsync();
            return _mapper.Map<List<GetPatintsListViewModel>>(allpatint);
        }
    }
}
