using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Application.Lolists
{
    public class LoDto
    {


        public Guid Id { get; set; }


        public string Lo_name { get; set; }


        public string Lo_code { get; set; }


        public string Description { get; set; }


        public double Weight { get; set; }

        public Guid? ModuleId { get; set; }

        public Module Module { get; set; }

        [JsonPropertyName("polist")]
        public ICollection<PolistDto> LolistPos { get; set; }

    }
}
