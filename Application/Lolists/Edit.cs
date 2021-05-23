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
    public class Edit
    {

        public class Command : IRequest<Lolist>
        {
            public Guid Id { get; set; }


            public string Lo_name { get; set; }


            public string Lo_code { get; set; }


            public string Description { get; set; }


            public double? Weight { get; set; }

            public Guid? ModuleId { get; set; }

        }

        public class Handler : IRequestHandler<Command,Lolist>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Lolist> Handle(Command request, CancellationToken cancellationToken)
            {
                var newModule = _context.Modules.SingleOrDefault(c => c.Id == request.ModuleId);
                var lolist = await _context.Lolists.FindAsync(request.Id);

                if (lolist == null)
                    throw new Exception("Could not find lolist");

                lolist.Lo_name = request.Lo_name ?? lolist.Lo_name;
                lolist.Lo_code = request.Lo_code ?? lolist.Lo_code;
                lolist.Description = request.Description ?? lolist.Description;
                lolist.Weight = request.Weight ?? lolist.Weight;
                lolist.ModuleId = request.ModuleId;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return lolist;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
