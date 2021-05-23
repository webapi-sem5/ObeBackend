using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Application.Students
{
    public class AssessmentDto
    {
        public Guid Id { get; set; }

        public string Assessment_name { get; set; }


        public string Assessment_type { get; set; }


        public int Marks { get; set; }

        public int Student_marks { get; set; }
    }
}
