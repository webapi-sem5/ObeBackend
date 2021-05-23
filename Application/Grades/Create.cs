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
    public class Create
    {
        public class Command : IRequest<Grade>
        {
            public Guid Id { get; set; }

            public int Lower_marks { get; set; }

            public int Higher_marks { get; set; }

            public string Grade_type { get; set; }

            public float Gpa { get; set; }


        }

        public class Handler : IRequestHandler<Command,Grade>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Grade> Handle(Command request, CancellationToken cancellationToken)
            {
                var grade = new Grade
                {
                    Id = request.Id,
                    Lower_marks = request.Lower_marks,
                    Higher_marks = request.Higher_marks,
                    Grade_type = request.Grade_type,
                    Gpa = request.Gpa

                };

                _context.Grades.Add(grade);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return grade;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
