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
    public class Create
    {
        public class Command : IRequest<Assessment>
        {
            public Guid Id { get; set; }

            public string Assessment_name { get; set; }


            public string Assessment_type { get; set; }


            public int Marks { get; set; }

            public int Student_marks { get; set; }

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
              

                var assessment = new Assessment
                {
                    Id = request.Id,
                    Assessment_name = request.Assessment_name,
                    Assessment_type = request.Assessment_type,
                    Marks = request.Marks,
                    Student_marks = request.Student_marks,
                    Module = newModule
                  
                   
                };



                _context.Assessments.Add(assessment);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return assessment;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
