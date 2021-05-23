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

        public int Lower_marks { get; set; }

        public int Higher_marks { get; set; }

        public string Grade_type { get; set; }

        public float Gpa { get; set; }

        [JsonIgnore]
        public ICollection<Module> Modules { get; set; }



    }
}
