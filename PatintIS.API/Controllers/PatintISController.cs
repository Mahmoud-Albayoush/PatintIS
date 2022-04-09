using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatintIS.Application.Features.Commands.Common.Pagination;
using PatintIS.Application.Features.Commands.CreatePatint;
using PatintIS.Application.Features.Commands.DeletePatint;
using PatintIS.Application.Features.Commands.UpdatePatint;
using PatintIS.Application.Features.Queries.GetPatintDetail;
using PatintIS.Application.Features.Queries.GetPatintList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatintIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatintISController : Controller
    {
        private readonly IMediator _mediator;

        public PatintISController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

       [HttpGet("all", Name = "GetAllPahint")]
        public async Task<ActionResult<List<GetPatintsListViewModel>>> GetAllPatint(int pageSize = 5,int Page=1,string? name=null,int? File=null,string? Phone=null)
        {
            var dtos = await _mediator.Send(new GetPatintsListQuery());
            var paginationData = new PagerMetaData(Page, dtos.Count, pageSize);
            Response.Headers.Add("X-PagerMetaData", JsonSerializer.Serialize(paginationData));
            Response.Headers.Add("Access-Control-Expose-Headers", "X-PagerMetaData");
            var items = dtos.Where(p => (string.IsNullOrEmpty(Phone) || p.PhoneNumber.Contains(Phone)) && (string.IsNullOrEmpty(name) || p.Name.ToLower() == name) && (File == null || p.FileNo == File)).Skip((Page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(items);
        }


        [HttpPost(Name = "AddPatint")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePatintCommand createPatintCommand)
        {
            Guid id = await _mediator.Send(createPatintCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdatePatint")]
        public async Task<ActionResult> Update([FromBody] UpdatePatintCommand updatePatintCommand)
        {
            await _mediator.Send(updatePatintCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePatint")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePatintCommand = new DeletePatintCommand() { Id = id };
            await _mediator.Send(deletePatintCommand);
            return NoContent();
        }
    }
}
