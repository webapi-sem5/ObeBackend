using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class StudentLolist
    {
        public Guid LolistId { get; set; }

        public Lolist Lolist { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public float Lo_marks { get; set; }
    }
}
