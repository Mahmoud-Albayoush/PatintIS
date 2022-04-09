using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
namespace PatintIS.Application.Features.Commands.DeletePatint
{
    public class DeletePatintCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
