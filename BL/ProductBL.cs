using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class ProductBL : IProductBL
    {
        IProductDL iProductDL;

        public ProductBL(IProductDL iProductDL)
        {
            this.iProductDL = iProductDL;
        }

        public async Task<List<Product>> Get()
        {
            List<Product> prod = await iProductDL.Get();
            if (prod == null)
                return null;
            return prod;
        }

        public async Task<List<Product>> Get(int category)
        {
            List<Product> prod = await iProductDL.Get(category);
            if (prod == null)
                return null;
            return prod;
        }

    }
}
