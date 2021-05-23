using MediatR;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Thresholds
{
    public class Create
    {
        public class Command : IRequest<Threshold>
        {
            public Guid Id { get; set; }

            public int End_marks { get; set; }

            public int Ca_marks { get; set; }

            public float Min_end_marks { get; set; }

            public float Min_ca_marks { get; set; }

            public float Min_total_marks { get; set; }

            public float Min_po_marks { get; set; }

            public float Min_lo_marks { get; set; }

            public float Min_attendance { get; set; }



        }

        public class Handler : IRequestHandler<Command,Threshold>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Threshold> Handle(Command request, CancellationToken cancellationToken)
            {
                var threshold = new Threshold
                {
                    Id = request.Id,
                    End_marks = request.End_marks,
                    Ca_marks = request.Ca_marks,
                    Min_end_marks = request.Min_end_marks,
                    Min_ca_marks = request.Min_ca_marks,
                    Min_total_marks = request.Min_total_marks,
                    Min_po_marks = request.Min_po_marks,
                    Min_lo_marks = request.Min_lo_marks,
                    Min_attendance = request.Min_attendance
                };

                _context.Thresholds.Add(threshold);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return threshold;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
