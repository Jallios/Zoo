using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class MedicalBook
    {
        public int? IdMedicalBook { get; set; }
        public string? Result { get; set; } = null!;
        public DateTime? DateTime { get; set; }
    }
}
