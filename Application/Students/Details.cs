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
    public class Details
    {

        public class Query : IRequest<StudentDto>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, StudentDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StudentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var student = await _context.Students
                    .Include(c => c.StudentLolists)
                    .ThenInclude(c => c.Lolist)
                    .Include(c => c.AssessmentStudents)
                    .ThenInclude(c => c.Assessment)
                    .SingleOrDefaultAsync(c => c.Id == request.Id);

                var studentToReturn = _mapper.Map<Student, StudentDto>(student);

                return studentToReturn;
            }
        }
    }
}
