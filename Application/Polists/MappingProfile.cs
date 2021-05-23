using AutoMapper;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Application.Polists
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Polist, PolistDto>();

            CreateMap<LolistPo, LolistDto>()
                .ForMember(c => c.Id, o => o.MapFrom(c => c.Lolist.Id))
                 .ForMember(c => c.Lo_name, o => o.MapFrom(c => c.Lolist.Lo_name))
                  .ForMember(c => c.Lo_code, o => o.MapFrom(c => c.Lolist.Lo_code))
                   .ForMember(c => c.Description, o => o.MapFrom(c => c.Lolist.Description));
                    //.ForMember(c => c.Weight, o => o.MapFrom(c => c.Lolist.Weight))

            CreateMap<PolistDto, PolistDto>()
                .ForMember(c => c.Weight, o => o.MapFrom(c => c.LolistPos.Count()));

            

            //CreateMap<LolistDto,PolistDto>()
            //    .ForMember(c => c.Weight, o => o.MapFrom(c => c.Weight/length))
            



        }
    }
}
