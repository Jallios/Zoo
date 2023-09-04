using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class HistoryAnimal
    {
        public int? IdHa { get; set; }
        public string? NameAnimal { get; set; } = null!;
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public string? NameType { get; set; } = null!;
        public int? NumberCardDiseases { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Action { get; set; } = null!;
    }
}
