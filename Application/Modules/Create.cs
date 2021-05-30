using FluentValidation;
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
    public class Create
    {
        public class Command : IRequest<Module>
        {
            public Guid Id { get; set; }


            public string Module_name { get; set; }

            public string Module_code { get; set; }


            public int Semester { get; set; }


            public string Lecturer { get; set; }


            public DateTime Date { get; set; }

            public Guid? ThresholdId { get; set; }

            public Guid? GradeId { get; set; }

              
        }


        public class CommandValidator : AbstractValidator<Command>
        {

            public CommandValidator()
            {

            RuleFor(x => x.Module_name).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command,Module>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Module> Handle(Command request, CancellationToken cancellationToken)
            {
                var newGrade = _context.Grades.SingleOrDefault(c => c.Id == request.GradeId);

                var newThreshold = _context.Thresholds.SingleOrDefault(c => c.Id == request.ThresholdId);

                var module = new Module
                {
                    Id = request.Id,
                    Module_name = request.Module_name,
                    Module_code = request.Module_code,
                    Semester = request.Semester,
                    Lecturer = request.Lecturer,
                    Date = request.Date,
                    Grade = newGrade,
                    Threshold = newThreshold
                  

                };

                _context.Modules.Add(module);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return module;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
