using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class Module
    {
       
         
        public Guid Id { get; set; }

   
        public string Module_name { get; set; }

        public string Module_code { get; set; }

        
        public int Semester { get; set; }

       
        public string Lecturer { get; set; }

        
        public DateTime Date { get; set; }


        [JsonIgnore]
        public ICollection<Assessment> Assessments { get; set; }

        [JsonIgnore]
        public ICollection<Lolist> Lolists { get; set; }

        [JsonIgnore]
        public ICollection<Polist> Polists { get; set; }

        public Guid? ThresholdId { get; set; }
        public Threshold Threshold { get; set; }

        public Guid? GradeId { get; set; }
        public  Grade Grade { get; set; }




        //public int Credits { get; set; }


        //public string Department { get; set; }

        //public int Semester { get; set; }

        //public DataType Date { get; set; }

        //public string Lecturer { get; set; }

        //public float MinEndMarks { get; set; }

        //public float MinContMarks { get; set; }

        //public float Attendance { get; set; }

        //public float AssessmentKPI { get; set; }

        //public float ModuleKPI { get; set; }



    }
}
