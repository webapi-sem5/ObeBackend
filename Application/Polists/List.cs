using MediatR;
using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Polists
{
    public class List
    {

        public class Query : IRequest<List<Polist>> { }

        public class Handler : IRequestHandler<Query, List<Polist>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Polist>> Handle(Query request, CancellationToken cancellationToken)
            {
                var polists = await _context.Polists
                    .Include(c => c.LolistPos)
                    .ThenInclude(c => c.Lolist)
                    .ToListAsync();

                return polists;
            }
        }
    }
}
