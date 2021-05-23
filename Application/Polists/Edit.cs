using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Polists
{
    public class Edit
    {

        public class Command : IRequest<Polist>
        {
            public Guid Id { get; set; }


            public string Po_name { get; set; }

            public string Po_code { get; set; }


            public string Description { get; set; }

        }

        public class Handler : IRequestHandler<Command,Polist>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Polist> Handle(Command request, CancellationToken cancellationToken)
            {
                var polist = await _context.Polists.FindAsync(request.Id);

                if (polist == null)
                    throw new Exception("Could not find polist");

                polist.Po_name = request.Po_name ?? polist.Po_name;
                polist.Po_code = request.Po_code ?? polist.Po_code;
                polist.Description = request.Description ?? polist.Description;
                

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return polist;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
