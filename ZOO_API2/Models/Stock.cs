using System;
using System.Collections.Generic;

namespace ZOO_API2.Models
{
    public partial class Stock
    {
        public int IdComponent { get; set; }
        public string NameComponent { get; set; } = null!;
        public decimal Quality { get; set; }
    }
}
