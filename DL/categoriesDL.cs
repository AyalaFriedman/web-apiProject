using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class categoriesDL : IcategoriesDL
    {
        Production_aaContext Production_aaContext;
    
        public categoriesDL(Production_aaContext Production_aaContext)
        {
            this.Production_aaContext = Production_aaContext;
        }
      
        public async Task<List<Category>> Get()
        {
            var ca = await Production_aaContext.Categories.Select(e => e)
                .ToListAsync();
            return ca;
        }
    }
}
