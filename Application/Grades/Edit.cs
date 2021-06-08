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


            public int? AplusMarks { get; set; }
            public int? AMarks { get; set; }
            public int? AminMarks { get; set; }
            public int? BpluseMarks { get; set; }
            public int? BMarks { get; set; }
            public int? BminMarks { get; set; }
            public int? CpluseMarks { get; set; }
            public int? CMarks { get; set; }
            public int? CminMarks { get; set; }
            public int? EMarks { get; set; }

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

                grade.AplusMarks = request.AplusMarks ?? grade.AplusMarks;
                grade.AMarks = request.AMarks ?? grade.AMarks;
                grade.AminMarks = request.AminMarks ?? grade.AminMarks;
                grade.BpluseMarks = request.BpluseMarks ?? grade.BpluseMarks;
                grade.BMarks = request.BMarks ?? grade.BMarks;
                grade.BminMarks = request.BminMarks ?? grade.BminMarks;
                grade.CpluseMarks = request.CpluseMarks ?? grade.CpluseMarks;
                grade.CMarks = request.CMarks ?? grade.CMarks;
                grade.CminMarks = request.CminMarks ?? grade.CminMarks;
                grade.EMarks = request.EMarks ?? grade.EMarks;
                grade.Grade_type = request.Grade_type ?? grade.Grade_type;
                grade.Gpa = request.Gpa ?? grade.Gpa;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return grade;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
