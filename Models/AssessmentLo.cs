using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class AssessmentLo
    {

        public Guid LolistId { get; set; }

        public Lolist Lolist { get; set; }

        public Guid AssessmentId { get; set; }

        public Assessment Assessment { get; set; }

         
    }
}
