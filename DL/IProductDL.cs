using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IProductDL
    {
        Task<List<Product>> Get();
        Task<List<Product>> Get(int category);
        Task<Product> getProductById(int? id);

    }
}