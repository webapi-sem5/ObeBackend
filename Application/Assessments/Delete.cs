using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Assessments
{
    public class Delete
    {
        public class Command : IRequest<Assessment>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Command, Assessment>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Assessment> Handle(Command request, CancellationToken cancellationToken)
            {
                var assessment = await _context.Assessments.FindAsync(request.Id);

                if (assessment == null)
                    throw new Exception("Could not find assessment");

                _context.Assessments.Remove(assessment);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return assessment;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
