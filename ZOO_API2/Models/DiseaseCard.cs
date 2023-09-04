using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class DiseaseCard
    {
        public int? IdDisease { get; set; }
        public int? NumberCardDiseases { get; set; }
        public string? Diseases { get; set; } = null!;
        public DateTime? DateStartIllness { get; set; }
        public DateTime? DateEndIllness { get; set; }

    }
}
