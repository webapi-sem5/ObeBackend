using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class Assessment
    {
        
        public Guid Id { get; set; }

        public string Assessment_name { get; set; }

       
        public string Assessment_type { get; set; }

      
        public int Marks { get; set; }

        public int Student_marks { get; set; }

        [JsonIgnore]
        public ICollection<AssessmentLo> AssessmentLos { get; set; }


        public Guid? ModuleId { get; set; }
        
        public Module Module { get; set; }


        [JsonIgnore]
        public ICollection<AssessmentStudent> AssessmentStudents { get; set; }

        

    }
}
