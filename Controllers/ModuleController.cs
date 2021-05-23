using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObeSystem.Application.Modules;
using ObeSystem.Interfaces;
using ObeSystem.Models;

namespace ObeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModuleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Module
        [HttpGet]
        public async Task<ActionResult<List<Module>>> List()
        {
            return await _mediator.Send(new List.Query());


        }


        //GET: api/Module/5
        [HttpGet("{id?}")]
        public async Task<ActionResult<Module>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult<Module>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut("{id?}")]
        public async Task<ActionResult<Module>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Module>> Delete(Guid id)
        {

            return await _mediator.Send(new Delete.Command { Id = id });
        }



    }
}
