using AutoMapper;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Application.Students
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            //CreateMap<LolistDto, StudentLolist>()


            CreateMap<StudentLolist, LolistDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Lolist.Id))
                .ForMember(d => d.Lo_name, o => o.MapFrom(s => s.Lolist.Lo_name))
                .ForMember(d => d.Lo_code, o => o.MapFrom(s => s.Lolist.Lo_code))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Lolist.Description))
                .ForMember(d => d.Weight, o => o.MapFrom(s => s.Lolist.Weight))
                .ForMember(d => d.ModuleId, o => o.MapFrom(s => s.Lolist.ModuleId))
                .ForMember(d => d.Student_marks, o => o.MapFrom(s => s.Lo_marks))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Lo_marks >= s.Lolist.Weight / 2 ? true : false));



            CreateMap<AssessmentStudent, AssessmentDto>()
                  .ForMember(d => d.Id, o => o.MapFrom(s => s.Assessment.Id))
                  .ForMember(d => d.Assessment_name, o => o.MapFrom(s => s.Assessment.Assessment_name))
                  .ForMember(d => d.Assessment_type, o => o.MapFrom(s => s.Assessment.Assessment_type))
                  .ForMember(d => d.Marks, o => o.MapFrom(s => s.Assessment.Marks))
                  .ForMember(d => d.ModuleId, o => o.MapFrom(s => s.Assessment.ModuleId))
                  .ForMember(d => d.Student_marks, o => o.MapFrom(s => s.Assessment_marks));
                 


            CreateMap<StudentDto, StudentDto>()
                .ForMember(c => c.Lo_count, o => o.MapFrom(c => c.StudentLolists.Count));
                  





        }
    }
}
