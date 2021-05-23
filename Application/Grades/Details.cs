using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Grades
{
    public class Details
    {

        public class Query : IRequest<Grade>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Grade>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Grade> Handle(Query request, CancellationToken cancellationToken)
            {
                var grade = await _context.Grades.FindAsync(request.Id);

                return grade;
            }
        }
    }
}
