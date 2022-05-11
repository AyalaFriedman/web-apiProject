using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public  interface IcategoriesDL
    {
        Task<List<Category>> Get();
    }
}