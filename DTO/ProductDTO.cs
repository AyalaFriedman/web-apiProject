using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public int Category { get; set; }
        public int Price { get; set; }
        public int? Image { get; set; }
    }
}
