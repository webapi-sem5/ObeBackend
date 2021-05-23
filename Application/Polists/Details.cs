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

namespace ObeSystem.Application.Polists
{
    public class Details
    {

        public class Query : IRequest<PolistDto> 
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, PolistDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PolistDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var polist = await _context.Polists
                    .Include(c => c.LolistPos)
                    .ThenInclude(c => c.Lolist)
                    .SingleOrDefaultAsync(c => c.Id ==request.Id);

                var polistToReturn = _mapper.Map<Polist, PolistDto>(polist);

                return polistToReturn;
            }
        }
    }
}
