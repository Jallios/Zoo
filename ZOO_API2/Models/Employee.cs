using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class Employee
    {
        public int? IdEmployee { get; set; }
        public string? Surname { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public string? Patronymic { get; set; } = null!;
        public string? Login { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? PassportData { get; set; } = null!;
        public int? PostId { get; set; }
        public int? MedicalBookId { get; set; }
        public int? ConcatId { get; set; }
        public int? StatusEmployeeId { get; set; }
    }
}
