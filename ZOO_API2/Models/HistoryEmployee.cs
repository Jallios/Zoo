using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class HistoryEmployee
    {
        public int? IdHe { get; set; }
        public string? Surname { get; set; } = null!;
        public string? Name { get; set; } = null!;
        public string? Patronymic { get; set; } = null!;
        public string? Login { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? PassportData { get; set; } = null!;
        public string? Post { get; set; } = null!;
        public DateTime? DateTime { get; set; }
        public string? Action { get; set; } = null!;
    }
}
