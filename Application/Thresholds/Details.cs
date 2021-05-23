using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Thresholds
{
    public class Details
    {

        public class Query : IRequest<Threshold>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Threshold>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Threshold> Handle(Query request, CancellationToken cancellationToken)
            {
                var threshold = await _context.Thresholds.FindAsync(request.Id);

                return threshold;
            }
        }
    }
}
