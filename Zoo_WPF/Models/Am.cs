using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_WPF.Models
{
    public class Am
    {
        public int? IdAm { get; set; }
        public int? EmployeeId { get; set; }
        public int? ComponentId { get; set; }
        public int? TypeOfWorkId { get; set; }
        public int? AnimalId { get; set; }

        public Employee employee { get; set; }
        public Stock component { get; set; }
        public TypeOfWork typeOfwork { get; set; }
        public Animal animal { get; set; }
    }
}
