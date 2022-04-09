using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PatintIS.Application.Contracts;

namespace PatintIS.Application.Features.Commands.DeletePatint
{
    public class DeletePatintCommandHandler : IRequestHandler<DeletePatintCommand>
    {
        private readonly IPatintRepository _repository;

        public DeletePatintCommandHandler(IPatintRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Unit> Handle(DeletePatintCommand request, CancellationToken cancellationToken)
        {
            var patint = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(patint);
            return Unit.Value;
        }
    }
}
