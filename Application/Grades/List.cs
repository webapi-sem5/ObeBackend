using MediatR;
using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Grades
{
    public class List
    {

        public class Query : IRequest<List<Grade>> { }

        public class Handler : IRequestHandler<Query, List<Grade>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Grade>> Handle(Query request, CancellationToken cancellationToken)
            {
                var grades = await _context.Grades.ToListAsync();

                return grades;
            }
        }
    }
}
