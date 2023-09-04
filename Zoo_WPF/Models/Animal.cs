using System;
using System.Collections.Generic;

namespace Zoo_WPF.Models
{
    public partial class Animal
    {
        public int? IdAnimal { get; set; }
        public string NameAnimal { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? TypeOfAnimalId { get; set; }
        public int? DiseaseId { get; set; }
        public int? AviaryId { get; set; }
        public int? StatusAnimalId { get; set; }

        public TypeOfAnimal typeOfanimal { get; set; }
        public DiseaseCard disease { get; set; }
        public Aviary aviary { get; set; }
        public StatusAnimal statusAnimal { get; set; }

    }
}
