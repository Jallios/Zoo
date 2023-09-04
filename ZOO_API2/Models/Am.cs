using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class Am
    {
        public int? IdAm { get; set; }
        public int? EmployeeId { get; set; }
        public int? ComponentId { get; set; }
        public int? TypeOfWorkId { get; set; }
        public int? AnimalId { get; set; }

        public Employee? employee { get; set; }
        public Stock? component { get; set; }
        public TypeOfWork? typeOfwork { get; set; }
        public Animal? animal { get; set; }

    }
}
