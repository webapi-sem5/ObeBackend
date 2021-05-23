using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Application.Assessments
{
    public class StudentDto
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Registration_number { get; set; }

        public float Student_marks { get; set; }

        public int Batch { get; set; }

    }
}
