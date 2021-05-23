using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class LolistPo
    {

        public Guid LolistId { get; set; }

        public Lolist Lolist { get; set; }

       
        public Guid PolistId { get; set; }

        public Polist Polist { get; set; }


    }
}
