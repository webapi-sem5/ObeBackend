using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObeSystem.Application.Thresholds;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThresholdController : Controller
    {
    
            private readonly IMediator _mediator;

            public ThresholdController(IMediator mediator)
            {
                _mediator = mediator;
            }


            // GET: api/Threshold
            [HttpGet]
            public async Task<ActionResult<List<Threshold>>> List()
            {
                return await _mediator.Send(new List.Query());


            }


            //GET: api/Threshold/5
            [HttpGet("{id?}")]
            public async Task<ActionResult<Threshold>> Details(Guid id)
            {
                return await _mediator.Send(new Details.Query { Id = id });
            }


            [HttpPost]
            public async Task<ActionResult<Threshold>> Create(Create.Command command)
            {
                return await _mediator.Send(command);
            }


            [HttpPut("{id?}")]
            public async Task<ActionResult<Threshold>> Edit(Guid id, Edit.Command command)
            {
                command.Id = id;
                return await _mediator.Send(command);
            }



            [HttpDelete("{id}")]
            public async Task<ActionResult<Threshold>> Delete(Guid id)
            {

                return await _mediator.Send(new Delete.Command { Id = id });
            }



        
    

    }
}
