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
    public class List
    {

        public class Query : IRequest<List<AssessmentDto>> { }

        public class Handler : IRequestHandler<Query, List<AssessmentDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AssessmentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                

                var assessments = await _context.Assessments
                    .Include(c => c.AssessmentStudents)
                    .ThenInclude(c => c.Student)
                    .Include(x => x.AssessmentLos)
                    .ThenInclude(x =>x.Lolist)
                    .Include(x => x.Module)
                    .ToListAsync();

                return _mapper.Map<List<Assessment>, List<AssessmentDto>>(assessments);
            }
        }
    }
}
