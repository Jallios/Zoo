using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class AnimalView
    {
        public string Животное { get; set; } = null!;
        public decimal Вес { get; set; }
        public decimal Рост { get; set; }
        public int НомерКарточкиБолезни { get; set; }
        public int НомерВольера { get; set; }
    }
}
