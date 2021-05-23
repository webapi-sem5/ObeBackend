using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObeSystem.Application.Grades;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : Controller
    {
        private readonly IMediator _mediator;

        public GradeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Grade
        [HttpGet]
        public async Task<ActionResult<List<Grade>>> List()
        {
            return await _mediator.Send(new List.Query());


        }


        //GET: api/Grade/5
        [HttpGet("{id?}")]
        public async Task<ActionResult<Grade>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult<Grade>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut("{id?}")]
        public async Task<ActionResult<Grade>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Grade>> Delete(Guid id)
        {

            return await _mediator.Send(new Delete.Command { Id = id });
        }
    }
}
