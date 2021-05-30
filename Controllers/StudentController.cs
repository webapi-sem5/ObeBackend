using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObeSystem.Application.Students;
using ObeSystem.Models;

namespace ObeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> List()
        {
            return await _mediator.Send(new List.Query());


        }


        //GET: api/Student/5
        [HttpGet("{id?}")]
        public async Task<ActionResult<StudentDto>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }


        [HttpPost]
        public async Task<ActionResult<Student>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut("{id?}")]
        public async Task<ActionResult<Student>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(Guid id)
        {

            return await _mediator.Send(new Delete.Command { Id = id });
        }



    }
}
