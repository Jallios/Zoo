using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class EmployeeConcat
    {
        public int? IdConcat { get; set; }
        public string? TaskList { get; set; } = null!;
        public decimal? Salary { get; set; }
        public int? HoursId { get; set; }
    }
}
