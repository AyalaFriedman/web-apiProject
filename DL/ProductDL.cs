using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
    public class ProductDL : IProductDL
    {
        Production_aaContext Production_aaContext;
        public ProductDL(Production_aaContext Production_aaContext)
        {
            this.Production_aaContext = Production_aaContext;
        }

        public async Task<List<Product>> Get()
        {
            var products = await Production_aaContext.Products
                                 .Select(e => e)
                                 .ToListAsync();
            if (products == null)
                return null;
            return products;
        }

        public async Task<List<Product>> Get(int category)
        {
            var products = await Production_aaContext.Products.Where(p => p.Category == category).ToListAsync();
            if (products == null)
                return null;
            return products;
        }
        public async Task<Product> getProductById(int? id)
        {
            return await Production_aaContext.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }

    }
}
