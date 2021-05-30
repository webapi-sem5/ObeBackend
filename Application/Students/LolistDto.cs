using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Application.Students
{
    public class LolistDto
    {


        public Guid Id { get; set; }


        public string Lo_name { get; set; }


        public string Lo_code { get; set; }


        public string Description { get; set; }


        public double Weight { get; set; }

        public float Student_marks { get; set; }

        public bool Status { get; set; }

        public Guid? ModuleId { get; set; }
    }
}
