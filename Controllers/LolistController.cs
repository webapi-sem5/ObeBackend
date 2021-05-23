using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObeSystem.Application.Lolists;
using ObeSystem.Interfaces;
using ObeSystem.Models;

namespace ObeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LolistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LolistController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Lolist
        [HttpGet]
        public async Task<ActionResult<List<LoDto>>> List()
        {
            return await _mediator.Send(new List.Query());


        }


        //GET: api/Lolist/5
        [HttpGet("{id?}")]
        public async Task<ActionResult<LoDto>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult<Lolist>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut("{id?}")]
        public async Task<ActionResult<Lolist>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Lolist>> Delete(Guid id)
        {

            return await _mediator.Send(new Delete.Command { Id = id });
        }



    }
}







