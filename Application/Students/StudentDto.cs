using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Application.Students
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Registration_number { get; set; }

        public float Student_marks { get; set; }

        public int Batch { get; set; }

        public int Lo_count { get; set; }

        [JsonPropertyName("lolist")]
        public ICollection<LolistDto> StudentLolists { get; set; }


        
        [JsonPropertyName("assessments")]
        public ICollection<AssessmentDto> AssessmentStudents { get; set; }
    }
}
