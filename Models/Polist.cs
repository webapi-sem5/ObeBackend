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
    
    public class Polist
    {
        
        public Guid Id { get; set; }

       
        public string Po_name { get; set; }

        public string Po_code { get; set; }

        
        public string Description { get; set; }


        public double Weight { get; set; }

        //public float Student_marks { get; set; }

        //public bool Status { get; set; }


        public Module Module { get; set; }

        [JsonIgnore]
        public ICollection<LolistPo> LolistPos { get; set; }



    }
}