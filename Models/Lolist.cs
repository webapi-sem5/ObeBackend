using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    
    public class Lolist
    {

        public Guid Id { get; set; }

      
        public string Lo_name { get; set; }

        
        public string Lo_code { get; set; }

        
        public string Description { get; set; }

       
        public double Weight { get; set; }

        public Guid? ModuleId { get; set; }

        public Module Module { get; set; }

        [JsonIgnore]
       public ICollection<AssessmentLo> AssessmentLos { get; set; }

        [JsonIgnore]
        public ICollection<LolistPo> LolistPos { get; set; }

        [JsonIgnore]
        public ICollection<StudentLolist> StudentLolists { get; set; }
    } 
}
