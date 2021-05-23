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
    public class Edit
    {

        public class Command : IRequest<Assessment>
        {
            public Guid Id { get; set; }

            public string Assessment_name { get; set; }


            public string Assessment_type { get; set; }


            public int? Marks { get; set; }

            public int? Student_marks { get; set; }

            public Guid? ModuleId { get; set; }

        }

        public class Handler : IRequestHandler<Command,Assessment>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Assessment> Handle(Command request, CancellationToken cancellationToken)
            {

                var newModule = _context.Modules.SingleOrDefault(c => c.Id == request.ModuleId);
                var assessment = await _context.Assessments.FindAsync(request.Id);
              

                if (assessment == null)
                    throw new Exception("Could not find assessment");

                assessment.Module = newModule;
                assessment.Assessment_name = request.Assessment_name ?? assessment.Assessment_name;
                assessment.Assessment_type = request.Assessment_type ?? assessment.Assessment_type;
                assessment.Marks = request.Marks ?? assessment.Marks;
                assessment.Student_marks = request.Student_marks ?? assessment.Student_marks;
                assessment.ModuleId = request.ModuleId;
               
               



                var success = await _context.SaveChangesAsync() > 0;

                if (success) return assessment;

                throw new Exception("Problem saving changes");



            }
        }
    }
}
