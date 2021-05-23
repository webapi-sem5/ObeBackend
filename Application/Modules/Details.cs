using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Modules
{
    public class Details
    {

        public class Query : IRequest<Module>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Module>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Module> Handle(Query request, CancellationToken cancellationToken)
            {
                var module = await _context.Modules.FindAsync(request.Id);

                return module;
            }
        }
    }
}
