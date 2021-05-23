using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Registration_number { get; set; }

        public float Student_marks { get; set; }

        public int Batch { get; set; }

        [JsonIgnore]
        public ICollection<AssessmentStudent> AssessmentStudents { get; set; }

        [JsonIgnore]
        public ICollection<StudentLolist> StudentLolists { get; set; }

        //public Guid? AssessmentId { get; set; }

        //public Assessment Assessment { get; set; }


    }
}
