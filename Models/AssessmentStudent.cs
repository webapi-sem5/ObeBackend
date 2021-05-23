using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class AssessmentStudent
    {
        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid AssessmentId { get; set; }

        public Assessment Assessment { get; set; }

        public float Assessment_marks { get; set; }

    }
}
