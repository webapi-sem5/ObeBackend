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
    public class Delete
    {
        public class Command : IRequest<Threshold>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Command, Threshold>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Threshold> Handle(Command request, CancellationToken cancellationToken)
            {
                var threshold = await _context.Thresholds.FindAsync(request.Id);

                if (threshold == null)
                    throw new Exception("Could not find threshold");

                _context.Thresholds.Remove(threshold);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return threshold;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
