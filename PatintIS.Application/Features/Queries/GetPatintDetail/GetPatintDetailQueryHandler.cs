using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatintIS.Application.Contracts;

namespace PatintIS.Application.Features.Queries.GetPatintDetail
{
    public class GetPatintDetailQueryHandler : IRequestHandler<GetPatintDetailQuery, GetPatintDetailViewModel>
    {
        private readonly IPatintRepository _patintRepository;
        private readonly IMapper _mapper;

        public GetPatintDetailQueryHandler(IPatintRepository patintRepository, IMapper mapper)
        {
            this._patintRepository = patintRepository;
            this._mapper = mapper;
        }
        public async Task<GetPatintDetailViewModel> Handle(GetPatintDetailQuery request, CancellationToken cancellationToken)
        {
            var patint = await _patintRepository.GetPatintByIdAsync(request.Id);
            return _mapper.Map<GetPatintDetailViewModel>(patint);
        }
    }
}
