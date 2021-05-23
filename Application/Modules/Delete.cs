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
    public class Delete
    {
        public class Command : IRequest<Module>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Command, Module>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Module> Handle(Command request, CancellationToken cancellationToken)
            {
                var module = await _context.Modules.FindAsync(request.Id);

                if (module == null)
                    throw new Exception("Could not find module");

                _context.Modules.Remove(module);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return module;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
