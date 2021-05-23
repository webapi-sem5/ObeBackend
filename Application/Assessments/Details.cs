using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Assessments
{
    public class Details
    {

        public class Query : IRequest<AssessmentDto> 
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, AssessmentDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AssessmentDto> Handle(Query request, CancellationToken cancellationToken)
            {


                var assessment = await _context.Assessments
                    .Include(c => c.Module)
                    .Include(c => c.AssessmentStudents)
                    .ThenInclude(c => c.Student)
                    .Include(x => x.AssessmentLos)
                    .ThenInclude(x => x.Lolist)
                    .SingleOrDefaultAsync(c => c.Id == request.Id);


                var assessmentToReturn = _mapper.Map<Assessment, AssessmentDto>(assessment);

                return assessmentToReturn;
            }
        }
    }
}
