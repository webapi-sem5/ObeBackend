using AutoMapper;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Application.Assessments
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Assessment, AssessmentDto>();
            CreateMap<AssessmentLo, LolistDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Lolist.Id))
                 .ForMember(d => d.Lo_code, o => o.MapFrom(s => s.Lolist.Lo_code))
                  .ForMember(d => d.Lo_name, o => o.MapFrom(s => s.Lolist.Lo_name))
                   .ForMember(d => d.Description, o => o.MapFrom(s => s.Lolist.Description))
                    .ForMember(d => d.Weight, o => o.MapFrom(s => s.Lolist.Weight));
                    




            /*CreateMap<Assessment, AssessmentDto>();*/

            CreateMap<AssessmentStudent, StudentDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Student.Id))
                 .ForMember(d => d.Name, o => o.MapFrom(s => s.Student.Name))
                  .ForMember(d => d.Registration_number, o => o.MapFrom(s => s.Student.Registration_number))
                   .ForMember(d => d.Student_marks, o => o.MapFrom(s => s.Student.Student_marks))
            .ForMember(d => d.Batch, o => o.MapFrom(s => s.Student.Batch));

            CreateMap<AssessmentDto, LolistDto>()
               .ForMember(c => c.ModuleId, o => o.MapFrom(c => c.ModuleId))
               .ForMember(c => c.Module, o => o.MapFrom(c => c.Module));












        }
    }
}
