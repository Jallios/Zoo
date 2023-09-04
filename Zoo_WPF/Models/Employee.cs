using System;
using System.Collections.Generic;

namespace Zoo_WPF.Models
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public string Surname { get; set; } 
        public string Name { get; set; } 
        public string Patronymic { get; set; } 
        public string Login { get; set; } 
        public string Password { get; set; } 
        public string PassportData { get; set; } 
        public int PostId { get; set; }
        public int MedicalBookId { get; set; }
        public int ConcatId { get; set; }
        public int StatusEmployeeId { get; set; }
    }
}
