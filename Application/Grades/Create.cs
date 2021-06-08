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


            public int AplusMarks { get; set; }
            public int AMarks { get; set; }
            public int AminMarks { get; set; }
            public int BpluseMarks { get; set; }
            public int BMarks { get; set; }
            public int BminMarks { get; set; }
            public int CpluseMarks { get; set; }
            public int CMarks { get; set; }
            public int CminMarks { get; set; }
            public int EMarks { get; set; }

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
                    AplusMarks = request.AplusMarks,
                    AMarks = request.AMarks,
                    AminMarks = request.AminMarks ,
                    BpluseMarks = request.BpluseMarks ,
                    BMarks = request.BMarks ,
                    BminMarks = request.BminMarks ,
                    CpluseMarks = request.CpluseMarks ,
                    CMarks = request.CMarks ,
                    CminMarks = request.CminMarks ,
                    EMarks = request.EMarks ,

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
