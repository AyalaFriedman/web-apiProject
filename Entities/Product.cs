using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public int Category { get; set; }
        public int Price { get; set; }
        public int? Image { get; set; }
    }
}
