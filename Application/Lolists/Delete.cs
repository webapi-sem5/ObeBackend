using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Lolists
{
    public class Delete
    {
        public class Command : IRequest<Lolist>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Command, Lolist>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Lolist> Handle(Command request, CancellationToken cancellationToken)
            {
                var lolist = await _context.Lolists.FindAsync(request.Id);

                if (lolist == null)
                    throw new Exception("Could not find lolist");

                _context.Lolists.Remove(lolist);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return lolist;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
