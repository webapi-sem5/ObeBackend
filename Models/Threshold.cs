using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObeSystem.Models
{
    public class Threshold
    {
        public Guid Id { get; set; }

        public int End_marks { get; set; }

        public int Ca_marks { get; set; }

        public float Min_end_marks { get; set; }

        public float Min_ca_marks { get; set; }

        public float Min_total_marks { get; set; }

        public float Min_po_marks { get; set; }

        public float Min_lo_marks { get; set; }

        public float Min_attendance { get; set; }

        [JsonIgnore]
        public ICollection<Module> Modules { get; set; }

    }
}
