using MediatR;
using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Modules
{
    public class List
    {

        public class Query : IRequest<List<Module>> { }

        public class Handler : IRequestHandler<Query, List<Module>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Module>> Handle(Query request, CancellationToken cancellationToken)
            {
                var modules = await _context.Modules.Include(c => c.Threshold ).Include(c => c.Grade).ToListAsync();

                return modules;
            }
        }
    }
}
