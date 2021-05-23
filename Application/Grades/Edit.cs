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
    public class Edit
    {

        public class Command : IRequest<Grade>
        {
            public Guid Id { get; set; }

            public int? Lower_marks { get; set; }

            public int? Higher_marks { get; set; }

            public string Grade_type { get; set; }

            public float? Gpa { get; set; }

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

                grade.Lower_marks = request.Lower_marks ?? grade.Lower_marks;
                grade.Higher_marks = request.Higher_marks ?? grade.Higher_marks;
                grade.Grade_type = request.Grade_type ?? grade.Grade_type;
                grade.Gpa = request.Gpa ?? grade.Gpa;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return grade;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
