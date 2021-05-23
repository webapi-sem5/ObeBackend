using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Application.Assessments
{
    public class AssessmentDto
    {

        public Guid Id { get; set; }

        public string Assessment_name { get; set; }


        public string Assessment_type { get; set; }


        public int Marks { get; set; }

        public int Student_marks { get; set; }

        public Guid? ModuleId { get; set; }

        public Module Module { get; set; }

        [JsonPropertyName("lolist")]
        public ICollection<LolistDto> AssessmentLos { get; set; }


        [JsonPropertyName("studentlist")]
        public ICollection<StudentDto> AssessmentStudents { get; set; }

       





    }
}
