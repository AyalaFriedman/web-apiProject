using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoriesBL : ICategoriesBL
    {
        IcategoriesDL IcategoriesDL;
        public CategoriesBL(IcategoriesDL IcategoriesDL)
        {
            this.IcategoriesDL = IcategoriesDL;
        }
        public async Task<List<Category>> Get()
        {
            List<Category> categories = await IcategoriesDL.Get();
            if (categories == null)
                return null;
            return categories;
        }
    }
}
