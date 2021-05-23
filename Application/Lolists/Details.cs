using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ObeSystem.Models;
using ObeSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObeSystem.Application.Lolists
{
    public class Details
    {

        public class Query : IRequest<LoDto> 
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, LoDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LoDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var lolist = await _context.Lolists
                    .Include(c => c.Module)
                    .Include(x => x.AssessmentLos)
                    .ThenInclude(x => x.Assessment)
                    .Include(x => x.LolistPos)
                    .ThenInclude(x => x.Polist)
                    .SingleOrDefaultAsync(c => c.Id == request.Id);

                var lolistToReturn = _mapper.Map<Lolist, LoDto>(lolist);

                return lolistToReturn;
            }
        }
    }
}
