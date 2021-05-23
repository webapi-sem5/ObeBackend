using AutoMapper;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Application.Lolists
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lolist, LoDto>();
            CreateMap<LolistPo, PolistDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Polist.Id))
                .ForMember(d => d.Po_name, o => o.MapFrom(s => s.Polist.Po_name))
                .ForMember(d => d.Po_code, o => o.MapFrom(s => s.Polist.Po_code))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Polist.Description));
        }
    }
}
