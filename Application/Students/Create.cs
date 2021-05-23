using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Students
{
    public class Create
    {
        public class Command : IRequest<Student>
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Registration_number { get; set; }

            public float Student_marks { get; set; }

            public int Batch { get; set; }


        }

        public class Handler : IRequestHandler<Command,Student>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Student> Handle(Command request, CancellationToken cancellationToken)
            {
                var student = new Student
                {
                    Id = request.Id,
                    Name = request.Name,
                    Registration_number = request.Registration_number,
                    Student_marks = request.Student_marks,
                    Batch = request.Batch

                };

                _context.Students.Add(student);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return student;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
