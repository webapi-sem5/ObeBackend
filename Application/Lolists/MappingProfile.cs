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

            CreateMap<AssessmentLo, AssessmentDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Assessment.Id))
                .ForMember(d => d.Assessment_name, o => o.MapFrom(s => s.Assessment.Assessment_name))
                .ForMember(d => d.Assessment_type, o => o.MapFrom(s => s.Assessment.Assessment_type))
                .ForMember(d => d.Marks, o => o.MapFrom(s => s.Assessment.Marks));


            CreateMap<StudentLolist, StudentDto>()
                .ForMember(a => a.Id, o => o.MapFrom(s => s.Student.Id))
                .ForMember(a => a.Name, o => o.MapFrom(s => s.Student.Name))
                .ForMember(a => a.Registration_number, o => o.MapFrom(s => s.Student.Registration_number))
                .ForMember(a => a.Batch, o => o.MapFrom(s => s.Student.Batch))
                .ForMember(a => a.Student_marks, o => o.MapFrom(s => s.Lo_marks));
        }
    }
}
