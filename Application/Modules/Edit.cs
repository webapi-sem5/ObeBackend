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
    public class Edit
    {

        public class Command : IRequest<Module>
        {
            public Guid Id { get; set; }


            public string Module_name { get; set; }

            public string Module_code { get; set; }


            public int? Semester { get; set; }


            public string Lecturer { get; set; }


            public DateTime? Date { get; set; }

            public Guid? ThresholdId { get; set; }

            public Threshold Threshold { get; set; }

            public Guid? GradeId { get; set; }
            public Grade Grade { get; set; }

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
                var newThreshold = _context.Thresholds.SingleOrDefault(c => c.Id == request.ThresholdId);
                var module = await _context.Modules.FindAsync(request.Id);

                if (module == null)
                    throw new Exception("Could not find module");

                module.Module_name = request.Module_name ?? module.Module_name;
                module.Module_code = request.Module_code ?? module.Module_code;
                module.Semester = request.Semester ?? module.Semester;
                module.Lecturer = request.Lecturer ?? module.Lecturer;
                module.Date = request.Date ?? module.Date;
                module.GradeId = request.GradeId ?? module.GradeId;
                module.ThresholdId = request.ThresholdId;
                module.Threshold = newThreshold;
                if(request.GradeId != null)
                {
                 var newGrade = _context.Grades.SingleOrDefault(c => c.Id == request.GradeId);
                 module.Grade = newGrade;

                }
                else
                {
                    module.GradeId = null;
                }


                var success = await _context.SaveChangesAsync() > 0;

                if (success) return module;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
