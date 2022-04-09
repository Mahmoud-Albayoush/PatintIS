using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatintIS.Application.Contracts;
using PatintIS.Domain;

namespace PatintIS.Application.Features.Commands.UpdatePatint
{
    public class UpdatePatintCommandHandler : IRequestHandler<UpdatePatintCommand>
    {
        private readonly IAsyncRepository<Patint> _repository;
        private readonly IMapper _mapper;

        public UpdatePatintCommandHandler(IAsyncRepository<Patint> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdatePatintCommand request, CancellationToken cancellationToken)
        {
            Patint patint = _mapper.Map<Patint>(request);
            await _repository.UpdateAsync(patint);
            return Unit.Value;
        }
    }
}
