using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObeSystem.Application.Polists;
using ObeSystem.Models;

namespace ObeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolistController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PolistController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Polist
        [HttpGet]
        public async Task<ActionResult<List<Polist>>> List()
        {
            return await _mediator.Send(new List.Query());


        }


        //GET: api/Polist/5
        [HttpGet("{id?}")]
        public async Task<ActionResult<PolistDto>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult<Polist>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut("{id?}")]
        public async Task<ActionResult<Polist>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Polist>> Delete(Guid id)
        {

            return await _mediator.Send(new Delete.Command { Id = id });
        }

    }
}
