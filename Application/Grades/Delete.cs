using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Grades
{
    public class Delete
    {
        public class Command : IRequest<Grade>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Command, Grade>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Grade> Handle(Command request, CancellationToken cancellationToken)
            {
                var grade = await _context.Grades.FindAsync(request.Id);

                if (grade == null)
                    throw new Exception("Could not find grade");

                _context.Grades.Remove(grade);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return grade;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
