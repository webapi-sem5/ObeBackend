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
    public class List
    {

        public class Query : IRequest<List<LoDto>> { }

        public class Handler : IRequestHandler<Query, List<LoDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LoDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var lolists = await _context.Lolists
                    .Include(c => c.Module)
                    .Include(x => x.AssessmentLos)
                    .ThenInclude(x => x.Assessment)
                    .Include(x => x.LolistPos)
                    .ThenInclude(x => x.Polist)
                    .ToListAsync();

                return _mapper.Map<List<Lolist>, List<LoDto>>(lolists);

                
            }
        }
    }
}
