using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Application.Polists
{
    public class PolistDto
    {

        public Guid Id { get; set; }


        public string Po_name { get; set; }

        public string Po_code { get; set; }


        public string Description { get; set; }


        public double Weight { get; set; }

        //public float Student_marks { get; set; }

        //public bool Status { get; set; }

        [JsonPropertyName("lolist")]
        public ICollection<LolistDto> LolistPos { get; set; }
    }
}
