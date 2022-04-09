using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PatintIS.Application.Contracts;
using PatintIS.Domain;

namespace PatintIS.Application.Features.Commands.CreatePatint
{
    public class CreatePatintCommandHandler : IRequestHandler<CreatePatintCommand,Guid>
    {
        private readonly IPatintRepository _patintRepository;
        private readonly IMapper _mapper;

        public CreatePatintCommandHandler(IPatintRepository patintRepository, IMapper mapper)
        {
            this._patintRepository = patintRepository;
            this._mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePatintCommand request, CancellationToken cancellationToken)
        {
            Patint student = _mapper.Map<Patint>(request);
            CreatePatintValidator validator = new CreatePatintValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Student is not Valid");
            }
            student = await _patintRepository.AddAsync(student);
            return student.Id;
        }
    }
}
