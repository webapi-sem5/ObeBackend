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

namespace ObeSystem.Application.Students
{
    public class List
    {

        public class Query : IRequest<List<StudentDto>> { }

        public class Handler : IRequestHandler<Query, List<StudentDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper )
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<StudentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _context.Students
                    .Include(c => c.StudentLolists)
                    .ThenInclude(c => c.Lolist)
                    .Include(c => c.AssessmentStudents)
                    .ThenInclude(c => c.Assessment)
                    .ToListAsync();

                return _mapper.Map<List<Student>,List<StudentDto>>(students);
            }
        }
    }
}
