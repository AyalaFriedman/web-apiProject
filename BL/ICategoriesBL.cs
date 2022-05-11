using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICategoriesBL
    {
        Task<List<Category>> Get();
    }
}