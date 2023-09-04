using System;
using System.Collections.Generic;

namespace Zoo_WPF.Models
{
    public partial class DiseaseCard
    {
        public int? IdDisease { get; set; }
        public int? NumberCardDiseases { get; set; }
        public string Diseases { get; set; }
        public DateTime? DateStartIllness { get; set; }
        public DateTime? DateEndIllness { get; set; }
    }
}
