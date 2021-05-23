using MediatR;
using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Thresholds
{
    public class List
    {

        public class Query : IRequest<List<Threshold>> { }

        public class Handler : IRequestHandler<Query, List<Threshold>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Threshold>> Handle(Query request, CancellationToken cancellationToken)
            {
                var thresholds = await _context.Thresholds.ToListAsync();

                return thresholds;
            }
        }
    }
}
