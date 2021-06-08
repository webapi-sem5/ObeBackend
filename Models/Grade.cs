using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class Grade
    {
        public Guid Id { get; set; }

        public int AplusMarks { get; set; }
        public int AMarks { get; set; }
        public int AminMarks { get; set; }
        public int BpluseMarks { get; set; }
        public int BMarks { get; set; }
        public int BminMarks { get; set; }
        public int CpluseMarks { get; set; }
        public int CMarks { get; set; }
        public int CminMarks { get; set; }
        public int EMarks { get; set; }

        public string Grade_type { get; set; }

        public float Gpa { get; set; }

        [JsonIgnore]
        public ICollection<Module> Modules { get; set; }



    }
}
