using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
   public interface IProductBL
    {
        Task<List<Product>> Get();
        Task<List<Product>> Get(int category);
    }
}