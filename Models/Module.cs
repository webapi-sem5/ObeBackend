using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int Batch { get; set; }

        [Required]
        public bool Gpa { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public int Semester { get; set; }

        public ICollection<Assessment> Assessments { get; set; }

        public  ICollection<Lolist> Lolists { get; set; }

    }
}
